﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Cascade0.Models;
using Cascade0.Controllers.DataTransferObjects;
using Cascade0.Helpers;
using Cascade0.Managers;
using System.Runtime.CompilerServices;

namespace Cascade0.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ContractorsController : ControllerBase
    {
        private readonly DDSPRODDBContext _context;
        private readonly Random random = new Random();
        private readonly IUserHelper _userHelp;
        private readonly IOnPageLoadHelper _onPageLoadHelper;

        public EmpInventory UpdateHealthCareDocuments { get; private set; }

        public ContractorsController(IUserHelper userHelp, IOnPageLoadHelper onPageLoadHelper)
        {
            _userHelp = userHelp;
            _onPageLoadHelper = onPageLoadHelper;
            _context = new DDSPRODDBContext();
        }

        // GET: api/Contractors
        [HttpGet]
        public async Task<ActionResult<IEnumerable<Contractor>>> GetContractor()
        {
            return await _context.Contractor.ToListAsync();
        }

        // GET: api/Contractors/5
        [HttpGet("{id}")]
        public async Task<ActionResult<Contractor>> GetContractor(int id)
        {
            var contractor = await _context.Contractor.FindAsync(id);

            if (contractor == null)
            {
                return NotFound();
            }

            return contractor;
        }
        [HttpPost]
        [Route("SetRates")]
        public async Task<ActionResult<Contractor>> SetRates([FromBody] ContractorSignUpDTO contractor)
        {
            UserInfo user = new UserInfo();

            try
            {
                user = _userHelp.GetUser(User);
            }
            catch (Exception e)
            {
                return Conflict("Error occured processing employee.");
            }
            try
            {
                var ContractRates = new EmpWage
                {
                    Userid = user.UserId,
                    Rate = contractor.ContractorAdjustmenetRate,
                    Effective = contractor.ContractorEffectiveAdjustmentDate,
                    Empratetypeid = contractor.ContractorRateTypeId,
                    Otnote = contractor.Otnote,
                    Regnote = contractor.Regnote,
                    Enteredby = user.UserId,
                    EnteredDate = DateTime.Now
                };
                if (ContractRates != null)
                {
                    _context.EmpWage.Add(ContractRates);
                    await _context.SaveChangesAsync();
                    return Ok("Contractors rate has been set");
                }

            }
            catch (DbUpdateConcurrencyException)
            {
                Conflict("a unique exception occured");
            }
            return BadRequest();
        }
        [HttpGet]
        [Route("ViewRates")]
        public async Task<ActionResult<Contractor>> ViewRates([FromBody] ContractorSignUpDTO contractor)
        {
            UserInfo user = new UserInfo();

            try
            {
                user = _userHelp.GetUser(User);
            }
            catch (Exception e)
            {
                return Conflict("Error occured processing employee.");
            }
            try
            {

                var GrabRates = await (
                   from contractWage in _context.EmpWage
                    where contractWage.Userid == user.UserId
                   select contractWage).ToListAsync();


                if (GrabRates != null)
                {
                    return Ok(GrabRates);
                }
                try
                {
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateException)
                {

                    return Conflict("Identifier issue: an issue occured viewing contracotr wages.");

                }

            }
            catch (DbUpdateConcurrencyException)
            {

            }
            return BadRequest();
        }

        [HttpPost]
        [Route("CancelContract")]
        public async Task<ActionResult<Contractor>> CancelContract([FromBody] ContractorSignUpDTO contractor)
        {
            UserInfo user = new UserInfo();

            try
            {
                user = _userHelp.GetUser(User);
            }
            catch (Exception e)
            {
                return Conflict("Error occured processing employee.");
            }
            try
            {

                var Terminate = _context.Contractor.Find(contractor.ContractorId);
                Terminate.Status = contractor.Status;
                if (Terminate != null)
                    _context.Contractor.Update(Terminate);

                try
                {
                    await _context.SaveChangesAsync();
                    return Ok("Contract has officially been cancelled");
                }
                catch (DbUpdateConcurrencyException)
                {
                    Conflict("Issue updating contractor status");

                }
                var ContractTerm = new EmpTerm
                {
                    UserId = user.UserId,
                    Lastday = contractor.ContractLastDay,
                    Sepdate = contractor.SeperationDate,
                    Rehire = contractor.Rehire,
                    Enteredby = user.UserId,
                    EnteredDate = DateTime.Now,
                    Gene = contractor.GeneralReason,
                    Type = contractor.DeductionType,
                    Pcret = contractor.Pcret
                };
                if (ContractTerm != null)
                {
                    _context.EmpTerm.Add(ContractTerm);
                }
                try
                {
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {

                    return Conflict("Identifier issue: an issue occured canceling a contract.");

                }

            }
            catch (DbUpdateConcurrencyException)
            {
                Conflict("Issue cancelling contractor");
            }
            return BadRequest();
        }
        [HttpPost]
        [Route("Deductions")]
        public async Task<ActionResult<Contractor>> Deductions([FromBody] ContractorSignUpDTO contractor)
        {
            UserInfo user = new UserInfo();

            try
            {
                user = _userHelp.GetUser(User);
            }
            catch (Exception e)
            {
                return Conflict("Error occured processing employee.");
            }
            switch (contractor.DeductionType)
            {
                case "BackgroundCheck":
                    var DeductibleBackGround = new EmpWage
                    {
                        Userid = user.UserId,

                        Effective = contractor.Effective,
                        Regnote = contractor.Regnote,
                        Otnote = contractor.Otnote,
                        Empratetypeid = contractor.Empratetypeid
                    };
                    if (DeductibleBackGround != null)
                    {
                        _context.EmpWage.Add(DeductibleBackGround);
                        await _context.SaveChangesAsync();
                        return Ok();
                    }
                    break;
                case "Drug Test":
                    var DeductibleDrugTest = new EmpWage
                    {
                        NoRate = +40,
                        Regnote = "Drug Test",
                       Userid = user.UserId
                    };
                    if (DeductibleDrugTest != null)
                    {
                        _context.EmpWage.Add(DeductibleDrugTest);
                        await _context.SaveChangesAsync();

                        return Ok();
                    }
                    break;
                case "Tuberculosis Test":
                    var DeductibleTuberculosisTest = new EmpWage
                    {
                        NoRate = +34,
                        Regnote = "Drug Test",
                        Userid = user.UserId
                    };
                    if (DeductibleTuberculosisTest != null)
                    {
                        _context.EmpWage.Add(DeductibleTuberculosisTest);
                        await _context.SaveChangesAsync();

                        return Ok();
                    }
                    break;
                case "MVR Request":
                    var DeductibleMVRRequest = new EmpWage
                    {
                        NoRate = +34,
                        Regnote = "MVR Request",
                        Userid = user.UserId
                    };
                    if (DeductibleMVRRequest != null)
                    {
                        _context.EmpWage.Add(DeductibleMVRRequest);
                        await _context.SaveChangesAsync();

                        return Ok();
                    }
                    break;
                default:
                    Conflict("Error finding deduction request");
                    break;


            }
            return BadRequest();
        }
        [HttpPost]
        [Route("BackgroundCheck")]
        public async Task<ActionResult<Contractor>> BackgroundCheck([FromBody] ContractorSignUpDTO contractor)
        {
            UserInfo userInfo = new UserInfo();
            try
            {
                userInfo = _userHelp.GetUser(User);
            }
            catch (Exception e)
            {
                return Conflict("Error occured processing employee.");
            }

            if (contractor.BackgroundCheckRequested == true)
            {
                var BackGroundCheckRequest = _context.EmpInventory.Find(contractor.ContractorId);

                BackGroundCheckRequest.Backgrd = contractor.BackgroundCheck;

                BackGroundCheckRequest.EnteredDate = DateTime.Now;
                BackGroundCheckRequest.Enteredby = userInfo.UserId;


                if (BackGroundCheckRequest != null)
                {
                    _context.EmpInventory.Update(BackGroundCheckRequest);
                    return Ok("Background test returned");
                }
                try
                {
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateException)
                {

                    return Conflict("Identifier issue: an issue occured requesting background check.");

                }

            }
            return BadRequest();
        }
        [HttpPost]
        [Route("NonCompliance")]
        public async Task<ActionResult<Contractor>> Noncompliance(int id, [FromBody] ContractorSignUpDTO contractor)
        {

            //outdated this can be deleted
            return BadRequest();

        }

        [HttpPost]
        [Route("Documents")]
        public async Task<ActionResult<Contractor>> RequestDocuments([FromBody] ContractorSignUpDTO contractor, bool wasMVRRequested)
        {
            UserInfo userInfo;
            try
            {
                userInfo = _userHelp.GetUser(User);
            }
            catch (Exception e)
            {
                return Conflict("Error occured processing employee.");
            }
            List<string> DocumentsRequested = new List<string>();

            DocumentsRequested = contractor.DocumentsRequested;
            using (var db = new DDSPRODDBContext())
            {
                if (contractor.HealthCareDocuments != null)
                {
                    try
                    {

                        UpdateHealthCareDocuments = _context.EmpInventory.Find(contractor.ContractorId);
                        for (int f = 0; f < DocumentsRequested.Count(); f++)
                        {
                            UpdateHealthCareDocuments.Documents = contractor.DocumentsRequested[f];
                        }
                        if (UpdateHealthCareDocuments != null)
                        {
                            _context.EmpInventory.Update(UpdateHealthCareDocuments);
                        }
                        return Ok("Document list was added");

                        await _context.SaveChangesAsync();

                    }
                    catch (DbUpdateConcurrencyException)
                    {
                        Conflict("Issue occured when requesting documents");
                    }

                }
                if (wasMVRRequested == true)
                {

                    var MvrRequest = _context.EmpInventory.Find(contractor.ContractorId);
                    MvrRequest.Mvrreason = contractor.MvrReason;
                    if (MvrRequest != null)
                    {
                        _context.Add(MvrRequest);
                        return Ok("MVR was added");
                    }
                    try
                    {
                        await _context.SaveChangesAsync();
                    }
                    catch (DbUpdateException)
                    {

                        return Conflict("Identifier issue: an issue occured requesting background check.");

                    }

                }
            }
            return BadRequest();

        }
        [HttpPost]
        [Route("Testing")]
        public async Task<ActionResult<Contractor>> RequestTesting([FromBody] ContractorSignUpDTO contractor)
        {
            UserInfo userInfo = new UserInfo();

            try
            {
                userInfo = _userHelp.GetUser(User);
            }
            catch (Exception e)
            {
                return Conflict("Error occured processing employee.");
            }
            try
            {
                var ContractorDrugTest = _context.Contractor.Find(contractor.ContractorId);

                //ContractorDrugTest.Firstname = contractor.FIRSTNAME;
                //ContractorDrugTest.Lastname = contractor.LASTNAME;
                //ContractorDrugTest.Middlename = contractor.Middlename;

                if (contractor.TubercolosisTest != false)
                {

                    var ContractorInventory = _context.EmpInventory.Find(contractor.ContractorId);

                    ContractorInventory.Tbtst = "Yes";
                    ContractorInventory.Tbexp = contractor.TubercolosisTestDate;
                    ContractorInventory.EnteredDate = DateTime.Now;
                    ContractorInventory.Enteredby = userInfo.UserId;
                    if (ContractorInventory != null)
                        _context.EmpInventory.Update(ContractorInventory);
                    try
                    {
                        await _context.SaveChangesAsync();
                        return Ok("tb test ordered");
                    }
                    catch (DbUpdateException)
                    {

                        return Conflict("Identifier issue: an issue occured requesting background check.");

                    }
                }
                if (contractor.DrugTest != false)
                {

                    var ContractorInventory = _context.EmpInventory.Find(contractor.ContractorId);

                    ContractorInventory.Dtsed = contractor.DrugTestDate;
                    ContractorInventory.Mvrreason = contractor.DrugTestReason;

                    if (ContractorInventory != null)
                        _context.EmpInventory.Add(ContractorInventory);
                    await _context.SaveChangesAsync();
                    return Ok("drug test ordered");

                }
            }
            catch (DbUpdateConcurrencyException)
            {
                Conflict("issue: Adding test");
            }

            return BadRequest();

        }
        [HttpPut]
        [Route("Edit")]
        public async Task<ActionResult<Contractor>> UpdateContractor([FromBody] ContractorSignUpDTO contractor)
        {
            UserInfo userInfo;
            try
            {
                userInfo = _userHelp.GetUser(User);
            }
            catch (Exception e)
            {
                return Conflict("Error occured processing employee.");
            }
            var CompanyName = _context.Company.Find(contractor.CompanyId);
            CompanyName.CompanyName = contractor.CompanyName;
            if (CompanyName != null)
                _context.Company.Update(CompanyName);
            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                Conflict("Issue arrose updating company");
            }
            var AddressChange = _context.ContractorAddressBook.Find(contractor.ContractorId);
            if (AddressChange != null)
            {
                AddressChange.Address1 = contractor.Address1;
                AddressChange.Address2 = contractor.Address2;
                AddressChange.City = contractor.City;
                AddressChange.State = contractor.State;
                AddressChange.Zip = contractor.Zip;

            }
            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                Conflict("Issue arrose adding address book");
            }

            var driver = _context.Driver.Find(contractor.DriverId);
            if (contractor.IsDriver == true)
            { 
                driver.Dlnumber = contractor.Dlnumber;
                driver.Dlexpire = contractor.Dlexpire;
                driver.Dlclass = contractor.Dlclass;
                driver.Dlstate = contractor.Dlstate;
                driver.Inscar = contractor.Inscar;
                driver.Inspno = contractor.Inspno;
                driver.Insexp = contractor.Insexp;
                driver.Insphn = contractor.Insphn;
                driver.Vin = contractor.Vin;

                _context.Driver.Update(driver);
            }
            try
            {
                await _context.SaveChangesAsync();
                return Ok("done successfully");
            }
            catch (DbUpdateConcurrencyException)
            {
                Conflict("issue arrose: updating contractor inventory");
            }
            return BadRequest();

        }

        [HttpGet]
        [Route("OnPageLoad")]
        public ActionResult OnPageLoad()
        {
            var branches = _onPageLoadHelper.GetBranches();
            var contractorTitles = _onPageLoadHelper.GetEmployeeTitles();
            var contractorStatuses = _onPageLoadHelper.GetClientStatuses();
            var onPageLoad = new { branches, contractorTitles, contractorStatuses };
            return Ok(onPageLoad);
        }

        // GET: api/Contractors/5

        public int RandomNumber(int min, int max)
        {
            return random.Next(min, max);
        }

        
        [HttpPost]
        [Route("Create")]
        public async Task<ActionResult<Contractor>> PostContractor(ContractorSignUpDTO contractorDTO)
        {
            UserInfo userInfo;
            try
            {
                userInfo = _userHelp.GetUser(User);
            }
            catch (Exception e)
            {
                return Conflict("Error occured processing employee.");
            }
            int? contractorId = null;
            //Add contractor address to the address book
            var contractorAddressBook = new ContractorAddressBook()
            {
                Address1 = contractorDTO.Address1,
                Address2 = contractorDTO.Address2,
                City = contractorDTO.City,
                State = contractorDTO.State,
                Zip = contractorDTO.Zip,
                Phone1 = contractorDTO.Phone1,
                Phone2 = contractorDTO.Phone2,
                EmergencyPhone= contractorDTO.EmeregencyPhone,
                //PrefferedPhone = contractorDTO.PrefferedPhone,
                Email = contractorDTO.Email,
                //Reference1 = contractorDTO.Reference1
            };

            _context.Add(contractorAddressBook);

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateException)
            {
                return Conflict("There was an error adding the contractor address to the database.");
            }

            Contractor contractor = new Contractor();
            contractor.Lastname = contractorDTO.LASTNAME;
            contractor.Firstname = contractorDTO.FIRSTNAME;
            contractor.Middlename = contractorDTO.Middlename;
            contractor.Organizationid = contractorDTO.OrganizationId;
            contractor.Addressbookid = contractorAddressBook.AddressBookId;
       
            contractor.Rds = contractorDTO.Rds;
            contractor.Card = contractorDTO.Card;
            contractor.Status = contractorDTO.Status;
            contractor.Entereddate = contractorDTO.Entereddate;
            contractor.Enteredby = contractorDTO.Enteredby;
            contractor.Pcommt = contractorDTO.Pcommt;
            contractor.Sctype = contractorDTO.Sctype;
           
            contractor.SoleProprietor = contractorDTO.SoleProprietor;
            contractor.Llc = contractorDTO.Llc;
            contractor.Corporation = contractorDTO.Corporation;
            contractor.Partnership = contractorDTO.Partnership;
          
            contractor.Anniversary = contractorDTO.Anniversary;
            contractor.Wcode = contractorDTO.Wcode;
            contractor.IsMaster = contractorDTO.IsMasterContractor;

            contractor.Enteredby = userInfo.UserId;
            contractor.Modifiedby = 1;



        
            if (contractor.SoleProprietor != null)
            {
                contractor.Ssn = contractorDTO.Ssn;
            }

            else
            {
                contractor.Feid = contractorDTO.FEID;
            }

            _context.Contractor.Add(contractor);

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateException ex)
            {
                if (ContractorExists(contractor.ContractorId))
                {
                    return Conflict();
                }
                else
                {
                    throw;
                }
            }
            var TerminateEmployee = (
              from employeeuser in _context.ContractorUser

              where employeeuser.ContractorId== contractor.ContractorId
              select employeeuser).SingleOrDefault();
            if (contractorDTO.IsDriver == true)
            {
                Driver driver = new Driver();
                driver.Nica = contractorDTO.Nica;
                driver.Checkname = contractorDTO.CheckName;
                driver.OperationStates = contractorDTO.OperationStates;
                driver.Adminfee = contractorDTO.AdminFee;
                driver.Dlnumber = contractorDTO.DriverLicense;
                driver.Dlstate = contractorDTO.DriverLicenseState;
                driver.Dlexpire = contractorDTO.DriverLicenseExpiration;
                driver.VehGrossWt = contractorDTO.VehicleGrossWeight;
               driver.Vin = contractorDTO.Vin;
                driver.Vlicense = contractorDTO.LicensePlate;
                driver.Dlclass = contractorDTO.Class;
                driver.Vdesc = contractorDTO.VehicleMake;
                driver.Insagn = contractorDTO.AgentName;
                driver.Vtypeid = contractorDTO.Vtypeid;
                driver.Inscar = contractorDTO.Carrier;
                driver.Inspno = contractorDTO.PolicyNo;
                driver.Insprf = contractorDTO.InsuranceProof;
                driver.Insphn = contractorDTO.AgentPhoneNO;
                driver.Insexp = contractorDTO.IExpirationDate;
                
                _context.Driver.Add(driver);
                try
                {
                    await _context.SaveChangesAsync();

                }
                catch (DbUpdateException ex)
                {
                    return Conflict("There was an error saving the drivers information to the database.");
                }

            }
          //dEmpInventory empInventory = new EmpInventory();

            //empInventory.Dob = contractorDTO.DOB;

            //empInventory.Cphone = contractorDTO.CarrierPhone;

            //empInventory.Limit = contractorDTO.InsuranceLimit;

            //Set contractor pay rate
            //var contractorWage = new EmpWage()
            //{
            //    /* empwage requires user id inorder to post it */
            //   Userid = 2,
            //    Rate = contractorDTO.Rate,
            //    //Needs an effective date
            //    Effective = contractorDTO.Effective
            //};
            //////_context.EmpInventory.Add(empInventory);
            //_context.EmpWage.Add(contractorWage);

            //try
            //{
            //    await _context.SaveChangesAsync();
            //    return CreatedAtAction("GetContractor", new { id = contractor.ContractorId }, contractor);

            //}
            //catch (DbUpdateException ex)
            //{
            //    return Conflict("There was an error saving the contractor's wage or insurance information to the database.");
            //}
            return Ok();

        }
        [HttpGet]
        [Route("History")]

        public async Task<ActionResult<Contractor>> ContractorHistory([FromBody] ContractorSignUpDTO contractor)
        {
            UserInfo user = new UserInfo();

            try
            {
                user = _userHelp.GetUser(User);
            }
            catch (Exception e)
            {
                return Conflict("Error occured processing employee.");
            }
            var ContractorHistory = await (
                from contractors in _context.Contractor
               from EmpTerm in _context.EmpTerm
                where EmpTerm.UserId == user.UserId
                select EmpTerm).ToListAsync();

            if (ContractorHistory != null)
            {
                return Ok(ContractorHistory);
            }
            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                Conflict("Issue viewing EmployeeHistory");

            }
            return BadRequest();
        }
        // DELETE: api/Contractors/5
        [HttpDelete("{id}")]
        public async Task<ActionResult<Contractor>> DeleteContractor(int id)
        {
            UserInfo user = new UserInfo();

            try
            {
                user = _userHelp.GetUser(User);
            }
            catch (Exception e)
            {
                return Conflict("Error occured processing employee.");
            }
            var contractor = await _context.Contractor.FindAsync(id);

            if (contractor == null)
            {
                return NotFound();
            }

            _context.Contractor.Remove(contractor);

            await _context.SaveChangesAsync();

            return contractor;
        }

        private bool ContractorExists(int id)
        {
            return _context.Contractor.Any(e => e.ContractorId == id);
        }
    }
}