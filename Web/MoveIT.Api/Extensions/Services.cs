using Microsoft.Extensions.DependencyInjection;

using MoveIT.Core;
using MoveIT.Core.Services;
using MoveIT.Data;
using MoveIT.Services;
using MoveIT.Services.Authentication;
using MoveIT.Services.PriceCalculators;

namespace MoveIT.Api.Extensions
{
    public class Services
    {
        public static void Configure(IServiceCollection services)
        {
            services.AddScoped<IUnitOfWork, UnitOfWork>();
            services.AddScoped<IMovingProposalService, MovingProposalService>();
            services.AddScoped<IOrderService, OrderService>();
            services.AddScoped<IMovingPriceCalculator, MovingPriceCalculator>();
            services.AddScoped<IAuthService, AuthService>();
            services.AddHttpContextAccessor();
        }
    }
}
