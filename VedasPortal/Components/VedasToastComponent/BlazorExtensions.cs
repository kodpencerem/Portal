using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.DependencyInjection.Extensions;
using System;
using VedasPortal.Components.VedasToastComponent.Core;
using VedasPortal.Components.VedasToastComponent.Core.Models;

namespace VedasPortal.Components.VedasToastComponent
{
    /// <summary>
    /// <see cref="VedasToaster"/> yapılandırma giriş noktalarını sağlar
    /// </summary>
    public static class BlazorExtensions
    {
        /// <summary>
        /// Singleton bir nesne <see cref="IVedasToaster"/> içerir -bu bir dependency injection - <see cref="IServiceCollection"/> koleksiyon olarak gösterir <see cref="ToasterConfiguration"/>
        /// </summary>
        public static IServiceCollection AddToaster(this IServiceCollection services, ToasterConfiguration configuration)
        {
            if (configuration == null) throw new ArgumentNullException(nameof(configuration));
            services.TryAddScoped<IVedasToaster>(builder => new VedasToaster(configuration));
            return services;
        }

        /// <summary>
        /// Singleton bir nesne <see cref="IVedasToaster"/> içerir -bu bir dependency injection - <see cref="IServiceCollection"/> koleksiyon olarak gösterir <see cref="ToasterConfiguration"/>
        /// </summary>
        public static IServiceCollection AddToaster(this IServiceCollection services)
        {
            return services.AddToaster(new ToasterConfiguration());
        }

        /// <summary>
        /// Singleton bir nesne <see cref="IVedasToaster"/> içerir -bu bir dependency injection - <see cref="IServiceCollection"/> koleksiyon olarak gösterir <see cref="ToasterConfiguration"/>
        /// </summary>
        public static IServiceCollection AddToaster(this IServiceCollection services, Action<ToasterConfiguration> configure)
        {
            if (configure == null) throw new ArgumentNullException(nameof(configure));

            var options = new ToasterConfiguration();
            configure(options);

            return services.AddToaster(options);
        }
    }
}