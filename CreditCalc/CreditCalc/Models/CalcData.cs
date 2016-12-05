using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using CreditCalc.Models;
using System.ComponentModel.DataAnnotations;

namespace CreditCalc.Models
{
    public class CalcData
    {
        [Required(ErrorMessage = "Пожалуйста, введите сумму")]
        [Display(Prompt = "Сумма кредита в рублях")]
        public decimal CreditCash { get; set; }

        [Required(ErrorMessage = "Пожалуйста, укажите срок кредитования")]
        public int CreditTime { get; set; }

        [Required(ErrorMessage = "Пожалуйста, укажите процентную ставку")]
        public double CreditPercent { get; set; }

        [Required(ErrorMessage = "Пожалуйста, выерите тип расчета")]
        public bool TypeCalc { get; set; }
        public decimal MonPay { get; set; }
        public decimal OverPay { get; set; }
        public decimal FullPay { get; set; }
        public decimal[] MonthlyPay { get; set; }
    }
}