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
    public interface IContaService
    {
        Task<IEnumerable<ContasDTO>> ObterListaContas();
        Task<IEnumerable<ContasDTO>> ObterListaContasPorTipo(int tipo);
        Task<ContasDTO> ObterContaPorId(Guid id);
        Task<IEnumerable<ContaItemDTO>> ObterContaItemsPorId(Guid id);
        Task<IEnumerable<ContasDTO>> ObterListaContasPorStatus(int tipo, int status);
    }
    public class ContaServices : Service, IContaService
    {
        private readonly HttpClient _httpClient;
        private readonly IClientesService _clienteService;

        public ContaServices(HttpClient httpClient, IOptions<AppServicesSettings> settings, IClientesService clienteService)
        {
            _httpClient = httpClient;
            _httpClient.BaseAddress = new Uri(settings.Value.ContasUrl);
            _clienteService = clienteService;
        }

        public async Task<IEnumerable<ContasDTO>> ObterListaContas()
        {
            var response = await _httpClient.GetAsync("contas");
            if (response.StatusCode == HttpStatusCode.NotFound) return null;

            TratarErrosResponse(response);

            var conta = await DeserializarObjetoResponse<IEnumerable<ContasDTO>>(response);
            foreach(ContasDTO c in conta)
            {
                var nome = await _clienteService.ObterClietePorId(c.ClienteId);
                c.Nome = (string.IsNullOrEmpty(nome) ? "" : nome) ;
            }
            return conta;
        }

        public async Task<IEnumerable<ContasDTO>> ObterListaContasPorTipo(int tipo)
        {
            var response = await _httpClient.GetAsync($"contas/Tipo/{tipo}");
            if (response.StatusCode == HttpStatusCode.NotFound) return null;

            TratarErrosResponse(response);

            var conta = await DeserializarObjetoResponse<IEnumerable<ContasDTO>>(response);
            foreach (ContasDTO c in conta)
            {
                var nome = await _clienteService.ObterClietePorId(c.ClienteId);
                c.Nome = (string.IsNullOrEmpty(nome) ? "" : nome);
            }
            return conta;
        }

        public async Task<IEnumerable<ContasDTO>> ObterListaContasPorStatus(int tipo, int status)
        {
            var response = await _httpClient.GetAsync($"contas/Status/{tipo}?status={status}");
            if (response.StatusCode == HttpStatusCode.NotFound) return null;

            TratarErrosResponse(response);

            var conta = await DeserializarObjetoResponse<IEnumerable<ContasDTO>>(response);
            foreach (ContasDTO c in conta)
            {
                var nome = await _clienteService.ObterClietePorId(c.ClienteId);
                c.Nome = (string.IsNullOrEmpty(nome) ? "" : nome);
            }
            return conta;
        }

        public async Task<ContasDTO> ObterContaPorId(Guid id)
        {
            var response = await _httpClient.GetAsync($"contas/PorId/{id}");
            if (response.StatusCode == HttpStatusCode.NotFound) return null;

            TratarErrosResponse(response);

           var conta = await DeserializarObjetoResponse<ContasDTO>(response);

            var nome = await _clienteService.ObterClietePorId(conta.ClienteId);
            conta.Nome = (string.IsNullOrEmpty(nome) ? "" : nome);
            

            return conta;
        }

        public async Task<IEnumerable<ContaItemDTO>> ObterContaItemsPorId(Guid id)
        {
            var response = await _httpClient.GetAsync($"contas/ObterItemsPorIdConta/{id}");
            if (response.StatusCode == HttpStatusCode.NotFound) return null;

            TratarErrosResponse(response);

            var conta = await DeserializarObjetoResponse<IEnumerable<ContaItemDTO>>(response);          


            return conta;
        }
    }
}
