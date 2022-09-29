using Microsoft.AspNetCore.Mvc;
using Assignment6.Models;
using Assignment6.DTO.Franchises;
using AutoMapper;
using Assignment6.DTO.Characters;
using Abp.Domain.Entities;
using Assignment6.Services.Franchises;
using System.Net;
using Assignment6.DTO.Movies;

namespace Assignment6.Controllers
{
    [Route("api/franchises")]
    [ApiController]
    [ApiConventionType(typeof(DefaultApiConventions))]
    public class FranchisesController : ControllerBase
    {
        //Uses the franchiseService for the different operations 
        private readonly FranchiseService _service;
        private readonly IMapper _mapper;

        public FranchisesController(FranchiseService service, IMapper mapper)
        {
            _service = service;
            _mapper = mapper;
        }

        // GET: api/Franchises
        /// <summary>
        /// Gets All Franchises 
        /// </summary>
        /// <returns></returns>
        [HttpGet]
        public async Task<ActionResult<IEnumerable<FranchiseReadDTO>>> GetFranchises()
        {
            return Ok(_mapper.Map<List<FranchiseReadDTO>>(
                await _service.GetAllAsync()
                ));
        }

        // GET: api/Franchises/5
        /// <summary>
        /// Gets Franchise By Id 
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        [HttpGet("{id}")]
        public async Task<IActionResult> GetFranchise(int id)
        {
            try
            {
                return Ok(_mapper.Map<FranchiseReadDTO>(
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

        // PUT: api/Franchises/5
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        /// <summary>
        /// Updates existing Franchise in db 
        /// </summary>
        /// <param name="id"></param>
        /// <param name="franchise"></param>
        /// <returns></returns>
        [HttpPut("{id}")]
        public async Task<IActionResult> PutFranchise(int id, FranchisePutDto franchise)
        {
            if (id != franchise.Id)
            {
                return BadRequest();
            }

            try
            {
                await _service.UpdateAsync(
                        _mapper.Map<Franchise>(franchise)
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
        /// Updates movies in franchise 
        /// </summary>
        /// <param name="id"></param>
        /// <param name="moviesIds"></param>
        /// <returns></returns>
       [HttpPut("{id}/movies")]
        public async Task<IActionResult> UpdateMoviesInFranchise(int id, int[] moviesIds)
        {
            try
            {
                await _service.UpdateMoviesAsync(moviesIds, id);
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
        /// Gets all movies in a franchise 
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        [HttpGet("{id}/movies")]
        public async Task<ActionResult<IEnumerable<MovieReadDTO>>> GetMoviesInFranchise(int id)
        {
            try
            {
                return Ok(
                        _mapper.Map<List<MovieReadDTO>>(
                            await _service.GetMoviesAsync(id)
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
        /// <summary>
        /// Gets all characters in a Franchise 
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        [HttpGet("{id}/characters")]
        public async Task<ActionResult<IEnumerable<CharacterReadDTO>>> GetCharactersInFranchise(int id)
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

        // POST: api/Franchises
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        /// <summary>
        /// Creates new Franchise in db 
        /// </summary>
        /// <param name="franchiseDTO"></param>
        /// <returns></returns>
        [HttpPost]
        public async Task<ActionResult<Franchise>> PostFranchise(FranchiseCreateDTO franchiseDTO)
        {
            Franchise franchise = _mapper.Map<Franchise>(franchiseDTO);
            await _service.AddAsync(franchise);
            return CreatedAtAction("GetFranchise", new { id = franchise.Id }, franchise);
        }

        // DELETE: api/Franchises/5
        /// <summary>
        /// Deletes a franchise in db 
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteFranchise(int id)
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
