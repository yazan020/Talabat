using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using TalabatApi.Domain.Model;
using TalabatApi.Domain.Model.Repositories;
using TalabatApi.Persistence.Context;

namespace TalabatApi.Persistence.Repositories
{
    public class DriverRepository : BaseRepository, IDriverRepository
    {
        public DriverRepository(DataContext context) : base(context)
        {
        }

        public async Task<Driver> GetDriverById(int id)
        {
            return await _context.Drivers.FirstOrDefaultAsync(d => d.Id == id);
        }

        public async Task AssignDriver(Driver driver)
        {
            await _context.Drivers.AddAsync(driver);
        }

        public void UpdateDriverLocation(Driver driver)
        {
            _context.Drivers.Update(driver);
        }

        public void DisapproveDriver(Driver driver)
        {
            _context.Drivers.Remove(driver);
        }
    }
}