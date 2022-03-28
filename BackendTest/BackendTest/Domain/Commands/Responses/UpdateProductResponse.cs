namespace BackendTest.Domain.Commands.Responses
{
    public class UpdateProductResponse
    {

        private static readonly string SuccessMensage = "Product updated successfully!";
        private static readonly string NotExists = "This product does not exist!";

        public string Mensage { get; set; }

        private UpdateProductResponse(string mensage)
        {
            Mensage = mensage;
        }

        public static UpdateProductResponse Success()
        {
            return new UpdateProductResponse(SuccessMensage);
        }

        public static UpdateProductResponse Error(string mensage)
        {
            return new UpdateProductResponse(mensage);
        }

        public static UpdateProductResponse NExists()
        {
            return new UpdateProductResponse(NotExists);
        }
    }
}
