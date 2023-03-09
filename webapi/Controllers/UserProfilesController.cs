﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Mime;
using System.Threading.Tasks;
using AutoMapper;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using webapi.DatabaseContext;
using webapi.Models;
using webapi.Services.UserProfileService;

namespace webapi.Controllers
{
    [Route("api/v1/[controller]")]
    [ApiController]
    [Produces(MediaTypeNames.Application.Json)]
    [Consumes(MediaTypeNames.Application.Json)]
    [ApiConventionType(typeof(DefaultApiConventions))]
    public class UserProfilesController : ControllerBase
    {
        private readonly IUserProfileService _service;
        private readonly IMapper _mapper;

        public UserProfilesController(IUserProfileService service, IMapper mapper)
        {
            _service = service;
            _mapper = mapper;
        }

        // GET: api/UserProfiles
        [HttpGet]
        public async Task<ActionResult<IEnumerable<UserProfile>>> GetUserProfiles()
        {
          if (_service.UserProfiles == null)
          {
              return NotFound();
          }
            return await _service.UserProfiles.ToListAsync();
        }

        // GET: api/UserProfiles/5
        [HttpGet("{id}")]
        public async Task<ActionResult<UserProfile>> GetUserProfile(int id)
        {
          if (_service.UserProfiles == null)
          {
              return NotFound();
          }
            var userProfile = await _service.UserProfiles.FindAsync(id);

            if (userProfile == null)
            {
                return NotFound();
            }

            return userProfile;
        }

        // Patch: api/UserProfiles/5
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPatch("{id}")]
        public async Task<IActionResult> PutUserProfile(int id, UserProfile userProfile)
        {
            if (id != userProfile.Id)
            {
                return BadRequest();
            }

            _service.Entry(userProfile).State = EntityState.Modified;

            try
            {
                await _service.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!UserProfileExists(id))
                {
                    return NotFound();
                }
                else
                {
                    throw;
                }
            }

            return NoContent();
        }

        // POST: api/UserProfiles
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPost]
        public async Task<ActionResult<UserProfile>> PostUserProfile(UserProfile userProfile)
        {
          if (_service.UserProfiles == null)
          {
              return Problem("Entity set 'MeFitContext.UserProfiles'  is null.");
          }
            _service.UserProfiles.Add(userProfile);
            await _service.SaveChangesAsync();

            return CreatedAtAction("GetUserProfile", new { id = userProfile.Id }, userProfile);
        }

        // DELETE: api/UserProfiles/5
        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteUserProfile(int id)
        {
            if (_service.UserProfiles == null)
            {
                return NotFound();
            }
            var userProfile = await _service.UserProfiles.FindAsync(id);
            if (userProfile == null)
            {
                return NotFound();
            }

            _service.UserProfiles.Remove(userProfile);
            await _service.SaveChangesAsync();

            return NoContent();
        }

        private bool UserProfileExists(int id)
        {
            return (_service.UserProfiles?.Any(e => e.Id == id)).GetValueOrDefault();
        }
    }
}