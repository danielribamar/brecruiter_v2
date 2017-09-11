using BRecruiter.Web.Core.Models;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;

namespace BRecruiter.Web.Frontend.Controllers
{
    public class CandidatesController : Controller
    {
        [HttpGet]
        public IActionResult Index()
        {
            var candidates = new List<Candidate>()
            {
                new Candidate
                {
                    Id=1,
                    FirstName="Daniel",
                    LastName = "Martins",
                    Email="daniel.martins@tribe.pt",
                    Available = false,
                    Experience=4,
                    Wage = 5000
                },
                new Candidate
                {
                    Id=2,
                    FirstName ="Bárbara",
                    LastName = "Mota",
                    Email="barbaralinaresmota@gmail.com",
                    Available = false,
                    Experience = 8,
                    Wage = 500
                }
            };
            return PartialView(candidates);
        }

        [HttpGet]
        public IActionResult Detail(int id)
        {
            return PartialView(id);
        }

        [HttpGet]
        public IActionResult Edit(int id)
        {
            ViewData["title"] = "Edit";
            var candidate = new Candidate
            {
                Id = 1,
                FirstName = "Daniel",
                LastName = "Martins",
                Email = "daniel.martins@tribe.pt",
                Available = false,
                Experience = 4,
                Wage = 5000,
                Languages = new List<string> { "c#", ".net" },
                Tools = new List<string>()
            };
            return PartialView(candidate);
        }

        [HttpPost]
        public IActionResult Edit(Candidate candidate)
        {
            return Ok(candidate);
        }

        [HttpGet]
        public IActionResult Create()
        {
            ViewData["title"] = "Create";
            return PartialView("Edit", new Candidate(0));
        }

        [HttpPost]
        public IActionResult Create(Candidate candidate)
        {
            return Ok($"O candidato {candidate.FirstName} foi inserido com sucesso.");
        }

        [HttpGet]
        public IActionResult Search([FromQuery]string query)
        {
            var candidates = new List<Candidate>()
            {
                new Candidate
                {
                    Id=1,
                    FirstName="Daniel",
                    LastName = "Martins",
                    Email="daniel.martins@tribe.pt",
                    Available = false,
                    Experience=4,
                    Wage = 5000
                }
            };

            return PartialView("Index", candidates);
        }
    }
}