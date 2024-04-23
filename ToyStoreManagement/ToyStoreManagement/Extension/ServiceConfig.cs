using BusinessObjects.Models;
using BusinessObjects;
using ToyStoreRepository.Implement;
using ToyStoreRepository.Interface;
using ToyStoreService.Implement;
using ToyStoreService.Interface;
using Microsoft.AspNetCore.Identity;

namespace ToyStoreManagement.Extension
{
    public static class ServiceConfig
    {
        public static IServiceCollection AddService(this IServiceCollection services)
        {
            services.AddScoped<IAccountRepository, AccountRepository>();
            services.AddScoped<IAccountService, AccountService>();

            services.AddScoped<ICategoryRepository, CategoryRepository>();
            services.AddScoped<ICategoryService, CategoryService>();

            services.AddScoped<IFeedbackRepository, FeedbackRepository>();
            services.AddScoped<IFeedbackService, FeedbackService>();

            services.AddScoped<IOrderDetailRepository, OrderDetailRepository>();
            services.AddScoped<IOrderDetailService, OrderDetailService>();

            services.AddScoped<IOrderRepository, OrderRepository>();
            services.AddScoped<IOrderService, OrderService>();

            services.AddScoped<IProductRepository, ProductRepository>();
            services.AddScoped<IProductService, ProductService>();

            services.AddScoped<IProductReviewRepository, ProductReviewRepository>();
            services.AddScoped<IProductReviewService, ProductReviewService>();

            services.AddScoped<IProductUrlRepository, ProductUrlRepository>();
            services.AddScoped<IProductUrlService, ProductUrlService>();

            return services;
        }
    }
}
