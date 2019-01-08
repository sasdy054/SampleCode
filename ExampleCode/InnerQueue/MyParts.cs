using System;
using System.Collections.Generic;
using System.Configuration;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using MESModule.DB;
using MESModule.Utility;

namespace InnerQueue
{
    class MyParts
    {
        #region *** Backing Fields && Properties

        #region ** Backing Fields
        //for this Workstation
        const int MAX_CONDITION = 3;
        static string[] _comp = new string[MAX_CONDITION];
        static string[] _cond = new string[MAX_CONDITION];
        static string[] _num = new string[MAX_CONDITION];

        // Condition Workstation
        private string[] _condPNT1 = new string[_cond.Length];
        private string[] _condPNT2 = new string[_cond.Length];
        private string[] _condPNT3 = new string[_cond.Length];

        // Database
        string _line;
        string _part;
        string _dwgPartFD;
        string _pnt;
        string _point;        
        MyDB _db;
        string _wc;
        string _recordTB;
        string _confirmTB;
        string _runnoTB;
        string _masterPartTB;
        string _planTB, _pnt1, _pnt2, _pnt3;
        string _bfnumber;
        string _bufferTB;
        string _pointerTB; 
        string _bfpnt;
        string _bfpnts;
        string _bfPointer;
        string _bfname;
        string _partType;

        //product information
        string _seban, _model, _planRunno;
        string _partCode;
        string _partDwg;
        string _status;
        int _numberModelInPlan;
        DbObject _groupedPlan;
        int _numberUsedPart;
        #endregion

        #region ** Properties
        public string Line { get => _line; }
        public string Part { get => _part; }
        public string Pnt { get => _part; }
        public string PartCode { get => _partCode; }
        public string PartDrawing { get => _partDwg; }
        public string Status { get => _status; }
        public string PartDWFD { get => _partDwg; }
        public int NumberModelInPlan { get => _numberModelInPlan; }
        public DbObject GroupedPlan { get => _groupedPlan; }
        public int NumberUsedPart { get => _numberUsedPart; }
        #endregion

        #endregion

        #region *** Constructor && Initialize
        public MyParts(string line, string part)
        {
            _line = line;
            _part = part;
            _dwgPartFD = part + "_DWG";            

            InitializePart();
        }

        private void InitializePart()
        {
            _db = new MyDB(ConfigurationManager.ConnectionStrings["ConnectionLN"].ConnectionString);
            _wc = GetWC(Line);
            _recordTB = ConfigurationManager.AppSettings["RecordTB"];
            _pointerTB = ConfigurationManager.AppSettings["PointerTB"];
            _bufferTB = ConfigurationManager.AppSettings["BufferTB"];
            _confirmTB = $"PRIOCF{_line}";
            _point = ConfigurationManager.AppSettings["Point"];
            _pnt = ConfigurationManager.AppSettings["Pnt"];
            _bfpnt = ConfigurationManager.AppSettings["BFPNT"];
            _bfname = ConfigurationManager.AppSettings["BFNAME"];
            _masterPartTB = ConfigurationManager.AppSettings["MasterPartTB"];
            _partType = ConfigurationManager.AppSettings["PartType"];
            _runnoTB = ConfigurationManager.AppSettings["RunnoTB"];
            _bfnumber = ConfigurationManager.AppSettings["BFRUNNO"];
            _bfpnts = ConfigurationManager.AppSettings["BFPOINTER"];

            InitPKCMMD();
        }

        private string GetWC(string line)
        {
            string tmpWC = ConfigurationManager.AppSettings["WC"];
            if (!string.IsNullOrWhiteSpace(tmpWC)) return tmpWC;

            string _sql = "select WC " +
                "from LINEMT " +
                "where LINE = '" + line + "'";
            using (DbObject LN = _db.ExecQuery(_sql))
            {
                if (LN.EOF)
                {
                    MessageBox.Show("Not Found Work Center (" + line + ")");
                    MyApp.Close(false);
                }

                return LN["WC"];
            }
        }

        private void InitPKCMMD()
        {
            DbObject[] thisPKCM, condPKCM;

            if (!GetPlanCondition(_point, out thisPKCM))
            {
                MessageBox.Show(_status);
                MyApp.Close(false);
            }

            _planTB = thisPKCM[1]["PLAN_TABLE"].Replace("*", Line);
            _pnt1 = thisPKCM[1]["PNT1"];
            _pnt2 = thisPKCM[1]["PNT2"].Replace("*", Line);
            _pnt3 = thisPKCM[1]["PNT3"];

            for (int i = 0; i < MAX_CONDITION; i++)
            {
                int j = i + 1;
                _comp[i] = thisPKCM[0]["COMP" + j];
                _cond[i] = thisPKCM[0]["COND" + j];
                _num[i] = thisPKCM[0]["NUM" + j];

                if (string.IsNullOrWhiteSpace(_comp[i]) &&
                    string.IsNullOrWhiteSpace(_cond[i])) continue;

                if (!GetPlanCondition(_cond[i], out condPKCM))
                {
                    MessageBox.Show(_status);
                    MyApp.Close(false);
                }

                _condPNT1[i] = condPKCM[1]["PNT1"];
                _condPNT2[i] = condPKCM[1]["PNT2"].Replace("*", Line);
                _condPNT3[i] = condPKCM[1]["PNT3"];
            }
        }
        #endregion

        #region *** Method
        private bool GetPlanCondition(string pname, out DbObject[] PKCM)
        {
            PKCM = null;
            string _sql = "select * " +
                "from PK_CMMD_LINE " +
                "where PNAME = '" + pname + "'";
            using (DbObject PKCL = _db.ExecQuery(_sql))
            {
                if (PKCL.EOF)
                {
                    _status = "Not Found Data In PK_CMMD_LINE, PNAME = " + pname;
                    return false;
                }

                _sql = "select * " +
                    "from PK_CMMD_TYPE " +
                    "where TYPE = '" + MyString.Left(PKCL["CODE_TYPE"], 1) + "' " +
                    "and NO = '" + PKCL["CODE_TYPE"].Substring(1) + "'";
                using (DbObject PKCT = _db.ExecQuery(_sql))
                {
                    if (PKCT.EOF)
                    {
                        _status = "Not Found Data In PK_CMMD_TYPE, CODE_TYPE = " + PKCL["CODE_TYPE"];
                        return false;
                    }

                    PKCM = new DbObject[2] { new DbObject(PKCL.Table), new DbObject(PKCT.Table) };
                    return true;
                }
            }
        }

        public bool GetPlan(int numberofPlan, out DbObject[] pn)
        {
            pn = null;
            string mainRunno = GetCurrentPlanRunno(_pnt1, _pnt2, _pnt3, _point);
            if (string.IsNullOrWhiteSpace(mainRunno))
            {
                _status = "Not Found Data In " + _pnt2;
                return false;
            }


            string _sql = $"SELECT A.PNDATE, A.SHT, A.SEQ, A.QTY, A.RUNNO, A.ITEM, A.SERIAL, A.SEBAN ,NVL(B.MODEL, ' ') MODEL,NVL(B.{_part}, 'NO USE') {_part} " +
                            $"FROM {_planTB}  A, {_masterPartTB} B " +
                            $"WHERE TRIM(A.SEBAN) = B.SEBAN(+) " +
                            $"AND LINE = '{_line}'";

            string pastSQL = $"SELECT * " +
                            $"FROM ({_sql}) " +
                            $"WHERE RUNNO < '{mainRunno}' " +
                            $"ORDER BY RUNNO DESC";
            pastSQL = $"SELECT * " +
                $"FROM ({pastSQL}) WHERE ROWNUM < 3";
            using (DbObject PP = _db.ExecQuery(pastSQL))
            {
                int ShowFuture = numberofPlan;

                string futureSQL = $"SELECT * " +
                                    $"FROM ({_sql}) " +
                                    $"WHERE RUNNO >= '{mainRunno}' " +
                                    $"ORDER BY RUNNO";
                futureSQL = $"SELECT * " +
                            $"FROM ({futureSQL}) " +
                            $"WHERE ROWNUM <= {ShowFuture} ";

                string groupSQL = $"SELECT * " +
                                  $"FROM ({futureSQL}) " +
                                  $"ORDER BY RUNNO,{_part}";

                string modelSQL = $"SELECT COUNT(*) TOT " +
                                $"FROM " +
                                $"(" +
                                    $"SELECT DISTINCT {_part} " +
                                    $"FROM ({futureSQL}) " +
                                $")";
                using (DbObject MD = _db.ExecQuery(modelSQL))
                {
                    _numberModelInPlan = int.Parse(MD["TOT"]);
                }

                string partSQL = $"SELECT COUNT(*) TOT " +
                                $"FROM ({futureSQL}) " +
                                $"WHERE {_part} <> 'NO USE'";
                using(DbObject PRT = _db.ExecQuery(partSQL))
                {
                    _numberUsedPart = int.Parse(PRT["TOT"]);
                }

                //futureSQL = "select * from(" + futureSQL + ") where rownum < " + Convert.ToInt16(ConfigurationManager.AppSettings["nLabelsPerRound"]);
                using (DbObject FP = _db.ExecQuery(futureSQL))
                {
                    pn = new DbObject[] { new DbObject(PP.Table), new DbObject(FP.Table) };

                    if (FP.EOF)
                    {
                        _status = "Wait Plan";
                        return false;
                    }
                    return true;                   
                }
            }
        }
        
        public void GetBufferPlan(out DbObject pn)
        {
            string currentRunno = GetCurrentBufferRunno();

            string _sql = $"SELECT MIN(RUNNO) RUNNO,SEBAN,COUNT(*) QTY " +
                        $"FROM " +
                        $"(" +
                            $"SELECT * " +
                            $"FROM {_bufferTB}  " +
                            $"WHERE PNT = '{_bfPointer}' " +
                            $"AND RUNNO >= '{currentRunno}' " +
                            $"ORDER BY RUNNO " +
                        $") " +
                        $"GROUP BY SEBAN " +
                        $"ORDER BY RUNNO";
            using(DbObject PN = _db.ExecQuery(_sql))
            {
                pn = new DbObject(PN.Table);
            }
        }

        private bool CheckMasterApproved(string seban, string inMaster, out string outMaster, out string status)
        {
            return CheckMasterApproved(seban, inMaster, out outMaster, out status, null);
        }

        public bool CheckMasterApproved(string seban, string inMaster, out string outMaster, out string status, string[] checkedFD, bool transfer = false)
        {
            outMaster = null;
            status = "";

            string applyFD = (inMaster == "PCLABEL_MT") ? "APPDATE" : MyString.Right(inMaster, 2) + "_APPLY";
            string statusFD = (inMaster == "PCLABEL_MT") ? "FORM_R" : "STATUS";
            outMaster = inMaster;
            string applyField = MyString.Right(inMaster, 2) + "_APPLY";
            string fieldToCompare = string.Empty;
            if (checkedFD != null)
            {
                foreach (string f in checkedFD)
                {
                    fieldToCompare += ", " + f;
                }
            }

            string _sql = $"SELECT {statusFD}{fieldToCompare} " +
                          $"FROM {inMaster}_BK " +
                          $"WHERE LINE='{_line}' " +
                          $"AND SEBAN = '{seban}' " +
                          $"AND TO_CHAR({applyFD},'YYYYMMDD')||'080000'<=TO_CHAR(SYSDATE,'YYYYMMDDHH24MISS') " +
                          $"AND {applyField} IS NOT NULL";
            using (DbObject BK = _db.ExecQuery(_sql))
            {
                _sql = $"SELECT {statusFD},{applyFD}{fieldToCompare} " +
                      $"FROM {inMaster} " +
                      $"WHERE LINE='{_line}' " +
                      $"AND SEBAN='{seban}'";
                using (DbObject MT = _db.ExecQuery(_sql))
                {
                    if (BK.EOF)
                    {
                        if (MT.EOF)
                        {
                            status = $"Not found seban {seban} in  {inMaster}";
                            return false;
                        }

                        if (MT[statusFD] != "OK")
                        {
                            status = $"{inMaster} NG!!!";
                            return false;
                        }

                        if (!string.IsNullOrWhiteSpace(MT[applyFD]))
                        {
                            DateTime applyDate = DateTime.Parse(MT[applyFD]);
                            DateTime now = GetServerTime();
                            if (applyDate > now)
                            {
                                status = $"{inMaster} wait apply date {applyDate.ToString("dd/MM/yyyy")}";
                                return false;
                            }
                        }

                        return true;
                    }

                    if (BK[statusFD] != "OK")
                    {
                        if (checkedFD != null)
                        {
                            bool isSameData = true;
                            for (int i = 0; i < checkedFD.Length; i++)
                            {
                                if (BK[checkedFD[i]] != MT[checkedFD[i]] && MT[checkedFD[i]] != "")
                                {
                                    isSameData = false;
                                    break;
                                }
                            }
                            if (isSameData) return true;
                        }

                        status = $"Wait Approve Master ( {outMaster} )";
                        return false;
                    }
                    else
                    {
                        if (transfer)
                        {
                            if (MT.EOF)
                            {
                                _sql= $"INSERT INTO {inMaster}_LOG " +
                                    $"SELECT * FROM {inMaster} " +
                                    $"WHERE LINE = '{Line}' " +
                                    $"AND SEBAN = '{seban}'";
                                _db.ExecNonQuery(_sql);

                                _sql = $"DELETE FROM {inMaster} " +
                                    $"WHERE LINE = '{Line}' " +
                                    "and SEBAN = '" + seban + "'";
                                _db.ExecNonQuery(_sql);
                            }

                            _sql= "insert into " + inMaster + " " +
                                "select * from " + inMaster + "_BK " +
                                "where LINE = '" + Line + "' " +
                                "and SEBAN = '" + seban + "'";
                            _db.ExecNonQuery(_sql);

                            _sql = "delete from " + inMaster + "_BK " +
                                "where LINE = '" + Line + "' " +
                                "and SEBAN = '" + seban + "'";
                            _db.ExecNonQuery(_sql);

                            _sql = "update " + inMaster + " " +
                                "set transfer_cname = '" + MyCom.GetMachineName() + "', " +
                                "transfer_ymdt = to_char(sysdate,'yyyymmddhh24miss') " +
                                "where LINE = '" + Line + "' " +
                                "and SEBAN = '" + seban + "'";

                            outMaster += "_BK";
                            return true;
                        }
                    }
                    outMaster += "_BK";
                    status = "Wait Transfer Master (" + outMaster + ")";
                    return false;
                }
            }
        }

        public DateTime GetServerTime()
        {
            string _sql = "select SYSDATE as DD from DUAL";
            using (DbObject DT = _db.ExecQuery(_sql))
            {
                return DateTime.Parse(DT["DD"]);
            }
        }

        private string GetCurrentPlanRunno(string pnt1, string pnt2, string pnt3, string pnt4)
        {
            string _sql = $"SELECT NVL({pnt1},'0') RUNNO " +
                  $"FROM {pnt2} " +
                  $"WHERE {pnt3}='{pnt4}'";
            using (DbObject RN = _db.ExecQuery(_sql))
            {
                return (RN.EOF) ? "" : RN["RUNNO"];
            }
        }

        public string GetCurrentBufferRunno()
        {
            string _sql = $"SELECT {_bfnumber},{_bfpnts} " +
                        $"FROM {_pointerTB} " +
                        $"WHERE PNT = '{_bfpnt}' " +
                        $"AND NAME = '{_bfname}'";
            using(DbObject PN = _db.ExecQuery(_sql))
            {
                _bfPointer = PN[_bfpnts];
                return PN[_bfnumber];
            }
        }

        public string GetHataRunno(string seban, string model)
        {
            string _sql = $"SELECT RUNNO " +
                          $"FROM {_runnoTB} " +
                          $"WHERE LINE='{_line}' " +
                          $"AND TYPE='{_partType}' " +
                          $"AND SEBAN='{seban}' " +
                          $"AND MODEL='{model}'";
            using (DbObject RN = _db.ExecQuery(_sql))
            {
                if (RN.EOF) return "0000001";
                return (int.Parse(RN["RUNNO"]) + 1).ToString("0000000");
            }
        }

        public bool UpdateHataRunno(string seban, string model, string runno)
        {
            string _sql = $"UPDATE {_runnoTB} " +
                          $"SET RUNNO='{runno}'," +
                          $"Udate = SYSDATE " +
                          $"WHERE LINE='{_line}' " +
                          $"AND TYPE='{_partType}' " +
                          $"AND SEBAN='{seban}' " +
                          $"AND MODEL='{model}'";
            _db.ExecNonQuery(_sql);

            if (_db.RowAffected < 1)
            {
                _sql = $"INSERT INTO {_runnoTB} " +
                    $"(LINE,TYPE,SEBAN,MODEL,RUNNO,UDATE,CDATE) " +
                      $"VALUES ('{Line}','{_partType}','{seban}','{model}','{runno}',SYSDATE,SYSDATE)";
                return _db.ExecNonQuery(_sql);
            }

            return true;
        }

        public bool UpdatePlanRunno(string runno)
        {            
            string tmpRunno = GetCurrentPlanRunno(_pnt1, _pnt2, _pnt3, _point);
            string nextRunno = (runno.Length == 15) ?
                $"{MyString.Left(runno, 9)}{(int.Parse(MyString.Mid(runno, 9, 6)) + 1).ToString("000000")}" :
                (int.Parse(runno) + 1).ToString("0000000");

            if (string.Compare(nextRunno, tmpRunno) != 1)
            {
                _status = $"Runno in server is equal or greater than next runno [{nextRunno}]";
                return false;
            }

            string _sql =   $"UPDATE {_pnt2} " +
                            $"SET {_pnt1} = '{nextRunno}' " +
                            $"WHERE {_pnt3} ='{_point}'";
            _db.ExecNonQuery(_sql);

            return true;
        }

        public bool InsertPrioCF()
        {
            return true;
        }

        public bool CreateBuffer(string seban, string serial, ushort qtyCheckLast = 1, ushort qtyDel = 3000)
        {
            #region Not use
            //string _sql = $"SELECT * FROM" +
            //    $"(" +
            //         $"SELECT rownum, pnt, seban, serial FROM " +
            //            $"(" +
            //            $"SELECT PNT, SEBAN, SERIAL " +
            //            $"FROM PKBF_{_line} " +
            //            $"WHERE PNT = '{_bfpnt}' " +
            //            $"order by runno desc" +
            //             $") " +
            //      $"WHERE ROWNUM<={qtyCheckLast} " +
            //    $") where SEBAN='{seban}' " +
            //      $"AND SERIAL='{serial}'";
            //using (DbObject BF = _db.ExecQuery(_sql))
            //{
            //    if (!BF.EOF)
            //    {
            //        // lblSendData.BackColor = Color.Red;
            //        // MyAudio.PlayBackground(SoundPath + "DOUBLE.wav");
            //        return true;
            //    }
            //}
            #endregion

            string tmpRunno, tmpRunnoDate, tmpRunnoNumber, nextRunno;
            string _sql = $"SELECT TO_CHAR(SYSDATE,'YYYYMMDD') AS YMD,MAX(RUNNO) RUNNO " +
                      $"FROM {_bufferTB} " +
                      $"WHERE PNT='{_bfPointer}'";
            using (DbObject RN = _db.ExecQuery(_sql))
            {
                string tmpToday = RN["YMD"];
                if (string.IsNullOrEmpty(RN["RUNNO"])) nextRunno = $"{tmpToday}0000100";
                else
                {
                    tmpRunno = RN["RUNNO"];
                    tmpRunnoDate = MyString.Left(tmpRunno, 8);
                    tmpRunnoNumber = MyString.Mid(tmpRunno, 8, 5);

                    bool areSameDate = (string.Compare(tmpToday, tmpRunnoDate) == 0);

                    if (areSameDate) nextRunno = $"{tmpRunnoDate}{(int.Parse(tmpRunnoNumber) + 1).ToString("00000")}00";
                    else nextRunno = $"{tmpToday}0000100";
                }

                _sql = $"INSERT INTO {_bufferTB} " +
                    $"(PNT,NAME,RUNNO,SEBAN,SERIAL,CREATEBY,CYMDT) " +
                      $"VALUES ('{_bfPointer}','{_bfname}','{nextRunno}','{seban}','{serial}','{_point}',TO_CHAR(SYSDATE,'YYYYMMDDHH24MISS'))";
                return _db.ExecNonQuery(_sql);                
            }
        }
        #endregion
    }

    public class PointerInformation
    {
        string _runno;
        string _seban;
        string _pointName;
        string _partDwg;
        string _line = ConfigurationManager.AppSettings["Line"];
        string _masterPartTB = ConfigurationManager.AppSettings["MasterPartTB"];
        string _part = ConfigurationManager.AppSettings["Part"];
        string _pointerTB = ConfigurationManager.AppSettings["PointersTB"];
        string _prioTB = ConfigurationManager.AppSettings["PrioTB"];
        public string Runno { get => _runno; }
        public string Seban { get => _seban; }
        public string PartDwg { get => _partDwg; }

        public PointerInformation(string pointname)
        {
            _pointName = pointname;
        }

        public void GetInformation()
        {
            string _sql = $"SELECT A.RUNNO,A.SEBAN,A.MODEL,B.{_part} " +
                        $"FROM {_prioTB} A,INDOOR_MT_PD B " +
                        $"WHERE A.RUNNO = " +
                        $"( " +
                            $"SELECT SUBSTR(RUNNO, 1, 14) || '0' " +
                            $"FROM {_pointerTB} " +
                            $"WHERE LINE = '{_pointName}' " +
                        $") " +
                        $"AND A.SEBAN = B.SEBAN";
            using (MyDB _db = new MyDB(ConfigurationManager.ConnectionStrings["ConnectionLN"].ConnectionString))
            using (DbObject _pnt = _db.ExecQuery(_sql))
            {
                _runno = _pnt["RUNNO"];
                _seban = _pnt["SEBAN"];
                _partDwg = _pnt[_part];
            }
        }
    }
}
