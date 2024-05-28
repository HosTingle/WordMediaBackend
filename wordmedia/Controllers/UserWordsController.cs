using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using wordmedia.Dtos.UserWordDtos;
using wordmedia.Dtos.UserWordsDtos;
using wordmedia.Repositories.UserWords;
using wordmedia.Repositories.WordRepository;

namespace wordmedia.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class UserWordsController : ControllerBase
    {
        private readonly IUserWordsRepository _userWordsRepository; 
         
        public UserWordsController(IUserWordsRepository userWordsRepository) 
        {
            _userWordsRepository = userWordsRepository;

        }
        [HttpGet("GetAllWordsbyUserId")] 
        public async Task<IActionResult> WordList(int id)
        {
            var values = await _userWordsRepository.GetAllWordsbyUserId(id);
            return Ok(values);
        }

        [HttpGet("getallUserWords")]
        public async Task<IActionResult> UserWordList() 
        {
            var values = await _userWordsRepository.GetAllUserWords();
            return Ok(values);
        }
        [HttpPost("CreatUserWords")]
        public async Task<IActionResult> CreatUserWord(CreateUserWordDtocs userWordsDto) 
        {
            _userWordsRepository.CreatUserWord(userWordsDto); 
            return Ok("UserWord Oluşturuldu");
        }
        [HttpDelete("DeleteUserWords")]
        public async Task<IActionResult> DeleteUserWord(int id)
        {
            _userWordsRepository.DeleteUserWord(id);
            return Ok("UserWords başarılı bir şekilde silindi."); 
        }
        [HttpPut("UpdateUserWords")]
        public async Task<IActionResult> UpdateUserWord(UserWordDto userWordsDto)
        {
            _userWordsRepository.UpdateUserWord(userWordsDto);
            return Ok("Word başarılı bir şekilde güncellendi");
        }
        [HttpGet("{id}GetByUserWordsId")]
        public async Task<IActionResult> GetUserId(int id)
        {
            var value = await _userWordsRepository.GetUserWordsId(id);
            return Ok(value);
        }
    
 
    }
}
