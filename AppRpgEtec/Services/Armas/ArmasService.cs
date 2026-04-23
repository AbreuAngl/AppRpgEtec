using AppRpgEtec.Models;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Text;

namespace AppRpgEtec.Services.Armas
{
    internal class ArmasService : Request
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
        public async Task<Arma> GetArmaAsync(int armaId)
        {
            string urlComplementar = string.Format("/{0}", armaId);
            var arma = await _request.GetAsync<Models.Arma>(apiUrlBase +
            urlComplementar, _token);
            return arma;
        }
        public async Task<int> PutArmaAsync(Arma a)
        {
            var result = await _request.PutAsync(apiUrlBase, a, _token);
            return result;
        }
        public async Task<int> DeleteArmaAsync(int armaId)
        {
            string urlComplementar = string.Format("/{0}", armaId);
            var result = await _request.DeleteAsync(apiUrlBase + urlComplementar, _token);
            return result;
        }
    }
}
