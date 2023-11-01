using System.Diagnostics;
using Microsoft.AspNetCore.Mvc;
using BrutNetAPP.Models;

namespace BrutNetAPP.Controllers;

public class HomeController : Controller
{
    private readonly ILogger<HomeController> _logger;
    private int asgari;
    private int vergi;

    public HomeController(ILogger<HomeController> logger)
    {
        _logger = logger;
    }

    public IActionResult Index()
    {
        return View();
    }

    public IActionResult hesap(decimal brut)
    {
        
        asgari = 11250;
        decimal dv_oran = (decimal)0.00759;
        decimal v = brut - asgari;
        int matrah = 0;
        int ogv = 0;
        int sgv = 0;
        decimal dv = 0;
        int issiz_sg = 0;
        int sgkiscic = 0;
        int isverenpay = 0;
        int pek = 0;
        int sgktaban = asgari;
        double sgktavan = asgari * 7.5;
        double net = 0;
        if (brut < asgari)
        {
            net = (int)brut;
            ViewBag.asg = "Brüt Ücret Asgari Ücretten Küçük Olamaz !";
        }
        else
        {
            if (brut >(int)sgktavan)
            {
                int sgktavan1 = (int)sgktavan;
                pek = sgktavan1;
            }
            else
            {
                pek = (int)brut;
            }

            if (brut > 0 )
            {
                sgkiscic = (int)((int)(brut) * 0.14);
                isverenpay = (int)(pek * 0.155);
                ViewBag.SGK = sgkiscic + ",00";
            }
            else
            {
                sgkiscic = 0;
                isverenpay = 0;
            }

            if( brut > asgari)
            {
                matrah = (int)(brut - sgkiscic);
                ogv = (int)(matrah * 0.15);q
                dv = brut* dv_oran;
                issiz_sg = (int)(matrah * 0.01);
                vergi = (int)(ogv + dv + issiz_sg);
            }
            else
            {
                vergi = 0;
            }
            net = (double)(brut - vergi);


            
        }
        ViewBag.brut = brut + ",00";
        ViewBag.net = net + ",00";
        ViewBag.maliyet = brut + isverenpay + issiz_sg + ",00";
        ViewBag.isci = (int)brut * 0.01 + ",00";
        ViewBag.gv = ogv + ",00";
        ViewBag.dv = dv.ToString("0.00");
        return View("Index");


        
    }

    public IActionResult Privacy()
    {
        bordro hesaplayıcı = new bordro();
        hesaplayıcı.brut = 20000;
        hesaplayıcı.sgk_matrah = 





        return View();
    }

    [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
    public IActionResult Error()
    {
        return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
    }
    public class bordro
    {
        public int brut { get; set; }
        public decimal sgk_matrah { get; set; } 
        public decimal vergi_matrah { get; set; }
        public decimal net { get; set; }
        public decimal sgkMatrah
        {
            return  brut * 0.14;
        }
    }
}

