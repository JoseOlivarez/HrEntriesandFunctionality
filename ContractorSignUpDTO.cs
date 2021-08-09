






using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Cascade0.Controllers.DataTransferObjects
{
    [JsonObject(MemberSerialization.OptIn)]
    public class ContractorSignUpDTO
    {
        public  string columnName { get; set; }

        [JsonProperty("ContractorId")]
        public int ContractorId { get; set; }
        [JsonProperty("CompanyId")]

        public int CompanyId { get; set; }
        [JsonProperty("LASTNAME")]
        public string LASTNAME { get; set; }
        [JsonProperty("FIRSTNAME")]
        public string FIRSTNAME { get; set; }
        [JsonProperty("Middlename")]
        public string Middlename { get; set; }

        [JsonProperty("Hiredate")]
        public DateTime? Hiredate { get; set; }
        [JsonProperty("Rehired")]
        public DateTime? Rehired { get; set; }
        [JsonProperty("Anniversary")]
        public DateTime? Anniversary { get; set; }
        [JsonProperty("Title")]
        public int? Title { get; set; }
        [JsonProperty("Nica")]
        public string Nica { get; set; }
        [JsonProperty("Rds")]
        public string Rds { get; set; }
        [JsonProperty("Card")]
        public string Card { get; set; }
        [JsonProperty("Status")]
        public int? Status { get; set; }
        [JsonProperty("ZipCode")]
        public string ZipCode { get; set; }
        [JsonProperty("Entereddate")]
        public DateTime? Entereddate { get; set; }
        [JsonProperty("Enteredby")]
        public int? Enteredby { get; set; }
        [JsonProperty("Modifieddate")]
        public DateTime? Modifieddate { get; set; }
        [JsonProperty("Modifiedby")]
        public int? Modifiedby { get; set; }
        [JsonProperty("Ssn")]
        public string Ssn { get; set; }
        [JsonProperty("Wcode")]
        public int? Wcode { get; set; }
        [JsonProperty("Export")]
        public string Export { get; set; }
        [JsonProperty("Misc")]
        public string Misc { get; set; }
        [JsonProperty("Dt")]
        public string Dt { get; set; }
        [JsonProperty("Pcommt")]
        public string Pcommt { get; set; }
        [JsonProperty("Sctype")]
        public string Sctype { get; set; }
        [JsonProperty("Activity")]
        public DateTime? Activity { get; set; }
        [JsonProperty("Scfor")]
        public int? Scfor { get; set; }
        [JsonProperty("Email")]
        public string Email { get; set; }
        [JsonProperty("AdminFee")]
        public decimal? AdminFee { get; set; }
        [JsonProperty("CheckName")]
        public string CheckName { get; set; }
        [JsonProperty("PayTimingId")]
        public int PayTimingId { get; set; }
        [JsonProperty("Like")]
        public string Like { get; set; }
        [JsonProperty("Description")]
        public string Description { get; set; }
        [JsonProperty("StartsWith")]
        public string StartsWith { get; set; }
        [JsonProperty("Contains")]
        public string Contains { get; set; }
        [JsonProperty("Equals")]
        public string Equals { get; set; }
        public int? Originizationid { get;  set; }

        [JsonProperty("IsBetween")]
        public string IsBetween { get; set; }
        [JsonProperty("dtPicker1")]
        public DateTime dtPicker1 { get; set; }
        [JsonProperty("dtPicker2")]
        public DateTime dtPicker2 { get; set; }
        [JsonProperty("GreaterThan")]
        public DateTime GreaterThan { get; set; }
        [JsonProperty("GreaterThanOrEqual")]
        public DateTime GreaterThanOrEqual { get; set; }
        [JsonProperty("LessThan")]
        public DateTime LessThan { get; set; }
        [JsonProperty("LessThanOrEqual")]
        public DateTime LessThanOrEqual { get; set; }
        public string Address1 { get; set; }
        public string Address2 { get; set; }

        [JsonProperty("Phone1")]
        public string Phone1 { get; set; }
        [JsonProperty("Phone2")]
        public string Phone2 { get; set; }
        [JsonProperty("EmeregencyPhone")]
        public string EmeregencyPhone { get; set; }
        [JsonProperty("City")]
        public string City { get; set; }
        [JsonProperty("State")]
        public string State { get; set; }
        [JsonProperty("Zip")]
        public string Zip { get; set; }
        public string PrefferedPhone { get; set; }
        public string Reference1 { get; set; }
        [JsonProperty("OperationStates")]
        public string OperationStates { get; set; }
        [JsonProperty("SoleProprietor")]
        public string SoleProprietor { get; set; }
        [JsonProperty("LLC")]
        public string Llc { get; set; }
        [JsonProperty("Corporation")]
        public string Corporation { get; set; }
        [JsonProperty("Partnership")]
        public string Partnership { get; set; }
        [JsonProperty("DOB")]
        public DateTime DOB { get; set; }
        [JsonProperty("DriverLicense")]
        public string  DriverLicense { get; set; }
        [JsonProperty("DriverLicenseState")]
        public string DriverLicenseState { get; set; }
        [JsonProperty("DriverLicenseExpiration")]
        public DateTime DriverLicenseExpiration { get; set; }
        [JsonProperty("Class")]
        public string Class { get; set; }
        [JsonProperty("VehicleGrossWeight")]
        public int? VehicleGrossWeight { get; set; }
        [JsonProperty("Vin")]
        public string Vin { get; set; }
        [JsonProperty("LicensePlate")] 
        public string LicensePlate { get; set; }
        [JsonProperty("VehicleMake")] 
        public string VehicleMake { get; set; }
        [JsonProperty("VehicleModel")]
        public string VehicleModel { get; set; }
        [JsonProperty("VehicleType")]

        public int Vtypeid { get; set; }
        public string VehicleType { get; set; }
        [JsonProperty("Carrier")]
        public string Carrier { get; set; }
        [JsonProperty("PolicyNo")]
        public string PolicyNo { get; set; }
        [JsonProperty("CarrierPhone")]
        public string CarrierPhone { get; set; }
        [JsonProperty("InsuranceProof")]
        public string InsuranceProof { get; set; }
        [JsonProperty("AgentName")]
        public string AgentName { get; set; }
        [JsonProperty("AgentPhone")]
        public string AgentPhone { get; set; }
        [JsonProperty("AgentPhoneNO")]
        public string AgentPhoneNO { get; set; }    
        [JsonProperty("IExpirationDate")]
        public DateTime IExpirationDate { get; set; }
        [JsonProperty("InsuranceLimit")]
        public string InsuranceLimit { get; set; }
        [JsonProperty("FEID")]
        public string FEID { get; set; }
        public string IsMasterContractor { get; set; }
        public int OrganizationId { get; set; }
        public decimal? Rate { get; set; }
        public DateTime Effective { get; set; }
        public string CompanyName { get;  set; }
        public DateTime Dlexpire { get;  set; }
        public string Dlnumber { get;  set; }
        public string Dlclass { get;  set; }
        public string Dlstate { get;  set; }
        public string Inscar { get;  set; }
        public string Insagn { get;  set; }
        public int Insepers { get;  set; }
        public string Inspno { get;  set; }
        public DateTime Insexp { get;  set; }
        public string Insphn { get;  set; }
        public bool TubercolosisTest { get;  set; }
        public bool DrugTest { get;  set; }
        public DateTime? DrugTestDate { get;  set; }
        public DateTime? TubercolosisTestDate { get;  set; }
        public Boolean BackgroundCheckRequested { get; set; }
        public DateTime? ContractEndingDate { get; set;  }
        public DateTime? InsDeductionDate { get; set; }
        public DateTime? InDeductionToDate { get; set; }
        public float InsDeductionAmmount { get; set; }
        public List<String> ProofOfCompany { get; set; }
        public List<String> ContractorsDocumentsRequested { get; set; }
        public string DrugTestReason { get;  set; }
        public List<string> DocumentsRequested { get;  set; }
        public List<string> RequestDocument { get;  set; }
        public object HealthCareDocuments { get;  set; }
        public string MvrReason { get;  set; }
        public string BackgroundCheck { get;  set; }
        public string DeductionType { get;  set; }
        public decimal? ContractorAdjustmenetRate { get;  set; }
        public DateTime ContractorEffectiveAdjustmentDate { get; set; }
        public int ContractorRateTypeId { get; set; }
        public DateTime? ContractLastDay { get; set; }
        public string Rehire { get; set; }
        public string Otnote { get;  set; }
        public string Regnote { get;  set; }
        public int Empratetypeid { get;  set; }
        public DateTime? SeperationDate { get;  set; }
        public string GeneralReason { get;  set; }
        public string Pcret { get;  set; }
        public string parameterValue { get;  set; }
        public int? parameterValueInt { get;  set; }
        public DateTime? parameterValueDateTime { get;  set; }
        public string parameterValue2 { get;  set; }
        public int? parameterValueInt2 { get;  set; }
        public DateTime? parameterValueDateTime2 { get;  set; }
        public string parameterValue3 { get;  set; }
        public int? parameterValueInt3 { get;  set; }
        public DateTime? parameterValueDateTime3 { get;  set; }
        public string parameterValue4 { get; set; }
        public int? parameterValueInt4 { get; set; }
        public DateTime? parameterValueDateTime4 { get; set; }
        public bool Or { get; set; }
        public bool Or2 { get; set; }
        public object parameterValueUndeclared { get; set; }
        public bool Or3 { get;  set; }
        public string paramaterValue1 { get;  set; }
        public string paramaterValue2 { get;  set; }
        public string paramaterValue3 { get; set; }

        public string  paramaterValue4 { get;  set; }
        public bool IsDriver { get;  set; }
        public int  DriverId { get;  set; }
    }
}

