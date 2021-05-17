using System;
using System.Collections.Generic;
using System.Data;
using StandardDAC;
using System.Data.SqlClient;
using StandardDAC.SqlClient;
using SaleMTDataAccessLayer.SaleMTDAL;

namespace SaleMTDataAccessLayer.SaleMTObj
{
    public class MASTER_EX_EXAMEYE
    {
        #region members
        string examEye_Code;
        string customer_ID;
        int? dept_Code;
        string store_Code;
        DateTime examDate;
        string employee_ID;
        string complaintOther;
        bool complaint01;
        bool complaint02;
        bool complaint03;
        bool complaint04;
        bool complaint05;
        bool complaint06;
        bool complaint07;
        bool complaint08;
        bool complaint09;
        bool complaint10;
        bool complaint11;
        string externalExam;
        string ocularHistory;
        string healthHistory;
        string familyHistory;
        string lIDS;
        string cORNEA;
        string lENS;
        string rETINA;
        string recommendation;
        string resultEOM;
        string remarksEOM;
        string oDPupillaryRespDLR;
        string oSPupillaryRespDLR;
        string oDPupillaryRespCLR;
        string oSPupillaryRespCLR;
        string oDCoverFar;
        string oDCoverNear;
        string oSCoverFar;
        string oSCoverNear;
        string oDNPC;
        string oSNPC;
        string amslerGrid;
        bool? rightEyeVSA;
        bool? rightEyeVSB;
        bool? rightEyeVSC;
        bool? leftEyeVSA;
        bool? leftEyeVSB;
        bool? leftEyeVSC;
        string cVF;
        string bP;
        string tonometer;
        bool? dLRpupil;
        bool? cLRpupil;
        string lastWear;
        string oldRXComplaint;
        string findings;
        string remarks;
        DateTime? nextAppointment;
        string new_OD_Sph;
        string new_OD_Cyl;
        string new_OD_Axis;
        string new_OD_FarVA;
        string new_OD_NearVA;
        string new_OD_RxADD;
        string new_OD_NearPD;
        string new_OD_FarPD;
        string new_OD_SegH;
        string new_OS_Sph;
        string new_OS_Cyl;
        string new_OS_Axis;
        string new_OS_FarVA;
        string new_OS_NearVA;
        string new_OS_RxADD;
        string new_OS_NearPD;
        string new_OS_FarPD;
        string new_OS_SegH;
        string new_NeedDemandID;
        string new_LensTypeID;
        string new_LensCT;
        string new_LensET;
        string new_LensBrandLineID;
        string new_LensMaterialID;
        string new_FrameBrandLineID;
        string new_FrameMaterialID;
        string new_FrameDesignID;
        string new_Complaint;
        string new_Remarks;
        string new_FrameSize;
        string new_FrameColor;
        string new_FrameModel;
        string new_LensMaterialIndexID;
        string old_OD_Sph;
        string old_OD_Cyl;
        string old_OD_Axis;
        string old_OD_FarVA;
        string old_OD_NearVA;
        string old_OD_RxADD;
        string old_OD_FarPD;
        string old_OD_NearPD;
        string old_OS_Sph;
        string old_OS_Cyl;
        string old_OS_Axis;
        string old_OS_FarVA;
        string old_OS_NearVA;
        string old_OS_RxADD;
        string old_OS_FarPD;
        string old_OS_NearPD;
        string old_Complaint;
        string old_Duration;
        string old_LastWear;
        string new_CL_OD_Sph;
        string new_CL_OD_Cyl;
        string new_CL_OD_Axis;
        string new_CL_OD_FarVA;
        string new_CL_OD_NearVA;
        string new_CL_OD_BC;
        string new_CL_OD_DIA;
        string new_CL_OS_Sph;
        string new_CL_OS_Cyl;
        string new_CL_OS_Axis;
        string new_CL_OS_FarVA;
        string new_CL_OS_NearVA;
        string new_CL_OS_BC;
        string new_CL_OS_DIA;
        string new_CL_CLTypeID;
        string new_CL_Tint;
        string new_CL_Brand;
        string old_CL_OD_Sph;
        string old_CL_OD_Cyl;
        string old_CL_OD_Axis;
        string old_CL_OD_FarVA;
        string old_CL_OD_NearVA;
        string old_CL_OD_BC;
        string old_CL_OD_DIA;
        string old_CL_OS_Sph;
        string old_CL_OS_Cyl;
        string old_CL_OS_Axis;
        string old_CL_OS_FarVA;
        string old_CL_OS_NearVA;
        string old_CL_OS_BC;
        string old_CL_OS_DIA;
        string old_CL_CLTypeID;
        string old_CL_CLMaterialID;
        string old_CL_Brand;
        string old_CL_Duration;
        DateTime? dateCreate;
        DateTime? dateUpdate;
        string userCreate;
        string userUpdate;
        int? sendMailTimes;
        DateTime? remindDate;
        float? tOTAL;
        string eVENT_ID;
        string new_CTOD;
        string new_CTOS;
        string new_ETOD;
        string new_ETOS;
        string new_BrandOfLens;
        string new_LensTint;
        string new_UVTint;
        string sta1_Frame;
        string sta1_AmountFamre;
        string sta1_Sunglass;
        string sta1_AmountSunglass;
        string sta1_Lens;
        string sta1_AmountLens;
        string sta1_Others;
        string sta1_AmountOthers;
        string sta2_Frame;
        string sta2_AmountFamre;
        string sta2_Sunglass;
        string sta2_AmountSunglass;
        string sta2_Lens;
        string sta2_AmountLens;
        string sta2_Others;
        string sta2_AmountOthers;
        string sta3_Frame;
        string sta3_AmountFamre;
        string sta3_Sunglass;
        string sta3_AmountSunglass;
        string sta3_Lens;
        string sta3_AmountLens;
        string sta3_Others;
        string sta3_AmountOthers;
        string new_Sta_Remarks;
        string new_Total;
        string new_Deposit;
        string new_Balance;
        string new_HMC;
        string new_HiIndex;
        string new_PhotoChromic;
        string new_TintedLens;
        Guid rowguid;

        #endregion members
        #region Properties
        [PKSqlColumn("ExamEye_Code", SqlDbType.VarChar, null)]
        public string ExamEye_Code
        {
            get { return examEye_Code; }
            set { examEye_Code = value; }
        }
        [StringSqlColumn("Customer_ID")]
        public string Customer_ID
        {
            get { return customer_ID; }
            set { customer_ID = value; }
        }
        [SqlColumn("Dept_Code", SqlDbType.Int)]
        public int? Dept_Code
        {
            get { return dept_Code; }
            set { dept_Code = value; }
        }
        [StringSqlColumn("Store_Code")]
        public string Store_Code
        {
            get { return store_Code; }
            set { store_Code = value; }
        }
        [SqlColumn("ExamDate", SqlDbType.DateTime)]
        public DateTime ExamDate
        {
            get { return examDate; }
            set { examDate = value; }
        }
        [StringSqlColumn("Employee_ID")]
        public string Employee_ID
        {
            get { return employee_ID; }
            set { employee_ID = value; }
        }
        [SqlColumn("ComplaintOther", SqlDbType.NVarChar)]
        public string ComplaintOther
        {
            get { return complaintOther; }
            set { complaintOther = value; }
        }
        [SqlColumn("Complaint01", SqlDbType.Bit)]
        public bool Complaint01
        {
            get { return complaint01; }
            set { complaint01 = value; }
        }
        [SqlColumn("Complaint02", SqlDbType.Bit)]
        public bool Complaint02
        {
            get { return complaint02; }
            set { complaint02 = value; }
        }
        [SqlColumn("Complaint03", SqlDbType.Bit)]
        public bool Complaint03
        {
            get { return complaint03; }
            set { complaint03 = value; }
        }
        [SqlColumn("Complaint04", SqlDbType.Bit)]
        public bool Complaint04
        {
            get { return complaint04; }
            set { complaint04 = value; }
        }
        [SqlColumn("Complaint05", SqlDbType.Bit)]
        public bool Complaint05
        {
            get { return complaint05; }
            set { complaint05 = value; }
        }
        [SqlColumn("Complaint06", SqlDbType.Bit)]
        public bool Complaint06
        {
            get { return complaint06; }
            set { complaint06 = value; }
        }
        [SqlColumn("Complaint07", SqlDbType.Bit)]
        public bool Complaint07
        {
            get { return complaint07; }
            set { complaint07 = value; }
        }
        [SqlColumn("Complaint08", SqlDbType.Bit)]
        public bool Complaint08
        {
            get { return complaint08; }
            set { complaint08 = value; }
        }
        [SqlColumn("Complaint09", SqlDbType.Bit)]
        public bool Complaint09
        {
            get { return complaint09; }
            set { complaint09 = value; }
        }
        [SqlColumn("Complaint10", SqlDbType.Bit)]
        public bool Complaint10
        {
            get { return complaint10; }
            set { complaint10 = value; }
        }
        [SqlColumn("Complaint11", SqlDbType.Bit)]
        public bool Complaint11
        {
            get { return complaint11; }
            set { complaint11 = value; }
        }
        [SqlColumn("ExternalExam", SqlDbType.NVarChar)]
        public string ExternalExam
        {
            get { return externalExam; }
            set { externalExam = value; }
        }
        [SqlColumn("OcularHistory", SqlDbType.NVarChar)]
        public string OcularHistory
        {
            get { return ocularHistory; }
            set { ocularHistory = value; }
        }
        [SqlColumn("HealthHistory", SqlDbType.NVarChar)]
        public string HealthHistory
        {
            get { return healthHistory; }
            set { healthHistory = value; }
        }
        [SqlColumn("FamilyHistory", SqlDbType.NVarChar)]
        public string FamilyHistory
        {
            get { return familyHistory; }
            set { familyHistory = value; }
        }
        [SqlColumn("LIDS", SqlDbType.NVarChar)]
        public string LIDS
        {
            get { return lIDS; }
            set { lIDS = value; }
        }
        [SqlColumn("CORNEA", SqlDbType.NVarChar)]
        public string CORNEA
        {
            get { return cORNEA; }
            set { cORNEA = value; }
        }
        [SqlColumn("LENS", SqlDbType.NVarChar)]
        public string LENS
        {
            get { return lENS; }
            set { lENS = value; }
        }
        [SqlColumn("RETINA", SqlDbType.NVarChar)]
        public string RETINA
        {
            get { return rETINA; }
            set { rETINA = value; }
        }
        [SqlColumn("Recommendation", SqlDbType.NVarChar)]
        public string Recommendation
        {
            get { return recommendation; }
            set { recommendation = value; }
        }
        [SqlColumn("ResultEOM", SqlDbType.NVarChar)]
        public string ResultEOM
        {
            get { return resultEOM; }
            set { resultEOM = value; }
        }
        [SqlColumn("RemarksEOM", SqlDbType.NVarChar)]
        public string RemarksEOM
        {
            get { return remarksEOM; }
            set { remarksEOM = value; }
        }
        [StringSqlColumn("ODPupillaryRespDLR")]
        public string ODPupillaryRespDLR
        {
            get { return oDPupillaryRespDLR; }
            set { oDPupillaryRespDLR = value; }
        }
        [StringSqlColumn("OSPupillaryRespDLR")]
        public string OSPupillaryRespDLR
        {
            get { return oSPupillaryRespDLR; }
            set { oSPupillaryRespDLR = value; }
        }
        [StringSqlColumn("ODPupillaryRespCLR")]
        public string ODPupillaryRespCLR
        {
            get { return oDPupillaryRespCLR; }
            set { oDPupillaryRespCLR = value; }
        }
        [StringSqlColumn("OSPupillaryRespCLR")]
        public string OSPupillaryRespCLR
        {
            get { return oSPupillaryRespCLR; }
            set { oSPupillaryRespCLR = value; }
        }
        [StringSqlColumn("ODCoverFar")]
        public string ODCoverFar
        {
            get { return oDCoverFar; }
            set { oDCoverFar = value; }
        }
        [StringSqlColumn("ODCoverNear")]
        public string ODCoverNear
        {
            get { return oDCoverNear; }
            set { oDCoverNear = value; }
        }
        [StringSqlColumn("OSCoverFar")]
        public string OSCoverFar
        {
            get { return oSCoverFar; }
            set { oSCoverFar = value; }
        }
        [StringSqlColumn("OSCoverNear")]
        public string OSCoverNear
        {
            get { return oSCoverNear; }
            set { oSCoverNear = value; }
        }
        [StringSqlColumn("ODNPC")]
        public string ODNPC
        {
            get { return oDNPC; }
            set { oDNPC = value; }
        }
        [StringSqlColumn("OSNPC")]
        public string OSNPC
        {
            get { return oSNPC; }
            set { oSNPC = value; }
        }
        [StringSqlColumn("AmslerGrid")]
        public string AmslerGrid
        {
            get { return amslerGrid; }
            set { amslerGrid = value; }
        }
        [SqlColumn("RightEyeVSA", SqlDbType.Bit)]
        public bool? RightEyeVSA
        {
            get { return rightEyeVSA; }
            set { rightEyeVSA = value; }
        }
        [SqlColumn("RightEyeVSB", SqlDbType.Bit)]
        public bool? RightEyeVSB
        {
            get { return rightEyeVSB; }
            set { rightEyeVSB = value; }
        }
        [SqlColumn("RightEyeVSC", SqlDbType.Bit)]
        public bool? RightEyeVSC
        {
            get { return rightEyeVSC; }
            set { rightEyeVSC = value; }
        }
        [SqlColumn("LeftEyeVSA", SqlDbType.Bit)]
        public bool? LeftEyeVSA
        {
            get { return leftEyeVSA; }
            set { leftEyeVSA = value; }
        }
        [SqlColumn("LeftEyeVSB", SqlDbType.Bit)]
        public bool? LeftEyeVSB
        {
            get { return leftEyeVSB; }
            set { leftEyeVSB = value; }
        }
        [SqlColumn("LeftEyeVSC", SqlDbType.Bit)]
        public bool? LeftEyeVSC
        {
            get { return leftEyeVSC; }
            set { leftEyeVSC = value; }
        }
        [SqlColumn("CVF", SqlDbType.NVarChar)]
        public string CVF
        {
            get { return cVF; }
            set { cVF = value; }
        }
        [StringSqlColumn("BP")]
        public string BP
        {
            get { return bP; }
            set { bP = value; }
        }
        [SqlColumn("Tonometer", SqlDbType.NVarChar)]
        public string Tonometer
        {
            get { return tonometer; }
            set { tonometer = value; }
        }
        [SqlColumn("DLRpupil", SqlDbType.Bit)]
        public bool? DLRpupil
        {
            get { return dLRpupil; }
            set { dLRpupil = value; }
        }
        [SqlColumn("CLRpupil", SqlDbType.Bit)]
        public bool? CLRpupil
        {
            get { return cLRpupil; }
            set { cLRpupil = value; }
        }
        [SqlColumn("LastWear", SqlDbType.NVarChar)]
        public string LastWear
        {
            get { return lastWear; }
            set { lastWear = value; }
        }
        [SqlColumn("OldRXComplaint", SqlDbType.NVarChar)]
        public string OldRXComplaint
        {
            get { return oldRXComplaint; }
            set { oldRXComplaint = value; }
        }
        [SqlColumn("Findings", SqlDbType.NVarChar)]
        public string Findings
        {
            get { return findings; }
            set { findings = value; }
        }
        [SqlColumn("Remarks", SqlDbType.NText)]
        public string Remarks
        {
            get { return remarks; }
            set { remarks = value; }
        }
        [SqlColumn("NextAppointment", SqlDbType.DateTime)]
        public DateTime? NextAppointment
        {
            get { return nextAppointment; }
            set { nextAppointment = value; }
        }
        [SqlColumn("New_OD_Sph", SqlDbType.NVarChar)]
        public string New_OD_Sph
        {
            get { return new_OD_Sph; }
            set { new_OD_Sph = value; }
        }
        [SqlColumn("New_OD_Cyl", SqlDbType.NVarChar)]
        public string New_OD_Cyl
        {
            get { return new_OD_Cyl; }
            set { new_OD_Cyl = value; }
        }
        [SqlColumn("New_OD_Axis", SqlDbType.NVarChar)]
        public string New_OD_Axis
        {
            get { return new_OD_Axis; }
            set { new_OD_Axis = value; }
        }
        [SqlColumn("New_OD_FarVA", SqlDbType.NVarChar)]
        public string New_OD_FarVA
        {
            get { return new_OD_FarVA; }
            set { new_OD_FarVA = value; }
        }
        [SqlColumn("New_OD_NearVA", SqlDbType.NVarChar)]
        public string New_OD_NearVA
        {
            get { return new_OD_NearVA; }
            set { new_OD_NearVA = value; }
        }
        [SqlColumn("New_OD_RxADD", SqlDbType.NVarChar)]
        public string New_OD_RxADD
        {
            get { return new_OD_RxADD; }
            set { new_OD_RxADD = value; }
        }
        [SqlColumn("New_OD_NearPD", SqlDbType.NVarChar)]
        public string New_OD_NearPD
        {
            get { return new_OD_NearPD; }
            set { new_OD_NearPD = value; }
        }
        [SqlColumn("New_OD_FarPD", SqlDbType.NVarChar)]
        public string New_OD_FarPD
        {
            get { return new_OD_FarPD; }
            set { new_OD_FarPD = value; }
        }
        [SqlColumn("New_OD_SegH", SqlDbType.NVarChar)]
        public string New_OD_SegH
        {
            get { return new_OD_SegH; }
            set { new_OD_SegH = value; }
        }
        [StringSqlColumn("New_OS_Sph")]
        public string New_OS_Sph
        {
            get { return new_OS_Sph; }
            set { new_OS_Sph = value; }
        }
        [StringSqlColumn("New_OS_Cyl")]
        public string New_OS_Cyl
        {
            get { return new_OS_Cyl; }
            set { new_OS_Cyl = value; }
        }
        [StringSqlColumn("New_OS_Axis")]
        public string New_OS_Axis
        {
            get { return new_OS_Axis; }
            set { new_OS_Axis = value; }
        }
        [SqlColumn("New_OS_FarVA", SqlDbType.NVarChar)]
        public string New_OS_FarVA
        {
            get { return new_OS_FarVA; }
            set { new_OS_FarVA = value; }
        }
        [SqlColumn("New_OS_NearVA", SqlDbType.NVarChar)]
        public string New_OS_NearVA
        {
            get { return new_OS_NearVA; }
            set { new_OS_NearVA = value; }
        }
        [SqlColumn("New_OS_RxADD", SqlDbType.NVarChar)]
        public string New_OS_RxADD
        {
            get { return new_OS_RxADD; }
            set { new_OS_RxADD = value; }
        }
        [SqlColumn("New_OS_NearPD", SqlDbType.NVarChar)]
        public string New_OS_NearPD
        {
            get { return new_OS_NearPD; }
            set { new_OS_NearPD = value; }
        }
        [SqlColumn("New_OS_FarPD", SqlDbType.NVarChar)]
        public string New_OS_FarPD
        {
            get { return new_OS_FarPD; }
            set { new_OS_FarPD = value; }
        }
        [SqlColumn("New_OS_SegH", SqlDbType.NVarChar)]
        public string New_OS_SegH
        {
            get { return new_OS_SegH; }
            set { new_OS_SegH = value; }
        }
        [StringSqlColumn("New_NeedDemandID")]
        public string New_NeedDemandID
        {
            get { return new_NeedDemandID; }
            set { new_NeedDemandID = value; }
        }
        [SqlColumn("New_LensTypeID", SqlDbType.NVarChar)]
        public string New_LensTypeID
        {
            get { return new_LensTypeID; }
            set { new_LensTypeID = value; }
        }
        [StringSqlColumn("New_LensCT")]
        public string New_LensCT
        {
            get { return new_LensCT; }
            set { new_LensCT = value; }
        }
        [StringSqlColumn("New_LensET")]
        public string New_LensET
        {
            get { return new_LensET; }
            set { new_LensET = value; }
        }
        [StringSqlColumn("New_LensBrandLineID")]
        public string New_LensBrandLineID
        {
            get { return new_LensBrandLineID; }
            set { new_LensBrandLineID = value; }
        }
        [SqlColumn("New_LensMaterialID", SqlDbType.NVarChar)]
        public string New_LensMaterialID
        {
            get { return new_LensMaterialID; }
            set { new_LensMaterialID = value; }
        }
        [StringSqlColumn("New_FrameBrandLineID")]
        public string New_FrameBrandLineID
        {
            get { return new_FrameBrandLineID; }
            set { new_FrameBrandLineID = value; }
        }
        [StringSqlColumn("New_FrameMaterialID")]
        public string New_FrameMaterialID
        {
            get { return new_FrameMaterialID; }
            set { new_FrameMaterialID = value; }
        }
        [StringSqlColumn("New_FrameDesignID")]
        public string New_FrameDesignID
        {
            get { return new_FrameDesignID; }
            set { new_FrameDesignID = value; }
        }
        [SqlColumn("New_Complaint", SqlDbType.NVarChar)]
        public string New_Complaint
        {
            get { return new_Complaint; }
            set { new_Complaint = value; }
        }
        [SqlColumn("New_Remarks", SqlDbType.NVarChar)]
        public string New_Remarks
        {
            get { return new_Remarks; }
            set { new_Remarks = value; }
        }
        [SqlColumn("New_FrameSize", SqlDbType.NVarChar)]
        public string New_FrameSize
        {
            get { return new_FrameSize; }
            set { new_FrameSize = value; }
        }
        [SqlColumn("New_FrameColor", SqlDbType.NVarChar)]
        public string New_FrameColor
        {
            get { return new_FrameColor; }
            set { new_FrameColor = value; }
        }
        [SqlColumn("New_FrameModel", SqlDbType.NVarChar)]
        public string New_FrameModel
        {
            get { return new_FrameModel; }
            set { new_FrameModel = value; }
        }
        [StringSqlColumn("New_LensMaterialIndexID")]
        public string New_LensMaterialIndexID
        {
            get { return new_LensMaterialIndexID; }
            set { new_LensMaterialIndexID = value; }
        }
        [StringSqlColumn("Old_OD_Sph")]
        public string Old_OD_Sph
        {
            get { return old_OD_Sph; }
            set { old_OD_Sph = value; }
        }
        [StringSqlColumn("Old_OD_Cyl")]
        public string Old_OD_Cyl
        {
            get { return old_OD_Cyl; }
            set { old_OD_Cyl = value; }
        }
        [StringSqlColumn("Old_OD_Axis")]
        public string Old_OD_Axis
        {
            get { return old_OD_Axis; }
            set { old_OD_Axis = value; }
        }
        [SqlColumn("Old_OD_FarVA", SqlDbType.NVarChar)]
        public string Old_OD_FarVA
        {
            get { return old_OD_FarVA; }
            set { old_OD_FarVA = value; }
        }
        [SqlColumn("Old_OD_NearVA", SqlDbType.NVarChar)]
        public string Old_OD_NearVA
        {
            get { return old_OD_NearVA; }
            set { old_OD_NearVA = value; }
        }
        [SqlColumn("Old_OD_RxADD", SqlDbType.NVarChar)]
        public string Old_OD_RxADD
        {
            get { return old_OD_RxADD; }
            set { old_OD_RxADD = value; }
        }
        [SqlColumn("Old_OD_FarPD", SqlDbType.NVarChar)]
        public string Old_OD_FarPD
        {
            get { return old_OD_FarPD; }
            set { old_OD_FarPD = value; }
        }
        [SqlColumn("Old_OD_NearPD", SqlDbType.NVarChar)]
        public string Old_OD_NearPD
        {
            get { return old_OD_NearPD; }
            set { old_OD_NearPD = value; }
        }
        [StringSqlColumn("Old_OS_Sph")]
        public string Old_OS_Sph
        {
            get { return old_OS_Sph; }
            set { old_OS_Sph = value; }
        }
        [StringSqlColumn("Old_OS_Cyl")]
        public string Old_OS_Cyl
        {
            get { return old_OS_Cyl; }
            set { old_OS_Cyl = value; }
        }
        [StringSqlColumn("Old_OS_Axis")]
        public string Old_OS_Axis
        {
            get { return old_OS_Axis; }
            set { old_OS_Axis = value; }
        }
        [SqlColumn("Old_OS_FarVA", SqlDbType.NVarChar)]
        public string Old_OS_FarVA
        {
            get { return old_OS_FarVA; }
            set { old_OS_FarVA = value; }
        }
        [SqlColumn("Old_OS_NearVA", SqlDbType.NVarChar)]
        public string Old_OS_NearVA
        {
            get { return old_OS_NearVA; }
            set { old_OS_NearVA = value; }
        }
        [SqlColumn("Old_OS_RxADD", SqlDbType.NVarChar)]
        public string Old_OS_RxADD
        {
            get { return old_OS_RxADD; }
            set { old_OS_RxADD = value; }
        }
        [SqlColumn("Old_OS_FarPD", SqlDbType.NVarChar)]
        public string Old_OS_FarPD
        {
            get { return old_OS_FarPD; }
            set { old_OS_FarPD = value; }
        }
        [SqlColumn("Old_OS_NearPD", SqlDbType.NVarChar)]
        public string Old_OS_NearPD
        {
            get { return old_OS_NearPD; }
            set { old_OS_NearPD = value; }
        }
        [SqlColumn("Old_Complaint", SqlDbType.NVarChar)]
        public string Old_Complaint
        {
            get { return old_Complaint; }
            set { old_Complaint = value; }
        }
        [SqlColumn("Old_Duration", SqlDbType.NVarChar)]
        public string Old_Duration
        {
            get { return old_Duration; }
            set { old_Duration = value; }
        }
        [SqlColumn("Old_LastWear", SqlDbType.NVarChar)]
        public string Old_LastWear
        {
            get { return old_LastWear; }
            set { old_LastWear = value; }
        }
        [StringSqlColumn("New_CL_OD_Sph")]
        public string New_CL_OD_Sph
        {
            get { return new_CL_OD_Sph; }
            set { new_CL_OD_Sph = value; }
        }
        [StringSqlColumn("New_CL_OD_Cyl")]
        public string New_CL_OD_Cyl
        {
            get { return new_CL_OD_Cyl; }
            set { new_CL_OD_Cyl = value; }
        }
        [StringSqlColumn("New_CL_OD_Axis")]
        public string New_CL_OD_Axis
        {
            get { return new_CL_OD_Axis; }
            set { new_CL_OD_Axis = value; }
        }
        [SqlColumn("New_CL_OD_FarVA", SqlDbType.NVarChar)]
        public string New_CL_OD_FarVA
        {
            get { return new_CL_OD_FarVA; }
            set { new_CL_OD_FarVA = value; }
        }
        [SqlColumn("New_CL_OD_NearVA", SqlDbType.NVarChar)]
        public string New_CL_OD_NearVA
        {
            get { return new_CL_OD_NearVA; }
            set { new_CL_OD_NearVA = value; }
        }
        [SqlColumn("New_CL_OD_BC", SqlDbType.NVarChar)]
        public string New_CL_OD_BC
        {
            get { return new_CL_OD_BC; }
            set { new_CL_OD_BC = value; }
        }
        [SqlColumn("New_CL_OD_DIA", SqlDbType.NVarChar)]
        public string New_CL_OD_DIA
        {
            get { return new_CL_OD_DIA; }
            set { new_CL_OD_DIA = value; }
        }
        [StringSqlColumn("New_CL_OS_Sph")]
        public string New_CL_OS_Sph
        {
            get { return new_CL_OS_Sph; }
            set { new_CL_OS_Sph = value; }
        }
        [StringSqlColumn("New_CL_OS_Cyl")]
        public string New_CL_OS_Cyl
        {
            get { return new_CL_OS_Cyl; }
            set { new_CL_OS_Cyl = value; }
        }
        [StringSqlColumn("New_CL_OS_Axis")]
        public string New_CL_OS_Axis
        {
            get { return new_CL_OS_Axis; }
            set { new_CL_OS_Axis = value; }
        }
        [SqlColumn("New_CL_OS_FarVA", SqlDbType.NVarChar)]
        public string New_CL_OS_FarVA
        {
            get { return new_CL_OS_FarVA; }
            set { new_CL_OS_FarVA = value; }
        }
        [SqlColumn("New_CL_OS_NearVA", SqlDbType.NVarChar)]
        public string New_CL_OS_NearVA
        {
            get { return new_CL_OS_NearVA; }
            set { new_CL_OS_NearVA = value; }
        }
        [SqlColumn("New_CL_OS_BC", SqlDbType.NVarChar)]
        public string New_CL_OS_BC
        {
            get { return new_CL_OS_BC; }
            set { new_CL_OS_BC = value; }
        }
        [SqlColumn("New_CL_OS_DIA", SqlDbType.NVarChar)]
        public string New_CL_OS_DIA
        {
            get { return new_CL_OS_DIA; }
            set { new_CL_OS_DIA = value; }
        }
        [StringSqlColumn("New_CL_CLTypeID")]
        public string New_CL_CLTypeID
        {
            get { return new_CL_CLTypeID; }
            set { new_CL_CLTypeID = value; }
        }
        [SqlColumn("New_CL_Tint", SqlDbType.NVarChar)]
        public string New_CL_Tint
        {
            get { return new_CL_Tint; }
            set { new_CL_Tint = value; }
        }
        [SqlColumn("New_CL_Brand", SqlDbType.NVarChar)]
        public string New_CL_Brand
        {
            get { return new_CL_Brand; }
            set { new_CL_Brand = value; }
        }
        [StringSqlColumn("Old_CL_OD_Sph")]
        public string Old_CL_OD_Sph
        {
            get { return old_CL_OD_Sph; }
            set { old_CL_OD_Sph = value; }
        }
        [StringSqlColumn("Old_CL_OD_Cyl")]
        public string Old_CL_OD_Cyl
        {
            get { return old_CL_OD_Cyl; }
            set { old_CL_OD_Cyl = value; }
        }
        [StringSqlColumn("Old_CL_OD_Axis")]
        public string Old_CL_OD_Axis
        {
            get { return old_CL_OD_Axis; }
            set { old_CL_OD_Axis = value; }
        }
        [SqlColumn("Old_CL_OD_FarVA", SqlDbType.NVarChar)]
        public string Old_CL_OD_FarVA
        {
            get { return old_CL_OD_FarVA; }
            set { old_CL_OD_FarVA = value; }
        }
        [SqlColumn("Old_CL_OD_NearVA", SqlDbType.NVarChar)]
        public string Old_CL_OD_NearVA
        {
            get { return old_CL_OD_NearVA; }
            set { old_CL_OD_NearVA = value; }
        }
        [SqlColumn("Old_CL_OD_BC", SqlDbType.NVarChar)]
        public string Old_CL_OD_BC
        {
            get { return old_CL_OD_BC; }
            set { old_CL_OD_BC = value; }
        }
        [SqlColumn("Old_CL_OD_DIA", SqlDbType.NVarChar)]
        public string Old_CL_OD_DIA
        {
            get { return old_CL_OD_DIA; }
            set { old_CL_OD_DIA = value; }
        }
        [StringSqlColumn("Old_CL_OS_Sph")]
        public string Old_CL_OS_Sph
        {
            get { return old_CL_OS_Sph; }
            set { old_CL_OS_Sph = value; }
        }
        [StringSqlColumn("Old_CL_OS_Cyl")]
        public string Old_CL_OS_Cyl
        {
            get { return old_CL_OS_Cyl; }
            set { old_CL_OS_Cyl = value; }
        }
        [StringSqlColumn("Old_CL_OS_Axis")]
        public string Old_CL_OS_Axis
        {
            get { return old_CL_OS_Axis; }
            set { old_CL_OS_Axis = value; }
        }
        [SqlColumn("Old_CL_OS_FarVA", SqlDbType.NVarChar)]
        public string Old_CL_OS_FarVA
        {
            get { return old_CL_OS_FarVA; }
            set { old_CL_OS_FarVA = value; }
        }
        [SqlColumn("Old_CL_OS_NearVA", SqlDbType.NVarChar)]
        public string Old_CL_OS_NearVA
        {
            get { return old_CL_OS_NearVA; }
            set { old_CL_OS_NearVA = value; }
        }
        [SqlColumn("Old_CL_OS_BC", SqlDbType.NVarChar)]
        public string Old_CL_OS_BC
        {
            get { return old_CL_OS_BC; }
            set { old_CL_OS_BC = value; }
        }
        [SqlColumn("Old_CL_OS_DIA", SqlDbType.NVarChar)]
        public string Old_CL_OS_DIA
        {
            get { return old_CL_OS_DIA; }
            set { old_CL_OS_DIA = value; }
        }
        [StringSqlColumn("Old_CL_CLTypeID")]
        public string Old_CL_CLTypeID
        {
            get { return old_CL_CLTypeID; }
            set { old_CL_CLTypeID = value; }
        }
        [StringSqlColumn("Old_CL_CLMaterialID")]
        public string Old_CL_CLMaterialID
        {
            get { return old_CL_CLMaterialID; }
            set { old_CL_CLMaterialID = value; }
        }
        [SqlColumn("Old_CL_Brand", SqlDbType.NVarChar)]
        public string Old_CL_Brand
        {
            get { return old_CL_Brand; }
            set { old_CL_Brand = value; }
        }
        [SqlColumn("Old_CL_Duration", SqlDbType.NVarChar)]
        public string Old_CL_Duration
        {
            get { return old_CL_Duration; }
            set { old_CL_Duration = value; }
        }
        [SqlColumn("DateCreate", SqlDbType.DateTime)]
        public DateTime? DateCreate
        {
            get { return dateCreate; }
            set { dateCreate = value; }
        }
        [SqlColumn("DateUpdate", SqlDbType.DateTime)]
        public DateTime? DateUpdate
        {
            get { return dateUpdate; }
            set { dateUpdate = value; }
        }
        [StringSqlColumn("UserCreate")]
        public string UserCreate
        {
            get { return userCreate; }
            set { userCreate = value; }
        }
        [StringSqlColumn("UserUpdate")]
        public string UserUpdate
        {
            get { return userUpdate; }
            set { userUpdate = value; }
        }
        [SqlColumn("SendMailTimes", SqlDbType.Int)]
        public int? SendMailTimes
        {
            get { return sendMailTimes; }
            set { sendMailTimes = value; }
        }
        [SqlColumn("RemindDate", SqlDbType.DateTime)]
        public DateTime? RemindDate
        {
            get { return remindDate; }
            set { remindDate = value; }
        }
        [SqlColumn("TOTAL", SqlDbType.Float)]
        public float? TOTAL
        {
            get { return tOTAL; }
            set { tOTAL = value; }
        }
        [SqlColumn("EVENT_ID", SqlDbType.NVarChar)]
        public string EVENT_ID
        {
            get { return eVENT_ID; }
            set { eVENT_ID = value; }
        }
        [SqlColumn("New_CTOD", SqlDbType.NVarChar)]
        public string New_CTOD
        {
            get { return new_CTOD; }
            set { new_CTOD = value; }
        }
        [SqlColumn("New_CTOS", SqlDbType.NVarChar)]
        public string New_CTOS
        {
            get { return new_CTOS; }
            set { new_CTOS = value; }
        }
        [SqlColumn("New_ETOD", SqlDbType.NVarChar)]
        public string New_ETOD
        {
            get { return new_ETOD; }
            set { new_ETOD = value; }
        }
        [SqlColumn("New_ETOS", SqlDbType.NVarChar)]
        public string New_ETOS
        {
            get { return new_ETOS; }
            set { new_ETOS = value; }
        }
        [SqlColumn("New_BrandOfLens", SqlDbType.NVarChar)]
        public string New_BrandOfLens
        {
            get { return new_BrandOfLens; }
            set { new_BrandOfLens = value; }
        }
        [SqlColumn("New_LensTint", SqlDbType.NVarChar)]
        public string New_LensTint
        {
            get { return new_LensTint; }
            set { new_LensTint = value; }
        }
        [StringSqlColumn("New_UVTint")]
        public string New_UVTint
        {
            get { return new_UVTint; }
            set { new_UVTint = value; }
        }
        [SqlColumn("Sta1_Frame", SqlDbType.NVarChar)]
        public string Sta1_Frame
        {
            get { return sta1_Frame; }
            set { sta1_Frame = value; }
        }
        [StringSqlColumn("Sta1_AmountFamre")]
        public string Sta1_AmountFamre
        {
            get { return sta1_AmountFamre; }
            set { sta1_AmountFamre = value; }
        }
        [SqlColumn("Sta1_Sunglass", SqlDbType.NVarChar)]
        public string Sta1_Sunglass
        {
            get { return sta1_Sunglass; }
            set { sta1_Sunglass = value; }
        }
        [StringSqlColumn("Sta1_AmountSunglass")]
        public string Sta1_AmountSunglass
        {
            get { return sta1_AmountSunglass; }
            set { sta1_AmountSunglass = value; }
        }
        [SqlColumn("Sta1_Lens", SqlDbType.NVarChar)]
        public string Sta1_Lens
        {
            get { return sta1_Lens; }
            set { sta1_Lens = value; }
        }
        [StringSqlColumn("Sta1_AmountLens")]
        public string Sta1_AmountLens
        {
            get { return sta1_AmountLens; }
            set { sta1_AmountLens = value; }
        }
        [SqlColumn("Sta1_Others", SqlDbType.NVarChar)]
        public string Sta1_Others
        {
            get { return sta1_Others; }
            set { sta1_Others = value; }
        }
        [StringSqlColumn("Sta1_AmountOthers")]
        public string Sta1_AmountOthers
        {
            get { return sta1_AmountOthers; }
            set { sta1_AmountOthers = value; }
        }
        [SqlColumn("Sta2_Frame", SqlDbType.NVarChar)]
        public string Sta2_Frame
        {
            get { return sta2_Frame; }
            set { sta2_Frame = value; }
        }
        [StringSqlColumn("Sta2_AmountFamre")]
        public string Sta2_AmountFamre
        {
            get { return sta2_AmountFamre; }
            set { sta2_AmountFamre = value; }
        }
        [SqlColumn("Sta2_Sunglass", SqlDbType.NVarChar)]
        public string Sta2_Sunglass
        {
            get { return sta2_Sunglass; }
            set { sta2_Sunglass = value; }
        }
        [StringSqlColumn("Sta2_AmountSunglass")]
        public string Sta2_AmountSunglass
        {
            get { return sta2_AmountSunglass; }
            set { sta2_AmountSunglass = value; }
        }
        [SqlColumn("Sta2_Lens", SqlDbType.NVarChar)]
        public string Sta2_Lens
        {
            get { return sta2_Lens; }
            set { sta2_Lens = value; }
        }
        [StringSqlColumn("Sta2_AmountLens")]
        public string Sta2_AmountLens
        {
            get { return sta2_AmountLens; }
            set { sta2_AmountLens = value; }
        }
        [SqlColumn("Sta2_Others", SqlDbType.NVarChar)]
        public string Sta2_Others
        {
            get { return sta2_Others; }
            set { sta2_Others = value; }
        }
        [StringSqlColumn("Sta2_AmountOthers")]
        public string Sta2_AmountOthers
        {
            get { return sta2_AmountOthers; }
            set { sta2_AmountOthers = value; }
        }
        [SqlColumn("Sta3_Frame", SqlDbType.NVarChar)]
        public string Sta3_Frame
        {
            get { return sta3_Frame; }
            set { sta3_Frame = value; }
        }
        [StringSqlColumn("Sta3_AmountFamre")]
        public string Sta3_AmountFamre
        {
            get { return sta3_AmountFamre; }
            set { sta3_AmountFamre = value; }
        }
        [SqlColumn("Sta3_Sunglass", SqlDbType.NVarChar)]
        public string Sta3_Sunglass
        {
            get { return sta3_Sunglass; }
            set { sta3_Sunglass = value; }
        }
        [StringSqlColumn("Sta3_AmountSunglass")]
        public string Sta3_AmountSunglass
        {
            get { return sta3_AmountSunglass; }
            set { sta3_AmountSunglass = value; }
        }
        [SqlColumn("Sta3_Lens", SqlDbType.NVarChar)]
        public string Sta3_Lens
        {
            get { return sta3_Lens; }
            set { sta3_Lens = value; }
        }
        [StringSqlColumn("Sta3_AmountLens")]
        public string Sta3_AmountLens
        {
            get { return sta3_AmountLens; }
            set { sta3_AmountLens = value; }
        }
        [SqlColumn("Sta3_Others", SqlDbType.NVarChar)]
        public string Sta3_Others
        {
            get { return sta3_Others; }
            set { sta3_Others = value; }
        }
        [StringSqlColumn("Sta3_AmountOthers")]
        public string Sta3_AmountOthers
        {
            get { return sta3_AmountOthers; }
            set { sta3_AmountOthers = value; }
        }
        [SqlColumn("New_Sta_Remarks", SqlDbType.NVarChar)]
        public string New_Sta_Remarks
        {
            get { return new_Sta_Remarks; }
            set { new_Sta_Remarks = value; }
        }
        [StringSqlColumn("New_Total")]
        public string New_Total
        {
            get { return new_Total; }
            set { new_Total = value; }
        }
        [StringSqlColumn("New_Deposit")]
        public string New_Deposit
        {
            get { return new_Deposit; }
            set { new_Deposit = value; }
        }
        [StringSqlColumn("New_Balance")]
        public string New_Balance
        {
            get { return new_Balance; }
            set { new_Balance = value; }
        }
        [StringSqlColumn("New_HMC")]
        public string New_HMC
        {
            get { return new_HMC; }
            set { new_HMC = value; }
        }
        [StringSqlColumn("New_HiIndex")]
        public string New_HiIndex
        {
            get { return new_HiIndex; }
            set { new_HiIndex = value; }
        }
        [StringSqlColumn("New_PhotoChromic")]
        public string New_PhotoChromic
        {
            get { return new_PhotoChromic; }
            set { new_PhotoChromic = value; }
        }
        [StringSqlColumn("New_TintedLens")]
        public string New_TintedLens
        {
            get { return new_TintedLens; }
            set { new_TintedLens = value; }
        }
        [SqlColumn("rowguid", SqlDbType.UniqueIdentifier)]
        public Guid Rowguid
        {
            get { return rowguid; }
            set { rowguid = value; }
        }

        #endregion Properties
        #region Constructors
        /// <summary>
        ///Default Constructor. Required by DAL Helper
        /// </summary>
        public MASTER_EX_EXAMEYE() { }

        #endregion Constructors
        #region DAC Methods
        /// <summary>
        ///Reads all items in database.
        /// </summary>
        public static List<MASTER_EX_EXAMEYE> ReadAll()
        {
            return posdb_vnmSqlDAC.ReadAll<MASTER_EX_EXAMEYE>("MASTER_EX_EXAMEYE");
        }
        /// <summary>
        ///Saves item to database.
        /// </summary>
        public void Save(bool isNew)
        {
            posdb_vnmSqlDAC.Save(this, "MASTER_EX_EXAMEYE",isNew);
        }
        /// <summary>
        ///Deletes item from database.
        /// </summary>
        public void Delete()
        {
            posdb_vnmSqlDAC.Delete(this, "MASTER_EX_EXAMEYE");
        }
        /// <summary>
        ///Read by Unique Constraint
        /// </summary>
        /// <param name="inExamEye_Code"></param>
        public static List<MASTER_EX_EXAMEYE> ReadByExamEye_Code(string inExamEye_Code)
        {
            return posdb_vnmSqlDAC.ReadByParams<MASTER_EX_EXAMEYE>("MASTER_EX_EXAMEYE", posdb_vnmSqlDAC.newInParam("@ExamEye_Code", inExamEye_Code));
        }
        /// <summary>
        ///Read by Unique Constraint
        /// </summary>
        /// <param name="inrowguid"></param>
        public static List<MASTER_EX_EXAMEYE> ReadByrowguid(Guid inrowguid)
        {
            return posdb_vnmSqlDAC.ReadByParams<MASTER_EX_EXAMEYE>("MASTER_EX_EXAMEYE", posdb_vnmSqlDAC.newInParam("@rowguid", inrowguid));
        }
        #endregion DAC Methods
    }
}
