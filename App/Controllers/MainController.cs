using App.Database;
using App.Models;
using App.Models.Queries;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Data.SqlClient;

namespace App.Controllers
{
    public class MainController : Controller
    {
        // do not use at home
        // sql injection
        public IActionResult Get(string query)
        {
            DatabaseSession session = null;
            try
            {
                session = new DatabaseSession();
                var repo = new Repository(session.Connection);

                var values = repo.Get(query);

                var result = new QueryResult
                {
                    Query = query,
                    Values = values
                };

                return View(result);
            }
            catch (SqlException)
            {
                return View(new QueryResult { IsCorrect = false });
            }
            finally
            {
                ((IDisposable)session)?.Dispose();
            }
        }

        public IActionResult GetAll()
        {
            return View("GetAll", KR2_queries.GetQueries);
        }

        public IActionResult GetAll2()
        {
            return View("GetAll", KR3_queries.GetQueries);
        }

        public IActionResult GetAll3()
        {
            return View("GetAll", KR4_queries.GetQueries);
        }

        public IActionResult GetAll4()
        {
            return View("GetAll", KR5_queries.GetQueries);
        }
    }
}