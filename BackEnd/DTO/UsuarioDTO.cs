namespace BackEnd.DTO
{
    public class UsuarioDTO
    {
        public int UsuarioID { get; set; }           
        public string Nombre { get; set; }              
        public string Apellido { get; set; }          
        public string Correo { get; set; }             
        public string Contrasena { get; set; }         
        public int RolId { get; set; }
        
        public DateTime FechaRegistro { get; set; }     
        public bool Activo { get; set; }                
        public string Direccion { get; set; }           
        public string Telefono { get; set; }   
        
        public TokenDTO? Token { get; set; }
    }
}
