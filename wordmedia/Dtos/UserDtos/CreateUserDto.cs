namespace wordmedia.Dtos.UserDtos
{
    public class CreateUserDto
    {
        public int avatarid { get; set; }
        public string username { get; set; }
        public string password { get; set; }
        public string name { get; set; }
        public string surname { get; set; }
        public DateTime birthdate { get; set; }
        public string phone { get; set; }
        public string eposta { get; set; }
    }
}
