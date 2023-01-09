
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
        public IActionResult PropertyManagement()
        {
            IEnumerable<InvSupplier> supplierModel = _db.invSupplier;

            var listOfModels = new ViewModelInventory();
            listOfModels.Suppliers = supplierModel;
            return View(listOfModels);
        }
        public IActionResult InventoryItems()
        {
            IEnumerable<InvInventoryItem> model = _db.invInventoryItem;
            return View("Property/InventoryItems/InventoryItems",model);
        }

        public IActionResult Equipment()
        {
            IEnumerable<InvEquipment> model = _db.invEquipment;
            return View("Property/Equipments/List",model);
        }
        public IActionResult AddEquipment()
        {
            return View("Property/Equipments/Create");
        }
        public IActionResult Suppliers()
        {
            IEnumerable<InvSupplier> model = _db.invSupplier;
            return View("Property/Suppliers/List",model);
        }
        public IActionResult AddSupplier()
        {
            return View("Property/Suppliers/Add");
        }
        public IActionResult EditSupplier(int Id)
        {
            InvSupplier model = _db.invSupplier.Where(e=>e.SupplierID == Id).FirstOrDefault();
            return View("Property/Suppliers/Edit", model);
        }
        public IActionResult DeleteSupplier(int Id)
        {
            InvSupplier model = _db.invSupplier.Where(e => e.SupplierID == Id).FirstOrDefault();
            return View("Property/Suppliers/Remove", model);
        }
        public IActionResult SupplierDetail(int Id)
        {
            InvSupplier model = _db.invSupplier.Where(e => e.SupplierID == Id).FirstOrDefault();
            return View("Property/Suppliers/view", model);
        }
        public IActionResult BinCard(int id)
        {
            string sid = id.ToString();
            IEnumerable<Vw_BinCard> objItemList = _db.vw_BinCard.Select(z => z).Where(s => s.ItemID == sid).ToList(); 
            return View(objItemList);
        }
        public IActionResult Index()
        {
            HttpContext.Session.Set("GRN", new List<InvInventoryItem>());
            try
            { 
                IEnumerable<Vw_Item> objItemList = _db.vw_Item.ToList();
                return View(objItemList);
            }
            catch
            {
                throw;
            }
            
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

        public ActionResult GRNList()
        {
            IEnumerable<Vw_GRNList> objItemList = _db.vw_GRNList.ToList();
            return View(objItemList);
        }

        public ActionResult IssueVoucherList()
        {
            IEnumerable<Vw_ItemIssue> objItemList = _db.vw_ItemIssue.ToList();
            return View(objItemList);
        }
        public ActionResult ItemReturnList()
        {
            IEnumerable<Vw_ItemReturn> objItemList = _db.vw_ItemReturn.ToList();
            return View(objItemList);
        }

        public ActionResult CountList()
        {
            IEnumerable<Vw_Count> objItemList = _db.vw_Count.ToList();
            return View(objItemList);
        }

        public ActionResult AdjustmentList()
        {
            IEnumerable<Vw_Adjustment> objItemList = _db.vw_Adjustment.ToList();
            return View(objItemList);
        }

        public ActionResult ItemTransferList()
        {
            IEnumerable<Vw_ItemTransfer> objItemList = _db.vw_ItemTransfer.ToList();
            return View(objItemList);
        }

        public IActionResult GRNInvoice(Guid? id)
        {
            ViewGRNInvoice mymodel = new ViewGRNInvoice();
            mymodel.receive = _db.invReceive.Find(id);
            mymodel.store = _db.invStore.Find(mymodel.receive.StoreID);
            mymodel.supplier = _db.invSupplier.Find(mymodel.receive.SupplierID);
            mymodel.Registration = _db.employeeRegistration.Find(Guid.Parse(mymodel.receive.ApprovedBy));
            //mymodel.Registration = _db.employeeRegistration.Find(mymodel.receive.ApprovedBy);
            mymodel.vw_ReceiveDetail = _db.vw_ReceiveDetail.Select(z => z).Where(s => s.ReferenceNo == id).ToList();
            

            return View(mymodel);
            //return View();
        }

        public JsonResult Stockchecked(int id)
        {
            List<Vw_Item> products = new List<Vw_Item>();

            var productsFromDb = _db.vw_Item.Find(id);

            if (productsFromDb == null)
            {
                return Json("");

            }

            if (products == null)
            {

                products = new List<Vw_Item>();
            }
            else
            {
                products = HttpContext.Session.Get<List<Vw_Item>>("GRN");
                
            }
            productsFromDb.ReoredrPoint = 1;
            if (products == null)
            {

                products = new List<Vw_Item>();
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
                            //orderItem.UnitMeasure = product.UnitMeasure;
                            orderItem.UnitMeasure = "NN";
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
            TempData["success"] = "Edit Add successfully";
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
                            //orderItem.UnitMeasure = product.UnitMeasure;
                            orderItem.UnitMeasure = "NN";
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
            TempData["success"] = "Edit Add successfully";
            return RedirectToAction("Index");
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DSAddOrEdit(Guid id, InvDisposal disposalModel)
        {
            //if (ModelState.IsValid)
            //{

            //Update
            if (disposalModel.DisposalId != Guid.Empty)
            {
                try
                {
                    _db.Update(disposalModel);
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
                    //disposalModel.i = Guid.NewGuid();
                    InvDisposal order1 = new InvDisposal();
                    order1 = disposalModel;
                   // String ISVNo = GetISVNo();
                    //order1.FinanceDepartment = ISVNo;
                    order1.FinanceDepartment = "";
                    order1.DivisionId = 1;
                    order1.SectionID = 1;
                    order1.SessionID = "";
                    order1.SessionIP = "";
                    order1.SessionMAC = "";
                    _db.invDisposal.Add(order1);
                    //await _db.SaveChangesAsync();
                    List<InvInventoryItem> products = HttpContext.Session.Get<List<InvInventoryItem>>("DS");
                    if (products != null)
                    {
                        foreach (var product in products)
                        {
                            InvDisposalDetail orderItem = new InvDisposalDetail();
                            //orderItem.DisposedId = Guid.NewGuid();
                            orderItem.DisposedId = order1.DisposalId;
                            orderItem.ItemID = product.ItemID;
                            orderItem.QuantityDisposed= double.Parse(product.ReoredrPoint.ToString());
                            orderItem.UnitCost = double.Parse(product.UnitCost.ToString());
                            //orderItem. = product.UnitMeasure;
                            orderItem.Remark = "";
                            _db.invDisposalDetail.Add(orderItem);      

                        }
                    }

                    await _db.SaveChangesAsync();
                    HttpContext.Session.Set("DS", new List<InvInventoryItem>());
                }
                catch (DbUpdateConcurrencyException)
                {
                    throw;
                }
            }
            TempData["success"] = "Edit Add successfully";
            return RedirectToAction("Index");
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> RTAddOrEdit(Guid id, InvItemReturn returnModel)
        {
            //if (ModelState.IsValid)
            //{

            //Update
            if (returnModel.ReturnID != Guid.Empty)
            {
                try
                {
                    _db.Update(returnModel);
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
                    //disposalModel.i = Guid.NewGuid();
                    InvItemReturn order1 = new InvItemReturn();
                    order1 = returnModel;
                    String RTNo = GetRTNo();
                    //order1.FinanceDepartment = ISVNo;
                    order1.DivisionID = 1;
                    order1.SectionID = 1;
                    order1.SessionID = "";
                    order1.SessionIP = "";
                    order1.SessionMAC = "";
                    order1.Reason = "";
                    
                    _db.invItemReturn.Add(order1);
                    //await _db.SaveChangesAsync();
                    List<InvInventoryItem> products = HttpContext.Session.Get<List<InvInventoryItem>>("RT");
                    if (products != null)
                    {
                        foreach (var product in products)
                        {
                            InvItemReturnDetail orderItem = new InvItemReturnDetail();
                            orderItem.ReturnDetailId = Guid.NewGuid();
                            orderItem.ReturnID = order1.ReturnID;
                            orderItem.ItemID = product.ItemID;
                            orderItem.QtyReturned = product.ReoredrPoint;
                            orderItem.UnitPrice = decimal.Parse(product.UnitCost.ToString());
                            //orderItem. = product.UnitMeasure;
                            orderItem.Remark = "";
                            
                            _db.invItemReturnDetail.Add(orderItem);

                        }
                    }

                    await _db.SaveChangesAsync();
                    HttpContext.Session.Set("RT", new List<InvInventoryItem>());
                }
                catch (DbUpdateConcurrencyException)
                {
                    throw;
                }
            }
            TempData["success"] = "Edit Add successfully";
            return RedirectToAction("Index");
        }
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> TRAddOrEdit(Guid id, InvItemTransfer transferModel)
        {
            //if (ModelState.IsValid)
            //{

            //Update
            if (transferModel.TransferId != Guid.Empty)
            {
                try
                {
                    //_db.Update(transferModel);
                    //await _db.SaveChangesAsync();
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
                    InvItemTransfer order1 = new InvItemTransfer();
                    transferModel.TransferId = Guid.NewGuid();
                    order1 = transferModel;
                    String TRNo = GetTRNo();
                    order1.TransferNumber = TRNo;
                    order1.DivisionId = 1;
                    order1.SessionID = "";
                    order1.SessionIP = "";
                    order1.SessionMAC = "";
                    order1.LastUpdated = DateTime.Now;
                    _db.invItemTransfer.Add(order1);
                    //await _db.SaveChangesAsync();
                    List<InvInventoryItem> products = HttpContext.Session.Get<List<InvInventoryItem>>("TR");
                    if (products != null)
                    {
                        foreach (var product in products)
                        {
                            InvItemTransferDetail orderItem = new InvItemTransferDetail();
                            orderItem.TransferDetailID = Guid.NewGuid();
                            orderItem.TransferId = order1.TransferId;
                            orderItem.ItemID = product.ItemID;
                            orderItem.QuantityTransfer = product.ReoredrPoint;
                            orderItem.UnitCost = decimal.Parse(product.UnitCost.ToString());
                            orderItem.LastUpdated=DateTime.Now;
                            orderItem.Remark = "";
                            _db.invItemTransferDetail.Add(orderItem);
                        }
                    }
                    await _db.SaveChangesAsync();
                    HttpContext.Session.Set("TR", new List<InvInventoryItem>());
                }
                catch (DbUpdateConcurrencyException)
                {
                    throw;
                }
            }
            TempData["success"] = "Edit Add successfully";
            return RedirectToAction("Index");
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> COAddOrEdit(Guid id, InvCount countModel)
        {
            //if (ModelState.IsValid)
            //{

            //Update
            if (countModel.CountID != Guid.Empty)
            {
                try
                {
                    _db.Update(countModel);
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
                    //disposalModel.i = Guid.NewGuid();
                    InvCount order1 = new InvCount();
                    order1 = countModel;
                    String TRNo = GetTRNo();
                    //order1.FinanceDepartment = ISVNo;
                    order1.DivisionID = 1;
                    order1.SectionID = 1;
                    order1.SessionID = "";
                    order1.SessionIP = "";
                    order1.SessionMAC = "";
                    order1.StoreKeeper = "";
                    _db.invCount.Add(order1);
                    //await _db.SaveChangesAsync();
                    List<InvInventoryItem> products = HttpContext.Session.Get<List<InvInventoryItem>>("CO");
                    if (products != null)
                    {
                        foreach (var product in products)
                        {
                            InvCountDetail orderItem = new InvCountDetail();
                            orderItem.CountDetailId = Guid.NewGuid();
                            orderItem.CountID = order1.CountID;
                            orderItem.ItemID = product.ItemID;
                            orderItem.PhysicalCount = product.ReoredrPoint;
                            orderItem.UnitPrice = decimal.Parse(product.UnitCost.ToString());
                            //orderItem. = product.UnitMeasure;
                            orderItem.Remark = "";
                            _db.invCountDetail.Add(orderItem);

                        }
                    }

                    await _db.SaveChangesAsync();
                    HttpContext.Session.Set("TR", new List<InvInventoryItem>());
                }
                catch (DbUpdateConcurrencyException)
                {
                    throw;
                }
            }
            TempData["success"] = "Edit Add successfully";
            return RedirectToAction("Index");
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> ADAddOrEdit(Guid id, InvAdjustment adjustmentModel)
        {
            //if (ModelState.IsValid)
            //{

            //Update
            if (adjustmentModel.AdjustmentID != Guid.Empty)
            {
                try
                {
                    _db.Update(adjustmentModel);
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
                    //disposalModel.i = Guid.NewGuid();
                    InvAdjustment order1 = new InvAdjustment();
                    order1 = adjustmentModel;
                    String TRNo = GetAdjNo();
                    //order1.FinanceDepartment = ISVNo;
                    order1.DivisionID = 1;
                    order1.SectionID = 1;
                    order1.SessionID = "";
                    order1.SessionIP = "";
                    order1.SessionMAC = "";
                    order1.Reason = "";
                    _db.invAdjustment.Add(order1);
                    //await _db.SaveChangesAsync();
                    List<InvInventoryItem> products = HttpContext.Session.Get<List<InvInventoryItem>>("AD");
                    if (products != null)
                    {
                        foreach (var product in products)
                        {
                            InvAdjustmentDetail orderItem = new InvAdjustmentDetail();
                            orderItem.AdjustmentDetailId = Guid.NewGuid();
                            orderItem.AdjustmentID = order1.AdjustmentID;
                            orderItem.ItemID = product.ItemID;
                            orderItem.QtyAdjusted = product.ReoredrPoint;
                            orderItem.UnitPrice = decimal.Parse(product.UnitCost.ToString());
                            orderItem.Remark = "";
                            _db.invAdjustmentDetail.Add(orderItem);

                        }
                    }

                    await _db.SaveChangesAsync();
                    HttpContext.Session.Set("TR", new List<InvInventoryItem>());
                }
                catch (DbUpdateConcurrencyException)
                {
                    throw;
                }
            }
            TempData["success"] = "Edit Add successfully";
            return RedirectToAction("Index");
        }

        // GET: Received/Delete/
        public async Task<IActionResult> GrnDelete(Guid? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var grnModel = await _db.invReceive
                .FirstOrDefaultAsync(m => m.ReferenceNo == id);
            if (grnModel == null)
            {
                return NotFound();
            }
            else
            {
                _db.invReceive.Remove(grnModel);
                await _db.SaveChangesAsync();
                TempData["success"] = "Delete successfully";
                return Json(new { isValid = true, html = Helper.RenderRazorViewToString(this, "Index") });
            }
        }

        // GET: ItemIssue/Delete/
        public async Task<IActionResult> ISVDelete(Guid? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var isvModel = await _db.invItemIssue
                .FirstOrDefaultAsync(m => m.ItemIssueID == id);
            if (isvModel == null)
            {
                return NotFound();
            }
            else
            {
                _db.invItemIssue.Remove(isvModel);
                await _db.SaveChangesAsync();
                TempData["success"] = "Delete successfully";
                return Json(new { isValid = true, html = Helper.RenderRazorViewToString(this, "Index") });
            }
        }

        // GET: ItemReturn/Delete/
        public async Task<IActionResult> RTDelete(Guid? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var rtModel = await _db.invItemReturn
                .FirstOrDefaultAsync(m => m.ReturnID == id);
            if (rtModel == null)
            {
                return NotFound();
            }
            else
            {
                _db.invItemReturn.Remove(rtModel);
                await _db.SaveChangesAsync();
                TempData["success"] = "Delete successfully";
                return Json(new { isValid = true, html = Helper.RenderRazorViewToString(this, "Index") });
            }
        }

        // GET: ItemTransfer/Delete/
        public async Task<IActionResult> TRDelete(Guid? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var rtModel = await _db.invItemTransfer
                .FirstOrDefaultAsync(m => m.TransferId == id);
            if (rtModel == null)
            {
                return NotFound();
            }
            else
            {
                _db.invItemTransfer.Remove(rtModel);
                await _db.SaveChangesAsync();
                TempData["success"] = "Delete successfully";
                return Json(new { isValid = true, html = Helper.RenderRazorViewToString(this, "Index") });
            }
        }

        // GET: ItemTransfer/Delete/
        public async Task<IActionResult> CODelete(Guid? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var coModel = await _db.invCount
                .FirstOrDefaultAsync(m => m.CountID == id);
            if (coModel == null)
            {
                return NotFound();
            }
            else
            {
                _db.invCount.Remove(coModel);
                await _db.SaveChangesAsync();
                TempData["success"] = "Delete successfully";
                return Json(new { isValid = true, html = Helper.RenderRazorViewToString(this, "Index") });
            }
        }

        // GET: ItemAdjustment/Delete/
        public async Task<IActionResult> ADDelete(Guid? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var adModel = await _db.invAdjustment
                .FirstOrDefaultAsync(m => m.AdjustmentID == id);
            if (adModel == null)
            {
                return NotFound();
            }
            else
            {
                _db.invAdjustment.Remove(adModel);
                await _db.SaveChangesAsync();
                TempData["success"] = "Delete successfully";
                return Json(new { isValid = true, html = Helper.RenderRazorViewToString(this, "Index") });
            }
        }
    }
}
