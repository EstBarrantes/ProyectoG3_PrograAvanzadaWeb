﻿using FrontEnd.ApiModels;
using FrontEnd.Models;

namespace FrontEnd.Helpers.Interfaces
{
    public interface IUsuarioHelper
    {


        List<UsuarioViewModel> GetUsuarios();
        UsuarioViewModel GetUsuario(int? id);
        UsuarioViewModel Add(UsuarioViewModel usuario);
        UsuarioViewModel Update(UsuarioViewModel usuario);
        void Delete(int id);

        LoginAPI Login(string correo, string contra);
    }
}
