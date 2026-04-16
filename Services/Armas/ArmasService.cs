using AppRpgEtec.Models;
using System;
using System.Text;
using System.Collections.Generic;
using System.Collections.ObjectModel;


namespace AppRpgEtec.Services.Armas
{
    public class ArmasService : Request
    {
        private readonly Request _request;
        private const string apiUrlBase = "http://luizsilva12.somee.com/RpgApi/Armas";

        private string _token;

        public ArmasService(string token)
        {
            _request = new Request();
            _token = token;
        }
        public async Task<int> PostArmaAsync(Arma a)
        {
            return await _request.PostReturnIntAsync(apiUrlBase, a, _token);
        }
        public async Task<ObservableCollection<Arma>> GetArmaAsync()
        {
            string urlComplementar = string.Format("{0}", "/GetAll");
            ObservableCollection<Models.Arma> listaArmas = await
            _request.GetAsync<ObservableCollection<Models.Arma>>(apiUrlBase + urlComplementar,
            _token);
            return listaArmas;
        }
        public async Task<Personagem> GetPersonagemAsync(int personagemId)
        {
            string urlComplementar = string.Format("/{0}", personagemId);
            var personagem = await _request.GetAsync<Models.Personagem>(apiUrlBase +
            urlComplementar, _token);
            return personagem;
        }
        public async Task<int> PutPersonagemAsync(Personagem p)
        {
            var result = await _request.PutAsync(apiUrlBase, p, _token);
            return result;
        }
        public async Task<int> DeletePersonagemAsync(int personagemId)
        {
            string urlComplementar = string.Format("/{0}", personagemId);
            var result = await _request.DeleteAsync(apiUrlBase + urlComplementar, _token);
            return result;
        }
    }
}
