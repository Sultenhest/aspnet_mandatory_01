using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using _1_mandatory_movies.Models;
using _1_mandatory_movies.Models.Entities;

namespace _1_mandatory_movies.Controllers
{
    public class MovieController : Controller
    {
        MovieDbContext db = new MovieDbContext();

        public IActionResult Index()
        {
            IEnumerable<Movie> movies = db.Movies;
            return View( movies );
        }

        //Details
        public IActionResult Details(int id)
        {
            Movie movie = db.Movies.Find(id);
            return View( movie );
        }

        //Create
        [HttpPost]
        public IActionResult Create(Movie movie)
        {
            db.Movies.Add(movie);
            db.SaveChanges();

            return View();
        }

        //Delete
        public IActionResult Delete(int id)
        {
            Movie movie = db.Movies.Find(id);
            return View( movie );
        }

        [HttpPost]
        public IActionResult DeleteConfirmed(int id)
        {
            Movie movie = db.Movies.Find(id);
            db.Movies.Remove(movie);
            db.SaveChanges();
            return RedirectToAction("Index");
        }

        //Update
        public IActionResult Update(int id)
        {
            Movie movie = db.Movies.Find(id);
            return View( movie );
        }

        [HttpPost]
        public IActionResult UpdateConfirmed(Movie updateMovie)
        {
            Movie movie = db.Movies.Find(updateMovie.Id);

            movie.Name = updateMovie.Name;
            movie.Director = updateMovie.Director;
            movie.Year = updateMovie.Year;
            movie.Description = updateMovie.Description;

            db.SaveChanges();
            
            return RedirectToAction("Index");
        }

        //Search
        public IActionResult Search()
        {
            string Name = HttpContext.Request.Query["s"];

            List<Movie> result = new List<Movie>();

            foreach(var movie in db.Movies)
            {
                if(movie.Name.ToLower().Contains( Name.ToLower() ))
                {
                    result.Add(movie);
                }
            }

            ViewBag.list = result;

            return View();
        }
    }
}