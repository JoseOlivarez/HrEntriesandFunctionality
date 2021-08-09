using System;
using System.Collections.Generic;
using System.Security;
using System.Text.Json;
using Newtonsoft.Json;

namespace Cascade0.Controllers.DataTransferObjects
{
    [JsonObject(MemberSerialization.OptIn)]
    public class BranchTemplateDTO
    {
        public BranchDTO Branch;

        public List<SettlementApproverDTO> Sa { get; set; }

        public List<AccountManagerDTO> Am { get; set; }

        public List<TerritoryDTO> Territory { get; set; }
    }
}
