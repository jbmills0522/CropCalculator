using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using TomatoCalculator.Shared.Models;

namespace TomatoCalculator.Server.Interfaces
{
    public interface IRouteInformationRepo
    {
        public Task<List<RouteInformation>> GetAll();
        public Task<RouteInformation> Get(Guid id);
        public Task<RouteInformation> Delete(Guid id);
        public Task<RouteInformation> Update(RouteInformation route);
    }
}