using Demo_EF.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace Demo_EF.Controllers
{
    public class KhoaController : Controller
    {
        private readonly QlsvContext _context;
        public KhoaController(QlsvContext context)
        {
            _context = context;
        }
        // Read
        public IActionResult Index(int page = 1)
        {
            // pagination: take(5) --- skip((page - 1) * 5)

            int limit = 5;
            int skip = ((page - 1) * limit);

            var item = _context.Khoas.OrderBy(k => k.MaKhoa)
                .Skip(skip)
                .Take(limit)
                .ToList();
            ViewBag.CurrentPage = page;
            return View(item);
        }
        
        // Delete
        public IActionResult Xoa(string? makhoa)
        {
            var itemToRemove = _context.Khoas.FirstOrDefault(x => x.MaKhoa == makhoa); //returns a single item.

            if (itemToRemove != null)
            {
                _context.Khoas.Remove(itemToRemove);
                _context.SaveChanges();
            }
            return RedirectToAction("Index");

        // Update


        } public IActionResult CapNhat(string? makhoa, string? tenkhoa, int? sdt, bool? isUpdate= true)
        {
            var itemToUpdate = _context.Khoas.FirstOrDefault(x => x.MaKhoa == makhoa);

            if (!(bool)isUpdate)
            {
                return View(itemToUpdate);
            }
            else
            {          
                itemToUpdate.TenKhoa = tenkhoa;
                itemToUpdate.Sdt = sdt.ToString();
                _context.Update(itemToUpdate);
                _context.SaveChanges();
                return RedirectToAction("Index");
            }
        }


        // Create
        public IActionResult Them(string? makhoa, string? tenkhoa, int? sdt)
            {
                if(!String.IsNullOrEmpty(makhoa))
                {
                    Khoa khoa = new Khoa();
                    khoa.MaKhoa = makhoa;
                    khoa.TenKhoa = tenkhoa;
                    khoa.Sdt = sdt.ToString();
                    _context.Add(khoa);
                    _context.SaveChanges();
                    return RedirectToAction("Index");
                }
                else
                {
                    Khoa khoa = new Khoa();
                    return View(khoa); 
                }
            }

        public IActionResult Search(string searchData)
       {

            if (!String.IsNullOrEmpty(searchData))
            {
            var searchResults = _context.Khoas
            //.Where(x => EF.Functions.Like(x.Filter, "%" + searchData + "%"))
            .Where(x => x.Filter.Contains(searchData))
            .ToList();
            return Json(searchResults);
            }
            else
            {
            return View();
            }

        }


    }



}
