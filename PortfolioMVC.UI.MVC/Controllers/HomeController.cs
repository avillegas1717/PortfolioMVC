using Microsoft.AspNetCore.Mvc;
using PortfolioMVC.UI.MVC.Models;
using System.Diagnostics;
using MailKit.Net.Smtp;
using MimeKit;
using Microsoft.Extensions.Configuration;




namespace PortfolioMVC.UI.MVC.Controllers
{
    public class HomeController : Controller
    {
        private readonly ILogger<HomeController> _logger;
        private readonly IConfiguration _config;

        public HomeController(ILogger<HomeController> logger, IConfiguration config)
        {
            _logger = logger;
            _config = config;
        }

        
        public IActionResult Index()
        {
            return View();
        }

        public IActionResult About()
        {
            return View();
        }

        public IActionResult Portfolio()
        {
            return View();

        }

        //public IActionResult Portfolio1()
        //{
        //    return View();
        //}

        public IActionResult Classmates()
        {
            return View();
        }

        [HttpGet]
        public IActionResult Contact()
        {
            return View();
        }
        [HttpPost]
        public IActionResult Contact(ContactViewModel cvm)
        {
           
            if (!ModelState.IsValid)
            {        
                return View(cvm);
            }

 
            var mm = new MimeMessage();

        
            string message = $"You have received a new email from your site's contact form!<br/>" +
                $"Sender: {cvm.Name}<br/>Email: {cvm.Email}<br/>Subject: {cvm.Subject}<br/>" +
                $"Message: {cvm.Message}";


            mm.From.Add(new MailboxAddress("Sender", _config.GetValue<string>("Credentials:Email:User")));

            mm.To.Add(new MailboxAddress("Personal", _config.GetValue<string>("Credentials:Email:Recipient")));

            mm.Subject = cvm.Subject;

            mm.Body = new TextPart("HTML") { Text = message };

            using (var client = new SmtpClient())
            {
               
                client.Connect(_config.GetValue<string>("Credentials:Email:Client"));

                //Log in
                client.Authenticate(
                    //Username
                    _config.GetValue<string>("Credentials:Email:User"),
                    //Password
                    _config.GetValue<string>("Credentials:Email:Password")
                );

                try
                {
                    client.Send(mm);
                }
                catch (Exception ex)
                {

                    ViewBag.ErrorMessage = $"There was an error processing your request." +
                        $"Please try again later.<br/>" +
                        $"Error Messsage: {ex.StackTrace}";


                    return View(cvm);
                }
            }


            return View("EmailConfirmation", cvm);
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

        //public IActionResult _DetailsDungeonPartial()
        //{
        //    return PartialView(_DetailsDungeonPartial);
        //}

        //public IActionResult _DetailsAPIPartial()
        //{
        //    return PartialView(_DetailsAPIPartial);
        //}

        //public IActionResult _DetailsSQLPartial()
        //{
        //    return PartialView(_DetailsSQLPartial);
        //}

        //public IActionResult _DetailsStoreFrontPartial()
        //{
        //    return PartialView(_DetailsStoreFrontPartial);
        //}

        //public IActionResult _DetailsTeamPartial()
        //{
        //    return PartialView(_DetailsTeamPartial);
        //}

        //public IActionResult _DetailsToDoPartial()
        //{
        //    return PartialView(_DetailsToDoPartial);
        //}

       
    }
}