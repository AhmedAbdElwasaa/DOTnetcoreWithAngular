using DOTnetcore.Services;
using DOTnetcore.ViewModels;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace DOTnetcore.Controllers
{
    public class AppController:Controller
    {
        private readonly IMailService _mailService;

        public AppController(IMailService mailService)
        {
            _mailService = mailService;
        }
        public IActionResult Index()
        {
            //throw new InvalidOperationException("bad thing happened !!");
            return View();
        }

        [HttpGet("Contact")]
        public IActionResult Contact()
        {

            //throw new InvalidOperationException("bad thinghappen!!");
            return View();
        }

        [HttpPost("Contact")]
        public IActionResult Contact(ContactViewModel myModel)
        {
            if(ModelState.IsValid)
            {
                _mailService.SendMessage("ahmedabdelwasaa@outlook.com", myModel.Subject, myModel.Message);
                ViewBag.UserMessage = "Mail Sent";
                ModelState.Clear();
            }
            else
            {

            }
            return View();
        }

        [HttpGet("About")]
        public IActionResult About()
        {
           
            return View();
        }
    }
}
