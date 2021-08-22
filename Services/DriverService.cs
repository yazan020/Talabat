using System.Collections.Generic;
using System.Threading.Tasks;
using TalabatApi.Domain.Model;
using TalabatApi.Domain.Model.Repositories;
using TalabatApi.Domain.Model.Services;
using TalabatApi.Domain.Model.Services.Communication;

namespace TalabatApi.Services
{
    public class DriverService : IDriverService
    {
        private readonly IDriverRepository _repository;
        private readonly IUnitOfWork _workUnit;
        public DriverService(IDriverRepository repository, IUnitOfWork workUnit)
        {
            this._workUnit = workUnit;
            this._repository = repository;
        }

        public async Task<Response<Driver>> AssignDriver(Driver driver)
        {
            if (driver is null)
            {
                return new Response<Driver>("Please enter your info");
            }

            try
            {
                await _repository.AssignDriver(driver);
                await _workUnit.SaveAsync();

                return new Response<Driver>(driver, "You've been assigned as a driver successfully");
            }

            catch (System.Exception ex)
            {
                return new Response<Driver>(ex.Message);
            }
        }

        public async Task<Response<Driver>> UpdateDriverLocation(Driver driver)
        {
            var existingDriver = await _repository.GetDriverById(driver.Id);

            if (existingDriver is null)
            {
                return new Response<Driver>("Driver does not exist");
            }

            existingDriver.DriverLocation = driver.DriverLocation;

            _repository.UpdateDriverLocation(existingDriver);
            await _workUnit.SaveAsync();

            return new Response<Driver>(driver, "your location has been updated");
        }

        public async Task<Response<Driver>> DisapproveDriver(Driver driver)
        {
            var existingDriver = await _repository.GetDriverById(driver.Id);

            if (existingDriver is null)
            {
                return new Response<Driver>("Driver does not exist");
            }

            try
            {
                _repository.DisapproveDriver(driver);
                await _workUnit.SaveAsync();

                return new Response<Driver>(driver, "your location has been updated");
            }
            catch (System.Exception ex)
            {
                return new Response<Driver>(ex.Message);
            }
        }

    }
}