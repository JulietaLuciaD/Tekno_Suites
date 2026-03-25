namespace teknoSuite_v02.Services
{
    public class AuthService
    {
        public bool ValidarCredenciales(string email, string password)
        {
             return email == "prueba" && password == "1234";
        }
    }
}