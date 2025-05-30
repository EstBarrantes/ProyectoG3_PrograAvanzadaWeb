﻿using FrontEnd.ApiModels;
using FrontEnd.Models;

namespace FrontEnd.Helpers.Interfaces
{
    public interface IUsuarioHelper
    {


        List<UsuarioViewModel> GetUsuarios();
        UsuarioViewModel GetUsuario(int? id);
        UsuarioViewModel GetUsuarioByCorreo(string correo);
        UsuarioViewModel Add(UsuarioViewModel usuario);
        UsuarioViewModel Update(UsuarioViewModel usuario);
        void Delete(int id);

        UsuarioAPI Login(string correo, string contra);
    }
}
