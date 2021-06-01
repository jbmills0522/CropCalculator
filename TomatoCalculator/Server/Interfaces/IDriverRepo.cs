using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using TomatoCalculator.Shared.Models;

namespace TomatoCalculator.Server.Interfaces
{
    public interface IDriverRepo
    {
        Task<List<DriverInformation>> GetAll();
        Task<DriverInformation> Get(Guid id);
        Task<DriverInformation> Delete(Guid id);
        Task<DriverInformation> Update(DriverInformation driverInformation);
    }
}
