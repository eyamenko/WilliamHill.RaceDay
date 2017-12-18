using System;
using System.Collections.Generic;
using System.Net.Http;
using System.Threading.Tasks;
using Newtonsoft.Json;
using WilliamHill.RaceDay.Contracts.ApiClients;
using WilliamHill.RaceDay.Models.ApiModels;

namespace WilliamHill.RaceDay.ApiClients
{
    public class WhatechApiClient : IWhatechApiClient
    {
        private static readonly object Lock = new object();

        private static HttpClient _httpClient;

        private static void InitClient(string endpoint)
        {
            if (_httpClient == null)
            {
                lock (Lock)
                {
                    if (_httpClient == null)
                    {
                        _httpClient = new HttpClient
                        {
                            BaseAddress = new Uri(endpoint)
                        };
                    }
                }
            }
        }

        private readonly string _name;

        public WhatechApiClient(string endpoint, string name)
        {
            _name = name;

            InitClient(endpoint);
        }

        public async Task<IList<Customer>> GetCustomers()
        {
            using (var response = await _httpClient.GetAsync($"/api/GetCustomers?name={_name}"))
            {
                response.EnsureSuccessStatusCode();

                var json = await response.Content.ReadAsStringAsync();

                return JsonConvert.DeserializeObject<List<Customer>>(json);
            }
        }

        public async Task<IList<Bet>> GetBets()
        {
            using (var response = await _httpClient.GetAsync($"/api/GetBetsV2?name={_name}"))
            {
                response.EnsureSuccessStatusCode();

                var json = await response.Content.ReadAsStringAsync();

                return JsonConvert.DeserializeObject<List<Bet>>(json);
            }
        }

        public async Task<IList<Race>> GetRaces()
        {
            using (var response = await _httpClient.GetAsync($"/api/GetRaces?name={_name}"))
            {
                response.EnsureSuccessStatusCode();

                var json = await response.Content.ReadAsStringAsync();

                return JsonConvert.DeserializeObject<List<Race>>(json);
            }
        }
    }
}