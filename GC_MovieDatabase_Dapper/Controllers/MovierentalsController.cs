using Dapper;
using GC_MovieDatabase_Dapper.Models;
using Microsoft.AspNetCore.Mvc;
using MySqlConnector;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace GC_MovieDatabase_Dapper.Controllers
{
    public class MovierentalsController : Controller
    {
        public IActionResult Index()
        {
            return View();
        }

        public IActionResult Registration()
        {
            return View();
        }

        [HttpPost]
        public IActionResult Registration(Movie m)
        {
            Movie movie = m;
            if (ModelState.IsValid)
            {
                using (var connect = new MySqlConnection(Secret.Connection))
                {
                    string sql = $"insert into movies values({0},'{movie.Title}','{movie.Category}',{movie.Year},{movie.Runtime})";

                    connect.Open();

                    connect.Query(sql);

                    connect.Close();

                    return RedirectToAction("Result", m);
                }
                
            }
            else
            {
                return View();
            }            
        }

        public IActionResult Result(Movie m)
        {
            if (ModelState.IsValid)
            {
                return View(m);
            }
            else
            {
                return RedirectToAction("Registration");
            }
            
        }

        public IActionResult ListMovies()
        {
            List<Movie> movies = new List<Movie>();
            using (var connect = new MySqlConnection(Secret.Connection))
            {
                string sql = "select * from movies";

                connect.Open();

                movies = connect.Query<Movie>(sql).ToList();

                connect.Close();
            }
            return View(movies);
        }

        public IActionResult Search()
        {
            return View();
        }

        [HttpPost]
        public IActionResult SearchByTitle(String s)
        {
            List<Movie> movies = new List<Movie>();
            using (var connect = new MySqlConnection(Secret.Connection))
            {
                string sql = $"select * from movies where Title = '{s}'";

                connect.Open();

                movies = connect.Query<Movie>(sql).ToList();

                connect.Close();
                return RedirectToAction("SearchResult", movies);
            }
        }
        [HttpPost]
        public IActionResult SearchByGenre(String s)
        {
            List<Movie> movies = new List<Movie>();
            using (var connect = new MySqlConnection(Secret.Connection))
            {
                string sql = $"select * from movies where Genre = '{s}'";

                connect.Open();

                movies = connect.Query<Movie>(sql).ToList();

                connect.Close();
               
            }
            return RedirectToAction("SearchResult", movies);
        }

        public IActionResult SearchResult(List<Movie>movies)
        {
            return View(movies);
        }
    }
}
