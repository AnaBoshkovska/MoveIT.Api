namespace MoveIT.Api.Dto
{
    public class AuthenticatedUser : LoginUser
    {
        public string Token { get; set; }
    }
}
