using Domain.Interfaces;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace BNW.Infra
{
    public class RepositoryBase<T> : IRepositoryBase<T> where T : class
    {
        private static List<T> objetos = new List<T>();
        public RepositoryBase()
        {
        }

        public static List<T> Objetos
        {
            get
            {
                if (objetos == null) objetos = new List<T>();
                return objetos;
            }
        }

        public async void Add(T obj)
        {
            Objetos.Add(obj);
        }

        public void Dispose()
        {
            GC.SuppressFinalize(this);
        }

        public async Task<IEnumerable<T>> GetAll()
        {
            return Objetos;
        }

        public async Task<T> GetById(int id)
        {
            return null;
        }

        public async void Remove(T obj)
        {
            Objetos.Remove(obj);
        }

        public async void Update(T obj)
        {
            Objetos.Remove(obj);
            Objetos.Add(obj);
        }
    }
}
