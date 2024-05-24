using Dapper;
using wordmedia.Dtos.UserWordDataDtos;
using wordmedia.Dtos.WordsDtos;
using wordmedia.Model.DapperContext;
using wordmedia.Repositories.WordRepository;

namespace wordmedia.Repositories.WordDataRepository
{
    public class WordDataRepository
    {
        private readonly Context _context;

        public WordDataRepository(Context context) 
        {
            _context = context;
        }
        public async Task<int> CreatWordCounter()
        {
            string query = "insert into WordCounter (WordCounter,LearnWordCounter) values (@wordCounter,@learnWordCounter); SELECT CAST(SCOPE_IDENTITY() AS INT)";
            var paramaters = new DynamicParameters();
            paramaters.Add("wordCounter", 0);
            paramaters.Add("learnWordCounter", 0);
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
        public async Task<UserWordDataDto> GetWordCounterId(int id)
        {
            string query = "Select * From WordCounter Where WordCounterId=@wordCounterId";
            var parameters = new DynamicParameters(query);
            parameters.Add("@wordCounterId", id);
            using (var connection = _context.CreatConnection())
            {
                var values = await connection.QueryFirstOrDefaultAsync<UserWordDataDto>(query, parameters);
                return values!;
            }
        }
        public async void DeleteWordCounter(int id)
        {
            string query = "Delete From WordCounter Where WordCounterId=@wordCounterId";
            var parameters = new DynamicParameters(query);
            parameters.Add("@wordCounterId", id);
            using (var connection = _context.CreatConnection())
            {
                await connection.ExecuteAsync(query, parameters);
            }
        }

        public async Task<List<UserWordDataDto>> GetAllWordCounter()
        {
            string query = "Select * From WordCounter";
            using (var connection = _context.CreatConnection())
            {
                var values = await connection.QueryAsync<UserWordDataDto>(query);
                return values.ToList();
            }
        }

    }
}
