namespace TalabatApi.Domain.Model.Dtos
{
    public class SaveUserData
    {
        public string UserAddress { get; set; }
        public long UserLat { get; set; }
        public long UserLong { get; set; }

        public int UserId { get; set; }
    }
}