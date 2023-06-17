using Demo_EF.Models;
using Microsoft.AspNetCore.Mvc;
using System.Diagnostics;

namespace Demo_EF.Controllers
{
    public class HomeController : Controller
    {
        private readonly QlsvContext _context;
        private readonly ILogger<HomeController> _logger;

        public HomeController(ILogger<HomeController> logger, QlsvContext context)
        {
            _logger = logger;
            _context = context;
        }

        public IActionResult Index()
        {
            HomeData data = new HomeData();
            var sv = _context.Sinhviens.ToList();
            var khoa = _context.Khoas.ToList();
            var gv = _context.Giangviens.ToList();

            data.DSSV = sv;
            data.DSK = khoa;
            data.DSGV = gv;

            return View(data);
        }

        public IActionResult _partialSinhVien()
        {
            return PartialView();
        }


        public IActionResult _partialGiangVien()
        {
            return View();
        }
        public IActionResult _partialKhoa()
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