using DDU.Data;
using DDU.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using System.Reflection;
using static DDU.Helper;
using IHostingEnvironment = Microsoft.AspNetCore.Hosting.IHostingEnvironment;
namespace DDU.Controllers
{
    public class RecruitmentController : Controller
    {
        private readonly ApplicationDbContext _db;
        private IHostingEnvironment _he;

        public RecruitmentController(ApplicationDbContext db, IHostingEnvironment he)
        {
            _db = db;
            _he = he;
        }
        public IActionResult Index()
        {
            IEnumerable<PositionJobs> objPositionJobsList = _db.positionJobs;
            foreach(var objJob in objPositionJobsList)
            {
              var depData  =_db.department.Find(objJob.DepartmentID);
                if(depData != null) objJob.DepartmentName = depData.DepartmentName;
              var PosData = _db.positions.Find(objJob.PositionId);
                if (PosData != null) objJob.PositionName = PosData.Job_title;
            }
            return View(objPositionJobsList);
            
        }

        public IActionResult JobApplicants()
        {
            return View();
        }
        [HttpGet]
        public IActionResult AddPositionJobs()
        {
            
            PositionJobs mymodel = new PositionJobs();

            mymodel.ListDepartment = new List<SelectListItem>();
            var datadep = _db.department.ToList();
            mymodel.ListDepartment.Add(new SelectListItem
            {
                Text = "Select Department",
                Value = ""

            });
            foreach (var item in datadep)
            {
                mymodel.ListDepartment.Add(new SelectListItem
                {
                    Text = item.DepartmentName,
                    Value = Convert.ToString(item.DepartmentID)

                });
            }
            mymodel.ListPosition = new List<SelectListItem>();
            var data = _db.positions.ToList();
            mymodel.ListPosition.Add(new SelectListItem
            {
                Text = "Select Position",
                Value = ""

            });
            foreach (var item in data)
            {
                mymodel.ListPosition.Add(new SelectListItem
                {
                    Text = item.Job_title, Value =Convert.ToString(item.PositionId)

                });
            }
            return View(mymodel);
        }

        //Post
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> AddPositionJobsAsync(PositionJobs obj)
        {
            obj.PositionJobId = Guid.NewGuid();
            if (ModelState.IsValid)
            {

                _db.positionJobs.Add(obj);
                _db.SaveChanges();
                TempData["success"] = "Position Job Create successfully";
                return RedirectToAction("Index");
            }
            return View(obj);
        }

        //Get    
        public IActionResult EditPositionJobs(Guid? id)
        {
            if (id == null || id == Guid.Empty)
            {
                return NotFound();
            }
            PositionJobs mymodel = new PositionJobs();

            
            mymodel = _db.positionJobs.Find(id);
            var depData = _db.department.Find(mymodel.DepartmentID);
            if (depData != null) mymodel.DepartmentName = depData.DepartmentName;
            var PosData = _db.positions.Find(mymodel.PositionId);
            if (PosData != null) mymodel.PositionName = PosData.Job_title;
            mymodel.ListDepartment = new List<SelectListItem>();
            var datadep = _db.department.ToList();

            foreach (var item in datadep)
            {
                mymodel.ListDepartment.Add(new SelectListItem
                {
                    Text = item.DepartmentName,
                    Value = Convert.ToString(item.DepartmentID)

                });
            }
            mymodel.ListPosition = new List<SelectListItem>();
            var data = _db.positions.ToList();
          
            foreach (var item in data)
            {
                mymodel.ListPosition.Add(new SelectListItem
                {
                    Text = item.Job_title,
                    Value = Convert.ToString(item.PositionId)

                });
            }
            mymodel.ListDepartment.Add(new SelectListItem
            {
                Text = mymodel.DepartmentName,
                Value = Convert.ToString(mymodel.DepartmentID)

            });
            mymodel.ListPosition.Add(new SelectListItem
            {
                Text = mymodel.PositionName,
                Value = Convert.ToString(mymodel.DepartmentID)

            });


            if (mymodel == null)
            {
                return NotFound();

            }


            return View(mymodel);
        }

        //Post
        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult EditPositionJobs(PositionJobs obj)
        {

            _db.positionJobs.Update(obj);
            _db.SaveChanges();
            TempData["success"] = "Edit Add successfully";
            return RedirectToAction("Index");
        }

        //Get Profile
        public IActionResult Applicants(Guid? id)
        {
            PositionViewModel pomodel = new PositionViewModel();
            ViewBag.JobPosId=id;
            var JobPosData = _db.positionJobs.Select(z => z).Where(s => s.PositionJobId == (Guid)id).ToList();
            
            if (JobPosData != null)
            {
                var Depdata = _db.department.Select(z => z).Where(s => s.DepartmentID == JobPosData[0].DepartmentID).ToList();
                var Posdata=_db.positions.Select(z => z).Where(s => s.PositionId == JobPosData[0].PositionId).ToList();
                var Appdata= _db.applicants.Select(z => z).Where(s => s.PositionJobId == id).ToList();
                if (Depdata != null) pomodel.Department = Depdata;
                if (Posdata != null) pomodel.Positions = Posdata;
                if(Appdata!=null) pomodel.Applicants = Appdata;
                foreach(Applicant obj in Appdata)
                {
                    obj.DepartmentName = Depdata[0].DepartmentName;
                    obj.PositionName = Posdata[0].Job_title;
                    obj.NoOfPos = JobPosData[0].NoOfPos;
                    obj.InterviewDate= JobPosData[0].InterviewDate;
                    obj.ReportingTo = JobPosData[0].ReportingTo;
                    obj.RequiredQualification = JobPosData[0].RequiredQualification;
                }
            }
            return View(pomodel);
        }
        
        //Get Applicants
        public IActionResult AddApplicants(Guid? id)
        {
            Applicant Appmodel = new Applicant();
            Appmodel.PositionJobId = (Guid)id;
            return View(Appmodel);
        }
        public IActionResult EditApplicants(Guid? id)
        {
            var Appmodel = _db.applicants.Find(id);
            if (Appmodel == null)
            {
                return NotFound();
            }
            return View(Appmodel);
        }

         [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> AddApplicants(Guid id, Applicant appModel, [FromForm(Name = "file")] IFormFile? image)
        {

            if (ModelState.IsValid)
            {

                //Update
                if (appModel.ApplicantID != Guid.Empty)
                {
                    try
                    {
                        _db.Update(appModel);
                        await _db.SaveChangesAsync();
                        if (!EmployeeModelExists(appModel.ApplicantID) && appModel.Recuited == true)
                        {
                            EmployeeRegistration obj = new EmployeeRegistration();
                            obj.EmployeeID = appModel.ApplicantID;
                            obj.FirstName = appModel.FirstName;
                            obj.MiddleName = appModel.MiddleName;
                            obj.Telephone = appModel.Phonenumber;
                            _db.employeeRegistration.Add(obj);
                            _db.SaveChanges();
                        }
                    }
                    catch (DbUpdateConcurrencyException)
                    {
                       throw; 
                    }

                }
                //Insert                
                else
                {                   



                    appModel.ApplicantID = Guid.NewGuid();
                    var filename = DateTime.Now.Ticks.ToString() + Path.GetExtension(image.FileName);
                    if (image != null)
                    {
                        var imagepath = @"\images\recruitment\";

                        var path = Path.Combine(_he.WebRootPath + imagepath, filename);
                        using (var stream = new FileStream(path, FileMode.Create))
                        {
                            await image.CopyToAsync(stream);
                        }
                    }
                    else
                    {
                        filename = "noimage.PNG";
                    }

                    appModel.Image1Path = "/images/recruitment/" + filename;
                    _db.applicants.Add(appModel);
                    _db.SaveChanges();
                }
                return Json(new { isValid = true, html = Helper.RenderRazorViewToString(this, "Index") });
            }
            return Json(new { isValid = false, html = Helper.RenderRazorViewToString(this, "AddApplicants", appModel) });
        }

        // POST: PositionJobs/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Delete(Guid? id)
        {
            var jobsModel = await _db.positionJobs.FindAsync(id);
            _db.positionJobs.Remove(jobsModel);
            await _db.SaveChangesAsync();
            return Json(new { isValid = true, html = Helper.RenderRazorViewToString(this, "Index") });
        }

        private bool EmployeeModelExists(Guid id)
        {
            return _db.employeeRegistration.Any(e => e.EmployeeID == id);
        }


    }
}
