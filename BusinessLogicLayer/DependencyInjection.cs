using DataBaseAccessLayer.Data;
using DataBaseAccessLayer.Data.Interfaces;
using DataBaseAccessLayer.Data.Repositories;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;

namespace BusinessLogicLayer;

public static class DependencyInjection
{
    public static IServiceCollection AddBusinessLogicLayer(this IServiceCollection services, IConfiguration configuration)
    {
       throw new NotImplementedException();
    }
}
