namespace LoginService.Models
{
    public interface IRegister
    {
        public string? UserName { get; set; }
        public string? Password { get; set; }
        public string CreatePassword(RegistrationDetails registrationDetails);
    }
            
}
