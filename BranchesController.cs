using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Cascade0.Models;
using Cascade0.Controllers.DataTransferObjects;
using System.Text.Json;
using AutoMapper;
using Cascade0.Controllers.MappingProfile;
using Cascade0.Core;
using Newtonsoft.Json;
using Microsoft.EntityFrameworkCore.Diagnostics;
using System.Data.Common;
using Cascade0.Helpers;
using Cascade0.Managers;
namespace Cascade0.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class BranchesController : ControllerBase
    {
        private readonly DDSPRODDBContext _context;
        private IMapper _mapper;
        private readonly IUnitOfWork wow;
        private readonly IUserHelper _userHelper;
        private UserInfo userInfo;
        public BranchesController(IMapper mapper)
        {
            _mapper = mapper;
            _context = new DDSPRODDBContext();
        }
        public IEnumerable<BranchDTO> Branch()
        {
            var model = _context.Branch.ToList();
            //  var config = new MapperConfiguration(m => m.CreateMap<Branch, BranchDTO>());
            //    var mapper = new Mapper(config);
            return _mapper.Map<List<Branch>, List<BranchDTO>>(model);
        }
        // GET: api/Branches
        [HttpGet]
        public async Task<ActionResult<IEnumerable<Branch>>> GetBranch()
        {
            return await _context.Branch.ToListAsync();
        }

        // GET: api/Branches/5
        [HttpGet("{id}")]
        public async Task<ActionResult<Branch>> GetBranch(int id)
        {
            var branch = await _context.Branch.FindAsync(id);

            if (branch == null)
            {
                return NotFound();
            }

            return branch;
        }
        [HttpGet]
        [Route("GetBranchInfo")]
        public async Task<ActionResult<object>> GetBranchInformation(int BranchId)
        {
            var Territories = (
               from TerritoryBranch in _context.BranchTerritory
               join branchs in _context.Branch on TerritoryBranch.BranchId equals branchs.Branchid
               join ters in _context.Territory on TerritoryBranch.TerritoryId equals ters.TerritoryId
               select TerritoryBranch
               ).ToList();

            var SettlementApproverName = (
                 from settlementapprover in _context.SettlementApprover
                 from settlementapproverterritory in _context.SettlementApproverTerritory
                 join ters in _context.Territory on settlementapproverterritory.TerritoryId equals ters.TerritoryId
                 join branchs in _context.Branch on BranchId equals branchs.Branchid
                 select settlementapproverterritory
                 ).ToList();

            var AccountManagers = (
                from managers in _context.AccountManager
                join branchs in _context.Branch on BranchId equals branchs.Branchid
                select managers
                ).ToList();

            var reserve = new { Territories, SettlementApproverName, AccountManagers };




            return Ok(reserve);
        }

        [HttpGet]
        [Route("BranchOverview")]
        public async Task<IActionResult> GetBranchInformation()
        {
            return BadRequest();
        }
        [HttpGet]
        [Route("GetSettlementApprovers")]
        public async Task<IActionResult> GetSettlmementApprover(int Branchid)
        {
            var GetSettlementApprovers = (
                from sa in _context.SettlementApprover
                join sat in _context.SettlementApproverTerritory on sa.SettlementApproverId equals sat.SettlementApproverId
                select new
                {
                    sa,
                    sat.TerritoryId,

                }).ToList();
            if (GetSettlementApprovers != null)
                return Ok(GetSettlementApprovers);
            else
                return BadRequest();
        }
        [HttpPut]
        [Route("UpdateBranch")]
        public async Task<IActionResult> UpdateBranch(int Branchid, BranchDTO brnch)
        {
            UserInfo userInfo;
            try
            {
                userInfo = _userHelper.GetUser(User);
            }
            catch (Exception ex)
            {
                return Conflict("issue getting user login");

            }

            var BranchFind = _context.Branch.Find(Branchid);
            BranchFind.Branchid = brnch.Branchid;
            BranchFind.Name = brnch.Name;
            BranchFind.State = brnch.State;
            //BranchFind.City = brnch.City;
            //BranchFind.Branchcode = brnch.Branchcode;
            //BranchFind.Address = brnch.Address;
            BranchFind.SettlementDate = brnch.SettlementDate;
            BranchFind.PayPeriodInitialDate = brnch.PayPeriodInitalDate;


            _context.Branch.Add(BranchFind);
            try
            {
                await _context.SaveChangesAsync();
            }
            catch (Exception ex)
            {
                Conflict("Issue editing this branch");
            }


            return BadRequest();
        }
        [HttpGet]
        [Route("GetAccountManagers")]
        public async Task<IActionResult> GetAccountManagers(int Branchid)
        {

            var GetAccountManagers = (
                from am in _context.AccountManager
                join amt in _context.AccountManagerTerritory on am.AccountManagerId equals amt.AccountManagerId
                select am
                ).ToList();
            return Ok(GetAccountManagers);
            return BadRequest();
        }
        [HttpGet]
        [Route("GetTerritories")]
        public async Task<IActionResult> GetTerritories()
        {
            var GetTerritories =
                    (
                    from branch in _context.Branch
                    join territory in _context.Territory on branch.TerritoryId equals territory.TerritoryId
                    select territory).ToList();
            return Ok(GetTerritories);
        }




        // PUT: api/Branches/5
        // To protect from overposting attacks, enable the specific properties you want to bind to, for
        // more details, see <https://go.microsoft.com/fwlink/?linkid=2123754>.
        [HttpPut("{id}")]
        public async Task<IActionResult> PutBranch(int id, Branch branch)
        {
            if (id != branch.Branchid)
            {
                return BadRequest();
            }

            _context.Entry(branch).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!BranchExists(id))
                {
                    return NotFound();
                }
                else
                {
                    throw;
                }
            }

            return NoContent();
        }

        // POST: api/Branches
        // To protect from overposting attacks, enable the specific properties you want to bind to, for
        // more details, see <https://go.microsoft.com/fwlink/?linkid=2123754.private> readonly IMapper _mapper;

        public IActionResult GetUser()
        {
            Branch branch = new Branch();
            var userDTO = _mapper.Map<BranchDTO>(branch);
            return Ok();
        }
        [HttpPost]
        [Route("PostTerritory")]
        public async Task<ActionResult<BranchDTO>> PostTerritory([FromBody] BranchDTO ter)
        {
            Territory territory = new Territory();
            territory.TerritoryId = ter.TerritoryId;
            territory.TerritoryName = ter.TerritoryName;
            territory.TerritoryDescription = ter.TerritoryDescription;
            territory.Enteredby = userInfo.UserId;
            territory.EnteredDate = DateTime.Now;
            territory.Modifiedby = userInfo.UserId;
            territory.ModifiedDate = DateTime.Now;
            _context.Territory.Add(territory);



            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbException)
            {

                return Conflict();

            }

            BranchTerritory branchterritory = new BranchTerritory();
            branchterritory.BranchTerritoryId = ter.TerritoryId;
            branchterritory.BranchId = ter.Branchid;
            branchterritory.TerritoryId = ter.TerritoryId;
            branchterritory.Enteredby = userInfo.UserId;
            branchterritory.EnteredDate = DateTime.Now;
            branchterritory.Modifiedby = userInfo.UserId;
            branchterritory.ModifiedDate = DateTime.Now;
            _context.BranchTerritory.Add(branchterritory);


            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbException)
            {

                return Conflict();

            }


            Branch branch = (
                            from branches in _context.Branch
                            where branches.Branchid == ter.Branchid
                            select branches).SingleOrDefault();
            branch.TerritoryId = territory.TerritoryId;
            _context.SaveChanges();
            return ter;
        }

        [Route("PostSettlementApprover")]
        public async Task<ActionResult<BranchTemplateDTO>> PostSettlementApprover([FromBody] BranchTemplateDTO ter)
        {
            SettlementApprover SA = new SettlementApprover();
            SettlementApproverTerritory sat = new SettlementApproverTerritory();


            for (int i = 0; i < ter.Sa.Count(); i++)
            {
                SA.EmployeeId = ter.Sa.ElementAt(i).SettlementApproverEmployeeId;

                _context.SettlementApprover.Add(SA);

            }

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbException ex)
            {

                return Conflict();

            }




            for (int i = 0; i < ter.Sa.Count(); i++)
            {
                sat.SettlementApproverId = ter.Sa.ElementAt(i).SettlementApproverId;
                sat.TerritoryId = ter.Sa.ElementAt(i).TerritoryId;

                _context.SettlementApprover.Add(SA);

            }

            _context.SettlementApproverTerritory.Add(sat);
            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbException exb)
            {

                return Conflict();

            }


            return ter;
        }

        [Route("PostAccountManager")]
        public async Task<ActionResult<BranchDTO>> PostAccountManager([FromBody] BranchDTO ter)
        {
            AccountManager am = new AccountManager();
            am.AccountManagerId = ter.AccountManagerId;
            am.EmployeeId = Convert.ToInt32(ter.AccountManagerEmployeeId);
            AccountManagerTerritory amt = new AccountManagerTerritory();
            amt.AccountManagerId = ter.AccountManagerId;
            amt.AccountManagerTerritoryId = ter.TerritoryId;


            _context.AccountManager.Add(am);
            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbException)
            {

                return Conflict();

            }
            _context.AccountManagerTerritory.Add(amt);
            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbException)
            {

                return Conflict();

            }
            return ter;
        }


        [Route("PostBranch")]
        [HttpPost]
        public async Task<ActionResult<Branch>> PostBranch([FromBody] BranchTemplateDTO branches)
        {
            BranchDTO branch = branches.Branch;
            Branch mainBranch = new Branch();
            var settings = new JsonSerializerSettings
            {
                NullValueHandling = NullValueHandling.Ignore,
                MissingMemberHandling = MissingMemberHandling.Ignore
            };
            var userDTO = _mapper.Map<BranchDTO>(mainBranch);
            //Branch();
            //GetUser();
            mainBranch.Branchid = branches.Branch.Branchid;

            //branch setup information
            mainBranch.Name = branches.Branch.Name;
            mainBranch.State = branches.Branch.State;
            mainBranch.Autogen = branches.Branch.Autogen;
            mainBranch.Codtrn = branches.Branch.Codtrn;
            mainBranch.Codml = branches.Branch.Codml;
            mainBranch.Gldivision = branches.Branch.Gldivision;
            mainBranch.Region = branches.Branch.Region;
            mainBranch.Company = branches.Branch.Company;
            //Noe: Please change name and type to int for Enterby
            //mainBranch.Enteredby = branch.Enterby;
            mainBranch.Glregion = branches.Branch.Glregion;
            mainBranch.PayPeriodInitialDate = branches.Branch.PayPeriodInitalDate;
            mainBranch.SettlementDate = branches.Branch.SettlementDate;
            mainBranch.ServiceDedicatedNetwork = branches.Branch.ServiceDedicatedNetwork;
            mainBranch.ServiceHealthcare = branches.Branch.ServiceHealthCare;
            mainBranch.ServiceHotShot = branches.Branch.ServiceHotShot;
            mainBranch.Status = branches.Branch.Status;
            mainBranch.Rgman = branches.Branch.Rgman;
            mainBranch.Bracnt = branches.Branch.Branct;
            mainBranch.EnteredDate = DateTime.Now;

            UserInfo userInfo = new UserInfo();
            mainBranch.Enteredby = 1;
            mainBranch.Modifiedby = 1;

            mainBranch.Afee = branches.Branch.Afee;




            _context.Branch.Add(mainBranch);
            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateException ex)
            {
                if (BranchExists(branch.Branchid))
                {
                    return Conflict();
                }
                else
                {
                    throw;
                }
            }

            Territory territory = new Territory();
            SettlementApprover sa = new SettlementApprover();
            AccountManager am = new AccountManager();

            for (int i = 0; i < branches.Territory.Count(); i++)
            {
                if (branches.Territory.ElementAt(i).TerritoryId != 0)
                {
                    territory.TerritoryId = branches.Territory.ElementAt(i).TerritoryId;
                    territory.TerritoryName = branches.Territory.ElementAt(i).TerritoryName;
                    territory.TerritoryDescription = branches.Territory.ElementAt(i).TerritoryDescription;
                    territory.Enteredby = userInfo.UserId;
                    territory.Modifiedby = 1;
                    territory.ModifiedDate = DateTime.Now;
                    territory.EnteredDate = DateTime.Now;


                    _context.Territory.Add(territory);
                    try
                    {
                        await _context.SaveChangesAsync();
                    }
                    catch (DbUpdateException)
                    {
                        if (BranchExists(branch.Branchid))
                        {
                            return Conflict();
                        }
                        else
                        {
                            throw;
                        }
                    }

                }

            }
            for (int i = 0; i < branches.Sa.Count(); i++)
            {
                if (sa != null)
                {
                    sa.SettlementApproverId = branches.Sa.ElementAt(i).SettlementApproverId;
                    sa.EmployeeId = branches.Sa.ElementAt(i).SettlementApproverEmployeeId;

                    sa.Enteredby = userInfo.UserId;
                    sa.Modifiedby = 1;
                    sa.ModifiedDate = DateTime.Now;
                    sa.EnteredDate = DateTime.Now;
                    _context.SettlementApprover.Add(sa);
                    try
                    {
                        await _context.SaveChangesAsync();
                    }
                    catch (DbUpdateException)
                    {
                        if (BranchExists(branch.Branchid))
                        {
                            return Conflict();
                        }
                        else
                        {
                            throw;
                        }
                    }

                }
            }
            for (int i = 0; i < branches.Am.Count(); i++)
            {
                if (am != null)
                {
                    am.AccountManagerId = branches.Am.ElementAt(i).AccountManagerId;
                    am.EmployeeId = branches.Am.ElementAt(i).AccountManagerEmployeeId;

                    am.Enteredby = userInfo.UserId;
                    am.Modifiedby = 1;
                    am.ModifiedDate = DateTime.Now;
                    am.EnteredDate = DateTime.Now;
                    _context.AccountManager.Add(am);

                    try
                    {
                        await _context.SaveChangesAsync();
                    }
                    catch (DbUpdateException)
                    {
                        if (BranchExists(branch.Branchid))
                        {
                            return Conflict();
                        }
                        else
                        {
                            throw;
                        }
                    }
                }
            }

            return CreatedAtAction("GetBranch", new { id = branch.Branchid }, branch);
        }

        // DELETE: api/Branches/5
        [HttpDelete("{id}")]
        public async Task<ActionResult<Branch>> DeleteBranch(int id)
        {
            var branch = await _context.Branch.FindAsync(id);
            if (branch == null)
            {
                return NotFound();
            }

            _context.Branch.Remove(branch);
            await _context.SaveChangesAsync();

            return branch;
        }

        private bool BranchExists(int id)
        {
            return _context.Branch.Any(e => e.Branchid == id);
        }
    }
}