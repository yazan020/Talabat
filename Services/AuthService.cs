using System.Threading.Tasks;
using TalabatApi.Domain.Model;
using TalabatApi.Domain.Model.Repositories;
using TalabatApi.Domain.Model.Services;
using TalabatApi.Domain.Model.Services.Communication;

namespace TalabatApi.Services
{
    public class AuthService : IAuthService
    {
        private readonly IAuthRepo _repository;
        private readonly IUnitOfWork _workUnit;
        public AuthService(IAuthRepo repository, IUnitOfWork workUnit)
        {
            this._workUnit = workUnit;
            this._repository = repository;

        }
        public Task<Response<User>> LoginUser(User user)
        {
            throw new System.NotImplementedException();
        }

        public async Task<Response<User>> RegisterUser(User user, string Password)
        {
            if (await _repository.GetUserByName(user.Name) != null)
            {
                return new Response<User>("User does exist");
            }


            try
            {

                CreatePasswordHash(Password, out byte[] passwordHash, out byte[] passwordSalt);
                user.PasswordHash = passwordHash;
                user.PasswordSalt = passwordSalt;

                await _repository.RegisterUser(user);
                await _workUnit.SaveAsync();

                return new Response<User>(user);
            }
            catch (System.Exception ex)
            {
                
                return new Response<User>(ex.Message);
            }
        }


        /////////////////////////////// password encryption ///////////////////////////////

        public void CreatePasswordHash(string password, out byte[] passwordHash, out byte[] passwordSalt)
        {
            using (var hmac = new System.Security.Cryptography.HMACSHA512())
            {
                passwordSalt = hmac.Key;
                passwordHash = hmac.ComputeHash(System.Text.Encoding.UTF8.GetBytes(password));
            }
        }

        public bool VerifyPasswordHash(string password, byte[] passwordHash, byte[] passwordSalt)
        {
            using (var hmac = new System.Security.Cryptography.HMACSHA512(passwordSalt))
            {
                var computedHash = hmac.ComputeHash(System.Text.Encoding.UTF8.GetBytes(password));

                for (int i = 0; i < computedHash.Length; i++)
                {
                    if (computedHash[i] != passwordHash[i]) return false;
                }

                return true;
            }
        }
    }
}