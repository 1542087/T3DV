using CreditManagement.Logic;
using CreditManagement.Models;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace CreditManagement.Controllers
{
    public class DealDetailController : Controller
    {

        //
        // GET: /GiaoDich/
        public ActionResult Index()
        {
            Session["MAKH"] = "KH0001";
            return RedirectToAction("DealDetail", "DealDetail");
            
        }

        public ActionResult DealDetail()
        {
            Session["MAKH"] = "KH0001";
            DealDetail model = new DealDetail();
            CTGiaoDich ctgd = new CTGiaoDich();
            model = ctgd.ShowDataToScreen();
            return View(model);
        }

        public ActionResult RutTien(string SoTien)
        {
            return RedirectToAction("DealDetail", "DealDetail");
        }

        public ActionResult ChuyenKhoan(string MaNH, string PhiDV, string NoiDung)
        {
            return RedirectToAction("DealDetail", "DealDetail");
        }
    }
}