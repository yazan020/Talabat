using System.Collections.Generic;
using System.Threading.Tasks;
using TalabatApi.Domain.Model;
using TalabatApi.Domain.Model.Repositories;
using TalabatApi.Domain.Model.Services;
using TalabatApi.Domain.Model.Services.Communication;

namespace TalabatApi.Services
{
    public class RestaurantService : IRestaurantService
    {
        private readonly IRestaurantRepo _repository;
        private readonly IUnitOfWork _workUnit;

        public RestaurantService(IRestaurantRepo repository, IUnitOfWork workUnit)
        {
            this._workUnit = workUnit;
            this._repository = repository;
        }

        public async Task<Response<Restuarant>> GetRestById(int id)
        {
            var rest = await _repository.GetRestById(id);

            if (rest == null)
            {
                return new Response<Restuarant>("No item was found");
            }

            return new Response<Restuarant>(rest, $"got restuarant with id {rest.Id}");
        }

        public async Task<Response<IEnumerable<Restuarant>>> GetRests()
        {
            var rests = await _repository.GetRest();

            if (rests == null)
            {
                return new Response<IEnumerable<Restuarant>>("No item was found");
            }

            return new Response<IEnumerable<Restuarant>>(rests, $"Got rests");
        }

        public async Task<Response<IEnumerable<Restuarant>>> SaveRest(Restuarant restuarant)
        {
            if (restuarant is null)
            {
                return new Response<IEnumerable<Restuarant>>("enter item");
            }

            try
            {
                await _repository.SaveRest(restuarant);
                await _workUnit.SaveAsync();

                return new Response<IEnumerable<Restuarant>>(await _repository.GetRest(), "rest saved successfully");
            }

            catch (System.Exception ex)
            {
                return new Response<IEnumerable<Restuarant>>(ex.Message);
            }
        }

        public Task<Response<Restuarant>> UpdateRest(Restuarant restuarant)
        {
            throw new System.NotImplementedException();
        }

        public Task<Response<Restuarant>> DeleteRest(Restuarant restuarant)
        {
            throw new System.NotImplementedException();
        }
    }
}