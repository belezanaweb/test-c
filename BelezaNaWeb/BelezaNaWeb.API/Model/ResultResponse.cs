
namespace BelezaNaWeb.API.Model
{
    public class ResultResponse
    {
        public ResultResponse(string message)
        {
            //Erro Genérico
            Code = "0001";
            Message = message;
        }

        public ResultResponse(string code, string message)
        {
            Code = code;
            Message = message;
        }

        public string Code { get; set; }

        public string Message { get; set; }
    }
}
