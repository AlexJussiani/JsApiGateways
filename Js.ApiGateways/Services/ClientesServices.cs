using Js.ApiGateways.Configurations;
using Js.ApiGateways.Models;
using Microsoft.Extensions.Options;
using System;
using System.Collections.Generic;
using System.Net;
using System.Net.Http;
using System.Threading.Tasks;

namespace Js.ApiGateways.Services
{
    public interface IClientesService
    {
        Task<string> ObterClietePorId(Guid id);
    }
    public class ClientesServices : Service, IClientesService
    {
        private readonly HttpClient _httpClient;

        public ClientesServices(HttpClient httpClient, IOptions<AppServicesSettings> settings)
        {
            _httpClient = httpClient;
            _httpClient.BaseAddress = new Uri(settings.Value.ClienteUrl);
        }

        public async Task<string> ObterClietePorId(Guid id)
        {
            var response1 = await _httpClient.GetAsync($"parceiros/{id}");
            if (response1.StatusCode == HttpStatusCode.NotFound || response1.StatusCode == HttpStatusCode.NoContent) return null;

            TratarErrosResponse(response1);

            var cliente = await DeserializarObjetoResponse<ContasDTO>(response1);

            return cliente.Nome;
        }
    }
}
