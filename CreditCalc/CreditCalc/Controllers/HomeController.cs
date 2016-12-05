using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using CreditCalc.Models;
using System.Data.Entity;
using CreditCalc.Controllers;

namespace CreditCalc.Controllers
{
    public class HomeController : Controller
    {
        [HttpGet]
        public ViewResult Index()
        {
            return View();
        }
        [HttpPost]
        public ViewResult Index(CalcData calc)
        {
            if (ModelState.IsValid)
            {
                if (calc.TypeCalc)
                {
                    double CreditPercent = calc.CreditPercent / 100 / 12;
                    calc.MonPay = calc.CreditCash * (decimal)CreditPercent / (decimal)(1 - 1 / Math.Pow((1 + CreditPercent), calc.CreditTime));
                    calc.OverPay = calc.MonPay * calc.CreditTime - calc.CreditCash;
                    calc.FullPay = calc.CreditCash + calc.OverPay;
                    return View("Submit", calc);
                }
                else
                {
                    double CreditPercent = calc.CreditPercent / 100 / 12;
                    decimal[] mass = new decimal[calc.CreditTime + 1];
                    for (int p = 1; p <= calc.CreditTime; p++)
                    {
                        mass[p] = calc.CreditCash / calc.CreditTime + calc.CreditCash * (calc.CreditTime - p + 1) * (decimal)CreditPercent / calc.CreditTime;
                    }
                    calc.MonthlyPay = mass;
                    decimal o = 0;
                    foreach (int x in mass) { o = o + x; }
                    calc.OverPay = o - calc.CreditCash;
                    calc.FullPay = calc.OverPay + calc.CreditCash;
                    return View("Submit_Dif", calc);
                }
            }
            else
                return View();
        }
    }
}


