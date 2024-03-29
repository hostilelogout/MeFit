﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Mime;
using System.Threading.Tasks;
using AutoMapper;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using webapi.DatabaseContext;
using webapi.Exceptions;
using webapi.Models;
using webapi.Models.DTO.ExerciseDTO;
using webapi.Models.DTO.TrainingprogramDTO;
using webapi.Profiles;
using webapi.Services.ExerciseServices;

namespace webapi.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    [Produces(MediaTypeNames.Application.Json)]
    [Consumes(MediaTypeNames.Application.Json)]
    [ApiConventionType(typeof(DefaultApiConventions))]
    [Authorize]
    public class ExercisesController : ControllerBase
    {
        private readonly IExerciseService _service;
        private readonly IMapper _mapper;

        public ExercisesController(IExerciseService service, IMapper mapper)
        {
            _service = service;
            _mapper = mapper;
        }

        #region basic CRUD
        /// <summary>
        /// Gets all exercises
        /// </summary>
        /// <returns></returns>
        [HttpGet]
        [Authorize(Roles = "Admin,Contributor,Regular")]
        public async Task<ActionResult<IEnumerable<Exercise>>> GetExercises()
        {
            return Ok(_mapper.Map<ICollection<ExerciseReadDto>>(await _service.GetAll()));
        }

        /// <summary>
        /// Gets an exercise by id
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        [HttpGet("{id}")]
        [Authorize(Roles = "Admin,Contributor,Regular")]
        public async Task<ActionResult<Exercise>> GetExercise(int id)
        {
            try
            {
                return Ok(_mapper.Map<ExerciseReadDto>(await _service.GetById(id)));
            }
            catch (EntityNotFoundException ex)
            {
                return NotFound(new ProblemDetails
                {
                    Detail = ex.Message
                });
            }
        }

        /// <summary>
        /// Creates a new exercise 
        /// </summary>
        /// <param name="id"></param>
        /// <param name="exerciseUpdateDto"></param>
        /// <returns></returns>
        [HttpPatch("{id}")]
        [Authorize(Roles = "Admin,Contributor")]
        public async Task<IActionResult> PutExercise(int id, ExerciseUpdateDto exerciseUpdateDto)
        {
            if (id != exerciseUpdateDto.Id)
            {
                return BadRequest();
            }


            try
            {
                var exercise = _mapper.Map<Exercise>(exerciseUpdateDto);
                await _service.Update(exercise);
            }
            catch (EntityNotFoundException ex)
            {
                return NotFound(new ProblemDetails
                {
                    Detail = ex.Message
                });
            }

            return NoContent();
        }

        /// <summary>
        /// Updates an exercise ny id
        /// </summary>
        /// <param name="exerciseCreateDto"></param>
        /// <returns></returns>
        [HttpPost]
        [Authorize(Roles = "Admin,Contributor")]
        public async Task<ActionResult<Exercise>> PostExercise(ExerciseCreateDto exerciseCreateDto)
        {
            var exercise = _mapper.Map<Exercise>(exerciseCreateDto);
            await _service.Create(exercise, exerciseCreateDto.SetIds,exerciseCreateDto.MusclegroupIds);
            var exerciseReadDto = _mapper.Map<ExerciseReadDto>(exercise);
            return CreatedAtAction(nameof(GetExercise), new { id = exercise.Id }, exerciseReadDto);
        }


        /// <summary>
        /// Delets an exercise ny id
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        [HttpDelete("{id}")]
        [Authorize(Roles = "Admin,Contributor")]
        public async Task<IActionResult> DeleteExercise(int id)
        {
            try
            {
                await _service.DeleteById(id);
            }
            catch (EntityNotFoundException ex)
            {
                return NotFound(new ProblemDetails
                {
                    Detail = ex.Message
                });
            }

            return NoContent();
        }


        /// <summary>
        /// Updates exercise musclegroup by exercise id
        /// </summary>
        /// <param name="musclegroups"></param>
        /// <returns></returns>
        [HttpPatch("{id}/musclegroups")]
        [Authorize(Roles = "Admin,Contributor")]
        public async Task<ActionResult<Exercise>> PatchExerciseMusclegroups(int id, ExerciseUpdateMusclegroupsDto exerciseUpdateMusclegroupsDto)
        {
            try
            {
                await _service.UpdateExerciseMusclegroups(id, exerciseUpdateMusclegroupsDto.Musclegroups);
            }
            catch (EntityNotFoundException ex)
            {
                return NotFound(new ProblemDetails
                {
                    Detail = ex.Message
                });
            }

            return NoContent();
        }

        /// <summary>
        /// Updates exercise sets by exercise id
        /// </summary>
        /// <param name="sets"></param>
        /// <returns></returns>
        [HttpPatch("{id}/sets")]
        [Authorize(Roles = "Admin,Contributor")]
        public async Task<ActionResult<Exercise>> PatchExerciseSets(int id, ExerciseUpdateSetsDto exerciseUpdateSetsDto)
        {
            try
            {
                await _service.UpdateExerciseSets(id, exerciseUpdateSetsDto.Sets);
            }
            catch (EntityNotFoundException ex)
            {
                return NotFound(new ProblemDetails
                {
                    Detail = ex.Message
                });
            }

            return NoContent();
        }
        #endregion

    }
}
