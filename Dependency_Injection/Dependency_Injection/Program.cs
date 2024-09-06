using Dependency_Injection.Services;
using Dependency_Injection.Services.Interfaces;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.

builder.Services.AddControllers();
// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

// Add custom services for Dependency Injection  (IoC için Container a nesnemizi eklemi? oluyoruz)
//builder.Services.AddScoped<IMyService, MyService>(); //Yeni kullan?m ? 

builder.Services.Add(new ServiceDescriptor(typeof(ConsoleLog), new ConsoleLog())); //singleton davran??
/* Add in singleton de?ilde transient davran?? göstermesini istersek;
 *serviceDesscriptor ?n ctorununun overload unda (serviceLifeTime) istedi?imiz davran??? seçebiliriz.
 *Bu durumda a?a??daki kodda arayüzüde bildirmek gerekmektedir. Yoksa hata verir . (Implementation)
 */
//builder.Services.Add(new ServiceDescriptor(typeof(ConsoleLog), new ConsoleLog(), ServiceLifetime.Transient)); //ConsoleLog tan gelen her talebe kar??l?k bir nesne üretilir.


//Add fonksiyonu çok efective de?ildir. Davran??lara göre operasyon yapacaksak bunun için haz?r methodlar mevcuttur.

//Singleton bütün talepler/isteklerde tek nir nesneyi yap?p onu gönderir.
builder.Services.AddSingleton<ConsoleLog>();

//parametreli constroctorlarda ne yapilmali ?
builder.Services.AddSingleton<ConsoleLogWithParameters>(p => new ConsoleLogWithParameters("seher"));


//Di?er davran??lar 
builder.Services.AddTransient<ConsoleLog>();
builder.Services.AddTransient<ConsoleLogWithParameters>(p => new ConsoleLogWithParameters("seher"));

builder.Services.AddScoped<ConsoleLog>();
builder.Services.AddScoped<ConsoleLogWithParameters>(p => new ConsoleLogWithParameters("seher"));



//Abtraction mantigi, ornek olarak AddScoped kullanaca??m
builder.Services.AddScoped<ILog, ConsoleLog>(); //ILog turunde nesne eklenir. nesne Ilog tan türemek zorunda
//bu nesnenin talebini contructorlar üzerinden yapar?z. => LogController


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
