using wordmedia.Dtos.UserDtos;

namespace wordmedia.Repositories.UserRepository
{
    public interface IUserRepository
    {
        Task<List<UserDto>> GetAllUser();
        void CreatUser(CreateUserDto userDto);
        void DeleteUser(int id);
        void UpdateUser(UpdateUserDto userDto);
        Task<UserDto> GetUserId(int id);
        Task<List<UserResultDto>> GetAllUserWithOther();
    }
}
