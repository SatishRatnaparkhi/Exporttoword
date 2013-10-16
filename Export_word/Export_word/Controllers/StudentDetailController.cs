using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using Export_word.Models;
using System.IO;
using System.Web.UI.WebControls;
using System.Web.UI;

namespace Export_word.Controllers
{
    public class StudentDetailController : Controller
    {
        private Export_Word db = new Export_Word();

        public ActionResult ExportData()
        {
            GridView gv = new GridView();
            gv.DataSource = db.Studentrecord.ToList();
            gv.DataBind();
            Response.ClearContent();
            Response.Buffer = true;
            Response.AddHeader("content-disposition", "attachment; filename=Marklist.doc");
            Response.ContentType = "application/vnd.ms-word ";
            Response.Charset = string.Empty;
            
            StringWriter sw = new StringWriter();
            HtmlTextWriter htw = new HtmlTextWriter(sw);
            gv.RenderControl(htw);
            Response.Output.Write(sw.ToString());
            Response.Flush();
            Response.End();

            return RedirectToAction("StudentDetails");
        }


        //
        // GET: /StudentDetail/

        public ActionResult Index()
        {
            return View(db.Studentrecord.ToList());
        }

        //
        // GET: /StudentDetail/Details/5

        public ActionResult Details(int id = 0)
        {
            StudentDetail studentdetail = db.Studentrecord.Find(id);
            if (studentdetail == null)
            {
                return HttpNotFound();
            }
            return View(studentdetail);
        }

        //
        // GET: /StudentDetail/Create

        public ActionResult Create()
        {
            return View();
        }

        //
        // POST: /StudentDetail/Create

        [HttpPost]
        public ActionResult Create(StudentDetail studentdetail)
        {
            if (ModelState.IsValid)
            {
                db.Studentrecord.Add(studentdetail);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            return View(studentdetail);
        }

        //
        // GET: /StudentDetail/Edit/5

        public ActionResult Edit(int id = 0)
        {
            StudentDetail studentdetail = db.Studentrecord.Find(id);
            if (studentdetail == null)
            {
                return HttpNotFound();
            }
            return View(studentdetail);
        }

        //
        // POST: /StudentDetail/Edit/5

        [HttpPost]
        public ActionResult Edit(StudentDetail studentdetail)
        {
            if (ModelState.IsValid)
            {
                db.Entry(studentdetail).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            return View(studentdetail);
        }

        //
        // GET: /StudentDetail/Delete/5

        public ActionResult Delete(int id = 0)
        {
            StudentDetail studentdetail = db.Studentrecord.Find(id);
            if (studentdetail == null)
            {
                return HttpNotFound();
            }
            return View(studentdetail);
        }

        //
        // POST: /StudentDetail/Delete/5

        [HttpPost, ActionName("Delete")]
        public ActionResult DeleteConfirmed(int id)
        {
            StudentDetail studentdetail = db.Studentrecord.Find(id);
            db.Studentrecord.Remove(studentdetail);
            db.SaveChanges();
            return RedirectToAction("Index");
        }

        protected override void Dispose(bool disposing)
        {
            db.Dispose();
            base.Dispose(disposing);
        }
    }
}