using Dapper;
using wordmedia.Dtos.UserWordDtos;
using wordmedia.Dtos.UserWordsDtos;
using wordmedia.Model.DapperContext;
using wordmedia.Repositories.UserRepository;

namespace wordmedia.Repositories.UserWords
{
    public class UserWordsRepository:IUserWordsRepository
    {
        private readonly Context _context;   


        public UserWordsRepository(Context context) 
        {
            _context = context;    
 
        }
         
        public async void CreatUserWord(CreateUserWordDtocs userWordsDto) 
        {           
            string query = "insert into userword (userid,wordid,wordcounter) values (@userId,@wordId,@wordCounter)";
            var paramaters = new DynamicParameters();
            paramaters.Add("userId", userWordsDto.userid);
            paramaters.Add("wordId", userWordsDto.wordid);
            paramaters.Add("wordCounter", 0);
            using (var connection = _context.CreatConnection())
            {
                await connection.ExecuteAsync(query, paramaters);
            }
        }


        public async void DeleteUserWord(int id)
        {
            string query = "Delete From userword Where wordforuserid=@wordforUserId";
            var parameters = new DynamicParameters(query); 
            parameters.Add("@wordforUserId", id); 
            using (var connection = _context.CreatConnection())
            {
                await connection.ExecuteAsync(query, parameters);
            }
        }

        public async Task<List<UserWordDto>> GetAllUserWords()  
        {
            string query = "Select wordforuserid,userid,wordid,wordcounter From userword";
            using (var connection = _context.CreatConnection())
            {
                var values = await connection.QueryAsync<UserWordDto>(query);
                return values.ToList();
            }
        }

        public async Task<List<GetAllWordbyUseridDto>> GetAllWordsbyUserId(int id)
        {
            string query = $"Select * From userword Where userid ={id} Order by wordforuserid asc";
            using (var connection = _context.CreatConnection())
            {
                var values = await connection.QueryAsync<GetAllWordbyUseridDto>(query);
                return values.ToList();
            }
        }

        public async Task<UserWordDto> GetUserWordsId(int id) 
        {
            string query = "Select * From userword Where wordforuserid=@wordforUserId";
            var parameters = new DynamicParameters(query);
            parameters.Add("@wordforUserId", id);
            using (var connection = _context.CreatConnection())
            {
                var values = await connection.QueryFirstOrDefaultAsync<UserWordDto>(query, parameters);
                return values!;
            }
        }

        public async void UpdateUserWord(UserWordDto userwordDto)
        {
            string query = "Update userword Set userid=@userId,wordid=@wordId,wordcounter=@wordCounter where wordforuserid=@wordforUserId";
            var paramaters = new DynamicParameters();
            paramaters.Add("@wordforUserId", userwordDto.wordforuserid);
            paramaters.Add("@userId", userwordDto.userid);
            paramaters.Add("wordId", userwordDto.wordid);
            paramaters.Add("wordCounter", userwordDto.wordcounter);  
            using (var connection = _context.CreatConnection())
            {
                await connection.ExecuteAsync(query, paramaters);
            }
        }
      
    }
}
