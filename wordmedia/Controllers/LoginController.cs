using Dapper;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using SweapCard.Tools;
using wordmedia.Model.DapperContext;
using wordmedia.Repositories.LoginDtos;

namespace wordmedia.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class LoginController : ControllerBase
    {
        private readonly Context _context; 
        public LoginController(Context context)
        {
            _context = context; 
        }
        [HttpPost]
        public async Task<IActionResult> SignIn(CreateLoginDto createLoginDto)
        {
            string query = "Select *From users where username=@userName and password=@passWord";
            string query2 = "Select userid From users where username=@userName and password=@passWord";
            var parameters = new DynamicParameters();
          
            parameters.Add("@PassWord",createLoginDto.Password);
            parameters.Add("@userName", createLoginDto.Username);
            using (var connection = _context.CreatConnection())
            {
                var values=await connection.QueryFirstOrDefaultAsync<CreateLoginDto>(query,parameters); 
                if (values!= null) 
                {
                    var values2 = await connection.QueryFirstAsync<GetAppUserIdDto>(query2, parameters);
                    GetCheckAppUserViewModel model = new GetCheckAppUserViewModel();
                    model.username=values.Username;
                    model.Id = values2.UserId;
                    var token = JwtTokenGenerator.GenerateToken(model);
                    return Ok(token);
                }
                else
                {
                    return Ok("Başarısız");
                }
            }
        }
    }
}
