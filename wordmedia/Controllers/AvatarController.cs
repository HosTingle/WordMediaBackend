using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using wordmedia.Repositories.AvatarRepository;

namespace wordmedia.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class AvatarController : ControllerBase
    {
        private readonly IAvatarRepository _avatarRepository;

        public AvatarController(IAvatarRepository avatarRepository)
        {
            _avatarRepository = avatarRepository;
        }

        [HttpGet("getallAvatars")]
        public async Task<IActionResult> GetallAvatars()
        {
            var values = await _avatarRepository.GetAllAvatar();
            return Ok(values);
        }
        [HttpGet("{id}GetByAvatarId")]
        public async Task<IActionResult> GetAvatarId(int id)
        {
            var value = await _avatarRepository.GetAvatarWithId(id);
            return Ok(value);
        }
    }
}
