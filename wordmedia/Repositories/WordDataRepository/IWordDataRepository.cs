using wordmedia.Dtos.UserWordDataDtos;

namespace wordmedia.Repositories.WordDataRepository
{
    public interface IWordDataRepository
    {
        Task<List<UserWordDataDto>> GetAllWordCounter();
        Task<int> CreatWordCounter();
        void DeleteWordCounter(int id);
        void UpdateWordCounter(UserWordDataDto updateWordCounterDto);
        Task<UserWordDataDto> GetWordCounterId(int id);
        void OneWordAdd(UserWordDataDto wordWithWordCounterDtos);
    }
}
