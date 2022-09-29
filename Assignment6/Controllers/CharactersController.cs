using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Assignment6.Models;
using AutoMapper;
using Assignment6.DTO.Characters;
using Assignment6.Services.Characters;
using Abp.Domain.Entities;
using System.Net;

namespace Assignment6.Controllers
{
    [Route("api/characters")]
    [ApiController]
    [ApiConventionType(typeof(DefaultApiConventions))]
    public class CharactersController : ControllerBase
    {
        //Uses the characterService for the different operations 
        private readonly CharacterService _service;
        private readonly IMapper _mapper;

        public CharactersController(CharacterService service, IMapper mapper)
        {
            _service = service;
            _mapper = mapper;
        }

        // GET: api/Characters
        /// <summary>
        /// Gets All Characters 
        /// </summary>
        /// <returns></returns>
        [HttpGet]
        public async Task<ActionResult<IEnumerable<CharacterReadDTO>>> GetCharacters()
        {
            return Ok(_mapper.Map<List<CharacterReadDTO>>(
                await _service.GetAllAsync()
                ));
        }

        // GET: api/Characters/5
        /// <summary>
        /// Gets Character By Id
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        [HttpGet("{id}")]
        public async Task<ActionResult<CharacterReadDTO>> GetCharacter(int id)
        {
            try
            {
                return Ok(_mapper.Map<CharacterReadDTO>(
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

        // PUT: api/Characters/5
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        /// <summary>
        /// Updates existing character in database
        /// </summary>
        /// <param name="id"></param>
        /// <param name="character"></param>
        /// <returns></returns>
        [HttpPut("{id}")]
        public async Task<IActionResult> PutCharacter(int id, CharacterPutDTO character)
        {
            if (id != character.Id)
            {
                return BadRequest();
            }

            try
            {
                await _service.UpdateAsync(
                        _mapper.Map<Character>(character)
                    );
                return NoContent();
            }
            catch (EntityNotFoundException ex)
            {
                // Formatting an error code for the exception messages.
                // Using the built in Problem Details.
                return NotFound(
                    new ProblemDetails()
                    {
                        Detail = ex.Message,
                        Status = ((int)HttpStatusCode.NotFound)
                    }
                    );
            }

        }

        // POST: api/Characters
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        /// <summary>
        /// Creates a new character and adds it to the database
        /// </summary>
        /// <param name="characterDTO"></param>
        /// <returns></returns>
        [HttpPost]
        public async Task<IActionResult> PostCharacter(CharacterCreateDTO characterDTO)
        {
            Character character = _mapper.Map<Character>(characterDTO);
            await _service.AddAsync(character);
            return CreatedAtAction("GetCharacter", new { id = character.Id }, character);

        }

        // DELETE: api/Characters/5
        /// <summary>
        /// Delete a character from the database
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteCharacter(int id)
        {
            try
            {
                await _service.DeleteByIdAsync(id);
                return NoContent();
            }
            catch (EntityNotFoundException ex)
            {
                // Formatting an error code for the exception messages.
                // Using the built in Problem Details.
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
