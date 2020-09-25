using MediatR;

namespace BelezaNaWeb.Api.Commands
{
    public sealed class CreateProductCommand : IRequest<CreateProductResult>
    {
        #region Public Properties


        public long Sku { get; private set; }


        public string Name { get; private set; }

        #endregion

        #region Constructors

        public CreateProductCommand(long sku, string name)
        {
            Sku = sku;
            Name = name;
        }

        #endregion
    }

    public sealed class CreateProductResult
    {
        #region Public Properties

        
        public long Sku { get; set; }

        
        public string Name { get; set; }

        #endregion

    }
}
