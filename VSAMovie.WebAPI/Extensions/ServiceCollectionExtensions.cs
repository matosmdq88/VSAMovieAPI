using MediatR;
using Microsoft.EntityFrameworkCore;
using VSAMovie.WebAPI.Helpers;
using VSAMovie.WebAPI.Servicios;

namespace VSAMovie.WebAPI.Extensions
{
    public static class ServiceCollectionExtensions
    {
        public static IServiceCollection AddApplicationServices(this IServiceCollection services, WebApplicationBuilder builder)
        {
            builder.Services.AddEndpointsApiExplorer();
            builder.Services.AddSwaggerGen();
            builder.Services.AddControllers();
            builder.Services.AddDbContext<ApplicationDbContext>(options => options.UseSqlServer(builder.Configuration.GetConnectionString("DefaultConnection")));
            builder.Services.AddMediatR(typeof(Program));
            builder.Services.AddAutoMapper(typeof(Program));
            builder.Services.AddTransient<IAlmacenadorArchivos, AlmacenadorArchivosLocal>();
            builder.Services.AddScoped<PeliculaExisteAttribute>();
            builder.Services.AddHttpContextAccessor();
            return services;
        }
    }
}
