using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Configuration;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using MESModule.DB;
using MESModule.Utility;

namespace InnerQueue
{
    public partial class Form1 : Form
    {
        #region *** Variables
        const string PathSound = @"C:\Picking\Sound\";
        int PntUpdate;
        string Line;
        string Part;
        MyParts MyPart;
        PointerInformation MyPointer;
        DbObject[] Plan;
        string[,] PlanBuffer;
        List<string> partList = new List<string>();
        List<string[]> bufferPlan = new List<string[]>();
        bool Enable_ShowPointer;
        #endregion

        #region *** Initialization
        public Form1()
        {
            InitializeComponent();
            lblQue.Text = ConfigurationManager.AppSettings["NumberofPlan"];
            txtQue.Text = string.Empty;
        }

        private void Form1_Load(object sender, EventArgs e)
        {
            MyApp.BlockMultiInstances();
            InitializeWorkstation();
            ShowBufferPlan();
            timPlan.Start();
            timBufferPlan.Start();
            timClock.Start();
        }

        private void InitializeWorkstation()
        {
            this.lblTitle.Text = ConfigurationManager.AppSettings["Title"];
            lblTitle.Location = new Point (this.Size.Width / 2 - lblTitle.Size.Width /2 , lblTitle.Location.Y);
            this.Text = Global.GetTitle();
            Line = ConfigurationManager.AppSettings["Line"];
            Part = ConfigurationManager.AppSettings["Part"];
            Enable_ShowPointer = Convert.ToBoolean(ConfigurationManager.AppSettings["Enable_ShowPointer"]);
            if (Enable_ShowPointer)
            {
                pnShowPointer.Visible = true;
                lblPointer.Text = ConfigurationManager.AppSettings["PointerName"];
                MyPointer = new PointerInformation(ConfigurationManager.AppSettings["PointerName"]);
            }
            MyPart = new MyParts(Line, Part);
        }
        #endregion

        #region *** Method

        #region ** Plan
        private bool ShowPlan()
        {                        
            bool isMasterOK = MyPart.GetPlan(int.Parse(lblQue.Text), out Plan);

            dgvPlan.Rows.Clear();
            btnConvert.Enabled = false;
            btnOK.Enabled = false;

            if (Plan == null)
            {
                lblStatus.Text = MyPart.Status;
                return false;
            }

            // Show past plan.
            if (!Plan[0].EOF)
            {
                Plan[0].MoveLast();
                for (int i = 0; i < Plan[0].RecordCount; i++)
                {
                    dgvPlan.Rows.Add(new string[] { Plan[0]["RUNNO"], Plan[0]["SEBAN"], Plan[0]["MODEL"], Plan[0][MyPart.Part], Plan[0]["QTY"] });
                    dgvPlan.Rows[i].DefaultCellStyle.BackColor = Color.LightSalmon;
                    Plan[0].MoveBack();
                }
                dgvPlan.ClearSelection();
            }

            // Show future plan.
            if (Plan[1].EOF)
            {
                lblStatus.Text = "Wait Plan";
                timPlan.Interval = 3000;
                lblUsedPart.Text = "0";
                return false;
            }

            for (int i = 0; i < Plan[1].RecordCount; i++)
            {
                dgvPlan.Rows.Add(new string[] { Plan[1]["RUNNO"], Plan[1]["SEBAN"], Plan[1]["MODEL"], Plan[1][MyPart.Part], Plan[1]["QTY"] });

                Plan[1].MoveNext();
            }
            dgvPlan.Rows[dgvPlan.Rows.Count - Plan[1].RecordCount].DefaultCellStyle.BackColor = Color.LimeGreen;
            dgvPlan.ClearSelection();
            Plan[1].MoveFirst();        

            if (!isMasterOK)
            {
                lblStatus.Text = MyPart.Status;
                timPlan.Interval = 1000;
                lblUsedPart.Text = "0";
                return false;
            }

            lblUsedPart.Text = MyPart.NumberUsedPart.ToString();
            btnOK.Enabled = true;
            lblStatus.Text = "Please press button to Confirm";
            return true;
        }

        private void ShowBufferPlan()
        {
            MyPart.GetBufferPlan(out DbObject BufferPlan);
            BufferPlan.MoveFirst();
            dgvBuffer.Rows.Clear();

            int count = 0 ;

            if (BufferPlan.RecordCount > 0)
            {
                for (int i = 0; i < BufferPlan.RecordCount; i++)
                {
                    dgvBuffer.Rows.Add(BufferPlan["SEBAN"], BufferPlan["QTY"]);
                    count += int.Parse(BufferPlan["QTY"]);
                    BufferPlan.MoveNext();
                }
                dgvBuffer.Rows[0].DefaultCellStyle.BackColor = Color.LimeGreen;
            }

            btnConvert.Enabled = BufferPlan.RecordCount == 0;
            dgvBuffer.ClearSelection();
            lblPlanRemaining.Text = count.ToString();

            if (Enable_ShowPointer)
            {
                MyPointer.GetInformation();
                lblRunnoPointer.Text = MyPointer.Runno;
                lblSebanPointer.Text = MyPointer.Seban;
                lblPartPointer.Text = MyPointer.PartDwg;
            }
        }

        #endregion

        #region ** Button
        private void btnConvert_Click(object sender, EventArgs e)
        {
            if (!bgwkUpdate.IsBusy)
            {
                lblStatus.Text = "Updating";
                lblStatus.Refresh();
                btnOK.Enabled = false;
                btnConvert.Enabled = false;
                timBufferPlan.Stop();
                bgwkUpdate.RunWorkerAsync();
            }
        }

        private void txtQue_TextChanged(object sender, EventArgs e)
        {
            if (string.IsNullOrEmpty(txtQue.Text)) return;

            if (!int.TryParse(txtQue.Text, out int number))
            {
                MessageBox.Show("Please Input Numeric Only");
                txtQue.Text = string.Empty;
            }
        }

        private void btnOK_Click(object sender, EventArgs e)
        {
            lblQue.Text = txtQue.Text;
            txtQue.Text = string.Empty;
            btnConvert.Enabled = false;

            ShowPlan();

            MessageBox.Show("Plan was updated successfully");
        }
        #endregion

        #region ** Clock
        private void timPlan_Tick(object sender, EventArgs e)
        {
            timPlan.Stop();
            if(!ShowPlan()) timPlan.Start();            
        }

        private void timBufferPlan_Tick(object sender, EventArgs e)
        {
            timBufferPlan.Stop();
            timBufferPlan.Interval = 4000;
            ShowBufferPlan();
            timBufferPlan.Start();
        }

        #endregion

        #region ** BackgroundWorker
        private void bgwkUpdate_DoWork(object sender, DoWorkEventArgs e)
        {
            PntUpdate = 0;
            int i = 0;
            partList.Clear();

            while (i <= MyPart.NumberModelInPlan)
            {
                i++;
                QuePlan();                
            }

            Plan[1].MoveLast();
            MyPart.UpdatePlanRunno(Plan[1]["RUNNO"]);
           
        }

        private void QuePlan()
        {
            Plan[1].MoveFirst();
            string tmpModel = string.Empty;
            bool foundNewPartDwg = false;

            for (int i = 0; i < Plan[1].RecordCount; i++)
            {

                Invoke(new Action(() =>
                {
                    this.lblStatus.Text = $"Updating : {Plan[1]["RUNNO"]}";
                    this.lblStatus.Refresh();
                }));

                if (Plan[1][MyPart.Part].Trim() == "NO USE")
                {
                    Plan[1].MoveNext();
                    continue;
                }

                string hataRunno = MyPart.GetHataRunno(Plan[1]["SEBAN"], Plan[1]["MODEL"]);                

                if (i == 0)
                {
                    if (!partList.Contains(Plan[1][MyPart.Part]))
                    {
                        tmpModel = Plan[1][MyPart.Part];
                        partList.Add(Plan[1][MyPart.Part]);
                        bufferPlan.Add(new string[] { Plan[1]["RUNNO"], Plan[1]["SEBAN"], hataRunno });
                        foundNewPartDwg = true;

                        MyPart.CreateBuffer(Plan[1][MyPart.Part], hataRunno);                                            
                        MyPart.UpdateHataRunno(Plan[1]["SEBAN"], Plan[1]["MODEL"], hataRunno);
                        PntUpdate++;
                        bgwkUpdate.ReportProgress(PntUpdate * 100 / MyPart.NumberUsedPart);
                    }
                }
                else
                {
                    if (foundNewPartDwg)
                    {
                        if (Plan[1][MyPart.Part] == tmpModel)
                        {
                            bufferPlan.Add(new string[] { Plan[1]["RUNNO"], Plan[1]["SEBAN"], hataRunno });

                            MyPart.CreateBuffer(Plan[1][MyPart.Part], hataRunno);                            
                            MyPart.UpdateHataRunno(Plan[1]["SEBAN"], Plan[1]["MODEL"], hataRunno);
                            PntUpdate++;
                            bgwkUpdate.ReportProgress(PntUpdate * 100 / MyPart.NumberUsedPart);
                        }
                    }
                    else
                    {
                        if (!partList.Contains(Plan[1][MyPart.Part]))
                        {
                            tmpModel = Plan[1][MyPart.Part];
                            partList.Add(Plan[1][MyPart.Part]);
                            bufferPlan.Add(new string[] { Plan[1]["RUNNO"], Plan[1]["SEBAN"], hataRunno });
                            foundNewPartDwg = true;

                            MyPart.CreateBuffer(Plan[1][MyPart.Part], hataRunno);                            
                            MyPart.UpdateHataRunno(Plan[1]["SEBAN"], Plan[1]["MODEL"], hataRunno);
                            PntUpdate++;
                            bgwkUpdate.ReportProgress(PntUpdate * 100 / MyPart.NumberUsedPart);
                        }
                    }
                }

                Plan[1].MoveNext();
            }
        }

        private void bgwkUpdate_ProgressChanged(object sender, ProgressChangedEventArgs e)
        {
            prgUpdate.Value = e.ProgressPercentage;
        }

        private void bgwkUpdate_RunWorkerCompleted(object sender, RunWorkerCompletedEventArgs e)
        {
            lblStatus.Text = "OK!";
            MyAudio.PlayBackground($"{PathSound}OK.wav");
            btnOK.Enabled = true;
            btnConvert.Enabled = true;
            timPlan.Start();
            timBufferPlan.Interval = 80;
            timBufferPlan.Start();
        }

        private void timClock_Tick(object sender, EventArgs e)
        {
            timClock.Stop();
            lblTime.Text = DateTime.Now.ToString();
            timClock.Start();
        }
        #endregion

        #endregion       
    }
}
