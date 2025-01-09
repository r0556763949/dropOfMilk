
using BL;
using DL;
using BL.InterfaceService;

namespace dropOfMilk
{
    public class Program
    {
        public static void Main(string[] args)
        {
            var builder = WebApplication.CreateBuilder(args);

            builder.Services.AddEndpointsApiExplorer();
            builder.Services.AddSwaggerGen();
            // Add services to the container.
            builder.Services.AddSingleton<IBabyService, BabyService>();
            builder.Services.AddSingleton<IAppointmentService, AppointmentService>();
            builder.Services.AddSingleton<INurseService, NurseService>();
            builder.Services.AddSingleton<IDataContext, DataContext>();
            builder.Services.AddControllers();
            // Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle


            var app = builder.Build();
            
            // Configure the HTTP request pipeline.
            if (app.Environment.IsDevelopment())
            {
                app.UseSwagger();
                app.UseSwaggerUI();
            }

            app.UseHttpsRedirection();

            app.UseAuthorization();

            app.MapControllers();

            app.Run();
        }
    }
}

