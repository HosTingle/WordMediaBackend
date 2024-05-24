using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using wordmedia.Dtos.WordsDtos;
using wordmedia.Repositories.WordRepository;

namespace wordmedia.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class WordController : ControllerBase
    {
        private readonly IWordRepository _wordRepository;

        public WordController(IWordRepository wordRepository)
        {
            _wordRepository = wordRepository;
        }
        [HttpGet("getallWord")]
        public async Task<IActionResult> WordList()
        {
            var values = await _wordRepository.GetAllWord();
            return Ok(values);
        }

        [HttpGet("{id}GetByWordId")]
        public async Task<IActionResult> GetUserId(int id)
        {
            var value = await _wordRepository.GetWordId(id);
            return Ok(value);
        }

        [HttpPost("CreatWord")]
        public async Task<IActionResult> CreatWord(WordsDto wordsDto) 
        {
            _wordRepository.CreatWord(wordsDto);
            return Ok("Word Oluşturuldu");
        }
        [HttpDelete("DeleteWord")]
        public async Task<IActionResult> DeleteWord(int id)
        {
            _wordRepository.DeleteWord(id);
            return Ok("Word başarılı bir şekilde silindi.");
        }
        [HttpPut("UpdateWord")]
        public async Task<IActionResult> UpdateWord(WordsDto wordsDto)
        {
            _wordRepository.UpdateWord(wordsDto);
            return Ok("Word başarılı bir şekilde güncellendi");
        }
    
    
   
    }
}
