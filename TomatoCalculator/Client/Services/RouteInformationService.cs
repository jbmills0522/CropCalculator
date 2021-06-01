using System;
using System.Collections.Generic;
using System.Net.Http;
using System.Net.Http.Json;
using System.Threading.Tasks;
using TomatoCalculator.Shared.Models;

namespace TomatoCalculator.Client.Services
{
    public class RouteInformationService
    {
        private readonly HttpClient _http;
        public bool IsBusy { get; private set; }
        private readonly string apiPath = "api/routeinformation";
        public RouteInformationService(HttpClient http)
        {
            _http = http;
        }
        public async Task<List<RouteInformation>> GetAll()
        {
            IsBusy = true;
            try
            {
                return await _http.GetFromJsonAsync<List<RouteInformation>>(apiPath);
                Console.WriteLine("Route List Loaded");
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

        public async Task<RouteInformation> Get(Guid id)
        {
            IsBusy = true;
            try
            {
                return await _http.GetFromJsonAsync<RouteInformation>($"{apiPath}/{id}");
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

        public async Task SaveRoute(RouteInformation route)
        {
            IsBusy = true;
            try
            {
                await _http.PutAsJsonAsync<RouteInformation>($"{apiPath}", route);
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

        public async Task UpdateRoute(RouteInformation route)
        {
            IsBusy = true;
            try
            {
                await _http.PutAsJsonAsync<RouteInformation>($"{apiPath}", route);
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

        public async Task RemoveRoute(RouteInformation route)
        {
            IsBusy = true;
            try
            {
                await _http.DeleteAsync($"{apiPath}/{route.Id}");
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