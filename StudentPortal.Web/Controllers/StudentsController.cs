using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using StudentPortal.Web.Data;
using StudentPortal.Web.Models;
using StudentPortal.Web.Models.Entites;

namespace StudentPortal.Web.Controllers
{
    public class StudentsController : Controller
    {
        private readonly ApplicationDbContext dbContext;

        public StudentsController(ApplicationDbContext dbContext)
        {
            this.dbContext = dbContext;
        }


        //Getting  add page for creating a student in db
        [HttpGet]
        public IActionResult Add()
        {
            return View();
        }

        //Creating a student in database
        [HttpPost]
        public async Task<IActionResult> Add(AddStudentViewModel viewModel)
        {
            var student = new Student
            {
                Name = viewModel.Name,
                Email = viewModel.Email,
                Phone = viewModel.Phone,
                Subscribed = viewModel.Subscribed
            };

            await dbContext.Students.AddAsync(student);
            await dbContext.SaveChangesAsync();
            return View();
        }


        //Reading or Retrieving Student from Db
        [HttpGet]
        public async Task<IActionResult> List()
        {
            var students = await dbContext.Students.ToListAsync();
            return View(students);
        }


        //First we get student for Updating student 
        [HttpGet]
        public async Task<IActionResult> Edit(Guid id)
        {
            var student = await dbContext.Students.FindAsync(id);

            return View(student);
        }

        //Now updating student using HttpPost method
        [HttpPost]
        public async Task<IActionResult> Edit(Student viewModel)
        {
            var student = await dbContext.Students.FindAsync(viewModel.Id);

            if(student is not null)
            {
                student.Name = viewModel.Name;
                student.Email = viewModel.Email;
                student.Phone = viewModel.Phone;
                student.Subscribed = viewModel.Subscribed;

                await dbContext.SaveChangesAsync();
            }

            //now returning to main action called "List"

            return RedirectToAction("List", "Students");
        }
    }


}
