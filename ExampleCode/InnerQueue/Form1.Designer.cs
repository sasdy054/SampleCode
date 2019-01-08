namespace InnerQueue
{
    partial class Form1
    {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            this.components = new System.ComponentModel.Container();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle1 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle2 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle3 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle4 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle5 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle6 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle7 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle8 = new System.Windows.Forms.DataGridViewCellStyle();
            this.lblTitle = new System.Windows.Forms.Label();
            this.dgvPlan = new System.Windows.Forms.DataGridView();
            this.PlanRunno = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Column1 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Model = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Code = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Quantity = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.label1 = new System.Windows.Forms.Label();
            this.txtQue = new System.Windows.Forms.TextBox();
            this.btnConvert = new System.Windows.Forms.Button();
            this.timPlan = new System.Windows.Forms.Timer(this.components);
            this.lblQue = new System.Windows.Forms.Label();
            this.btnOK = new System.Windows.Forms.Button();
            this.lblStatus = new System.Windows.Forms.Label();
            this.dgvBuffer = new System.Windows.Forms.DataGridView();
            this.dataGridViewTextBoxColumn2 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Qty = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.panel1 = new System.Windows.Forms.Panel();
            this.lblUsedPart = new System.Windows.Forms.Label();
            this.ddd = new System.Windows.Forms.Label();
            this.panel2 = new System.Windows.Forms.Panel();
            this.lblPlanRemaining = new System.Windows.Forms.Label();
            this.label3 = new System.Windows.Forms.Label();
            this.bgwkUpdate = new System.ComponentModel.BackgroundWorker();
            this.prgUpdate = new System.Windows.Forms.ProgressBar();
            this.timBufferPlan = new System.Windows.Forms.Timer(this.components);
            this.lblTime = new System.Windows.Forms.Label();
            this.timClock = new System.Windows.Forms.Timer(this.components);
            this.lblPointer = new System.Windows.Forms.Label();
            this.label4 = new System.Windows.Forms.Label();
            this.label5 = new System.Windows.Forms.Label();
            this.lblRunnoPointer = new System.Windows.Forms.Label();
            this.lblSebanPointer = new System.Windows.Forms.Label();
            this.pnShowPointer = new System.Windows.Forms.Panel();
            this.lblPartPointer = new System.Windows.Forms.Label();
            this.lblPart = new System.Windows.Forms.Label();
            ((System.ComponentModel.ISupportInitialize)(this.dgvPlan)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.dgvBuffer)).BeginInit();
            this.panel1.SuspendLayout();
            this.panel2.SuspendLayout();
            this.pnShowPointer.SuspendLayout();
            this.SuspendLayout();
            // 
            // lblTitle
            // 
            this.lblTitle.AutoSize = true;
            this.lblTitle.Font = new System.Drawing.Font("Times New Roman", 36F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblTitle.ForeColor = System.Drawing.Color.RoyalBlue;
            this.lblTitle.Location = new System.Drawing.Point(253, 4);
            this.lblTitle.Name = "lblTitle";
            this.lblTitle.Size = new System.Drawing.Size(349, 55);
            this.lblTitle.TabIndex = 42;
            this.lblTitle.Text = "F2-Inner Queue";
            this.lblTitle.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // dgvPlan
            // 
            this.dgvPlan.AllowUserToAddRows = false;
            this.dgvPlan.AllowUserToDeleteRows = false;
            this.dgvPlan.AllowUserToResizeColumns = false;
            this.dgvPlan.AllowUserToResizeRows = false;
            this.dgvPlan.BackgroundColor = System.Drawing.Color.White;
            dataGridViewCellStyle1.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleCenter;
            dataGridViewCellStyle1.BackColor = System.Drawing.SystemColors.Control;
            dataGridViewCellStyle1.Font = new System.Drawing.Font("Times New Roman", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            dataGridViewCellStyle1.ForeColor = System.Drawing.SystemColors.WindowText;
            dataGridViewCellStyle1.SelectionBackColor = System.Drawing.SystemColors.Highlight;
            dataGridViewCellStyle1.SelectionForeColor = System.Drawing.SystemColors.HighlightText;
            dataGridViewCellStyle1.WrapMode = System.Windows.Forms.DataGridViewTriState.True;
            this.dgvPlan.ColumnHeadersDefaultCellStyle = dataGridViewCellStyle1;
            this.dgvPlan.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dgvPlan.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.PlanRunno,
            this.Column1,
            this.Model,
            this.Code,
            this.Quantity});
            dataGridViewCellStyle2.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleCenter;
            dataGridViewCellStyle2.BackColor = System.Drawing.SystemColors.Window;
            dataGridViewCellStyle2.Font = new System.Drawing.Font("Times New Roman", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            dataGridViewCellStyle2.ForeColor = System.Drawing.SystemColors.ControlText;
            dataGridViewCellStyle2.SelectionBackColor = System.Drawing.SystemColors.Highlight;
            dataGridViewCellStyle2.SelectionForeColor = System.Drawing.SystemColors.HighlightText;
            dataGridViewCellStyle2.WrapMode = System.Windows.Forms.DataGridViewTriState.False;
            this.dgvPlan.DefaultCellStyle = dataGridViewCellStyle2;
            this.dgvPlan.EditMode = System.Windows.Forms.DataGridViewEditMode.EditProgrammatically;
            this.dgvPlan.Location = new System.Drawing.Point(6, 5);
            this.dgvPlan.MultiSelect = false;
            this.dgvPlan.Name = "dgvPlan";
            this.dgvPlan.ReadOnly = true;
            dataGridViewCellStyle3.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft;
            dataGridViewCellStyle3.BackColor = System.Drawing.SystemColors.Control;
            dataGridViewCellStyle3.Font = new System.Drawing.Font("Times New Roman", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            dataGridViewCellStyle3.ForeColor = System.Drawing.SystemColors.WindowText;
            dataGridViewCellStyle3.SelectionBackColor = System.Drawing.SystemColors.Highlight;
            dataGridViewCellStyle3.SelectionForeColor = System.Drawing.SystemColors.HighlightText;
            dataGridViewCellStyle3.WrapMode = System.Windows.Forms.DataGridViewTriState.True;
            this.dgvPlan.RowHeadersDefaultCellStyle = dataGridViewCellStyle3;
            this.dgvPlan.RowHeadersVisible = false;
            dataGridViewCellStyle4.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleCenter;
            this.dgvPlan.RowsDefaultCellStyle = dataGridViewCellStyle4;
            this.dgvPlan.ScrollBars = System.Windows.Forms.ScrollBars.Vertical;
            this.dgvPlan.Size = new System.Drawing.Size(677, 543);
            this.dgvPlan.TabIndex = 43;
            // 
            // PlanRunno
            // 
            this.PlanRunno.HeaderText = "PlanRunno";
            this.PlanRunno.Name = "PlanRunno";
            this.PlanRunno.ReadOnly = true;
            this.PlanRunno.SortMode = System.Windows.Forms.DataGridViewColumnSortMode.NotSortable;
            this.PlanRunno.Width = 210;
            // 
            // Column1
            // 
            this.Column1.HeaderText = "Seban";
            this.Column1.Name = "Column1";
            this.Column1.ReadOnly = true;
            this.Column1.Width = 70;
            // 
            // Model
            // 
            this.Model.HeaderText = "Model";
            this.Model.Name = "Model";
            this.Model.ReadOnly = true;
            this.Model.SortMode = System.Windows.Forms.DataGridViewColumnSortMode.NotSortable;
            this.Model.Width = 160;
            // 
            // Code
            // 
            this.Code.HeaderText = "Inner Dwg";
            this.Code.Name = "Code";
            this.Code.ReadOnly = true;
            this.Code.SortMode = System.Windows.Forms.DataGridViewColumnSortMode.NotSortable;
            this.Code.Width = 150;
            // 
            // Quantity
            // 
            this.Quantity.HeaderText = "Quantity";
            this.Quantity.Name = "Quantity";
            this.Quantity.ReadOnly = true;
            this.Quantity.SortMode = System.Windows.Forms.DataGridViewColumnSortMode.NotSortable;
            this.Quantity.Width = 65;
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(192)))), ((int)(((byte)(255)))));
            this.label1.Font = new System.Drawing.Font("Microsoft Sans Serif", 15.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(222)));
            this.label1.Location = new System.Drawing.Point(10, 557);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(174, 25);
            this.label1.TabIndex = 44;
            this.label1.Text = "Number of Plan";
            // 
            // txtQue
            // 
            this.txtQue.Font = new System.Drawing.Font("Microsoft Sans Serif", 15.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(222)));
            this.txtQue.Location = new System.Drawing.Point(236, 554);
            this.txtQue.MaxLength = 3;
            this.txtQue.Name = "txtQue";
            this.txtQue.Size = new System.Drawing.Size(91, 31);
            this.txtQue.TabIndex = 45;
            this.txtQue.TextChanged += new System.EventHandler(this.txtQue_TextChanged);
            // 
            // btnConvert
            // 
            this.btnConvert.Font = new System.Drawing.Font("Microsoft Sans Serif", 20.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(222)));
            this.btnConvert.Location = new System.Drawing.Point(801, 322);
            this.btnConvert.Name = "btnConvert";
            this.btnConvert.Size = new System.Drawing.Size(164, 68);
            this.btnConvert.TabIndex = 46;
            this.btnConvert.Text = ">>";
            this.btnConvert.UseVisualStyleBackColor = true;
            this.btnConvert.Click += new System.EventHandler(this.btnConvert_Click);
            // 
            // timPlan
            // 
            this.timPlan.Interval = 800;
            this.timPlan.Tick += new System.EventHandler(this.timPlan_Tick);
            // 
            // lblQue
            // 
            this.lblQue.AutoSize = true;
            this.lblQue.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(192)))), ((int)(((byte)(255)))));
            this.lblQue.Font = new System.Drawing.Font("Microsoft Sans Serif", 15.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(222)));
            this.lblQue.Location = new System.Drawing.Point(188, 557);
            this.lblQue.Name = "lblQue";
            this.lblQue.Size = new System.Drawing.Size(40, 25);
            this.lblQue.TabIndex = 47;
            this.lblQue.Text = "XX";
            // 
            // btnOK
            // 
            this.btnOK.Location = new System.Drawing.Point(333, 556);
            this.btnOK.Name = "btnOK";
            this.btnOK.Size = new System.Drawing.Size(60, 27);
            this.btnOK.TabIndex = 48;
            this.btnOK.Text = "OK";
            this.btnOK.UseVisualStyleBackColor = true;
            this.btnOK.Click += new System.EventHandler(this.btnOK_Click);
            // 
            // lblStatus
            // 
            this.lblStatus.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(255)))), ((int)(((byte)(192)))));
            this.lblStatus.Font = new System.Drawing.Font("Times New Roman", 24F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblStatus.Location = new System.Drawing.Point(4, 667);
            this.lblStatus.Name = "lblStatus";
            this.lblStatus.Size = new System.Drawing.Size(1347, 58);
            this.lblStatus.TabIndex = 49;
            this.lblStatus.Text = "LABEL STATUS PROGRAM";
            this.lblStatus.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // dgvBuffer
            // 
            this.dgvBuffer.AllowUserToAddRows = false;
            this.dgvBuffer.AllowUserToDeleteRows = false;
            this.dgvBuffer.AllowUserToResizeColumns = false;
            this.dgvBuffer.AllowUserToResizeRows = false;
            this.dgvBuffer.BackgroundColor = System.Drawing.Color.White;
            dataGridViewCellStyle5.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleCenter;
            dataGridViewCellStyle5.BackColor = System.Drawing.SystemColors.Control;
            dataGridViewCellStyle5.Font = new System.Drawing.Font("Times New Roman", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            dataGridViewCellStyle5.ForeColor = System.Drawing.SystemColors.WindowText;
            dataGridViewCellStyle5.SelectionBackColor = System.Drawing.SystemColors.Highlight;
            dataGridViewCellStyle5.SelectionForeColor = System.Drawing.SystemColors.HighlightText;
            dataGridViewCellStyle5.WrapMode = System.Windows.Forms.DataGridViewTriState.True;
            this.dgvBuffer.ColumnHeadersDefaultCellStyle = dataGridViewCellStyle5;
            this.dgvBuffer.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dgvBuffer.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.dataGridViewTextBoxColumn2,
            this.Qty});
            dataGridViewCellStyle6.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleCenter;
            dataGridViewCellStyle6.BackColor = System.Drawing.SystemColors.Window;
            dataGridViewCellStyle6.Font = new System.Drawing.Font("Times New Roman", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            dataGridViewCellStyle6.ForeColor = System.Drawing.SystemColors.ControlText;
            dataGridViewCellStyle6.SelectionBackColor = System.Drawing.SystemColors.Highlight;
            dataGridViewCellStyle6.SelectionForeColor = System.Drawing.SystemColors.HighlightText;
            dataGridViewCellStyle6.WrapMode = System.Windows.Forms.DataGridViewTriState.False;
            this.dgvBuffer.DefaultCellStyle = dataGridViewCellStyle6;
            this.dgvBuffer.EditMode = System.Windows.Forms.DataGridViewEditMode.EditProgrammatically;
            this.dgvBuffer.Location = new System.Drawing.Point(3, 3);
            this.dgvBuffer.MultiSelect = false;
            this.dgvBuffer.Name = "dgvBuffer";
            this.dgvBuffer.ReadOnly = true;
            dataGridViewCellStyle7.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft;
            dataGridViewCellStyle7.BackColor = System.Drawing.SystemColors.Control;
            dataGridViewCellStyle7.Font = new System.Drawing.Font("Times New Roman", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            dataGridViewCellStyle7.ForeColor = System.Drawing.SystemColors.WindowText;
            dataGridViewCellStyle7.SelectionBackColor = System.Drawing.SystemColors.Highlight;
            dataGridViewCellStyle7.SelectionForeColor = System.Drawing.SystemColors.HighlightText;
            dataGridViewCellStyle7.WrapMode = System.Windows.Forms.DataGridViewTriState.True;
            this.dgvBuffer.RowHeadersDefaultCellStyle = dataGridViewCellStyle7;
            this.dgvBuffer.RowHeadersVisible = false;
            dataGridViewCellStyle8.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleCenter;
            this.dgvBuffer.RowsDefaultCellStyle = dataGridViewCellStyle8;
            this.dgvBuffer.ScrollBars = System.Windows.Forms.ScrollBars.Vertical;
            this.dgvBuffer.Size = new System.Drawing.Size(267, 545);
            this.dgvBuffer.TabIndex = 50;
            // 
            // dataGridViewTextBoxColumn2
            // 
            this.dataGridViewTextBoxColumn2.HeaderText = "Seban";
            this.dataGridViewTextBoxColumn2.Name = "dataGridViewTextBoxColumn2";
            this.dataGridViewTextBoxColumn2.ReadOnly = true;
            this.dataGridViewTextBoxColumn2.SortMode = System.Windows.Forms.DataGridViewColumnSortMode.NotSortable;
            this.dataGridViewTextBoxColumn2.Width = 150;
            // 
            // Qty
            // 
            this.Qty.HeaderText = "Qty";
            this.Qty.Name = "Qty";
            this.Qty.ReadOnly = true;
            // 
            // panel1
            // 
            this.panel1.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(192)))), ((int)(((byte)(255)))));
            this.panel1.Controls.Add(this.lblUsedPart);
            this.panel1.Controls.Add(this.ddd);
            this.panel1.Controls.Add(this.dgvPlan);
            this.panel1.Controls.Add(this.label1);
            this.panel1.Controls.Add(this.btnOK);
            this.panel1.Controls.Add(this.lblQue);
            this.panel1.Controls.Add(this.txtQue);
            this.panel1.Location = new System.Drawing.Point(2, 71);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(688, 593);
            this.panel1.TabIndex = 51;
            // 
            // lblUsedPart
            // 
            this.lblUsedPart.AutoSize = true;
            this.lblUsedPart.Font = new System.Drawing.Font("Microsoft Sans Serif", 14.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(222)));
            this.lblUsedPart.Location = new System.Drawing.Point(510, 558);
            this.lblUsedPart.Name = "lblUsedPart";
            this.lblUsedPart.Size = new System.Drawing.Size(40, 24);
            this.lblUsedPart.TabIndex = 50;
            this.lblUsedPart.Text = "XX";
            // 
            // ddd
            // 
            this.ddd.AutoSize = true;
            this.ddd.Font = new System.Drawing.Font("Microsoft Sans Serif", 14.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(222)));
            this.ddd.Location = new System.Drawing.Point(418, 559);
            this.ddd.Name = "ddd";
            this.ddd.Size = new System.Drawing.Size(70, 24);
            this.ddd.TabIndex = 49;
            this.ddd.Text = "Used :";
            // 
            // panel2
            // 
            this.panel2.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(192)))), ((int)(((byte)(255)))), ((int)(((byte)(192)))));
            this.panel2.Controls.Add(this.lblPlanRemaining);
            this.panel2.Controls.Add(this.label3);
            this.panel2.Controls.Add(this.dgvBuffer);
            this.panel2.Location = new System.Drawing.Point(1071, 68);
            this.panel2.Name = "panel2";
            this.panel2.Size = new System.Drawing.Size(274, 593);
            this.panel2.TabIndex = 52;
            // 
            // lblPlanRemaining
            // 
            this.lblPlanRemaining.AutoSize = true;
            this.lblPlanRemaining.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(192)))), ((int)(((byte)(255)))), ((int)(((byte)(192)))));
            this.lblPlanRemaining.Font = new System.Drawing.Font("Microsoft Sans Serif", 15.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(222)));
            this.lblPlanRemaining.Location = new System.Drawing.Point(165, 558);
            this.lblPlanRemaining.Name = "lblPlanRemaining";
            this.lblPlanRemaining.Size = new System.Drawing.Size(96, 25);
            this.lblPlanRemaining.TabIndex = 52;
            this.lblPlanRemaining.Text = "9999999";
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Font = new System.Drawing.Font("Microsoft Sans Serif", 15.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(222)));
            this.label3.Location = new System.Drawing.Point(4, 557);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(159, 25);
            this.label3.TabIndex = 51;
            this.label3.Text = "Plan Remain :";
            // 
            // bgwkUpdate
            // 
            this.bgwkUpdate.WorkerReportsProgress = true;
            this.bgwkUpdate.WorkerSupportsCancellation = true;
            this.bgwkUpdate.DoWork += new System.ComponentModel.DoWorkEventHandler(this.bgwkUpdate_DoWork);
            this.bgwkUpdate.ProgressChanged += new System.ComponentModel.ProgressChangedEventHandler(this.bgwkUpdate_ProgressChanged);
            this.bgwkUpdate.RunWorkerCompleted += new System.ComponentModel.RunWorkerCompletedEventHandler(this.bgwkUpdate_RunWorkerCompleted);
            // 
            // prgUpdate
            // 
            this.prgUpdate.BackColor = System.Drawing.Color.White;
            this.prgUpdate.Location = new System.Drawing.Point(1071, 36);
            this.prgUpdate.Name = "prgUpdate";
            this.prgUpdate.Size = new System.Drawing.Size(272, 26);
            this.prgUpdate.TabIndex = 53;
            // 
            // timBufferPlan
            // 
            this.timBufferPlan.Interval = 8000;
            this.timBufferPlan.Tick += new System.EventHandler(this.timBufferPlan_Tick);
            // 
            // lblTime
            // 
            this.lblTime.AutoSize = true;
            this.lblTime.Font = new System.Drawing.Font("Times New Roman", 18F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblTime.ForeColor = System.Drawing.Color.RoyalBlue;
            this.lblTime.Location = new System.Drawing.Point(1124, 3);
            this.lblTime.Name = "lblTime";
            this.lblTime.Size = new System.Drawing.Size(212, 27);
            this.lblTime.TabIndex = 54;
            this.lblTime.Text = "14/12/2018 14:29:00";
            this.lblTime.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // timClock
            // 
            this.timClock.Tick += new System.EventHandler(this.timClock_Tick);
            // 
            // lblPointer
            // 
            this.lblPointer.AutoSize = true;
            this.lblPointer.Font = new System.Drawing.Font("Times New Roman", 36F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblPointer.ForeColor = System.Drawing.Color.RoyalBlue;
            this.lblPointer.Location = new System.Drawing.Point(77, 13);
            this.lblPointer.Name = "lblPointer";
            this.lblPointer.Size = new System.Drawing.Size(211, 55);
            this.lblPointer.TabIndex = 55;
            this.lblPointer.Text = "F2-DPIN";
            this.lblPointer.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // label4
            // 
            this.label4.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(128)))), ((int)(((byte)(128)))), ((int)(((byte)(255)))));
            this.label4.Font = new System.Drawing.Font("Microsoft Sans Serif", 14.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(222)));
            this.label4.ForeColor = System.Drawing.Color.White;
            this.label4.Location = new System.Drawing.Point(13, 79);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(167, 31);
            this.label4.TabIndex = 56;
            this.label4.Text = "Plan Runno";
            this.label4.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // label5
            // 
            this.label5.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(128)))), ((int)(((byte)(128)))), ((int)(((byte)(255)))));
            this.label5.Font = new System.Drawing.Font("Microsoft Sans Serif", 14.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(222)));
            this.label5.ForeColor = System.Drawing.Color.White;
            this.label5.Location = new System.Drawing.Point(181, 79);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(168, 31);
            this.label5.TabIndex = 57;
            this.label5.Text = "Seban";
            this.label5.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // lblRunnoPointer
            // 
            this.lblRunnoPointer.BackColor = System.Drawing.Color.Gray;
            this.lblRunnoPointer.Font = new System.Drawing.Font("Microsoft Sans Serif", 14.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(222)));
            this.lblRunnoPointer.ForeColor = System.Drawing.Color.White;
            this.lblRunnoPointer.Location = new System.Drawing.Point(13, 111);
            this.lblRunnoPointer.Name = "lblRunnoPointer";
            this.lblRunnoPointer.Size = new System.Drawing.Size(167, 31);
            this.lblRunnoPointer.TabIndex = 58;
            this.lblRunnoPointer.Text = "20181212A010000";
            this.lblRunnoPointer.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // lblSebanPointer
            // 
            this.lblSebanPointer.BackColor = System.Drawing.Color.Gray;
            this.lblSebanPointer.Font = new System.Drawing.Font("Microsoft Sans Serif", 14.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(222)));
            this.lblSebanPointer.ForeColor = System.Drawing.Color.White;
            this.lblSebanPointer.Location = new System.Drawing.Point(181, 111);
            this.lblSebanPointer.Name = "lblSebanPointer";
            this.lblSebanPointer.Size = new System.Drawing.Size(168, 31);
            this.lblSebanPointer.TabIndex = 59;
            this.lblSebanPointer.Text = "0123456789ABCD";
            this.lblSebanPointer.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // pnShowPointer
            // 
            this.pnShowPointer.Controls.Add(this.lblPartPointer);
            this.pnShowPointer.Controls.Add(this.lblPart);
            this.pnShowPointer.Controls.Add(this.lblSebanPointer);
            this.pnShowPointer.Controls.Add(this.lblPointer);
            this.pnShowPointer.Controls.Add(this.lblRunnoPointer);
            this.pnShowPointer.Controls.Add(this.label4);
            this.pnShowPointer.Controls.Add(this.label5);
            this.pnShowPointer.Location = new System.Drawing.Point(696, 105);
            this.pnShowPointer.Name = "pnShowPointer";
            this.pnShowPointer.Size = new System.Drawing.Size(359, 210);
            this.pnShowPointer.TabIndex = 60;
            this.pnShowPointer.Visible = false;
            // 
            // lblPartPointer
            // 
            this.lblPartPointer.BackColor = System.Drawing.Color.Gray;
            this.lblPartPointer.Font = new System.Drawing.Font("Microsoft Sans Serif", 14.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(222)));
            this.lblPartPointer.ForeColor = System.Drawing.Color.White;
            this.lblPartPointer.Location = new System.Drawing.Point(83, 175);
            this.lblPartPointer.Name = "lblPartPointer";
            this.lblPartPointer.Size = new System.Drawing.Size(205, 31);
            this.lblPartPointer.TabIndex = 61;
            this.lblPartPointer.Text = "0123456789ABCD";
            this.lblPartPointer.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // lblPart
            // 
            this.lblPart.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(128)))), ((int)(((byte)(128)))), ((int)(((byte)(255)))));
            this.lblPart.Font = new System.Drawing.Font("Microsoft Sans Serif", 14.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(222)));
            this.lblPart.ForeColor = System.Drawing.Color.White;
            this.lblPart.Location = new System.Drawing.Point(83, 143);
            this.lblPart.Name = "lblPart";
            this.lblPart.Size = new System.Drawing.Size(205, 31);
            this.lblPart.TabIndex = 60;
            this.lblPart.Text = "Part";
            this.lblPart.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // Form1
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.White;
            this.ClientSize = new System.Drawing.Size(1350, 729);
            this.Controls.Add(this.pnShowPointer);
            this.Controls.Add(this.lblTime);
            this.Controls.Add(this.prgUpdate);
            this.Controls.Add(this.panel2);
            this.Controls.Add(this.lblStatus);
            this.Controls.Add(this.btnConvert);
            this.Controls.Add(this.lblTitle);
            this.Controls.Add(this.panel1);
            this.Name = "Form1";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Form1";
            this.Load += new System.EventHandler(this.Form1_Load);
            ((System.ComponentModel.ISupportInitialize)(this.dgvPlan)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.dgvBuffer)).EndInit();
            this.panel1.ResumeLayout(false);
            this.panel1.PerformLayout();
            this.panel2.ResumeLayout(false);
            this.panel2.PerformLayout();
            this.pnShowPointer.ResumeLayout(false);
            this.pnShowPointer.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion
        internal System.Windows.Forms.Label lblTitle;
        internal System.Windows.Forms.DataGridView dgvPlan;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.TextBox txtQue;
        private System.Windows.Forms.Button btnConvert;
        private System.Windows.Forms.Timer timPlan;
        private System.Windows.Forms.Label lblQue;
        private System.Windows.Forms.Button btnOK;
        internal System.Windows.Forms.Label lblStatus;
        private System.Windows.Forms.DataGridViewTextBoxColumn PlanRunno;
        private System.Windows.Forms.DataGridViewTextBoxColumn Column1;
        private System.Windows.Forms.DataGridViewTextBoxColumn Model;
        private System.Windows.Forms.DataGridViewTextBoxColumn Code;
        private System.Windows.Forms.DataGridViewTextBoxColumn Quantity;
        internal System.Windows.Forms.DataGridView dgvBuffer;
        private System.Windows.Forms.Panel panel1;
        private System.Windows.Forms.Panel panel2;
        private System.Windows.Forms.Label lblPlanRemaining;
        private System.Windows.Forms.Label label3;
        private System.ComponentModel.BackgroundWorker bgwkUpdate;
        private System.Windows.Forms.ProgressBar prgUpdate;
        private System.Windows.Forms.Label lblUsedPart;
        private System.Windows.Forms.Label ddd;
        private System.Windows.Forms.Timer timBufferPlan;
        internal System.Windows.Forms.Label lblTime;
        private System.Windows.Forms.Timer timClock;
        private System.Windows.Forms.DataGridViewTextBoxColumn dataGridViewTextBoxColumn2;
        private System.Windows.Forms.DataGridViewTextBoxColumn Qty;
        internal System.Windows.Forms.Label lblPointer;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.Label lblRunnoPointer;
        private System.Windows.Forms.Label lblSebanPointer;
        private System.Windows.Forms.Panel pnShowPointer;
        private System.Windows.Forms.Label lblPartPointer;
        private System.Windows.Forms.Label lblPart;
    }
}

