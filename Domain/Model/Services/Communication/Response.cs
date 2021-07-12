namespace TalabatApi.Domain.Model.Services.Communication
{
    public class Response<T> : ResponseBase
    {

        public T Data { get; set; }
        public Response(bool Success, string Message, T Data) : base(Success, Message)
        {
            this.Data = Data;
        }

        /// <summary>
        /// Creates a success response.
        /// </summary>
        /// <param name="T"> Item. </param> 
        /// <returns> Response </returns>

        public Response(T Data, string Message) : this(true, Message, Data)
        {}

        /// <summary>
        /// Creates an error response.
        /// </summary>
        /// <param name="message"> Error Message. </param>
        /// <returns> Response. </returns>
        
        public Response(string Message) : this(false, Message, default)
        {}
    }
}