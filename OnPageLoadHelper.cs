using Cascade0.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Cascade0.Helpers
{
    public class OnPageLoadHelper : IOnPageLoadHelper
    {
        private readonly DDSPRODDBContext _context;
        public OnPageLoadHelper(){
            _context = new DDSPRODDBContext();
        }
        public object GetBranches() {

            return (from b in _context.Branch
                    select new 
                    {
                        Branchid = b.Branchid,
                        BranchName = b.Name
                    }).ToList();
        }
        public object GetClientCategories() {

            return (from c in _context.ClientCategory
                    select new
                    {
                        CategoryID = c.Categid,
                        Name = c.Descrip
                    }).ToList();
        }
        public object GetInternalCompanies() {

            return (from ic in _context.CompMaster
                    select new
                    {
                        CompanyID = ic.Coid,
                        Name = ic.Coname
                    }).ToList();
        }
        public object GetEmployeeTitles() {

            return (from t in _context.Titles
                    select new
                    {
                        TitleId = t.Titleid,
                        Name = t.Description
                    }).ToList();
        }
        public object GetClientStatuses() {
            
            return (from cs in _context.ClientStatus
                     select new
                     {
                         StatusId = cs.ClientStatusId,
                         Name = cs.Description
                     }).ToList();
        }
        public object GetEmployeeStatuses()
        {

            return (from es in _context.EmployeeStatus
                    select new
                    {
                        StatusId = es.EmployeeStatusId,
                        Name = es.Description
                    }).ToList();
        }

        public object GetBillingMethod()
        {

            return (from bm in _context.BillingMethod
                    select new
                    {
                        StatusId = bm.BillingMethodId,
                        Name = bm.Description
                    }).ToList();
        }
        public object GetBillingCycle()
        {

            return (from bc in _context.ClientBillingCycle
                    select new
                    {
                        StatusId = bc.BillingCycleId,
                        Name = bc.Btype
                    }).ToList();
        }
    }
}
