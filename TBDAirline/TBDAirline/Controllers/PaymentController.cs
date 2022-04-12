using Microsoft.AspNetCore.Mvc;
using TBDAirline.Data;
using TBDAirline.Models;

namespace TBDAirline.Controllers
{
    public class PaymentController : Controller
    {

        private ApplicationDbContext _context;
        public PaymentController(ApplicationDbContext context)
        {
            _context = context;
        }

        public IActionResult Index(PaymentView PaymentView)
        {
            string total = this.HttpContext.Session.GetString("TotalAmount");
            decimal totalAmount = decimal.Parse(total);
            PaymentView paymentView = new PaymentView();
            paymentView.Payment = new Payment();
            paymentView.Payment.TotalAmount = totalAmount;

            if (PaymentView != null && PaymentView.Payment!= null)
            {
                Payment newPayment = new Payment
                {
                    CardNumber = PaymentView.Payment.CardNumber,
                    CardHolder= PaymentView.Payment.CardHolder,
                    CVV= PaymentView.Payment.CVV,
                    Expiration = PaymentView.Payment.Expiration,
                    TotalAmount = totalAmount,
                };
                _context.Add(newPayment);
                _context.SaveChanges();
                HttpContext.Session.SetInt32("PaymentID", newPayment.PaymentID);
                
                return RedirectToAction("Index", "Reservation");
            }
            
            else return View(paymentView);
        }
    }
}
