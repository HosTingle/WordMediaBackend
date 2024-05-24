using Dapper;
using wordmedia.Dtos.WordsDtos;
using wordmedia.Model.DapperContext;
using wordmedia.Repositories.UserRepository;

namespace wordmedia.Repositories.WordRepository
{
    public class WordRepository: IWordRepository
    {
        private readonly Context _context;
        private readonly IUserRepository _userRepository;

        public WordRepository(Context context, IUserRepository userRepository)
        {
            _context = context;
            _userRepository = userRepository;

        }


        public async Task<List<WordsDto>> GetAllWord()
        {
            string query = "Select * From words";
            using (var connection = _context.CreatConnection())
            {
                var values = await connection.QueryAsync<WordsDto>(query);
                return values.ToList();
            }

        }
        public async Task<WordsDto> GetWordId(int id)
        {
            string query = "Select * From words Where wordid=@wordId";
            var parameters = new DynamicParameters(query);
            parameters.Add("@wordId", id);
            using (var connection = _context.CreatConnection())
            {
                var values = await connection.QueryFirstOrDefaultAsync<WordsDto>(query, parameters);
                return values!;
            }
        }

        public async void CreatWord(WordsDto wordDto)
        {
            string query = "insert into words (word,wordtranslate,sentence,descriptionword,wordlevel,languageid,typeofword) values (@wordd,@wordTranslate,@sentencee,@descriptionWord,@wordLevel,@languageId,@typeofWord)";
            var paramaters = new DynamicParameters();
            paramaters.Add("wordd", wordDto.word); 
            paramaters.Add("wordTranslate", wordDto.wordtranslate);
            paramaters.Add("sentencee", wordDto.sentence);
            paramaters.Add("descriptionWord", wordDto.descriptionword);
            paramaters.Add("wordLevel", wordDto.wordlevel);
            paramaters.Add("languageId", wordDto.languageid);
            paramaters.Add("typeofWord", wordDto.typeofword);


            using (var connection = _context.CreatConnection())

            {
                await connection.ExecuteAsync(query, paramaters);
            }

        }

        public async void DeleteWord(int id)
        {
            string query = "Delete From words Where wordid=@wordId";
            var parameters = new DynamicParameters(query);
            parameters.Add("@wordId", id);
            using (var connection = _context.CreatConnection())
            {
                await connection.ExecuteAsync(query, parameters);
            }
        }


        public async void UpdateWord(WordsDto wordDto)
        {
            string query = "Update Words Set word=@wordd,wordtranslate=@wordTranslate,sentence=@sentencee,descriptionword=@descriptionWord,wordlevel=@wordLevel,languageid=@languageId,typeofword=@typeofWord where wordid=@wordId";
            var paramaters = new DynamicParameters();
            paramaters.Add("wordId", wordDto.wordid);
            paramaters.Add("wordd", wordDto.word);
            paramaters.Add("wordTranslate", wordDto.wordtranslate);
            paramaters.Add("sentencee", wordDto.sentence);
            paramaters.Add("descriptionWord", wordDto.descriptionword);
            paramaters.Add("wordLevel", wordDto.wordlevel);
            paramaters.Add("languageId", wordDto.languageid);
            paramaters.Add("typeofWord", wordDto.typeofword);
            using (var connection = _context.CreatConnection())
            {
                await connection.ExecuteAsync(query, paramaters);
            }
        }

       
    }


}
