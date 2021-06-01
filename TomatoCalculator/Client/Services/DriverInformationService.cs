using System;
using System.Collections.Generic;
using System.Net.Http;
using System.Net.Http.Json;
using System.Threading.Tasks;
using Blazorise;
using TomatoCalculator.Shared.Models;

namespace TomatoCalculator.Client.Services
{
    public class DriverInformationService
    {
        private readonly HttpClient _http;
        public bool IsBusy { get; private set; }
        private readonly string apiPath = "api/driver";
        public DriverInformationService(HttpClient http)
        {
            _http = http;
        }

        public async Task<List<DriverInformation>> GetAll()
        {
            IsBusy = true;
            try
            {
                return await _http.GetFromJsonAsync<List<DriverInformation>>(apiPath);
                Console.WriteLine("Driver List Loaded");
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

        public async Task<DriverInformation> Get(Guid id)
        {
            IsBusy = true;
            try
            {
                return await _http.GetFromJsonAsync<DriverInformation>($"{apiPath}/{id}");
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

        public async Task UpdateDriver(DriverInformation driver)
        {
            IsBusy = true;
            try
            {
                await _http.PutAsJsonAsync<DriverInformation>(apiPath, driver);
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

        public async Task RemoveDriver(DriverInformation driver)
        {
            IsBusy = true;
            try
            {
                await _http.DeleteAsync($"{apiPath}/{driver.Id}");
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
        
    }
}