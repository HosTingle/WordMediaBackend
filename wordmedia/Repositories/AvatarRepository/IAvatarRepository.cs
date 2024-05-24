using wordmedia.Dtos.AvatarDtos;

namespace wordmedia.Repositories.AvatarRepository
{
    public interface IAvatarRepository
    {
        Task<List<AvatarDto>> GetAllAvatar();
        Task<AvatarDto> GetAvatarWithId(int id);


    }
}
