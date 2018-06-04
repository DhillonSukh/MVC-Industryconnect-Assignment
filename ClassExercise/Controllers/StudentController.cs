using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;


namespace ClassExercise.Controllers
{
    public class StudentController : Controller
    {
        public ActionResult Index()
        {
            var context = new DataBaseFirstExampleEntities();
            var student = context.Students.ToList();
            ViewBag.student = student;
            return View();
        }

        public ActionResult create()
        {
            return View();
        }


        [HttpPost]
        public ActionResult create(Student student)
        {
            var context = new DataBaseFirstExampleEntities();
            context.Students.Add(student);
            context.SaveChanges();
            return RedirectToAction("Index", "Student");
        }

        public ActionResult update(int id)
        {
            var context = new DataBaseFirstExampleEntities();
            Student student = context.Students.Where(temp => temp.StudentId == id).FirstOrDefault();
            if(student == null)
            {
                return Content("No data found");
            }
            else
            {
                ViewBag.studentupdate = student;
                return View();
            }
           
        }
        [HttpPost]
        public ActionResult update(Student student,int id)
        {
            var context = new DataBaseFirstExampleEntities();
            Student st = context.Students.Where(temp => temp.StudentId == id).FirstOrDefault();
            st.StudentId = student.StudentId;
            st.StudentName = student.StudentName;
            st.Gender = student.Gender;
            st.Subject = student.Subject;
            st.Fee = student.Fee;
            context.SaveChanges();
            return RedirectToAction("Index", "Student");
        }
        public ActionResult delete(int id)
        {
            var context = new DataBaseFirstExampleEntities();
            Student student = context.Students.Where(temp => temp.StudentId == id).FirstOrDefault();
            if (student == null)
            {
                return Content("No data found");
            }
            else
            {
                ViewBag.studentdelete = student;
                return View();
            }

        }
        [HttpPost]
        public ActionResult delete(Student student, int id)
        {
            var context = new DataBaseFirstExampleEntities();
            Student st = context.Students.Where(temp => temp.StudentId == id).FirstOrDefault();
            context.Students.Remove(st);
            context.SaveChanges();
            return RedirectToAction("Index", "Student");
        }
    }
}