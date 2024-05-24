using wordmedia.Dtos.UserWordsDtos;

namespace wordmedia.Repositories.UserWords
{
    public interface IUserWordsRepository
    {
        Task<int> CreatUserWord(UserWordDto userWordsDto); 
        void DeleteUserWord(int id); 
        void UpdateUserWord(UserWordDto userwordDto);  
        Task<UserWordDto> GetUserWordsId(int id);
        Task<List<UserWordDto>> GetAllUserWords();  
    }
}
 