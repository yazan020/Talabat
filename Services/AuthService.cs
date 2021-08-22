using System.Threading.Tasks;
using Newtonsoft.Json;
using TalabatApi.Domain.Model;
using TalabatApi.Domain.Model.Dtos;
using TalabatApi.Domain.Model.Repositories;
using TalabatApi.Domain.Model.Services;
using TalabatApi.Domain.Model.Services.Communication;
using TalabatApi.NetworkRequests;

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

        public async Task<Response<User>> LoginUser(User user, string password)
        {
            var loggedInUser = await _repository.GetUserByName(user.Name);

            if (loggedInUser == null)
            {
                return new Response<User>("User does not Exist");
            }

            user = loggedInUser;
             
            try
            {
                if (!VerifyPasswordHash(password, user.PasswordHash, user.PasswordSalt))
                {
                    return new Response<User>("Username or Password does not exist");
                }
                else return new Response<User>(user, "you logged in successfully");

            }
            catch (System.Exception ex)
            {

                return new Response<User>(ex.Message);
            }


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

                return new Response<User>(user, "");
            }
            catch (System.Exception ex)
            {

                return new Response<User>(ex.Message);
            }
        }

        public async Task<Response<User>> SeeUserData(int userId)
        {
            var existingUser = await _repository.GetUserById(userId);
            if (existingUser is null)
            {
                return new Response<User>("User Not Found 404");
            }

            return new Response<User>(existingUser, "Success");
        }

        public async Task<Response<UserData>> AddUserDataInfo(UserData userDataDto)
        {

            var existingUser = await _repository.GetUserById(userDataDto.UserId);
            if (existingUser is null)
                return new Response<UserData>("User Not Found 404");
            

            var clientAddress = new GetClientAddress();
            var userLocation = await clientAddress.GetGeoInfo();

            UserData userData = JsonConvert.DeserializeObject<UserData>(userLocation);
            userData.UserId = userDataDto.UserId;

            try
            {
                await _repository.AddUserInfo(userData);
                await _workUnit.SaveAsync();

                return new Response<UserData>(userData, "User data is saved successfully");
            }
            catch (System.Exception ex)
            {
                return new Response<UserData>(ex.Message);
            }
        }

        public Task<Response<UserData>> UpdateUserDataInfo(UserData userData)
        {
            throw new System.NotImplementedException();
        }

        public Task<Response<UserData>> DeleteUserDataInfo(UserData userData)
        {
            throw new System.NotImplementedException();
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