using wordmedia.Dtos.UserWordDtos;
using wordmedia.Dtos.UserWordsDtos;

namespace wordmedia.Repositories.UserWords
{
    public interface IUserWordsRepository
    {
        void CreatUserWord(CreateUserWordDtocs userWordsDto); 
        void DeleteUserWord(int id); 
        void UpdateUserWord(UserWordDto userwordDto);  
        Task<UserWordDto> GetUserWordsId(int id);
        Task<List<UserWordDto>> GetAllUserWords();
        Task<List<GetAllWordbyUseridDto>> GetAllWordsbyUserId(int id);
    }
}
 