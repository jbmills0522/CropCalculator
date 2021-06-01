using System;
using System.Collections.Generic;
using System.Net.Http;
using System.Net.Http.Json;
using System.Threading.Tasks;
using Blazorise;
using Blazorise.DataGrid;
using TomatoCalculator.Shared.Models;

namespace TomatoCalculator.Client.Services
{
    public class ShippingService
    {
        private readonly HttpClient _http;
        public ShippingService(HttpClient http) => _http = http;

        private bool IsBusy = false;
        private string apiPath = "api/shipping";

        public async Task<List<Shipping>> GetAll()
        {
            IsBusy = true;
            try
            {
                return await _http.GetFromJsonAsync<List<Shipping>>(apiPath);
                Console.WriteLine("Shipping List Loaded");
            }
            catch (Exception ex)
            {
                throw new InvalidOperationException(ex.Message);
            }
            finally
            {
                IsBusy = false;
            }
        }

        public async Task Remove(Shipping ship)
        {
            IsBusy = true;
            try
            {
                await _http.DeleteAsync($"{apiPath}/{ship.Id}");
            }
            catch (Exception exception)
            {
                throw new InvalidOperationException(exception.Message);
            }
            finally
            {
                IsBusy = false;
            }
        }

        public async Task Update(Shipping ship)
        {
            IsBusy = true;
            try
            {
                await _http.PutAsJsonAsync($"{apiPath}", ship);
            }
            catch (Exception exception)
            {
                throw new InvalidOperationException(exception.Message);
            }
            finally
            {
                IsBusy = false;
            }
        }

        public async Task<List<Shipping>> GetByDriver(int driverNumber)
        {
            IsBusy = true;
            try
            {
                return await _http.GetFromJsonAsync<List<Shipping>>($"{apiPath}/byDriver/{driverNumber}");
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
            finally
            {
                IsBusy = false;
            }
        }

        public async Task<Shipping> Get(Guid id)
        {
            IsBusy = true;
            try
            {
                return await _http.GetFromJsonAsync<Shipping>($"{apiPath}/{id}");
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
            finally
            {
                IsBusy = false;
            }
        }
    }
}