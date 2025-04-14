namespace BackEnd.DTO
{
    public class LoginDTO
    {
        public string Correo { get; set; }=  null!;
        public string Contrasena { get; set; } = null!;

        public TokenDTO? Token { get; set; }

        public RolDTO? Rol { get; set; }
    }
}
