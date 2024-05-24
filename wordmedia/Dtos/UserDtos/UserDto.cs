namespace wordmedia.Dtos.UserDtos
{
    public class UserDto
    {
        public int userid {  get; set; }
        public int avatarid { get; set; }
        public string username {  get; set; }
        public string password { get; set; }
        public string name { get; set; }
        public string surname { get; set; } 
        public DateTime birthdate { get; set; }
        public bool status { get; set; }
        public string phone { get; set; }
        public string eposta { get; set; }
        public DateTime lastseen { get; set; }
        public int userroleid { get; set; }
        public int userworddataid {  get; set; }
    }
}
