using Dapper;
using wordmedia.Dtos.UserDtos;
using wordmedia.Dtos.UserRoleDtos;
using wordmedia.Dtos.UserWordDataDtos;
using wordmedia.Dtos.UserWordsDtos;
using wordmedia.Model.DapperContext;
using wordmedia.Repositories.UserDataRepository;
using wordmedia.Repositories.UserRoleRepository;
using wordmedia.Repositories.UserWords;

namespace wordmedia.Repositories.UserRepository
{
    public class UserRepository : IUserRepository
    {
        private readonly Context _context;
        private readonly IUserWordDataRepository _userWordDataRepository;
        private readonly IUserWordsRepository _userWordsRepository;
        private readonly IUserRoleRepository _userRoleRepository; 

        public UserRepository(Context context,IUserWordDataRepository userWordDataRepository,IUserWordsRepository userWordsRepository,IUserRoleRepository userRoleRepository)
        {
            _context = context;
            _userWordDataRepository = userWordDataRepository;
            _userWordsRepository = userWordsRepository;
            _userRoleRepository = userRoleRepository;
        }
         
        public async void CreatUser(CreateUserDto userDto)
        {
           
            int userWorddataId  = await _userWordDataRepository.CreatUserWordData();
            UserRoleDto userole = await _userRoleRepository.GetUserRoleId(1);
            string query = "insert into users (avatarid,username,password,name,surname,birthdate,status,phone,eposta,lastseen,userroleid,userworddataid) values (@avatarId,@userName,@passWord,@Name,@surName,@birthDate,@statuss,@phonee,@ePosta,@lastSeen,@userroleid,@userworddataid)";
            var paramaters = new DynamicParameters();
            paramaters.Add("avatarId", userDto.avatarid);
            paramaters.Add("userName", userDto.username);
            paramaters.Add("passWord", userDto.password);
            paramaters.Add("Name", userDto.name);
            paramaters.Add("surName", userDto.surname);
            paramaters.Add("birthDate", userDto.birthdate);
            paramaters.Add("statuss", true);
            paramaters.Add("phonee", userDto.phone);
            paramaters.Add("ePosta", userDto.eposta);
            paramaters.Add("lastSeen", DateTime.Now);
            paramaters.Add("userroleid", 1);   
            paramaters.Add("userworddataid", userWorddataId);
            using (var connection = _context.CreatConnection())
            {
                await connection.ExecuteAsync(query, paramaters);
            }

        }

        public async void DeleteUser(int id)
        {
            string query = "Delete From users Where userid=@userId";
            var parameters = new DynamicParameters(query);
            parameters.Add("@userId", id);
            using (var connection = _context.CreatConnection())
            {
                await connection.ExecuteAsync(query, parameters);
            }
        }

        public async Task<List<UserDto>> GetAllUser()
        {
            string query = "Select * From users";
            using (var connection = _context.CreatConnection())
            {
                var values = await connection.QueryAsync<UserDto>(query);
                return values.ToList();
            }
        }

        public async Task<List<UserResultDto>> GetAllUserWithOther()
        {
            string query = "Select userid,avatarpath,username,password,name,surname,birthdate,status,phone,eposta,lastseen,userrole,learnword From users inner join avatars on users.avatarid=avatars.avatarid inner join userrole on users.userroleid=userrole.userroleid inner join userworddata on users.userworddataid=userworddata.userworddataid ";
            using (var connection = _context.CreatConnection())
            {
                var values = await connection.QueryAsync<UserResultDto>(query);
                return values.ToList();
            }
        }
        public async Task<UserResultDto> GetUserWithOtherId(int id)
        {
            string query = "Select userid,avatarid,username,password,name,surname,birthdate,status,phone,eposta,lastseen,userroleid,userworddataid From users inner join avatars on users.avatarid=avatars.avatarid inner join userrole on users.userroleid=userrole.userroleid inner join userworddata on users.userworddataid=userworddata.userworddataid Where userid=@userId";
            var parameters = new DynamicParameters(query);
            parameters.Add("@userId", id);
            using (var connection = _context.CreatConnection())
            {
                var values = await connection.QueryFirstOrDefaultAsync<UserResultDto>(query, parameters);
                return values!;
            }
        }

        public async Task<UserDto> GetUserId(int id)
        {
            string query = "Select * From Users Where userid=@userId";
            var parameters = new DynamicParameters(query);
            parameters.Add("@userId", id);
            using (var connection = _context.CreatConnection())
            {
                var values = await connection.QueryFirstOrDefaultAsync<UserDto>(query, parameters);
                return values!;
            }

        }



        public async void UpdateUser(UpdateUserDto userDto)
        {
            string query = "Update users Set avatarid=@avatarId,username=@userName,password=@passWord,name=@namee,surname=@surName,birthdate=@birthDate,status=@Status,phone=@phonee,eposta=@ePosta,lastseen=@lastSeen,userroleid=@userroleId where userid=@userId";
            var paramaters = new DynamicParameters();
            paramaters.Add("@userId", userDto.userid);
            paramaters.Add("@avatarId", userDto.avatarid);
            paramaters.Add("@userName", userDto.username);
            paramaters.Add("@password", userDto.password);
            paramaters.Add("@namee", userDto.name);
            paramaters.Add("@surName", userDto.surname);
            paramaters.Add("@birthDate", userDto.birthdate);
            paramaters.Add("@Status", userDto.status);
            paramaters.Add("@phonee", userDto.phone);
            paramaters.Add("@ePosta", userDto.eposta);
            paramaters.Add("@lastSeen", userDto.lastseen);
            paramaters.Add("@userroleId", userDto.userroleid);

            using (var connection = _context.CreatConnection())
            {
                await connection.ExecuteAsync(query, paramaters);
            }

        }
    }
}
