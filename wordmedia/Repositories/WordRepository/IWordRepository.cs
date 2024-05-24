using wordmedia.Dtos.WordsDtos;

namespace wordmedia.Repositories.WordRepository
{
    public interface IWordRepository
    {
        Task<List<WordsDto>> GetAllWord();
        Task<WordsDto> GetWordId(int id);
        void CreatWord(WordsDto wordWithWordCounterDtos);
        void DeleteWord(int id);
        void UpdateWord(WordsDto wordDto);

    }
}
