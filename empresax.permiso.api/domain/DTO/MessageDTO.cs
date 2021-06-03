
namespace empresax.permiso.api.domain.DTO
{
    public class MessageDTO
    {
        public MessageDTO(string code, string message)
        {
            this.code = code;
            this.message = message;
        }

        public string code {get;set;}
        public string message {get;set;}
    }
}