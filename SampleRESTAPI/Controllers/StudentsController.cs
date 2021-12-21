﻿using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using SampleRESTAPI.Data;
using SampleRESTAPI.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace SampleRESTAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class StudentsController : ControllerBase
    {
        private IStudent _student;
        public StudentsController(IStudent student)
        {
            _student = student;
        }
       

        [HttpGet]
        public async Task<IEnumerable<Student>> Get()
        {
            var results = await _student.GetAll();
            return results;
        }

        [HttpGet("{id}")]
        public async Task<Student> Get(int id)
        {
            var result = await _student.GetById(id.ToString());
            return result;
        }

        [HttpPost]
        public async Task<IActionResult> Post([FromBody]Student student)
        {
            try
            {
                var result = await _student.Insert(student);
                return Ok(result);
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }

       
    }
}
