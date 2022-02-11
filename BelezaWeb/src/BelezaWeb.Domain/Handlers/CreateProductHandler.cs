using System;
using MediatR;
using AutoMapper;
using BelezaWeb.Domain.Models;
using BelezaWeb.Domain.Interfaces;
using BelezaWeb.Domain.Requests;

namespace BelezaWeb.Domain.Handlers
{
    public class CreateProductHandler : IRequestHandler<CreateProductRequest, Response>
    {
        private readonly IMapper Mapper;
        private readonly IRepository<Product> Repository;

        public CreateProductHandler(IRepository<Product> productRepository, IMapper mapper)
        {
            Mapper = mapper;
            Repository = productRepository;
        }

        public Response Handle(CreateProductRequest payload)
        {
            try
            {
                var product = Repository.Create(Mapper.Map<Product>(payload)).Result;

                if (product == null)
                    return new Response(new { response = $"Sku já utilizado por outro produto." }, true);

                return new Response(new { response = $"Produto cadastrado com sucesso." });
            }
            catch (Exception ex)
            {
                return new Response(new { response = $"Erro ao cadastrar produto. {ex.Message}" });
            }
        }
    }
}
