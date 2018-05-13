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
    public class HocSinhThuocLopsController : Controller
    {
        private QLHocSinhEntities db = new QLHocSinhEntities();

        // GET: HocSinhThuocLops
        public ActionResult Index()
        {
            var hocSinhThuocLops = db.HocSinhThuocLops.Include(h => h.HocSinh).Include(h => h.Lop);
            return View(hocSinhThuocLops.ToList());
        }

        // GET: HocSinhThuocLops/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            HocSinhThuocLop hocSinhThuocLop = db.HocSinhThuocLops.Find(id);
            if (hocSinhThuocLop == null)
            {
                return HttpNotFound();
            }
            return View(hocSinhThuocLop);
        }

        // GET: HocSinhThuocLops/Create
        public ActionResult Create()
        {
            ViewBag.IDHS = new SelectList(db.HocSinhs, "IDHS", "MaHS");
            ViewBag.MaLop = new SelectList(db.Lops, "MaLop", "TenLop");
            return View();
        }

        // POST: HocSinhThuocLops/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "ID,IDHS,MaLop")] HocSinhThuocLop hocSinhThuocLop)
        {
            if (ModelState.IsValid)
            { 
                db.HocSinhThuocLops.Add(hocSinhThuocLop);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            ViewBag.IDHS = new SelectList(db.HocSinhs, "IDHS", "MaHS", hocSinhThuocLop.IDHS);
            ViewBag.MaLop = new SelectList(db.Lops, "MaLop", "TenLop", hocSinhThuocLop.MaLop);
            return View(hocSinhThuocLop);
        }

        // GET: HocSinhThuocLops/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            HocSinhThuocLop hocSinhThuocLop = db.HocSinhThuocLops.Find(id);
            if (hocSinhThuocLop == null)
            {
                return HttpNotFound();
            }
            ViewBag.IDHS = new SelectList(db.HocSinhs, "IDHS", "MaHS", hocSinhThuocLop.IDHS);
            ViewBag.MaLop = new SelectList(db.Lops, "MaLop", "TenLop", hocSinhThuocLop.MaLop);
            return View(hocSinhThuocLop);
        }

        // POST: HocSinhThuocLops/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "ID,IDHS,MaLop")] HocSinhThuocLop hocSinhThuocLop)
        {
            if (ModelState.IsValid)
            {
                db.Entry(hocSinhThuocLop).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            ViewBag.IDHS = new SelectList(db.HocSinhs, "IDHS", "MaHS", hocSinhThuocLop.IDHS);
            ViewBag.MaLop = new SelectList(db.Lops, "MaLop", "TenLop", hocSinhThuocLop.MaLop);
            return View(hocSinhThuocLop);
        }

        // GET: HocSinhThuocLops/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            HocSinhThuocLop hocSinhThuocLop = db.HocSinhThuocLops.Find(id);
            if (hocSinhThuocLop == null)
            {
                return HttpNotFound();
            }
            return View(hocSinhThuocLop);
        }

        // POST: HocSinhThuocLops/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            HocSinhThuocLop hocSinhThuocLop = db.HocSinhThuocLops.Find(id);
            db.HocSinhThuocLops.Remove(hocSinhThuocLop);
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


        public ActionResult LayDanhSachHocSinh(int id)
        {
            if (String.IsNullOrEmpty(id.ToString()) || String.IsNullOrWhiteSpace(id.ToString()))
            {
                return HttpNotFound();
            }
            else
            {
                var danhSachHocSinh = db.HocSinhThuocLops.Where(h=>h.MaLop==id).Include(h => h.HocSinh).Include(h => h.Lop);
                if(danhSachHocSinh==null)
                {
                    return HttpNotFound();
                }
                else
                return PartialView(danhSachHocSinh.ToList());

            }

        }
    }
}
