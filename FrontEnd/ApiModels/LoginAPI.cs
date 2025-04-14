namespace FrontEnd.ApiModels
{
    public class LoginAPI
    {
        public string Correo { get; set; } = null!;
        public string Contrasena { get; set; } = null!;
        public TokenAPI? Token { get; set; }
        public RolAPI? Rol { get; set; }


    }
}
