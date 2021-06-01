using System;
using System.Collections.Generic;
using System.Net.Http;
using System.Threading.Tasks;
using TomatoCalculator.Shared.Models;

namespace TomatoCalculator.Client.Services
{
    public class TomatoCalculatorService
    {
        private readonly HttpClient _http;

        public TomatoCalculatorService(HttpClient http) => _http = http;
        
        public float GenerateLoadWeight()
        {
            Random r = new Random();
            return (float)Math.Round(r.NextDouble() * 10, 5);
        }
    }
}