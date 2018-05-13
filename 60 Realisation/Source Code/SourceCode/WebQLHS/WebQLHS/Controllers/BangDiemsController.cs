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
    public class BangDiemsController : Controller
    {
        private QLHocSinhEntities db = new QLHocSinhEntities();

        // GET: BangDiems
        public ActionResult Index()
        {
            var bangDiems = db.BangDiems.Include(b => b.HocSinh).Include(b => b.MonHoc);
            return View(bangDiems.ToList());
        }

        // GET: BangDiems/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            BangDiem bangDiem = db.BangDiems.Find(id);
            if (bangDiem == null)
            {
                return HttpNotFound();
            }
            return View(bangDiem);
        }

        // GET: BangDiems/Create
        public ActionResult Create()
        {
            ViewBag.IDHS = new SelectList(db.HocSinhs, "IDHS", "MaHS");
            ViewBag.MaMH = new SelectList(db.MonHocs, "MaMH", "TenMH");
            return View();
        }

        // POST: BangDiems/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "ID,IDHS,MaMH,Diem15,Diem1Tiet,DiemTB,HocKi")] BangDiem bangDiem)
        {
            if (ModelState.IsValid)
            {   bangDiem.DiemTB=(bangDiem.Diem15+bangDiem.Diem1Tiet*2)/3;
                db.BangDiems.Add(bangDiem);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            ViewBag.IDHS = new SelectList(db.HocSinhs, "IDHS", "MaHS", bangDiem.IDHS);
            ViewBag.MaMH = new SelectList(db.MonHocs, "MaMH", "TenMH", bangDiem.MaMH);
            return View(bangDiem);
        }

        // GET: BangDiems/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            BangDiem bangDiem = db.BangDiems.Find(id);
            if (bangDiem == null)
            {
                return HttpNotFound();
            }
            ViewBag.IDHS = new SelectList(db.HocSinhs, "IDHS", "MaHS", bangDiem.IDHS);
            ViewBag.MaMH = new SelectList(db.MonHocs, "MaMH", "TenMH", bangDiem.MaMH);
            return View(bangDiem);
        }

        // POST: BangDiems/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "ID,IDHS,MaMH,Diem15,Diem1Tiet,DiemTB,HocKi")] BangDiem bangDiem)
        {
            if (ModelState.IsValid)
            { double? diemTB = ((bangDiem.Diem15 + bangDiem.Diem1Tiet * 2) / 3);
                bangDiem.DiemTB = (Math.Round((double)diemTB,3));
                db.Entry(bangDiem).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            ViewBag.IDHS = new SelectList(db.HocSinhs, "IDHS", "MaHS", bangDiem.IDHS);
            ViewBag.MaMH = new SelectList(db.MonHocs, "MaMH", "TenMH", bangDiem.MaMH);
            return View(bangDiem);
        }

        // GET: BangDiems/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            BangDiem bangDiem = db.BangDiems.Find(id);
            if (bangDiem == null)
            {
                return HttpNotFound();
            }
            return View(bangDiem);
        }

        // POST: BangDiems/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            BangDiem bangDiem = db.BangDiems.Find(id);
            db.BangDiems.Remove(bangDiem);
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
    }
}
