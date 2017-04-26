using CreditManagement.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace CreditManagement.Controllers
{
    public class GiaoDichController : Controller
    {
        //
        // GET: /GiaoDich/
        public ActionResult Index()
        {
            BankingContext ctx = new BankingContext();
             List<GiaoDich> lst = new List<GiaoDich>();
            lst = ctx.GiaoDich.ToList();

            return View();
        }
    }
}