namespace BackendTest.Domain.Commands.Responses
{
    public class DeleteProductResponse
    {

        private static readonly string SuccessMensage = "Product deleted successfully!";
        private static readonly string NotExists = "This product does not exist!";

        public string Mensage { get; set; }

        private DeleteProductResponse(string mensage)
        {
            Mensage = mensage;
        }

        public static DeleteProductResponse Success()
        {
            return new DeleteProductResponse(SuccessMensage);
        }

        public static DeleteProductResponse Error(string mensage)
        {
            return new DeleteProductResponse(mensage);
        }

        public static DeleteProductResponse NExists()
        {
            return new DeleteProductResponse(NotExists);
        }
    }
}
