using DateMePlease.Data;
using DateMePlease.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace DateMePlease.Controllers
{
    public class HomeController : Controller
    {
        private IDateMePleaseRepository _repository;
        public HomeController(IDateMePleaseRepository repository)
        {
            _repository = repository;
        }

        public ActionResult Index()
        {
            var randomProfiles = _repository.GetRandomProfiles(6);

            var results = from p in randomProfiles
                          select new RandomProfileViewModel
                          {
                              PhotoUrl = p.Photos.Where(i => i.IsMain).FirstOrDefault().Url,
                              LookingFor = p.LookingFor,
                              MemberName = p.Member.MemberName
                          }; 
            
            return View(results.ToList());
        }

        public ActionResult About()
        {
            ViewBag.Message = "Your application description page.";

            return View();
        }

        public ActionResult Contact()
        {
            ViewBag.Message = "Your contact page.";

            return View();
        }

        public ActionResult Acknowledgements()
        {
            return View();
        }
    }
}