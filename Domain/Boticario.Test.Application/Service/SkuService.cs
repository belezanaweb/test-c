using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using AutoMapper;
using Boticario.Test.Application.Entity;
using Boticario.Test.Application.Interface;

namespace Boticario.Test.Application.Service
{
    public class SkuService : IService<Product>
    {
        private readonly IRepository<Product> _repository;
        private readonly IMapper _mapper;

        public SkuService(IRepository<Product> repository, IMapper mapper)
        {
            _repository = repository;
            _mapper = mapper;
        }

        public async Task<Product> add(Product entity)
        {
            var exists = await getBySku(entity.Sku);

            if(exists != null)
                throw new Exception("Produto já cadastrado anteriormente.");

            var added = await _repository.add(entity);

            var newEntity = FillSku(added);

            return newEntity;
        }

        public async Task<IEnumerable<Product>> getAll()
        {
            var entities = await _repository.getAll();

            entities.ToList().ForEach(async entity => {
                var entityWithInclude = await _repository.AddInclude(entity, "Inventory.Warehouses");
                entity = FillSku(entityWithInclude.FirstOrDefault());
            });

            return entities;
        }

        public async Task<Product> getBySku(int sku)
        {
            var entity = await _repository.getBy(x => x.Sku.Equals(sku));

            if(entity != null)
            {
                entity = (await _repository.AddInclude(entity, "Inventory.Warehouses")).FirstOrDefault();
                entity = FillSku(entity);
            }

            return entity;
        }

        public async Task remove(int sku)
        {
            var entity = await getBySku(sku);
            await _repository.remove(entity);
        }

        public async Task update(Product entity)
        {
            var existsEntity = await getBySku(entity.Sku);

            if(existsEntity == null)
                throw new Exception("Produto não válido.");

            _mapper.Map(entity, existsEntity);
            //(entity, exists);

            await _repository.update(existsEntity);
        }

        public Product FillSku(Product entity)
        {
            if(entity.Inventory != null) 
            {
                if(entity.Inventory.Warehouses.Count() > 0){
                    var quantity = entity.Inventory.Warehouses.Sum(x => x.Quantity);
                    entity.Inventory.Quantity = quantity;
                }

                entity.IsMarketable = entity.Inventory.Quantity > 0;
            }

            return entity;
        }
    }
}