﻿using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using SampleRESTAPI.Data;
using SampleRESTAPI.Dtos;
using SampleRESTAPI.Models;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace SampleRESTAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class UsersController : ControllerBase
    {
        private IUser _user;
        public UsersController(IUser user)
        {
            _user = user;
        }

        [HttpPost]
        public async Task<ActionResult> Registration(CreateUserDto user)
        {
            try
            {
                await _user.Registration(user);
                return Ok($"Registrasi user {user.Username} berhasil");
            }
            catch (System.Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }

        [HttpGet]
        public ActionResult<IEnumerable<UserDto>> GetAll()
        {
            return Ok(_user.GetAllUser());
        }

        [HttpPost("Role")]
        public async Task<ActionResult> AddRole(CreateRoleDto roleDto)
        {
            try
            {
                await _user.AddRole(roleDto.RoleName);
                return Ok($"Tambah role {roleDto.RoleName} berhasil");
            }
            catch (System.Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }

        [HttpGet("Role")]
        public ActionResult<IEnumerable<CreateRoleDto>> GetAllRole()
        {
            return Ok(_user.GetRoles());
        }

        [HttpPost("UserInRole")]
        public async Task<ActionResult> AddUserToRole(string username,string role)
        {
            try
            {
                await _user.AddUserToRole(username, role);
                return Ok($"Berhasil menambahkan user {username} ke role {role}");
            }
            catch (System.Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }
    }
}
