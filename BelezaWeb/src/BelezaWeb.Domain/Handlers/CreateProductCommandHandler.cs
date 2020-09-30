using AutoMapper;
using BelezaWeb.Domain.Command.Input.AddProduct;
using BelezaWeb.Domain.Interfaces;
using BelezaWeb.Domain.Model;
using BelezaWeb.Domain.Models;
using MediatR;

namespace BelezaWeb.Domain.Handlers
{
    public class CreateProductCommandHandler : IRequestHandler<AddProductCommand, Response>
    {
        private readonly IRepository<Product> _productRepository;
        private readonly IMapper _mapper;

        public CreateProductCommandHandler(IRepository<Product> productRepository, IMapper mapper)
        {
            _productRepository = productRepository;
            _mapper = mapper;
        }

        public Response Handle(AddProductCommand message)
        {
            try
            {
               var produto = _productRepository.Add(_mapper.Map<Product>(message)).Result;
                return new Response(new { message = $"Produto inserido com sucesso." }, false);
            }
            catch (System.Exception ex)
            {
                return new Response(new { message = $"Ocorreu um erro ao tentar cadastrar o Produto. Exception = {ex.Message}" }, true);
            }
        }
    }
}
