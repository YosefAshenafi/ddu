
﻿using DDU.Data;
using DDU.Models;
using DDU.Utility;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using NuGet.Protocol.Plugins;
﻿using Microsoft.AspNetCore.Mvc;


namespace DDU.Controllers
{
    public class InventoryController : Controller
    {


        private readonly ApplicationDbContext _db;
      
        public InventoryController(ApplicationDbContext db)
        {
            _db = db;
        }
        public IActionResult Index()
        {
            HttpContext.Session.Set("GRN", new List<InvInventoryItem>());
            IEnumerable<Vw_Item> objItemList = _db.vw_Item.ToList();
            return View(objItemList);
        }
        public ActionResult GRN()
        {
            //String.Format("{0} {1}", @ViewBag.Registration.FirstName, @ViewBag.Registration.MiddleName)

            ViewData["employeeid"] = new SelectList(_db.employeeRegistration.ToList(), "EmployeeID", "FirstName"); 
            ViewData["vendorid"] = new SelectList(_db.invSupplier.ToList(), "SupplierID", "SupName");
            ViewData["store"] = new SelectList(_db.invStore.ToList(), "StoreID", "StoreCode");
            return View();
        }
        public ActionResult IssueVoucher()
        {
            //String.Format("{0} {1}", @ViewBag.Registration.FirstName, @ViewBag.Registration.MiddleName)
            ViewData["costCenter"] = new SelectList(_db.invCostCenter.ToList(), "CostID", "CostName");
            ViewData["employeeid"] = new SelectList(_db.employeeRegistration.ToList(), "EmployeeID", "FirstName");
            ViewData["store"] = new SelectList(_db.invStore.ToList(), "StoreID", "StoreCode");
            return View();
        }

        public ActionResult ItemReturn()
        {
           
            ViewData["costCenter"] = new SelectList(_db.invCostCenter.ToList(), "CostID", "CostName");
            ViewData["employeeid"] = new SelectList(_db.employeeRegistration.ToList(), "EmployeeID", "FirstName");
            ViewData["store"] = new SelectList(_db.invStore.ToList(), "StoreID", "StoreCode");
            return View();
        }

        public ActionResult Disposal()
        {

            ViewData["costCenter"] = new SelectList(_db.invCostCenter.ToList(), "CostID", "CostName");
            ViewData["employeeid"] = new SelectList(_db.employeeRegistration.ToList(), "EmployeeID", "FirstName");
            ViewData["store"] = new SelectList(_db.invStore.ToList(), "StoreID", "StoreCode");
            return View();
        }

        public ActionResult Count()
        {

            ViewData["costCenter"] = new SelectList(_db.invCostCenter.ToList(), "CostID", "CostName");
            ViewData["employeeid"] = new SelectList(_db.employeeRegistration.ToList(), "EmployeeID", "FirstName");
            ViewData["store"] = new SelectList(_db.invStore.ToList(), "StoreID", "StoreCode");
            return View();
        }

        public ActionResult Adjustment()
        {

            ViewData["costCenter"] = new SelectList(_db.invCostCenter.ToList(), "CostID", "CostName");
            ViewData["employeeid"] = new SelectList(_db.employeeRegistration.ToList(), "EmployeeID", "FirstName");
            ViewData["store"] = new SelectList(_db.invStore.ToList(), "StoreID", "StoreCode");
            return View();
        }

        public ActionResult ItemTransfer()
        {

            ViewData["costCenter"] = new SelectList(_db.invCostCenter.ToList(), "CostID", "CostName");
            ViewData["employeeid"] = new SelectList(_db.employeeRegistration.ToList(), "EmployeeID", "FirstName");
            ViewData["store"] = new SelectList(_db.invStore.ToList(), "StoreID", "StoreCode");
            return View();
        }
      


        public JsonResult Stockchecked(int id)
        {
            List<InvInventoryItem> products = new List<InvInventoryItem>();

            var productsFromDb = _db.invInventoryItem.Find(id);

            if (productsFromDb == null)
            {
                return Json("");

            }

            if (products == null)
            {

                products = new List<InvInventoryItem>();
            }
            else
            {
                products = HttpContext.Session.Get<List<InvInventoryItem>>("GRN");
                
            }
            productsFromDb.ReoredrPoint = 1;
            if (products == null)
            {

                products = new List<InvInventoryItem>();
            }
#pragma warning disable CS8602 // Dereference of a possibly null reference
            products.Add(productsFromDb);
#pragma warning restore CS8602 // Dereference of a possibly null reference.
            HttpContext.Session.Set("GRN", products);
            HttpContext.Session.Set("ISV", products);
            HttpContext.Session.Set("RT", products);
            HttpContext.Session.Set("DS", products);
            HttpContext.Session.Set("CO", products);
            HttpContext.Session.Set("AD", products);
            HttpContext.Session.Set("TR", products);
            return Json(products.Count());
        }

        public JsonResult textChangeF(int id, string name, double value)
        {
           
            List<InvInventoryItem> sitem = HttpContext.Session.Get<List<InvInventoryItem>>("GRN");
            var item = sitem.SingleOrDefault(x => x.ItemID.Equals(id));
 

            if (name == "Qty")
            {
                if (item != null)
                {
                    item.ReoredrPoint= decimal.Parse(value.ToString());

                    HttpContext.Session.Set("GRN", sitem); //it's must add for a set new session data
                }
            }
            else if (name == "UnitCost")
            {
                if (item != null)
                {
                    item.UnitCost = value;

                    HttpContext.Session.Set("GRN", sitem); //it's must add for a set new session data
                }

            }
 
            else
            {

            }

            return Json(item);
        }

        public JsonResult textChangeIsv(int id, string name, double value)
        {

            List<InvInventoryItem> sitem = HttpContext.Session.Get<List<InvInventoryItem>>("ISV");
            var item = sitem.SingleOrDefault(x => x.ItemID.Equals(id));


            if (name == "Qty")
            {
                if (item != null)
                {
                    item.ReoredrPoint = decimal.Parse(value.ToString());

                    HttpContext.Session.Set("ISV", sitem); //it's must add for a set new session data
                }
            }
            else if (name == "UnitCost")
            {
                if (item != null)
                {
                    item.UnitCost = value;

                    HttpContext.Session.Set("ISV", sitem); //it's must add for a set new session data
                }

            }

            else
            {

            }

            return Json(item);
        }

        public JsonResult textChangeRT(int id, string name, double value)
        {

            List<InvInventoryItem> sitem = HttpContext.Session.Get<List<InvInventoryItem>>("RT");
            var item = sitem.SingleOrDefault(x => x.ItemID.Equals(id));


            if (name == "Qty")
            {
                if (item != null)
                {
                    item.ReoredrPoint = decimal.Parse(value.ToString());

                    HttpContext.Session.Set("RT", sitem); //it's must add for a set new session data
                }
            }
            else if (name == "UnitCost")
            {
                if (item != null)
                {
                    item.UnitCost = value;

                    HttpContext.Session.Set("RT", sitem); //it's must add for a set new session data
                }

            }

            else
            {

            }

            return Json(item);
        }

        public JsonResult textChangeDS(int id, string name, double value)
        {

            List<InvInventoryItem> sitem = HttpContext.Session.Get<List<InvInventoryItem>>("DS");
            var item = sitem.SingleOrDefault(x => x.ItemID.Equals(id));


            if (name == "Qty")
            {
                if (item != null)
                {
                    item.ReoredrPoint = decimal.Parse(value.ToString());

                    HttpContext.Session.Set("DS", sitem); //it's must add for a set new session data
                }
            }
            else if (name == "UnitCost")
            {
                if (item != null)
                {
                    item.UnitCost = value;

                    HttpContext.Session.Set("DS", sitem); //it's must add for a set new session data
                }

            }

            else
            {

            }

            return Json(item);
        }
        public JsonResult textChangeCO(int id, string name, double value)
        {

            List<InvInventoryItem> sitem = HttpContext.Session.Get<List<InvInventoryItem>>("CO");
            var item = sitem.SingleOrDefault(x => x.ItemID.Equals(id));


            if (name == "Qty")
            {
                if (item != null)
                {
                    item.ReoredrPoint = decimal.Parse(value.ToString());

                    HttpContext.Session.Set("CO", sitem); //it's must add for a set new session data
                }
            }
            else if (name == "UnitCost")
            {
                if (item != null)
                {
                    item.UnitCost = value;

                    HttpContext.Session.Set("CO", sitem); //it's must add for a set new session data
                }

            }

            else
            {

            }

            return Json(item);
        }

        public JsonResult textChangeAD(int id, string name, double value)
        {

            List<InvInventoryItem> sitem = HttpContext.Session.Get<List<InvInventoryItem>>("AD");
            var item = sitem.SingleOrDefault(x => x.ItemID.Equals(id));


            if (name == "Qty")
            {
                if (item != null)
                {
                    item.ReoredrPoint = decimal.Parse(value.ToString());

                    HttpContext.Session.Set("AD", sitem); //it's must add for a set new session data
                }
            }
            else if (name == "UnitCost")
            {
                if (item != null)
                {
                    item.UnitCost = value;

                    HttpContext.Session.Set("AD", sitem); //it's must add for a set new session data
                }

            }

            else
            {

            }

            return Json(item);
        }

        public JsonResult textChangeTR(int id, string name, double value)
        {

            List<InvInventoryItem> sitem = HttpContext.Session.Get<List<InvInventoryItem>>("TR");
            var item = sitem.SingleOrDefault(x => x.ItemID.Equals(id));


            if (name == "Qty")
            {
                if (item != null)
                {
                    item.ReoredrPoint = decimal.Parse(value.ToString());

                    HttpContext.Session.Set("TR", sitem); //it's must add for a set new session data
                }
            }
            else if (name == "UnitCost")
            {
                if (item != null)
                {
                    item.UnitCost = value;

                    HttpContext.Session.Set("TR", sitem); //it's must add for a set new session data
                }

            }

            else
            {

            }

            return Json(item);
        }
        public string GetGRNNo()
        {

            int rowCount = 1;
            try
            {
                if (_db.invReceive.ToList().Count() != null)
                {
                    rowCount = _db.invReceive.ToList().Count() + 1;
                }
                else
                {

                }
            }
            catch
            {
                return rowCount.ToString("000");
            }

            return rowCount.ToString("000");
        }

        public string GetISVNo()
        {

            int rowCount = 1;
            try
            {
                if (_db.invItemIssue.ToList().Count() != null)
                {
                    rowCount = _db.invItemIssue.ToList().Count() + 1;
                }
                else
                {

                }
            }
            catch
            {
                return rowCount.ToString("000");
            }

            return rowCount.ToString("000");
        }
        public string GetRTNo()
        {

            int rowCount = 1;
            try
            {
                if (_db.invItemReturn.ToList().Count() != null)
                {
                    rowCount = _db.invItemReturn.ToList().Count() + 1;
                }
                else
                {

                }
            }
            catch
            {
                return rowCount.ToString("000");
            }

            return rowCount.ToString("000");
        }

        public string GetDSNo()
        {

            int rowCount = 1;
            try
            {
                if (_db.invDisposal.ToList().Count() != null)
                {
                    rowCount = _db.invDisposal.ToList().Count() + 1;
                }
                else
                {

                }
            }
            catch
            {
                return rowCount.ToString("000");
            }

            return rowCount.ToString("000");
        }

        public string GetCONo()
        {

            int rowCount = 1;
            try
            {
                if (_db.invCount.ToList().Count() != null)
                {
                    rowCount = _db.invCount.ToList().Count() + 1;
                }
                else
                {

                }
            }
            catch
            {
                return rowCount.ToString("000");
            }

            return rowCount.ToString("000");
        }

        public string GetAdjNo()
        {

            int rowCount = 1;
            try
            {
                if (_db.invAdjustment.ToList().Count() != null)
                {
                    rowCount = _db.invAdjustment.ToList().Count() + 1;
                }
                else
                {

                }
            }
            catch
            {
                return rowCount.ToString("000");
            }

            return rowCount.ToString("000");
        }

        public string GetTRNo()
        {

            int rowCount = 1;
            try
            {
                if (_db.invItemTransfer.ToList().Count() != null)
                {
                    rowCount = _db.invItemTransfer.ToList().Count() + 1;
                }
                else
                {

                }
            }
            catch
            {
                return rowCount.ToString("000");
            }

            return rowCount.ToString("000");
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> GRNAddOrEdit(Guid id, InvReceive receiveModel)
        {
            //if (ModelState.IsValid)
            //{

                //Update
                if (receiveModel.ReferenceNo != Guid.Empty)
                {
                    try
                    {
                        _db.Update(receiveModel);
                        await _db.SaveChangesAsync();
                    }
                    catch (DbUpdateConcurrencyException)
                    {                       
                         throw; 
                    }

                }
                //Insert                
                else
                {
                    try
                    {
                        receiveModel.ReferenceNo = Guid.NewGuid();
                        InvReceive order1 = new InvReceive();
                        order1 = receiveModel;
                        String GRNNo = GetGRNNo();                        
                        order1.GRNNO = GRNNo;
                        order1.PurchaseOrderNo = "PR-001";
                        order1.PurchasedDate = DateTime.Now;
                        //order1.RecivedBy = "Ahmed";
                        //order1.ApprovedBy = "Kebede";
                        order1.Currencytype = "EBT";
                        order1.SessionID = "";
                        order1.SessionIP = "";
                        order1.SessionMAC = "";    
                        _db.invReceive.Add(order1);
                        //await _db.SaveChangesAsync();
                        List<InvInventoryItem> products = HttpContext.Session.Get<List<InvInventoryItem>>("GRN");
                        if (products != null)
                        {
                            foreach (var product in products)
                            {
                                InvReceiveDetail orderItem = new InvReceiveDetail();
                                orderItem.ReferenceDetailID= Guid.NewGuid();
                                orderItem.ReferenceNo = order1.ReferenceNo;
                                orderItem.ItemID = product.ItemID;
                                orderItem.QtyReceived = product.ReoredrPoint;
                                orderItem.UnitPrice = decimal.Parse(product.UnitCost.ToString());
                                orderItem.UnitMeasure = product.UnitMeasure;
                                orderItem.Remark = "";
                                _db.invReceiveDetail.Add(orderItem);
                                
                            }
                        }

                        await _db.SaveChangesAsync();
                        HttpContext.Session.Set("GRN", new List<InvInventoryItem>());
                    }
                    catch (DbUpdateConcurrencyException)
                    {
                        throw;
                    }                
            }
            return RedirectToAction("Index");
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> ISVAddOrEdit(Guid id, InvItemIssue issueModel)
        {
            //if (ModelState.IsValid)
            //{

            //Update
            if (issueModel.ItemIssueID != Guid.Empty)
            {
                try
                {
                    _db.Update(issueModel);
                    await _db.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    throw;
                }

            }
            //Insert                
            else
            {
                try
                {
                    issueModel.ItemIssueID = Guid.NewGuid();
                    InvItemIssue order1 = new InvItemIssue();
                    order1 = issueModel;
                    String ISVNo = GetISVNo();
                    order1.IssueNumber = ISVNo;
                    order1.EquipmentID = 1;
                    order1.DivisionID = 1;
                    order1.SectionID = 1;
                    order1.SessionID = "";
                    order1.SessionIP = "";
                    order1.SessionMAC = "";
                    _db.invItemIssue.Add(order1);
                    //await _db.SaveChangesAsync();
                    List<InvInventoryItem> products = HttpContext.Session.Get<List<InvInventoryItem>>("ISV");
                    if (products != null)
                    {
                        foreach (var product in products)
                        {
                            InvItemIssueDetail orderItem = new InvItemIssueDetail();
                            orderItem.ItemIssueDetailId = Guid.NewGuid();
                            orderItem.ItemIssueID = order1.ItemIssueID;
                            orderItem.ItemID = product.ItemID;
                            orderItem.Qty = product.ReoredrPoint;
                            orderItem.UnitPrice = decimal.Parse(product.UnitCost.ToString());
                            orderItem.UnitMeasure = product.UnitMeasure;
                            orderItem.Remark = "";
                            _db.invItemIssueDetail.Add(orderItem);

                        }
                    }

                    await _db.SaveChangesAsync();
                    HttpContext.Session.Set("ISV", new List<InvInventoryItem>());
                }
                catch (DbUpdateConcurrencyException)
                {
                    throw;
                }
            }
            return RedirectToAction("Index");
        }

    }
}
