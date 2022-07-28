using Microsoft.AspNetCore.ResponseCompression;
using Newtonsoft.Json.Serialization;
using System.IO.Compression;

namespace ListR.Api
{
    public class Startup
    {
        private readonly IConfiguration _configuration;
        private string _dbConnectionString;

        public Startup(IConfiguration configuration)
        {
            _configuration = configuration;
        }

        public void ConfigureServices(IServiceCollection services)
        {
            services.AddResponseCompression(
                options =>
                {
                    options.Providers.Add<GzipCompressionProvider>();
                    options.EnableForHttps = true;
                });
            services.Configure<GzipCompressionProviderOptions>(options => options.Level = CompressionLevel.Fastest);

            services.AddControllers(
                    options =>
                    {
                        options.MaxModelValidationErrors = 50;
                        options.ModelBindingMessageProvider.SetValueMustNotBeNullAccessor(_ => "The field is required");
                    })
                .AddNewtonsoftJson(options => options.SerializerSettings.ContractResolver = new CamelCasePropertyNamesContractResolver());
        }
    }
}
