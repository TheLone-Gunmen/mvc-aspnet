using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;

// For more information on enabling MVC for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace Movie.Controllers
{
    public class PersonController : Controller
    {

        public IActionResult PersonList()
        {

            string[] lines = System.IO.File.ReadAllLines(@"/Users/silvio/r");

            Student[] estudatesLista = new Student[lines.Length];

            int cont = 0;
            foreach (string line in lines)
            {
                string[] col = line.Split(',');
                estudatesLista[cont] = new Student(Convert.ToInt32(col[0]), col[1], Convert.ToInt32(col[2]));
                cont = cont + 1;
            }


            cont = 0;

            IList<Student> studentList = new List<Student>();
            foreach (Student s in estudatesLista)
            {
                studentList.Add(estudatesLista[cont]);
                cont = cont + 1;
            }

            ViewData["students"] = studentList;

            return View();
        }


        public IActionResult insertStudent()
        {
            return View();
        }

        public IActionResult Insert(int id, string nome, int idade)
        {
            ViewData["Message"] = "cadastrado: " + id + " Nome: " + nome + " Idade:  " + idade;
            ViewData["Nome"] = nome;
            //ViewData["NumTimes"] = numTimes;

            using (System.IO.StreamWriter file =
            new System.IO.StreamWriter(@"/Users/silvio/r", true))
            {
                file.WriteLine(id + "," + nome + "," + idade);
            }

            return View();
        }
        public IActionResult NovaFunc(string name, int numTimes = 1)
        {
            ViewData["Message"] = "Hello " + name;
            ViewData["NumTimes"] = numTimes;

            return View();
        }

        // GET: /<controller>/
        public IActionResult PersonView()
        {
            //new Movie.Models.Person()
            //return View(new Movie.Models.Person());
            return View();


        }

        [HttpPost]
        public IActionResult GetNicerUrl(string id)
        {
            //return RedirectToAction("Index", new { id = id });
            return Content($"id {id}");
        }

        /*
        [HttpPost]
        public IActionResult Create()
        {
            //string Name
            return Content($"Hello {Name}");
        }*/
    }
}
