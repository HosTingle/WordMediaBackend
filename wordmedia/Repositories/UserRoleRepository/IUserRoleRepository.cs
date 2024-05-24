using wordmedia.Dtos.UserDtos;
using wordmedia.Dtos.UserRoleDtos;
using wordmedia.Dtos.UserWordDataDtos;

namespace wordmedia.Repositories.UserRoleRepository
{
    public interface IUserRoleRepository
    {

          
        Task<UserRoleDto> GetUserRoleId(int id); 

    }
}
