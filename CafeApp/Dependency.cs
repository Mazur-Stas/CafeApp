using CafeApp.Core.Interfaces;
using CafeApp.Services;
using CafeApp.Storage;
using CafeApp.Storage.Repositories;
using Microsoft.Extensions.Configuration;
using Serilog;
using Serilog.Core;

namespace CafeApp;

internal static class Dependency
{
    private static CafeAppContext GetCafeAppContext()
    {
        var config = new ConfigurationBuilder()
            .AddJsonFile("config.json")
            .Build();

        return new CafeAppContext(config["ConnectionString"]);
    }

    private static IOrderRepository GetOrderRepository()
    {
        return new OrderRepository(GetCafeAppContext());
    }

    public static IOrderService GetOrderService()
    {
        return new OrderService(GetOrderRepository());
    }

    public static IAuthService GetAuthService()
    {
        return new AuthService(GetCafeAppContext());
    }

    public static Logger GetLogger()
    {
        return new LoggerConfiguration()
                .WriteTo.Console()
                .CreateLogger();
    }
}
