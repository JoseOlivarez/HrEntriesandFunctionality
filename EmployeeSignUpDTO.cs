using System;
using System.Collections.Generic;
using System.Data.Entity.Core.Metadata.Edm;
using System.Linq;
using System.Threading.Tasks;
using Newtonsoft.Json;
namespace Cascade0.Controllers.DataTransferObjects
{
    [JsonObject(MemberSerialization.OptIn)]

    public class EmployeeSignUpDTO
    {
    
        [JsonProperty("Employeeid")]
        public int Employeeid { get; set; }
        [JsonProperty("LASTNAME")]
        public string LASTNAME { get; set; }
        [JsonProperty("FIRSTNAME")]
        public string FIRSTNAME { get; set; }
        [JsonProperty("Contact")]
        public string Contact { get; set; }
        [JsonProperty("MIDDLENAME")]
        public string MIDDLENAME { get; set; }
        [JsonProperty("Hiredate")]
        public DateTime? Hiredate { get; set; }
        [JsonProperty("Rehiredate")]
        public DateTime? Rehiredate { get; set; }
        [JsonProperty("Anniversary")]
        public DateTime? Anniversary { get; set; }
        [JsonProperty("Fullname")]
        public string Fullname { get; set; }
        [JsonProperty("Titleid")]
        public int? Titleid { get; set; }
        [JsonProperty("Homecl")]
        public int Homecl { get; set; }
        [JsonProperty("State")]
        public string State { get; set; }
        [JsonProperty("Address1")]
        public string Address1 { get; set; }
        [JsonProperty("Address2")]
        public string Address2 { get; set; }
        [JsonProperty("EmergencyPhone")]
        public string EmergencyPhone { get; set; }

        [JsonProperty("Vacationdays")]
        public decimal Vacationdays { get; set; }
        [JsonProperty("Status")]
        public int? Status { get; set; }
        [JsonProperty("Entered")]
        public DateTime? Entered { get; set; }
        [JsonProperty("Enterby")]
        public int? Enteredby { get; set; }
        [JsonProperty("EnterbyId")]
        public int? EnterbyId { get; set; }
        [JsonProperty("Modified")]
        public DateTime? Modified { get; set; }
        [JsonProperty("Modby")]
        public int? Modby { get; set; }
        [JsonProperty("Ssn")]
        public string Ssn { get; set; }
        [JsonProperty("Mirem")]
        public string Mirem { get; set; }
        [JsonProperty("Wcode")]
        public int? Wcode { get; set; }
        [JsonProperty("Export")]
        public string Export { get; set; }
        [JsonProperty("Pcommt")]
        public string Pcommt { get; set; }
        [JsonProperty("Startdate")]
        public DateTime Startdate { get; set; }
        [JsonProperty("Enddate")]
        public DateTime Enddate { get; set; }
        [JsonProperty("Email")]
        public string Email { get; set; }
        [JsonProperty("Cphone")]
        public string Cphone { get; set; }
        [JsonProperty("Dob")]
        public DateTime Dob { get; set; }
        [JsonProperty("City")]
        public string City { get; set; }
        [JsonProperty("Dlnumber")]
        public string Dlnumber { get; set; }
        [JsonProperty("Dlexpire")]
        public DateTime Dlexpire { get; set; }
        [JsonProperty("Vdesc")]
        public string Vdesc { get; set; }
        [JsonProperty("Vin")]
        public string Vin { get; set; }
        [JsonProperty("Inspocc")]
        public int Inspocc { get; set; }
        [JsonProperty("Inspdam")]
        public int Inspdam { get; set; }
        [JsonProperty("Vlicense")]
        public string Vlicense { get; set; }
        [JsonProperty("Vtype")]
        public string Vtype { get; set; }
        [JsonProperty("Dlstate")]
        public string Dlstate { get; set; }
        [JsonProperty("Insepers")]
        public int Insepers { get; set; }
        [JsonProperty("Insexp")]
        public DateTime Insexp { get; set; }
        [JsonProperty("Comment")]
        public string Comment { get; set; }
        [JsonProperty("Capcode")]
        public string Capcode { get; set; }
        [JsonProperty("Phone")]
        public string Phone { get; set; }
        [JsonProperty("Pers")]
        public string Pers { get; set; }
        [JsonProperty("Comment")]
        public string CommentForPager { get; set; }
        [JsonProperty("DESCRIPTION")]
        public string Description { get; set; }
        [JsonProperty("ZipCode")]
        public string ZipCode { get; set; }

        [JsonProperty("Like")]
        public string Like { get; set; }
        [JsonProperty("StartsWith")]
        public string StartsWith { get; set; }
        [JsonProperty("dtPicker1")]
        public DateTime dtPicker1 { get; set; }
        [JsonProperty("dtPicker2")]
        public DateTime dtPicker2 { get; set; }
        [JsonProperty("IsBetween")]
        public string IsBetween { get; set; }
        [JsonProperty("GreaterThan")]
        public string GreaterThan { get; set; }
        [JsonProperty("GreaterThanOrEqual")]
        public string GreaterThanOrEqual { get; set; }
        [JsonProperty("LessThan")]
        public string LessThan { get; set; }
        [JsonProperty("LessThanOrEqual")]
        public string LessThanOrEqual { get; set; }
        [JsonProperty("AddressBookId")]
        public int AddressBookId { get; set; }
        [JsonProperty("Contains")]
        public string Contains { get; set; }
        [JsonProperty("Equals")]
        public string Equals { get; set; }
        public int BranchId { get; set; }
        public string Phone2 { get; set; }
        public string Reference { get; set; }
        //Driver license and insurance information
        public string Dlclass { get; set; }
        public string Inscar { get; set; }
        public string Insagn { get; set; }
        public string Inspno { get; set; }
        public string Insphn { get; set; }
        //employee termination information
        public string RadioCell { get; set; }
        public  int? Reason { get; set;  }
        public string EmployeeWorkedAs { get; set; }

        public string WasEmployeeRehirable { get; set; }

        public string PrivateNote { get; set; }

        public DateTime SeperationDate { get; set; }
        public DateTime TerminationDate { get; set; }
        public string Rehirable { get; set; }

        public string TerminationComment { get; set; }


        //Employees history         
        public string TransactionType { get; set; }

        public string Notes { get; set; }
        public string GeneralReason { get;  set; }
        public string Type { get;  set; }
        public string Ins { get;  set; }
        public int Tranid { get;  set; }
        public string CompanyName { get;  set; }
        public string columnName { get; set; }
        public string parameterValue { get; set; }
        public int? parameterValueInt { get; set; }
        public DateTime? parameterValueDateTime { get; set; }
        public string parameterValue2 { get;  set; }
        public int? parameterValueInt2 { get; set; }
        public DateTime? parameterValueDateTime2 { get; set; }
        public string parameterValue3 { get; set; }
        public int? parameterValueInt3 { get; set; }
        public DateTime? parameterValueDateTime3 { get; set; }
        public string parameterValue4 { get; set; }
        public int? parameterValueInt4 { get; set; }
        public DateTime? parameterValueDateTime4 { get; set; }
        public string propName4 { get; set; }
        public bool Or { get; set; }
        public bool Or2 { get; set; }

        public dynamic parameterValueUndeclared { get;  set; }
        public bool Or3 { get;  set; }
        public string paramaterverValue1 { get;  set; }
        public string paramaterValue1 { get;  set; }
        public string paramaterValue2 { get;  set; }
        public string paramaterValue3 { get; set; }
        public string paramaterValue4 { get; set; }
        public int? VehicleGrossWeight { get;  set; }
        public string VehicleDescription { get;  set; }
        public int DriverId { get;  set; }
        public string Inprf { get;  set; }
        public bool IsDriver { get; set; }
        public int? VtypeId { get; internal set; }
    }

}   


