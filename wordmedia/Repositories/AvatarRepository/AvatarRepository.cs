using Dapper;
using wordmedia.Dtos.AvatarDtos;
using wordmedia.Model.DapperContext;

namespace wordmedia.Repositories.AvatarRepository
{
    public class AvatarRepository : IAvatarRepository
    {
        private readonly Context _context;

        public AvatarRepository(Context context)
        {
            _context = context;
        }
        public async Task<List<AvatarDto>> GetAllAvatar()
        {
            string query = "Select * From Avatars";
            using (var connection = _context.CreatConnection()) 
            {
                var values = await connection.QueryAsync<AvatarDto>(query);
                return values.ToList();
            }
        }
        public async Task<AvatarDto> GetAvatarWithId(int id)
        {
            string query = "Select * From Avatars Where AvatarId=@avatarId";
            var parameters = new DynamicParameters(query);
            parameters.Add("@avatarId", id);
            using (var connection = _context.CreatConnection())
            {
                var values = await connection.QueryFirstOrDefaultAsync<AvatarDto>(query, parameters);
                return values;
            }
        }
    }
}
