namespace BackendTest.Domain.Commands.Responses
{
    public class CreateProductResponse
    {
        private static readonly string SuccessMensage = "Product created successfully!";
        private static readonly string AlreadyExists = "This product already exists!";
        public string Mensage { get; set; }

        private CreateProductResponse(string mensage)
        {
            Mensage = mensage;
        }

        public static CreateProductResponse Success()
        {
            return new CreateProductResponse(SuccessMensage);
        }

        public static CreateProductResponse Error(string mensage)
        {
            return new CreateProductResponse(mensage);
        }

        public static CreateProductResponse Exists()
        {
            return new CreateProductResponse(AlreadyExists);
        }
    }
}
