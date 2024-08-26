using BancoCodigo.Models;
using BancoCodigo.Services;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;

namespace BancoCodigo
{
    public class Startup
    {
        readonly string MiCors = "MiCors";
        public Startup(IConfiguration configuration)
        {
            Configuration = configuration;
        }

        public IConfiguration Configuration { get; }

        // This method gets called by the runtime. Use this method to add services to the container.
        public void ConfigureServices(IServiceCollection services)
        {
            services.AddControllers();
            services.AddCors(options => {
                options.AddPolicy(name: MiCors,
                                        builder =>
                                        {
                                            builder.WithOrigins("*");
                                        });
            });
            services.AddDbContext<BaseDeDatosBancoContext>(options =>
            options.UseSqlServer(Configuration.GetConnectionString("BaseDeDatosBancoConnection")));
            _ = services.AddScoped<ICliente, SrvCliente>();
            _ = services.AddScoped<ICuentas, SrvCuentas>();
            _ = services.AddScoped<IMovimientos, SrvMovimientos>();
            _ = services.AddScoped<IReportes, SrvReportes>();
        }

        // This method gets called by the runtime. Use this method to configure the HTTP request pipeline.
        public void Configure(IApplicationBuilder app, IWebHostEnvironment env)
        {
            if (env.IsDevelopment())
            {
                app.UseDeveloperExceptionPage();
            }

            app.UseHttpsRedirection();

            app.UseRouting();

            app.UseCors(MiCors);

            app.UseAuthorization();

            app.UseEndpoints(endpoints =>
            {
                endpoints.MapControllers();
            });
        }
    }
}
