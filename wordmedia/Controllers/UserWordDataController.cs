using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using wordmedia.Dtos.UserWordDataDtos;
using wordmedia.Dtos.UserWordsDtos;
using wordmedia.Repositories.AvatarRepository;
using wordmedia.Repositories.UserDataRepository;
using wordmedia.Repositories.WordDataRepository;

namespace wordmedia.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class UserWordDataController : ControllerBase
    {
        private readonly IUserWordDataRepository _userwordDataRepository;  
         
        public UserWordDataController(IUserWordDataRepository userworddataRepository)  
        {
            _userwordDataRepository = userworddataRepository; 
        }

        [HttpGet("getallUserWordData")]
        public async Task<IActionResult> GetallUserWordData()
        {
            var values = await _userwordDataRepository.GetAllUserWordData();
            return Ok(values);
        }

        [HttpGet("{id}GetByUserWordDataId")]
        public async Task<IActionResult> GetUserWordDataId(int id) 
        {
            var value = await _userwordDataRepository.GetUserWordDataWithId(id);
            return Ok(value);
        }
        [HttpPost("CreatUserWords")]
        public async Task<IActionResult> CreatUserWord()
        {
            await _userwordDataRepository.CreatUserWordData();
            return Ok("UserWord Oluşturuldu");
        }
    }
}
