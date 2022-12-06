using MathParserTest.Models;
using Microsoft.AspNetCore.Mvc;
using org.mariuszgromada.math.mxparser;
using System.Diagnostics;

namespace MathParserTest.Controllers
{
    public class HomeController : Controller
    {
        private readonly ILogger<HomeController> _logger;

        public HomeController(ILogger<HomeController> logger)
        {
            _logger = logger;
        }

        public IActionResult Index()
        {
            string Expression = "1==1 && ";

            Expression += " ";
            Expression += " 1==" + ("ali".Contains("ali")?1:0);
            Expression += " && 3==3";


            Expression a1 = new Expression("3==3 & 1==2");
            Expression a2 = new Expression("3==3 | 1==2");
            Expression a3 = new Expression(Expression);
            Expression a4 = new Expression("3>=6");
            Expression a5 = new Expression("3<6");


            string ValueString = a1.getExpressionString() + " : " + a1.calculate() +
                " <br/> " + a2.getExpressionString() + " : " + a2.calculate() +
                " <br/> " + a3.getExpressionString() + " : " + a3.calculate() +
            " <br/> " + a4.getExpressionString() + " : " + a4.calculate() +
                " <br/> " + a5.getExpressionString() + " : " + a5.calculate();


        ViewBag.Value = ValueString;

            return View();
        }

        public IActionResult Privacy()
        {
            return View();
        }

        [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
        public IActionResult Error()
        {
            return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
        }
    }
}