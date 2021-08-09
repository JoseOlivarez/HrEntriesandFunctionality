 using Cascade0.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Cascade0.Helpers
{
    public interface IOnPageLoadHelper
    {
        object GetBranches();
        object GetClientCategories();
        object GetInternalCompanies();
        object GetEmployeeTitles();
        object GetClientStatuses();
        object GetBillingMethod();
        object GetBillingCycle();

    }
}
