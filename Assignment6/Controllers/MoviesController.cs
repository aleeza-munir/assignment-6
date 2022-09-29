using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Assignment6.Models;
using AutoMapper;
using Assignment6.DTO.Movies;
using Assignment6.Services.Movies;
using Assignment6.DTO.Characters;
using Abp.Domain.Entities;
using System.Net;

namespace Assignment6.Controllers
{
    [Route("api/movies")]
    [ApiController]
    [ApiConventionType(typeof(DefaultApiConventions))]
    public class MoviesController : ControllerBase
    {
        //Uses the movieservice to implement the different operations 
        private readonly MovieService _service;
        private readonly IMapper _mapper;

        public MoviesController(MovieService service, IMapper mapper)
        {
            _service = service;
            _mapper = mapper;
        }

        // GET: api/Movies
        /// <summary>
        /// Gets All Movies 
        /// </summary>
        /// <returns></returns>
        [HttpGet]
        public async Task<ActionResult<IEnumerable<MovieReadDTO>>> GetMovies()
        {
            return Ok(_mapper.Map<List<MovieReadDTO>>(
                await _service.GetAllAsync()
                ));
        }

        // GET: api/Movies/5
        /// <summary>
        /// Gets movie By Id 
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        [HttpGet("{id}")]
        public async Task<IActionResult> GetMovie(int id)
        {
            try
            {
                return Ok(_mapper.Map<MovieReadDTO>(
                        await _service.GetByIdAsync(id))
                    );
            }
            catch (EntityNotFoundException ex)
            {

                return NotFound(
                    new ProblemDetails()
                    {
                        Detail = ex.Message,
                        Status = ((int)HttpStatusCode.NotFound)
                    }
                    );
            }
        }

        // PUT: api/Movies/5
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        /// <summary>
        /// Updates existing Movie in db
        /// </summary>
        /// <param name="id"></param>
        /// <param name="movie"></param>
        /// <returns></returns>
        [HttpPut("{id}")]
        public async Task<IActionResult> PutMovie(int id, MoviePutDTO movie)
        {
            if (id != movie.Id)
            {
                return BadRequest();
            }

            try
            {
                await _service.UpdateAsync(
                        _mapper.Map<Movie>(movie)
                    );
                return NoContent();
            }
            catch (EntityNotFoundException ex)
            {
                return NotFound(
                    new ProblemDetails()
                    {
                        Detail = ex.Message,
                        Status = ((int)HttpStatusCode.NotFound)
                    }
                    );
            }
        }
        /// <summary>
        /// Updates characters in an existing movie 
        /// </summary>
        /// <param name="id"></param>
        /// <param name="charactersIds"></param>
        /// <returns></returns>
        [HttpPut("{id}/characters")] //Update character in movie 
        public async Task<IActionResult> UpdateCharactersInMovie(int id, int[] charactersIds)
        {
            try
            {
                await _service.UpdateCharactersAsync(charactersIds, id);
                return NoContent();
            }
            catch (EntityNotFoundException ex)
            {
                return NotFound(
                    new ProblemDetails()
                    {
                        Detail = ex.Message,
                        Status = ((int)HttpStatusCode.NotFound)
                    }
                    );
            }

        }
        /// <summary>
        /// Gets all Characters in a movie 
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        [HttpGet("{id}/characters")]
        public async Task<ActionResult<IEnumerable<CharacterReadDTO>>> GetCharactersInMovie(int id)
        {
            try
            {
                return Ok(
                        _mapper.Map<List<CharacterReadDTO>>(
                            await _service.GetCharactersAsync(id)
                        )
                    );
            }
            catch (EntityNotFoundException ex)
            {
                return NotFound(
                    new ProblemDetails()
                    {
                        Detail = ex.Message,
                        Status = ((int)HttpStatusCode.NotFound)
                    }
                    );
            }
        }


        // POST: api/Movies
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        /// <summary>
        /// Creates new movie and adds it to database 
        /// </summary>
        /// <param name="movieDTO"></param>
        /// <param name="movie"></param>
        /// <returns></returns>
        [HttpPost]
        public async Task<ActionResult<Movie>> PostMovie(MovieCreateDTO movieDTO)
        {
            Movie movie = _mapper.Map<Movie>(movieDTO);
            await _service.AddAsync(movie);
            return CreatedAtAction("GetMovie", new { id = movie.Id }, movie);
        }

        // DELETE: api/Movies/5
        /// <summary>
        /// Deletes Movie in db
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteMovie(int id)
        {
            try
            {
                await _service.DeleteByIdAsync(id);
                return NoContent();
            }
            catch (EntityNotFoundException ex)
            {
                return NotFound(
                    new ProblemDetails()
                    {
                        Detail = ex.Message,
                        Status = ((int)HttpStatusCode.NotFound)
                    }
                    );
            }
        }
    }
}
