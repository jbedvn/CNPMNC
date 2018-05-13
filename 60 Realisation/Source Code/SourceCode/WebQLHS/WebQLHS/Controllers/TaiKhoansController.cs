using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.Linq;
using System.Net;
using System.Web;
using System.Web.Mvc;
using WebQLHS.Models;

namespace WebQLHS.Controllers
{
    public class TaiKhoansController : Controller
    {
        private QLHocSinhEntities db = new QLHocSinhEntities();

        // GET: TaiKhoans
        public ActionResult Index()
        {
            var taiKhoans = db.TaiKhoans.Include(t => t.GiaoVien).Include(t => t.LoaiTaiKhoan);
            return View(taiKhoans.ToList());
        }

        // GET: TaiKhoans/Details/5
        public ActionResult Details(string id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            TaiKhoan taiKhoan = db.TaiKhoans.Find(id);
            if (taiKhoan == null)
            {
                return HttpNotFound();
            }
            return View(taiKhoan);
        }

        // GET: TaiKhoans/Create
        public ActionResult Create()
        {
            ViewBag.IDGV = new SelectList(db.GiaoViens, "IDGV", "MaGV");
            ViewBag.MaLoai = new SelectList(db.LoaiTaiKhoans, "MaLoai", "TenLoai");
            return View();
        }

        // POST: TaiKhoans/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "TaiKhoan1,MatKhau,IDGV,MaLoai")] TaiKhoan taiKhoan)
        {
            if (ModelState.IsValid)
            {
                db.TaiKhoans.Add(taiKhoan);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            ViewBag.IDGV = new SelectList(db.GiaoViens, "IDGV", "MaGV", taiKhoan.IDGV);
            ViewBag.MaLoai = new SelectList(db.LoaiTaiKhoans, "MaLoai", "TenLoai", taiKhoan.MaLoai);
            return View(taiKhoan);
        }

        // GET: TaiKhoans/Edit/5
        public ActionResult Edit(string id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            TaiKhoan taiKhoan = db.TaiKhoans.Find(id);
            if (taiKhoan == null)
            {
                return HttpNotFound();
            }
            ViewBag.IDGV = new SelectList(db.GiaoViens, "IDGV", "MaGV", taiKhoan.IDGV);
            ViewBag.MaLoai = new SelectList(db.LoaiTaiKhoans, "MaLoai", "TenLoai", taiKhoan.MaLoai);
            return View(taiKhoan);
        }

        // POST: TaiKhoans/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "TaiKhoan1,MatKhau,IDGV,MaLoai")] TaiKhoan taiKhoan)
        {
            if (ModelState.IsValid)
            {
                db.Entry(taiKhoan).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            ViewBag.IDGV = new SelectList(db.GiaoViens, "IDGV", "MaGV", taiKhoan.IDGV);
            ViewBag.MaLoai = new SelectList(db.LoaiTaiKhoans, "MaLoai", "TenLoai", taiKhoan.MaLoai);
            return View(taiKhoan);
        }

        // GET: TaiKhoans/Delete/5
        public ActionResult Delete(string id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            TaiKhoan taiKhoan = db.TaiKhoans.Find(id);
            if (taiKhoan == null)
            {
                return HttpNotFound();
            }
            return View(taiKhoan);
        }

        // POST: TaiKhoans/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(string id)
        {
            TaiKhoan taiKhoan = db.TaiKhoans.Find(id);
            db.TaiKhoans.Remove(taiKhoan);
            db.SaveChanges();
            return RedirectToAction("Index");
        }

        protected override void Dispose(bool disposing)
        {
            if (disposing)
            {
                db.Dispose();
            }
            base.Dispose(disposing);
        }
       
        public ActionResult DangNhap()
        {
            return View();
        }
       [HttpPost]
       public ActionResult DangNhap(FormCollection form)
        {
            string TaiKhoan = form["TaiKhoan"];
            string MatKhau = form["MatKhau"];
          if (TaiKhoan==null||MatKhau==null)
            {
                ViewData["Loi"] = "Tài khoản và mật khẩu không được để trống!";
                return View();
            }
          
            TaiKhoan tk= db.TaiKhoans.Find(TaiKhoan);
             if (tk == null)
                {
                    ViewData["Loi"] = "Tài khoản hoặc mật khẩu không đúng!";
                    return View();
                }
             else
                {

                    Session["TaiKhoan"] = tk.TaiKhoan1;
                    Session["LoaiTK"] = tk.MaLoai;
                    Session["IDGV"] = tk.IDGV;
                    Session["HoTen"] = tk.GiaoVien.Ho + tk.GiaoVien.Ten;
                return RedirectToAction("Index", "BangDieuKhien");
                    
                }


            

        }



    }
}
