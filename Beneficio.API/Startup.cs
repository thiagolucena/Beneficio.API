using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Threading.Tasks;
using AutoMapper;
using Beneficio.Infra.Data.Context;
using Beneficio.Infra.Data.Repository;
using Beneficio.Service.Services;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.HttpsPolicy;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.FileProviders;
using Microsoft.Extensions.Hosting;
using Microsoft.Extensions.Logging;

namespace Beneficio.API
{
    public class Startup
    {
        public Startup(IConfiguration configuration)
        {
            Configuration = configuration;
        }

        public IConfiguration Configuration { get; }

        // This method gets called by the runtime. Use this method to add services to the container.
        public void ConfigureServices(IServiceCollection services)
        {
            services.AddControllers();
            services.AddCors();
            services.AddMvc();
            services.AddHttpClient();

            services.AddDbContext<BeneficioContext>(x => x.UseSqlite(Configuration.GetConnectionString("Default")));
            services.AddScoped<IBeneficioServidorRepository, BeneficioServidorRepository>();
            services.AddScoped<IBeneficioServidorService, BeneficioServidorService>();
            services.AddScoped<IServidorRepository, ServidorRepository>();
            services.AddScoped<IServidorService, ServidorService>();
            services.AddScoped<IAnexoBeneficioRepository, AnexoBeneficioRepository>();
            services.AddScoped<IAnexoBeneficioService, AnexoBeneficioService>();
            services.AddScoped<IMovimentacaoBeneficioRepository, MovimentacaoBeneficioRepository>();
            services.AddScoped<IMovimentacaoBeneficioService, MovimentacaoBeneficioService>();
            services.AddScoped<IOrgaoRepository, OrgaoRepository>();
            services.AddScoped<IOrgaoService, OrgaoService>();
            services.AddScoped<ISetorRepository, SetorRepository>();
            services.AddScoped<ISetorService, SetorService>();
            services.AddScoped<ICategoriaRepository, CategoriaRepository>();
            services.AddScoped<ICategoriaService, CategoriaService>();
            services.AddScoped(typeof(IBaseRepository<>), typeof(BaseRepository<>));

            services.AddControllersWithViews().
                AddNewtonsoftJson(options =>
                options.SerializerSettings.ReferenceLoopHandling =
                Newtonsoft.Json.ReferenceLoopHandling.Ignore
                );
        }

        // This method gets called by the runtime. Use this method to configure the HTTP request pipeline.
        public void Configure(IApplicationBuilder app, IWebHostEnvironment env)
        {
            if (env.IsDevelopment())
            {
                app.UseDeveloperExceptionPage();
            }

            app.UseCors(x => x.AllowAnyOrigin().AllowAnyMethod().AllowAnyHeader());
            
            app.UseStaticFiles();
            app.UseStaticFiles(new StaticFileOptions()
            {
                FileProvider = new PhysicalFileProvider(Path.Combine(Directory.GetCurrentDirectory(), @"Resources")),
                RequestPath = new PathString("/Resources")
            });

            app.UseHttpsRedirection();

            app.UseRouting();

            app.UseAuthorization();

            app.UseEndpoints(endpoints =>
            {
                endpoints.MapControllers();
            });
        }
    }
}
