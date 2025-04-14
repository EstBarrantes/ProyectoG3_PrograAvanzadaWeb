﻿using System.ComponentModel;

namespace FrontEnd.Models
{
    public class UsuarioViewModel
    {

        public int UsuarioID { get; set; }
        public string? Nombre { get; set; }
        public string? Apellido { get; set; }
        public string? Correo { get; set; }
        public string? Contrasena { get; set; }
        [DisplayName("Rol")]
        public int RolId { get; internal set; }
        public DateTime FechaRegistro { get; set; }
        public bool Activo { get; set; }
        public string? Direccion { get; set; }
        public string? Telefono { get; set; }
        public List<RolViewModel>? listaRoles { get; set; }


    }
}
