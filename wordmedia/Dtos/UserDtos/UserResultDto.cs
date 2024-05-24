namespace wordmedia.Dtos.UserDtos
{
    public class UserResultDto
    {
        public int userid { get; set; } 
        public string avatarpath { get; set; }  

        public string username { get; set; }  

        public string password { get; set; }
        public string name { get; set; }
        public string surname { get; set; } 
        public DateTime birthDate { get; set; }

        public bool status { get; set; }
        public string phone { get; set; } 
        public string eposta { get; set; }
        public DateTime lastseen { get; set; } 
        public string userrole { get; set; } 
        public int learnword { get; set; } 
    }
}
