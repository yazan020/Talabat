namespace TalabatApi.Domain.Model.Services.Communication
{
    public abstract class ResponseBase
    {
        public bool Success { get; set; }
        public string Message { get; set; }

        public ResponseBase(bool Success, string Message)
        {
            this.Success = Success;
            this.Message = Message;
        }
    }
}