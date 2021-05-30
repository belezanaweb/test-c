using AutoMapper;
using Boticario.Domain.AutoMapper;
using Boticario.Domain.Handlers;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.Hosting;
using Microsoft.Extensions.Logging;
using Moq;
using System;

namespace Boticario.ApplicationService.Test
{
    public abstract class TestBase
    {
        protected IHostingEnvironment _mockEnviroment;
        protected ILogger _logger;
        protected INotification _notification;
        public IMapper _mapper;
        protected IConfiguration _configuration = null;
  


        public void InicializaMock()
        {

            if (_configuration == null)
            {
                var configuration = new Mock<IConfiguration>();
                _configuration = configuration.Object;

            }

            var mockEnvironment = new Mock<IHostingEnvironment>();
            mockEnvironment
               .Setup(m => m.EnvironmentName)
               .Returns("Development");

            _notification = new NotificatorHandler();

            var logger = new Mock<ILogger>();
           
            
           


            _mockEnviroment = mockEnvironment.Object;


            _logger = logger.Object;
     



            var conf = new MapperConfiguration(cf => cf.AddProfile(new AutoMapperConfig()));
            _mapper = conf.CreateMapper(); //MockaModel<TSource, TDestination>(model);


            //C:\\Repositórios\\api_esa\\src\\ESA.WebApi

            string root = AppDomain.CurrentDomain.BaseDirectory;
            var builder = new ConfigurationBuilder()
                .SetBasePath(root)
                .AddJsonFile($"appsettings.{_mockEnviroment.EnvironmentName}.json", optional: true)
                .AddEnvironmentVariables();

            _configuration = builder.Build();

        }



    }
}
