using AppRpgEtec.Models;
using System;
using System.Collections.Generic;
using System.Text;

namespace AppRpgEtec.Services.Usuarios
{
    public class UsuarioService : Request
    {
        private readonly Request _request;

        private const string _apiUrlBase = "https://xyz.somee.com/RpgApi/Usuarios";

        public UsuarioService()
        {
            _request = new Request();

        }

        public async Task<Usuario> PostRegistrarUsuarioAsync(Usuario u)
        {
            string urlComplementar = "/Registrar";
            u.id = await _request.PostReturnIntAsync(_apiUrlBase + urlComplementar, u, string.Empty);

            return u;
        }

        public async Task<Usuario> PostAutenticarUsuarioAsync (Usuario u)
        {
            string urlComplementar = "/Autenticar";
            u = await _request.PostAsync(_apiUrlBase + urlComplementar, u, string.Empty);

            return u;
        }
    }
}
