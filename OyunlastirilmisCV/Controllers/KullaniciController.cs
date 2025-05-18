using Microsoft.AspNetCore.Mvc;
using OyunlastirilmisCV.Models;
using OyunlastirilmisCV.DataAccess;
using OyunlastirilmisCV.Entities;
using Microsoft.AspNetCore.Http;
using Microsoft.EntityFrameworkCore;
using OyunlastirilmisCV.Business;
using SelectPdf;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.AspNetCore.Mvc.ViewEngines;
using Microsoft.AspNetCore.Mvc.ViewFeatures;
using Microsoft.AspNetCore.Mvc.Razor;

namespace OyunlastirilmisCV.Web.Controllers
{
    public class KullaniciController : Controller
    {
        private readonly UygulamaDbContext _veritabani;
        private readonly ISeviyeHesaplayici _seviyeHesaplayici;
        private readonly IRazorViewEngine _viewEngine;
        private readonly IServiceProvider _serviceProvider;
        private readonly ITempDataProvider _tempDataProvider;
        private readonly IHttpContextAccessor _httpContextAccessor;
        private readonly UygulamaDbContext _context;
        private readonly IKisilikTestiServisi _kisilikTestiServisi;
        public IActionResult Dashboard()
        {
            var kullaniciId = HttpContext.Session.GetInt32("KullaniciId");

            if (kullaniciId == null)
            {
                return RedirectToAction("Login");
            }

            var kullanici = _veritabani.Kullanicilar
    .Include(k => k.KullaniciBecerileri).ThenInclude(kb => kb.Beceri)
    .Include(k => k.Projeler)
    .Include(k => k.KullaniciRozetleri).ThenInclude(kr => kr.Rozet)
    .FirstOrDefault(k => k.Id == kullaniciId);



            if (kullanici == null)
            {
                return RedirectToAction("Login");
            }

            return View(kullanici);
        }

        public IActionResult Logout()
        {
            HttpContext.Session.Clear();
            return RedirectToAction("Login");
        }



        public KullaniciController(
    UygulamaDbContext veritabani,
    ISeviyeHesaplayici seviyeHesaplayici,
    IRazorViewEngine viewEngine,
    IServiceProvider serviceProvider,
    ITempDataProvider tempDataProvider,
    IHttpContextAccessor httpContextAccessor,
    UygulamaDbContext context,
     IKisilikTestiServisi kisilikTestiServisi)
        {
            _veritabani = veritabani;
            _seviyeHesaplayici = seviyeHesaplayici;
            _viewEngine = viewEngine;
            _serviceProvider = serviceProvider;
            _tempDataProvider = tempDataProvider;
            _httpContextAccessor = httpContextAccessor;
            _context = context;
            _kisilikTestiServisi = kisilikTestiServisi;
        }

        [HttpGet]
        public IActionResult Register()
        {
            return View();
        }

        [HttpPost]
        public IActionResult Register(KullaniciKayitModeli model)
        {
            if (ModelState.IsValid)
            {
                var yeniKullanici = new Kullanici
                {
                    AdSoyad = model.AdSoyad.Trim(),
                    Eposta = model.Eposta.Trim(),
                    Sifre = model.Sifre, 
                    Sinifi = model.Sinif,
                    Seviye = 1
                };

                _veritabani.Kullanicilar.Add(yeniKullanici);
                _veritabani.SaveChanges();

                TempData["KayitBasarili"] = "Kayıt işlemi başarılı. Giriş yapabilirsiniz.";
                return RedirectToAction("Login");
            }

            return View(model);
        }


        [HttpGet]
        public IActionResult Login()
        {
            return View();
        }

        [HttpPost]
        public IActionResult Login(KullaniciGirisModeli model)
        {
            if (ModelState.IsValid)
            {
                var girenKullanici = _veritabani.Kullanicilar
                    .FirstOrDefault(k => k.Eposta == model.Eposta && k.Sifre == model.Sifre);

                if (girenKullanici != null)
                {
                    HttpContext.Session.SetInt32("KullaniciId", girenKullanici.Id);
                    HttpContext.Session.SetString("KullaniciAdi", girenKullanici.AdSoyad);
                    HttpContext.Session.SetString("KullaniciEposta", girenKullanici.Eposta); 

                    TempData["GirisBasarili"] = "Hoş geldin " + girenKullanici.AdSoyad;

                    if (girenKullanici.Eposta == "admin@example.com")
                    {
                        return RedirectToAction("Index", "Admin");
                    }

                    return RedirectToAction("Dashboard", "Kullanici");
                }

                ModelState.AddModelError("", "Geçersiz e-posta veya şifre.");
            }

            return View(model);
        }



        [HttpGet]
        public IActionResult BeceriEkle()
        {
            return View();
        }

        [HttpPost]
        public IActionResult BeceriEkle(BeceriEkleModeli model)
        {
            var kullaniciId = HttpContext.Session.GetInt32("KullaniciId");

            if (kullaniciId == null)
                return RedirectToAction("Login");

            if (ModelState.IsValid)
            {
                //ayni isimde beceri var mı yı kontrol ettik
                var mevcutBeceri = _veritabani.Beceriler.FirstOrDefault(b => b.Ad == model.BeceriAdi);

                if (mevcutBeceri == null)
                {
                    mevcutBeceri = new Beceri
                    {
                        Ad = model.BeceriAdi,
                        ZorlukSeviyesi = model.ZorlukSeviyesi
                    };
                    _veritabani.Beceriler.Add(mevcutBeceri);
                    _veritabani.SaveChanges();
                }

                var yeniIliski = new KullaniciBecerisi
                {
                    KullaniciId = kullaniciId.Value,
                    BeceriId = mevcutBeceri.Id,
                    Seviye = model.Seviye
                };

                _veritabani.Add(yeniIliski);
                _veritabani.SaveChanges();

                var seviye = _seviyeHesaplayici.SeviyeHesapla(kullaniciId.Value);
                var kullanici = _veritabani.Kullanicilar.Find(kullaniciId.Value);
                kullanici.Seviye = seviye;
                _veritabani.SaveChanges();

                //rozet kontroll 
                if (model.Seviye >= 9)
                {
                    var rozet = _veritabani.Rozetler.FirstOrDefault(r => r.Ad == "Usta Beceri");
                    var dahaOnceAlinmis = _veritabani.KullaniciRozetleri.Any(kr => kr.KullaniciId == kullaniciId && kr.RozetId == rozet.Id);

                    if (!dahaOnceAlinmis)
                    {
                        _veritabani.KullaniciRozetleri.Add(new KullaniciRozeti
                        {
                            KullaniciId = kullaniciId.Value,
                            RozetId = rozet.Id,
                            KazanmaTarihi = DateTime.Now
                        });
                        _veritabani.SaveChanges();
                    }
                }

                kullanici.Seviye = _seviyeHesaplayici.SeviyeHesapla(kullaniciId.Value);
                _veritabani.SaveChanges();

                TempData["BeceriEklendi"] = "Beceri başarıyla eklendi.";
                return RedirectToAction("Dashboard");
            }

            return View(model);
        }

        public IActionResult BeceriSil(int id)
        {
            var kullaniciId = HttpContext.Session.GetInt32("KullaniciId");
            var beceri = _veritabani.KullaniciBecerileri.FirstOrDefault(b => b.KullaniciId == kullaniciId && b.BeceriId == id);

            if (beceri != null)
            {
                _veritabani.KullaniciBecerileri.Remove(beceri);
                _veritabani.SaveChanges();
            }

            return RedirectToAction("Dashboard");
        }

        [HttpGet]
        public IActionResult ProjeEkle()
        {
            return View();
        }

        [HttpPost]
        public IActionResult ProjeEkle(ProjeEkleModeli model)
        {
            var kullaniciId = HttpContext.Session.GetInt32("KullaniciId");
            if (kullaniciId == null)
                return RedirectToAction("Login");

            if (ModelState.IsValid)
            {
                var proje = new Proje
                {
                    ProjeAdi = model.ProjeAdi,
                    Aciklama = model.Aciklama,
                    ZorlukSeviyesi = model.ZorlukSeviyesi,
                    KullaniciId = kullaniciId.Value
                };

                _veritabani.Projeler.Add(proje);
                _veritabani.SaveChanges();

                TempData["ProjeEklendi"] = "Proje başarıyla eklendi.";
                return RedirectToAction("Dashboard");
            }

            return View(model);
        }

      

        public IActionResult ProjeSil(int id)
        {
            var kullaniciId = HttpContext.Session.GetInt32("KullaniciId");
            var proje = _veritabani.Projeler.FirstOrDefault(p => p.Id == id && p.KullaniciId == kullaniciId);

            if (proje != null)
            {
                _veritabani.Projeler.Remove(proje);
                _veritabani.SaveChanges();
            }

            return RedirectToAction("Dashboard");
        }


        [HttpGet]
        public IActionResult AvatarSec()
        {
            var kullaniciId = HttpContext.Session.GetInt32("KullaniciId");
            if (kullaniciId == null) return RedirectToAction("Login");

            //
            ViewBag.Avatarlar = new List<string>
    {
        "/img/avatar1.png",
        "/img/avatar2.png",
        "/img/avatar3.png",
        "/img/avatar4.png",
        "/img/avatar5.png"
    };

            return View();
        }

        [HttpPost]
        public IActionResult AvatarSec(string secilenAvatar)
        {
            var kullaniciId = HttpContext.Session.GetInt32("KullaniciId");
            if (kullaniciId == null) return RedirectToAction("Login");

            var kullanici = _veritabani.Kullanicilar.Find(kullaniciId.Value);
            if (kullanici != null)
            {
                kullanici.AvatarUrl = secilenAvatar;
                _veritabani.SaveChanges();
            }

            return RedirectToAction("Dashboard");
        }

        [HttpGet]
        public IActionResult KisilikTesti()
        {
            var kullaniciId = HttpContext.Session.GetInt32("KullaniciId");
            if (kullaniciId == null)
                return RedirectToAction("Login");

            // daha önce test yapılıp yapmadığını kontrol ediyoruz
            var dahaOnceYapildiMi = _veritabani.KisilikTestiSonuclari.Any(x => x.KullaniciId == kullaniciId.Value);
            if (dahaOnceYapildiMi)
            {
                TempData["KisilikTestiMesaj"] = "Kişilik testini zaten tamamladınız.";
                return RedirectToAction("Dashboard");
            }

            var sorular = _veritabani.KisilikTestiSorulari.ToList();
            return View(sorular);
        }


        [HttpPost]
        public IActionResult KisilikTesti(List<KisilikTestiCevapModel> cevaplar)
        {
            var kullaniciId = HttpContext.Session.GetInt32("KullaniciId");
            if (kullaniciId == null) return RedirectToAction("Login");

            // Renklerin toplam puanları
            int mavi = 0, yesil = 0, sari = 0, kirmizi = 0;

            foreach (var cevap in cevaplar)
            {
                mavi += cevap.Mavi;
                yesil += cevap.Yesil;
                sari += cevap.Sari;
                kirmizi += cevap.Kirmizi;
            }

            
            string kisilikRengi = new Dictionary<string, int>
    {
        { "Mavi", mavi },
        { "Yeşil", yesil },
        { "Sarı", sari },
        { "Kırmızı", kirmizi }
    }.OrderByDescending(x => x.Value).First().Key;

            
            var kullanici = _veritabani.Kullanicilar.Find(kullaniciId.Value);
            kullanici.KisilikRengi = kisilikRengi;

            
            _veritabani.KisilikTestiSonuclari.Add(new KisilikTestiSonucu
            {
                KullaniciId = kullaniciId.Value,
                Renk = kisilikRengi,
                Tarih = DateTime.Now
            });

            _veritabani.SaveChanges();

            TempData["KisilikTestiTamamlandi"] = $"Kisilik Testiniz tamamlandi! Renginiz: {kisilikRengi}. Avatar cerceveniz bu renge gore guncellendi.";
            return RedirectToAction("Dashboard");
        }







        public async Task<IActionResult> PdfOlustur()
        {
            var kullaniciId = HttpContext.Session.GetInt32("KullaniciId");
            if (kullaniciId == null) return RedirectToAction("Login");

            var kullanici = _veritabani.Kullanicilar
                .Include(k => k.KullaniciBecerileri).ThenInclude(b => b.Beceri)
                .Include(k => k.Projeler)
                .FirstOrDefault(k => k.Id == kullaniciId);

            if (kullanici == null) return RedirectToAction("Dashboard");

            var html = await RenderViewToStringAsync("PdfCv", kullanici);

            HtmlToPdf converter = new HtmlToPdf();
            PdfDocument doc = converter.ConvertHtmlString(html);
            byte[] pdf = doc.Save();
            doc.Close();

            return File(pdf, "application/pdf", "OyunlastirilmisCV.pdf");
        }


        private async Task<string> RenderViewToStringAsync<TModel>(string viewName, TModel model)
        {
            var actionContext = new ActionContext(_httpContextAccessor.HttpContext, RouteData, ControllerContext.ActionDescriptor);

            using var sw = new StringWriter();

            var viewResult = _viewEngine.FindView(actionContext, viewName, false);
            if (!viewResult.Success)
                throw new InvalidOperationException($"View {viewName} bulunamadı.");

            var viewDictionary = new ViewDataDictionary<TModel>(ViewData, model);
            var tempData = new TempDataDictionary(_httpContextAccessor.HttpContext, _tempDataProvider);

            var viewContext = new ViewContext(
                actionContext,
                viewResult.View,
                viewDictionary,
                tempData,
                sw,
                new HtmlHelperOptions()
            );

            await viewResult.View.RenderAsync(viewContext);
            return sw.ToString();
        }

        public IActionResult Projelerim()
        {
            var kullaniciId = HttpContext.Session.GetInt32("KullaniciId");
            if (kullaniciId == null)
                return RedirectToAction("Login");

            var projeler = _veritabani.KullaniciProjeleri
                .Include(kp => kp.Proje)
                .Where(kp => kp.KullaniciId == kullaniciId)
                .ToList();

            return View(projeler);
        }


    }
}
