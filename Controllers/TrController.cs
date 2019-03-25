using BRC.Derya.Business.Abstract;
using BRC.Derya.DataAccsess.Abstract;
using BRC.Derya.Entities;
using BRC.Derya.WebUI.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace BRC.Derya.WebUI.Controllers
{
    public class TrController : Controller
    {
        private IIletisimService _iletisimService;
        private IGaleriService _galeriService;
        private IKullaniciService _kullaniciService;
        private IMedyaService _medyaService;
        private ISliderService _sliderService;
        private IUrunlerService _urunlerService;


        public TrController(
            IIletisimService iletisimService,
            IGaleriService galeriService,
            IKullaniciService kullaniciService,
            IMedyaService medyaService,
            ISliderService sliderService,
            IUrunlerService urunlerService)
        {
            _iletisimService = iletisimService;
            _galeriService = galeriService;
            _iletisimService = iletisimService;
            _kullaniciService = kullaniciService;
            _medyaService = medyaService;
            _sliderService = sliderService;
            _urunlerService = urunlerService;
        }
        // GET: Tr
        public ActionResult Index()
        {
            ViewBag.OnlineVisitor = HttpContext.Application["OnlineVisitor"];
            return View();
        }
        public ActionResult Contact()
        {
            ViewBag.OnlineVisitor = HttpContext.Application["OnlineVisitor"];
            //var il = _iletisimService.GetAll();
            //IletisimListViewModel model
            //= new IletisimListViewModel
            //{
            //    iletisims = il
            //};
            //return View(model);
            return View();
        }
        [HttpPost]
        public ActionResult Contact(iletisim iletisim)
        {
            ViewBag.OnlineVisitor = HttpContext.Application["OnlineVisitor"];
            _iletisimService.Add(iletisim);
            return View();
        }
        public ActionResult Products()
        {
            ViewBag.OnlineVisitor = HttpContext.Application["OnlineVisitor"];
            var urunler = _urunlerService.GetAll();
            UrunlerListViewModel model
            = new UrunlerListViewModel 
            {
                Urunlers=urunler
            };
            return View(model);
        }
        public ActionResult Gallery()
        {
            ViewBag.OnlineVisitor = HttpContext.Application["OnlineVisitor"];
            var galeri= _galeriService.GetAll();
            GaleriListViewModel galeriListViewModel 
            = new GaleriListViewModel
            {
                Galeris = galeri
            };
            return View(galeriListViewModel);
        }
        public ActionResult Media()
        {
            ViewBag.OnlineVisitor = HttpContext.Application["OnlineVisitor"];
            var medya = _medyaService.GetAll();
            MedyaListViewModel model   
            = new MedyaListViewModel
            {
                Medyas = medya
            };
            return View(model);
        }
        public ActionResult test()
        {
            return View();
        }
    }
}