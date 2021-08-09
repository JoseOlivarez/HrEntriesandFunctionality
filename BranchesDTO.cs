using System;
using System.Security;
using System.Text.Json;
using Newtonsoft.Json;

namespace Cascade0.Controllers.DataTransferObjects
{
    [JsonObject(MemberSerialization.OptIn)]
    public class BranchDTO
    {
       

        [JsonProperty("Branchid")]
        public int Branchid { get; set; }
        [JsonProperty("Name")]
        public string Name { get; set; }
        [JsonProperty("State")]
        public string State { get; set; }
        [JsonProperty("Autogen")]
        public string Autogen { get; set; }
        [JsonProperty("Codtrn")]
        public string Codtrn { get; set; }
        [JsonProperty("Codml")]
        public string Codml { get; set; }
        [JsonProperty("Gldivision")]
        public string Gldivision { get; set; }
        [JsonProperty("Region")]
        public int Region { get; set; }
        [JsonProperty("Enterby")]
        public string Enterby { get; set; }
        [JsonProperty("Glregion")]
        public string Glregion { get; set; }
        [JsonProperty("SettlementApproverName")]
        public string SettlementApproverName { get; set; }
        [JsonProperty("SettlementApproverEmployeeId")]
        public int SettlementApproverEmployeeId { get; set; }
        [JsonProperty("AccountManagerName")]
        public string AccountManagerName { get; set; }
        [JsonProperty("AccountManagerEmployeeId")]
        public int AccountManagerEmployeeId { get; set; }
        public DateTime? PayPeriodInitalDate { get;  set; }
        public DateTime? SettlementDate { get;  set; }
        public bool? ServiceDedicatedNetwork { get;  set; }
        public bool? ServiceHealthCare { get;  set; }
        public bool? ServiceHotShot { get;  set; }
        public int TerritoryId { get;  set; }   
        public string TerritoryDescription { get;  set; }
        public string TerritoryName { get;  set; }
        public int SettlementApproverId { get;  set; }
        public int AccountManagerId { get;  set; }
        public string columnName { get;  set; }
        public int? parameterValueInt4 { get;  set; }
        public DateTime? parameterValueDateTime4 { get;  set; }
        public string parameterValue4 { get;  set; }
        public bool parameterValueUndeclared { get;  set; }

        public int? parameterValueInt3 { get;  set; }
        public DateTime? parameterValueDateTime3 { get;  set; }
        public string parameterValue3 { get;  set; }
        public int? parameterValueInt2 { get;  set; }
        public DateTime? parameterValueDateTime2 { get;  set; }
        public string parameterValue2 { get;  set; }

        public int? parameterValueInt { get;  set; }
        public DateTime? parameterValueDateTime { get;  set; }
        public string parameterValue { get;  set; }
        public bool Or { get; set; }
        public bool Or2 { get; set; }
        public bool Or3 { get; set;  }
         public int Company { get; set; }
        public int Status { get; set; }
        public int Rgman { get; set; }
        public int Branct { get; set; }
        public DateTime? EnteredDate { get; set; }
        public int Enteredby { get; set;  }
        public DateTime? ModifiedDate { get; set;  }
        public  int Modifiedby { get; set; }
        public int Afee { get; set; }





        /*
        public string placevalues(string json) {
        var user = JsonSerializer.Deserialize<Branch>(json);
        branchid = user.Branchid;
        name = user.Name;
        state = user.State;
        autogen = user.Autogen;
        enteredby = user.Enterby;
        entered = (DateTime)user.Entered;
        codtrn = user.Codtrn;
        codml = user.Codml;
        return name;
    
        */
    }
}
