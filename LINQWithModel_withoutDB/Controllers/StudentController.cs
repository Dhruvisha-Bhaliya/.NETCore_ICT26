using LINQWithModel_withoutDB.Models;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace LINQWithModel_withoutDB.Controllers
{
    public class StudentController : Controller
    {
        private static List<StudentModel> Students = new List<StudentModel>();

        public StudentController() { 
        
            if(Students.Count == 0)
            {
                Students.Add(
                    new StudentModel
                    {
                        StudentID = 1,
                        StudentName = "Dhruvisha",
                        Marks = 50,
                        City = "Surat"
                    });
                Students.Add(
                    new StudentModel
                    {
                        StudentID = 2,
                        StudentName = "Khushi",
                        Marks = 50,
                        City = "Rajkot"
                    });         
            }
        }

        public ActionResult ShowST()
        {
            return View(Students.Where(s => s.Marks > 70).ToList());
        }

        // GET: StudentController
        public ActionResult Index(int ?Marks,string ?str)
        {
            if (Marks != null)
            {
                if (str != null)
                {
                    var studentlist = Students.Where(s => s.Marks > Marks).Where(s => s.StudentName.Contains(str));
                    return View(studentlist.ToList());
                }
                return View(Students.Where(s => s.Marks > Marks).ToList());
            }
            return View(Students.ToList());
        }

        // GET: StudentController/Details/5
        public ActionResult Details(int id)
        {
            return View(Students.SingleOrDefault(s => s.StudentID == id));
        }

        // GET: StudentController/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: StudentController/Create
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create(StudentModel newStudent)
        {
            try
            {
                Students.Add(newStudent);
                return RedirectToAction(nameof(Index));
            }
            catch
            {
                return View();
            }
        }

        // GET: StudentController/Edit/5
        public ActionResult Edit(int id)
        {
            var student = Students.SingleOrDefault(s => s.StudentID == id);

            if(Students == null)
            {
                return NotFound();
            }
            return View(student);
        }

        // POST: StudentController/Edit/5
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit(int id, StudentModel updateStudent)
        {
            try
            {
                var studentToUpdate = Students.SingleOrDefault(s => s.StudentID == id);

                if (studentToUpdate == null)
                {
                    return NotFound();
                }

                studentToUpdate.StudentName = updateStudent.StudentName;
                studentToUpdate.City = updateStudent.City;
                studentToUpdate.Marks = updateStudent.Marks;

                return RedirectToAction(nameof(Index));
            }
            catch
            {
                return View(updateStudent);
            }
        }

        // GET: StudentController/Delete/5
        public ActionResult Delete(int id)
        {
            return View(Students.SingleOrDefault(s => s.StudentID == id));
        }

        // POST: StudentController/Delete/5
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Delete(int id, IFormCollection collection)
        {
            try
            {
                Students.Remove(Students.SingleOrDefault(s => s.StudentID == id)!);
                return RedirectToAction(nameof(Index));
            }
            catch
            {
                return View();
            }
        }
    }
}
