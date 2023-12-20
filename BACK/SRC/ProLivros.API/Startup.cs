using Microsoft.OpenApi.Models;
using Microsoft.EntityFrameworkCore;
using ProLivros.Persistence;
<<<<<<< HEAD
=======
using ProLivros.Application;
>>>>>>> PROLIVROS COMMIT-06

namespace ProLivros5
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
<<<<<<< HEAD
  
            
                        services.AddDbContext<ProLivrosContext>(options => options.UseSqlServer(Configuration.GetConnectionString("ProLivrosAPIContext")));
                    
=======


            services.AddDbContext<ProLivrosContext>(options => options.UseSqlServer(Configuration.GetConnectionString("ProLivrosAPIContext")));
            services.AddScoped<ILivroService, LivroService>();
            // services.AddScoped<IAssuntoService, AssuntoService>();
            // services.AddScoped<<IAutorService, AutorService>();
            services.AddScoped<IGeralPersistence, GeralPersistence>();
            services.AddScoped<ILivroPersistence, LivroPersistence>();
            // services.AddScoped< IAssuntoPersistence, AssuntoPersistence>();
            // services.AddScoped< IAutorPersistence, AutorPersistence>();    

>>>>>>> PROLIVROS COMMIT-06
            services.AddControllers();
            services.AddCors();
            services.AddSwaggerGen(c =>
            {
                c.SwaggerDoc("v1", new OpenApiInfo { Title = "ProLivros.API", Version = "v1" });
            });
        }

        // This method gets called by the runtime. Use this method to configure the HTTP request pipeline.
        public void Configure(IApplicationBuilder app, IWebHostEnvironment env)
        {
            if (env.IsDevelopment())
            {
                app.UseDeveloperExceptionPage();
                app.UseSwagger();
                app.UseSwaggerUI(c => c.SwaggerEndpoint("/swagger/v1/swagger.json", "ProLivros5 v1"));
            }

            app.UseHttpsRedirection();

            app.UseRouting();

            app.UseAuthorization();

            app.UseCors(x => x.AllowAnyHeader()
                              .AllowAnyMethod()
                              .AllowAnyOrigin());

            app.UseEndpoints(endpoints =>
            {
                endpoints.MapControllers();
            });
        }
    }
}
