using wordmedia.Dtos.AvatarDtos;
using wordmedia.Dtos.UserWordDataDtos;

namespace wordmedia.Repositories.UserDataRepository
{
    public interface IUserWordDataRepository 
    {
        Task<List<UserWordDataDto>> GetAllUserWordData(); 
        Task<UserWordDataDto> GetUserWordDataWithId(int id);
        Task<int> CreatUserWordData(); 
    }
}
