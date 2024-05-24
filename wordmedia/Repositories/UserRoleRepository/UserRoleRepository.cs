using Dapper;
using wordmedia.Dtos.UserDtos;
using wordmedia.Dtos.UserRoleDtos;
using wordmedia.Dtos.WordsDtos;
using wordmedia.Model.DapperContext;

namespace wordmedia.Repositories.UserRoleRepository
{
    public class UserRoleRepository: IUserRoleRepository
    {
        private readonly Context _context;

        public UserRoleRepository(Context context)
        {
            _context = context;
        } 

        public async Task<UserRoleDto> GetUserRoleId(int id) 
        {
            string query = "Select * From userrole Where userroleid=@userroleId";
            var parameters = new DynamicParameters(query);
            parameters.Add("@userroleId", id);
            using (var connection = _context.CreatConnection())
            {
                var values = await connection.QueryFirstOrDefaultAsync<UserRoleDto>(query, parameters);
                return values;
            }
        }

   
    }
}
