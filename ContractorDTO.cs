using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Cascade0.Controllers.DataTransferObjects
{
    public class ContractorDTO
    {
       public string timing { get; set; }
        public static int? Originizationid { get;  set; }
        public int ContractorId { get; set; }
        public string Lastname { get; set; }
        public string Firstname { get; set; }
        public string Middlename { get; set; }
        public string FullName { get; set; }
        public string Title { get; set; }
        public int EmployeeId { get;  set; }
        public string IC { get;  set; }
        public string PBCH { get;  set; }
    }
}
