using BookStore.Infrastructure.Interfaces;
using BookStore.Infrastructure.Repositories;
using Microsoft.Extensions.DependencyInjection;

namespace BookStore.Infrastructure.DependencyInjection
{
    public static class AddRepositoryDI
    {
        public static IServiceCollection AddDefaultRepository(this IServiceCollection services)
        {
            services.AddSingleton<IBookRepository, DefaultBookRepository>();

            return services;
        }
    }
}
