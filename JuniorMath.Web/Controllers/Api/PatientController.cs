﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using JuniorMath.Web.Interfaces.Api;
using JuniorMath.Web.Models;
using JuniorMath.Web.Models.Patients;
using JuniorMath.Web.ViewModels.Patients;

// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace JuniorMath.Web.Controllers.Api
{
    [Authorize]
    [Produces("application/json")]
    [Route("api/[controller]")]
    public class PatientController : Controller
    {
        private readonly IPatientApiService _patientApiService;

        public PatientController(IPatientApiService patientApiService)
        {
            _patientApiService = patientApiService;
        }
        // GET: api/<controller>
        [HttpGet]
        public IEnumerable<string> Get()
        {
            return new string[] { "value1", "value2" };
        }

        // GET api/<controller>/5
        [HttpGet("{id}")]
        public string Get(int id)
        {
            return "value";
        }

        // POST api/<controller>
        [HttpPost]
        public IActionResult Post([FromBody]List<PatientRequestModel> patients)
        {
            var result = _patientApiService.CreateNewPatient(patients);
            return Json(result);
        }

        // POST api/<controller>/PostSearchPatients
        [Route("[action]")]
        [HttpPost]
        public IActionResult PostSearchPatients([FromBody]WebSearchRequestModel webSearchRequestModel)
        {
            var result = _patientApiService.SearchPatients(webSearchRequestModel);
            return Json(result);
        }

        // PUT api/<controller>/5
        [HttpPut("{id}")]
        public void Put(int id, [FromBody]string value)
        {
        }

        // DELETE api/<controller>/5
        [HttpDelete("{id}")]
        public void Delete(int id)
        {
        }
    }
}
