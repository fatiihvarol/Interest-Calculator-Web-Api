    using System.Reflection;
    using Interest_Calculator.Business.Cqrs;

    var builder = WebApplication.CreateBuilder(args);

    // Add services to the container.
    // Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
    builder.Services.AddEndpointsApiExplorer();
    builder.Services.AddSwaggerGen();
    builder.Services.AddControllers();
    builder.Services.AddMediatR(cfg => cfg.RegisterServicesFromAssembly(typeof(CalculateBasicInterestQuery).GetTypeInfo().Assembly));

    var app = builder.Build();

    // Configure the HTTP request pipeline.
    if (app.Environment.IsDevelopment())
    {
        app.UseSwagger();
        app.UseSwaggerUI();
    }
    app.UseHttpsRedirection();
    app.UseRouting();
    app.UseEndpoints(x => { x.MapControllers(); });

    app.UseHttpsRedirection();
    


    app.Run();

