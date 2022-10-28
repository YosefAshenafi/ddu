
using DDU.Core;
using DDU.Data;
using DDU.Models;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using System.Reflection;
using static DDU.Helper;
using IHostingEnvironment = Microsoft.AspNetCore.Hosting.IHostingEnvironment;
namespace DDU.Controllers
{
    public class EmployeesController : Controller
    {
        private readonly ApplicationDbContext _db;
        private IHostingEnvironment _he;

        public EmployeesController(ApplicationDbContext db, IHostingEnvironment he)
        {
            _db = db;
            _he = he;
        }
        [Authorize(Roles = $"{Constants.Roles.Administrator}" + "," + $"{Constants.Roles.Manager}")]
        //[Authorize(Roles = $"{Constants.Roles.Administrator}")]
        public IActionResult Index()
        {
            IEnumerable<EmployeeRegistration> objEmployeeList = _db.employeeRegistration;
            return View(objEmployeeList);
        }

        public IActionResult AddEmployee()
        {
            return View();
        }

        //Post
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> AddEmployeeAsync(EmployeeRegistration obj, [FromForm(Name = "file")] IFormFile image)
        {
            obj.EmployeeID = Guid.NewGuid();            
            if (ModelState.IsValid)
            {
                var filename = DateTime.Now.Ticks.ToString() + Path.GetExtension(image.FileName);
                if (image != null)
                {
                    var imagepath = @"\images\employee\";
                   
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

                obj.Image1Path = "/images/employee/" + filename;

                _db.employeeRegistration.Add(obj);
                _db.SaveChanges();
                TempData["success"] = "Employee Create successfully";
                return RedirectToAction("Index");
            }
            return View(obj);
        }
        //Get Profile
        public IActionResult Profile(Guid? id)
        {
            ViewModel mymodel = new ViewModel();
            ViewBag.Registration = _db.employeeRegistration.Find(id);
            ViewBag.Annualleave= _db.vw_Annualleave.Find(id);
            mymodel.EmployeeEducations = _db.employeeEducation.Select(z => z).Where(s => s.EmployeeID == id).ToList();
            mymodel.EmployeeFamilys = _db.employeeFamily.Select(z => z).Where(s => s.EmployeeId == id).ToList();
            mymodel.EmploymentHistorys =_db.employmentHistory.Select(z => z).Where(s => s.EmployeeId == id).ToList();
            mymodel.EmployeeTrainings = _db.employeeTraining.Select(z => z).Where(s => s.EmployeeID == id).ToList();
            mymodel.EmployeeSkills = _db.employeeSkill.Select(z => z).Where(s => s.EmployeeId == id).ToList();
            mymodel.SalaryChange = _db.salaryChange.Select(z => z).Where(s => s.EmployeeID == id).ToList();
            return View(mymodel);
        }

        //Get    
        public IActionResult Edit(Guid? id)
        {
            if (id == null || id == Guid.Empty)
            {
                return NotFound();
            }

            var employeesFromDb = _db.employeeRegistration.Find(id);
       

            if (employeesFromDb == null)
            {
                return NotFound();

            }


            return View(employeesFromDb);
        }
        //Post
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> EditAsync(EmployeeRegistration obj, [FromForm(Name = "file")] IFormFile image)
        {
          
            _db.employeeRegistration.Update(obj);
            var filename = DateTime.Now.Ticks.ToString() + Path.GetExtension(image.FileName);
            if (image != null)
            {
                var imagepath = @"\images\employee\";

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

            obj.Image1Path = "/images/employee/" + filename;
            _db.SaveChanges();
            TempData["success"] = "Edit Add successfully";
            return RedirectToAction("Index");
        }

        //Get    
        public IActionResult Delete(Guid? id)
        {

            var employeesFromDb = _db.employeeRegistration.Find(id);


            if (employeesFromDb == null)
            {
                return NotFound();

            }
            return View(employeesFromDb);
        }
        //Post
        [HttpPost, ActionName("DeletePost")]
        [ValidateAntiForgeryToken]
        public IActionResult DeletePost(Guid? id)
        {
            
            var obj = _db.employeeRegistration.Find(id);
            if (obj == null)
            {
                return NotFound();
            }
            _db.employeeRegistration.Remove(obj);
            _db.SaveChanges();
            TempData["success"] = "delete successfully";
            IEnumerable<EmployeeRegistration> objEmployeeList = _db.employeeRegistration;
            objEmployeeList = _db.employeeRegistration;
            return Json(new { isValid = true, html = Helper.RenderRazorViewToString(this, "Index", objEmployeeList) });         

        }


        // GET: EmployeeEducation/AddOrEdit(Insert)
        // GET: EmployeeEducation/AddOrEdit/5(Update)
        [NoDirectAccess]
        public async Task<IActionResult> AddOrEdit(Guid id,Guid Employeeid)
        {
            if (id == Guid.Empty)
            {
                var eduModel = new EmployeeEducation();
                eduModel.EmployeeID = Employeeid;
                return View(eduModel);
            }
               
            else
            {
                var eduModel =  _db.employeeEducation.Find(id);
                if (eduModel == null)
                {
                    return NotFound();
                }
                return View(eduModel);
            }
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> AddOrEdit(Guid id, [Bind("EmpEduId,EmployeeID,Credential,Field,Institute,FYear,TYear,EffectiveDate,EducationLev,SessionID,SessionIP,SessionMAC")] EmployeeEducation eduModel)
        {
            if (ModelState.IsValid)
            {
               
                //Update
                if(eduModel.EmpEduId != Guid.Empty)
                {
                    try
                    {
                        _db.Update(eduModel);
                        await _db.SaveChangesAsync();
                    }
                    catch (DbUpdateConcurrencyException)
                    {
                        if (!EducationModelExists(eduModel.EmpEduId))
                        { return NotFound(); }
                        else
                        { throw; }
                    }

                } 
                //Insert                
                else
                {
                    eduModel.EmpEduId = Guid.NewGuid();
                    _db.employeeEducation.Add(eduModel);
                    _db.SaveChanges();
                }
                return Json(new { isValid = true, html = Helper.RenderRazorViewToString(this, "Index") });
            }
            return Json(new { isValid = false, html = Helper.RenderRazorViewToString(this, "AddOrEdit", eduModel) });
        }

        // GET: EmployeeHistory/AddOrEdit(Insert)
        // GET: EmployeeHistory/AddOrEdit/5(Update)
        [NoDirectAccess]
        public async Task<IActionResult> EmpAddOrEdit(Guid id, Guid Employeeid)
        {
            if (id == Guid.Empty)
            {
                var emplModel = new EmploymentHistory();
                emplModel.EmployeeId = Employeeid;
                return View(emplModel);
            }

            else
            {
                var emplModel = _db.employmentHistory.Find(id);
                if (emplModel == null)
                {
                    return NotFound();
                }
                return View(emplModel);
            }
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> EmpAddOrEdit(Guid id, [Bind("EmpEmploymentId,seq_no, EmployeeId, Organiazation, tax_payment_letter_no, Job_title, Date_from, Date_to, salary, Date_termination, termination_reason, emp_status, net_duration, Remark, SessionID, SessionIP,SessionMAC")] EmploymentHistory empModel)
        {
            if (ModelState.IsValid)
            {

                //Update
                if (empModel.EmpEmploymentId!= Guid.Empty)
                {
                    try
                    {
                        _db.Update(empModel);
                        await _db.SaveChangesAsync();
                    }
                    catch (DbUpdateConcurrencyException)
                    {
                        if (!EducationModelExists(empModel.EmpEmploymentId))
                        { return NotFound(); }
                        else
                        { throw; }
                    }

                }
                //Insert                
                else
                {
                    try
                    {
                        empModel.EmpEmploymentId = Guid.NewGuid();
                        _db.employmentHistory.Add(empModel);
                        _db.SaveChanges();
                    }
                    catch (DbUpdateConcurrencyException)
                    {
                        throw;
                    }
                }
                return Json(new { isValid = true, html = Helper.RenderRazorViewToString(this, "Index") });
            }
            return Json(new { isValid = false, html = Helper.RenderRazorViewToString(this, "EmpAddOrEdit", empModel) });
        }

        private bool EducationModelExists(Guid id)
        {
            return _db.employeeEducation.Any(e => e.EmployeeID == id);
        }
        // GET: EmployeeHistory/AddOrEdit(Insert)
        // GET: EmployeeHistory/AddOrEdit/5(Update)
        [NoDirectAccess]
        public async Task<IActionResult> SkillAddOrEdit(Guid id, Guid Employeeid)
        {
            if (id == Guid.Empty)
            {
                var skillModel = new EmployeeSkill();
                skillModel.EmployeeId = Employeeid;
                return View(skillModel);
            }

            else
            {
                var skillModel = _db.employeeSkill.Find(id);
                if (skillModel == null)
                {
                    return NotFound();
                }
                return View(skillModel);
            }
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> SkillAddOrEdit(Guid id, [Bind("EmpSkillId, EmployeeId, Aria_valuenow, Aria_valuemin, Aria_valuemax, Skill, Color, SessionID, SessionIP, SessionMAC")] EmployeeSkill skillModel)
        {
            if (ModelState.IsValid)
            {

                //Update
                if (skillModel.EmpSkillId != Guid.Empty)
                {
                    try
                    {
                        _db.Update(skillModel);
                        await _db.SaveChangesAsync();
                    }
                    catch (DbUpdateConcurrencyException)
                    {
                        if (!EducationModelExists(skillModel.EmpSkillId))
                        { return NotFound(); }
                        else
                        { throw; }
                    }

                }
                //Insert                
                else
                {
                    try
                    {
                        skillModel.EmpSkillId = Guid.NewGuid();
                        _db.employeeSkill.Add(skillModel);
                        _db.SaveChanges();
                    }
                    catch (DbUpdateConcurrencyException)
                    {
                        throw;
                    }
                }
                return Json(new { isValid = true, html = Helper.RenderRazorViewToString(this, "Index") });
            }
            return Json(new { isValid = false, html = Helper.RenderRazorViewToString(this, "SkillAddOrEdit", skillModel) });
        }

        // GET: EmployeeEducation/Delete/5
        public async Task<IActionResult> EduDelete(Guid? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var eduModel = await _db.employeeEducation
                .FirstOrDefaultAsync(m => m.EmpEduId == id);
            if (eduModel == null)
            {
                return NotFound();
            }
            else
            {
                _db.employeeEducation.Remove(eduModel);
                _db.SaveChangesAsync();
                return View(eduModel);
            }

            return View(eduModel);
        }

        // POST: EmployeeEducation/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> EduDeleteConfirmed(int id)
        {
            var eduModel = await _db.employeeEducation.FindAsync(id);
            _db.employeeEducation.Remove(eduModel);
            await _db.SaveChangesAsync();
            return Json(new { isValid = true, html = Helper.RenderRazorViewToString(this, "Index") });
        }

        // POST: EmployeeEducation/Delete/5
        [HttpPost, ActionName("SkillDelete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> SkillDelete(Guid? id)
        {
            var skillModel = await _db.employeeSkill.FindAsync(id);
            _db.employeeSkill.Remove(skillModel);
            await _db.SaveChangesAsync();
            return Json(new { isValid = true, html = Helper.RenderRazorViewToString(this, "Index") });
        }


    }
}
