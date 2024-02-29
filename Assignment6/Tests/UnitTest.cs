using Assignment6.DTO.Characters;
using Assignment6.Models;
using Assignment6.Services.Characters;
using AutoMapper;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace Assignment6.Tests
{
    [TestClass]
    public class UnitTest
    {
        private readonly CharacterService characterService;
        private readonly IMapper _mapper;
        public UnitTest(CharacterService characterService, IMapper mapper) 
        {
            this.characterService = characterService;
            this._mapper = mapper;
        }
        [TestMethod]
        public void CreateCharacter()
        {
            //Arrange
            var newCharacter = new CharacterCreateDTO()
            {
                Alias = "",
                FullName = "",
                Gender = "",
                Picture = ""
            };
            //Act
            var character = _mapper.Map<Character>(newCharacter);
            var check = characterService.AddAsync(character);
            //Assert
            Assert.IsNotNull(check);
        }
    }
}
