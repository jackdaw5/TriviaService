using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.HttpsPolicy;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using Microsoft.Extensions.Logging;
using Autofac;
using Autofac.Extensions.DependencyInjection;
using DDTriviaService.Managers;
using DDTriviaService.Managers.Interfaces;
using Microsoft.OpenApi.Models;
using DDTriviaService.Controllers;
using System.Reflection;
using System.Diagnostics;
using Swashbuckle.Swagger;
using Swashbuckle.AspNetCore.Swagger;
using DDTriviaService.Respositories.Interfaces;
using DDTriviaService.Respositories;

namespace DDTriviaService
{
	public class Startup
	{
		public Startup(IConfiguration configuration)
		{
			Configuration = configuration;
		}

		public IConfiguration Configuration { get; set; }

		// This method gets called by the runtime. Use this method to add services to the container.
		public IServiceProvider ConfigureServices(IServiceCollection services)
		{
			ContainerBuilder builder = new ContainerBuilder();
			builder.RegisterType<DDTriviaServiceManager>()
				.As<IDDTriviaServiceManager>()
				.SingleInstance();

			builder.Populate(services);
			builder.RegisterType<DDTriviaServiceRepository>()
			.As<IDDTriviaServiceRepository>()
			.SingleInstance();

			services.AddMvc();
			//services.AddSingleton<IDDTriviaServiceManager, DDTriviaServiceManager>();
			//services.AddSingleton<IDDTriviaServiceRepository, DDTriviaServiceRepository>();
			services.AddSwaggerGen(c =>
			{

				c.SwaggerDoc("v1", new OpenApiInfo { Title = "DDTriviaService", Version = "v1" });
			});

			return new AutofacServiceProvider(builder.Build());

		}

		// This method gets called by the runtime. Use this method to configure the HTTP request pipeline.
		public void Configure(IApplicationBuilder app, IWebHostEnvironment env)
		{
			app.UseSwagger();

			app.UseSwaggerUI(c =>
			{
				c.SwaggerEndpoint("/swagger/v1/swagger.json", "DDTriviaService");
				//string appName = Assembly.GetExecutingAssembly().GetName().Name;
				//c.SwaggerEndpoint($"../swagger/{appName}/swagger.json", appName);
				//c.RoutePrefix = string.Empty;

			});

			//if (env.IsDevelopment())
			//{
			//	app.UseDeveloperExceptionPage();
			//}

			//app.UseHttpsRedirection();

			//app.UseRouting();

			//app.UseAuthorization();

			//app.UseEndpoints(endpoints =>
			//{
			//	endpoints.MapControllers();
			//});
		}
	}
}
