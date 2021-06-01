using System;
using System.Collections.Generic;
using System.Net;
using System.Net.Http;
using System.Net.Http.Json;
using System.Threading.Tasks;
using TomatoCalculator.Shared.Models;


namespace TomatoCalculator.Client.Services
{
    public class TomatoService
    {

        private readonly HttpClient _http;
        public TomatoService(HttpClient http) => _http = http;

        public bool IsBusy = false;
        public string apiPath = "api/tomato";

        public async Task<List<Tomato>> GetAll()
        {
            IsBusy = true;
            try
            {
                return await _http.GetFromJsonAsync<List<Tomato>>(apiPath);
                Console.WriteLine("Tomato List Loaded");
            }
            catch(Exception ex)
            {
                throw new InvalidOperationException(ex.Message);
            }
            finally
            {
                IsBusy = false;
            }
        }

        public async Task<Tomato> Get(Guid id)
        {
            IsBusy = true;
            try
            {
                return await _http.GetFromJsonAsync<Tomato>($"{apiPath}/{id}");
            }
            catch(Exception ex)
            {
                throw new InvalidOperationException(ex.Message);
            }
            finally
            {
                IsBusy = false;
            }
            
        }

        public async Task Update(Tomato tomato)
        {
            IsBusy = true;
            try
            {
                await _http.PutAsJsonAsync<Tomato>($"{apiPath}", tomato);
            }
            catch(Exception ex)
            {
                throw new InvalidOperationException(ex.Message);
            }
            finally
            {
                IsBusy = false;
            }
        }

        public async Task Remove(Tomato tomato)
        {
            IsBusy = true;
            try
            {
                await _http.DeleteAsync($"{apiPath}/{tomato.Id}");
            }
            catch(Exception ex)
            {
                throw new InvalidOperationException(ex.Message);
            }
            finally
            {
                IsBusy = false;
            }
        }

    }
}