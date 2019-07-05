using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using AutoMapper;
using Microsoft.AspNetCore.Authentication;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.HttpsPolicy;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Logging;
using Microsoft.Extensions.Options;
using Positivo.AtividadesComplementares.Application.IService;
using Positivo.AtividadesComplementares.Application.Service;
using Positivo.AtividadesComplementares.Domain.Infrastructure;
using Positivo.AtividadesComplementares.Infrastructure.IRepositoy;
using Positivo.AtividadesComplementares.Infrastructure.Mapper;
using Positivo.AtividadesComplementares.Infrastructure.Repository;
using Positivo.AtividadesComplementares.Positivo.AtividadesComplementares.Infrastructure;
using Positivo.AtividadesComplementares.Api.ViewModel;

namespace Positivo.AtividadesComplementares
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
            // services.AddScoped<PositivoDbContext, PositivoDbContext>();
            services.AddDbContext<PositivoDbContext>(
               x => x.UseSqlServer(Configuration.GetConnectionString("PositivoDatabase"))
           );

            services.AddAutoMapper(c =>
            {
                c.AddProfile<MapperRepository>();
            });

            services.AddScoped<IAtividadeService, AtividadeService>();
            services.AddScoped<ICursoService, CursoService>();
            services.AddScoped<ISolicitacaoService, SolicitacaoService>();
            services.AddScoped<ITipoCursoService, TipoCursoService>();

            services.AddScoped<IAtividadeRepository, AtividadeRepository>();
            services.AddScoped<ICursoRepository, CursoRepository>();
            services.AddScoped<ISolicitacaoRepository, SolicitacaoRepository>();
            services.AddScoped<ITipoCursoRepository, TipoCursoRepository>();

            services.AddMvc().SetCompatibilityVersion(CompatibilityVersion.Version_2_2);
            services.AddAutoMapper();
            services.AddCors();
        }

        // This method gets called by the runtime. Use this method to configure the HTTP request pipeline.
        public void Configure(IApplicationBuilder app, IHostingEnvironment env, ILoggerFactory loggerFactory)
        {
            if (env.IsDevelopment())
            {
                app.UseDeveloperExceptionPage();
            }
            else
            {
                // The default HSTS value is 30 days. You may want to change this for production scenarios, see https://aka.ms/aspnetcore-hsts.
                app.UseHsts();
            }

            loggerFactory.AddProvider(new CustomLoggerProvider(
                new CustomLoggerProviderConfiguration
                {
                    LogLevel = LogLevel.Information
                }
            ));

            // app.UseHttpsRedirection();
            app.UseCors(x => x.AllowAnyOrigin().AllowAnyMethod().AllowAnyHeader());
            app.UseStaticFiles();
            app.UseMvc();
        }
    }
}
