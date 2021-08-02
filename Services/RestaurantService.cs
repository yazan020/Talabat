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

        public async Task<Response<Restuarant>> UpdateRest(int id, Restuarant restuarant)
        {
            if (restuarant is null)
            {
                return new Response<Restuarant>("Not Found");
            }

            var existingRest = await _repository.GetRestById(id);

            if (existingRest is null)
            {
                return new Response<Restuarant>("404 Not Found");
            }

            existingRest.Name = restuarant.Name;
            existingRest.Offer = restuarant.Offer;
            existingRest.DeliveryPrice = restuarant.DeliveryPrice;

            try
            {
                _repository.UpdateRest(existingRest);
                await _workUnit.SaveAsync();

                return new Response<Restuarant>(restuarant, "rest updated successfully");
            }

            catch (System.Exception ex)
            {
                return new Response<Restuarant>(ex.Message);
            }
        }

        public async Task<Response<IEnumerable<Restuarant>>> DeleteRest(int Id)
        {
            var deletedRest = await _repository.GetRestById(Id);

            if (deletedRest is null)
            {
                return new Response<IEnumerable<Restuarant>>("You are trying to delete an unexciting restaurant!");
            }
    
            try
            {
                _repository.DeleteRest(deletedRest);
                await _workUnit.SaveAsync();

                return new Response<IEnumerable<Restuarant>>(await _repository.GetRest(), "Restaurant deleted Successfully");
            }
            catch (System.Exception ex)
            {
                return new Response<IEnumerable<Restuarant>>(ex.Message);
            }
        }
    }
}