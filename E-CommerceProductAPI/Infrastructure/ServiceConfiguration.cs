using E_CommerceProduct.Infrastructure.Extensions;

namespace E_CommerceProductAPI.Infrastructure
{
    public static class ServiceConfiguration
    {
        public static WebApplicationBuilder ConfigureServices(this WebApplicationBuilder builder)
        {
            builder.Services.AddInfrastructure();

            return builder;
        }
    }
}