using Dapper;
using wordmedia.Dtos.AvatarDtos;
using wordmedia.Dtos.UserWordDataDtos;
using wordmedia.Model.DapperContext;

namespace wordmedia.Repositories.UserDataRepository
{
    public class UserWordDataRepository:IUserWordDataRepository
    {
        private readonly Context _context;

        public UserWordDataRepository(Context context)
        {
            _context = context; 
        }

        public async Task<int> CreatUserWordData()
        {
            string query = "insert into userworddata (learnword,knowword,learned) values (@learnWord,@knowWord,@learnedd); SELECT CAST(SCOPE_IDENTITY() AS INT)";
            var paramaters = new DynamicParameters();
            paramaters.Add("learnWord", 0);
            paramaters.Add("knowWord", 0);
            paramaters.Add("learnedd", 0);
            using (var connection = _context.CreatConnection())
            {
                int? result = await connection.QueryFirstOrDefaultAsync<int?>(query, paramaters);
                int? wordCounterId = result;

                if (wordCounterId.HasValue)
                {
                    return wordCounterId.Value;
                }
                else
                {
                    // İşlem başarısız olduysa burada bir hata işleyebilirsiniz.
                    throw new Exception("WordCounter eklenemedi.");
                }
            }
        }

        public async Task<List<UserWordDataDto>> GetAllUserWordData() 
        {
            string query = "select * from userworddata";
            using (var connection = _context.CreatConnection())
            { 
                var values = await connection.QueryAsync<UserWordDataDto>(query);
                return values.ToList(); 
            }
        }
        public async Task<UserWordDataDto> GetUserWordDataWithId(int id)  
        {
            string query = "select * from userworddata where userworddataid=@userworddataId";  
            var parameters = new DynamicParameters(query);
            parameters.Add("@userworddataId", id);  
            using (var connection = _context.CreatConnection())
            {
                var values = await connection.QueryFirstOrDefaultAsync<UserWordDataDto>(query, parameters);
                return values!;
            }
        }
    }
}
