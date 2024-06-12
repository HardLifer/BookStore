using BookStore.Services.Concrete;
using BookStore.Services.Interfaces;
using Microsoft.Extensions.DependencyInjection;

namespace BookStore.Services.DependencyInjection
{
    public static class AddBookServiceDI
    {
        public static IServiceCollection AddBookService(this IServiceCollection services) 
        {
            services.AddScoped<IBookService, BookService>();

            return services;
        }
    }
}
