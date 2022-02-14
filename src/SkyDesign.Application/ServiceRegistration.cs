using MediatR;
using Microsoft.Extensions.DependencyInjection;
using System.Reflection;

namespace SkyDesign.Application
{
    public static class ServiceRegistration
    {
        /// <summary>
        /// 
        /// </summary>
        /// <param name="services"></param>
        public static void AddApplicationRegistration(this IServiceCollection services)
        {
            var assm = Assembly.GetExecutingAssembly();
            services.AddMediatR(assm);
        }
    }
}
