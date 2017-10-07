using BRecruiter.Web.Core.Models;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;

namespace BRecruiter.Web.Frontend.Controllers
{
    public class CandidatesController : Controller
    {
        private int PageSize = 5;

        [HttpGet]
        public IActionResult Index([FromQuery]int page = 1)
        {
            var viewModel = new CandidatesViewModel();

            viewModel.Candidates = new List<Candidate>();
            for (int index = 0; index < 100; index++)
            {
                viewModel.Candidates.Add(new Candidate
                {
                    Id = index,
                    FirstName = Guid.NewGuid().ToString(),
                    LastName = "Surname",
                    Email = $"daniel.{Guid.NewGuid().ToString()}@tribe.pt",
                    Available = false,
                    Experience = index,
                    Wage = index * 1000
                });
            }

            viewModel.Pagination = new PaginationModel();
            viewModel.Pagination.Page = page;
            viewModel.Pagination.NumberOfRecords = viewModel.Candidates.Count;
            viewModel.Pagination.NumberOfPages = (viewModel.Pagination.NumberOfRecords + PageSize - 1) / PageSize;
            viewModel.Candidates = viewModel.Candidates.Skip(PageSize * (page - 1)).Take(PageSize).ToList();
            return PartialView(viewModel);
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
        public IActionResult Search([FromQuery]string query, int page = 1)
        {
            var viewModel = new CandidatesViewModel();
            viewModel.Candidates = new List<Candidate>()
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

            viewModel.Pagination = new PaginationModel();
            viewModel.Pagination.Page = page;
            viewModel.Pagination.NumberOfRecords = viewModel.Candidates.Count;
            viewModel.Pagination.NumberOfPages = (viewModel.Pagination.NumberOfRecords + PageSize - 1) / PageSize;
            viewModel.Candidates = viewModel.Candidates.Skip(PageSize * (page - 1)).Take(PageSize).ToList();

            return PartialView("Index", viewModel);
        }
    }
}