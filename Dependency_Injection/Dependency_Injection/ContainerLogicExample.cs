using Dependency_Injection.Services;

namespace Dependency_Injection
{
    public class ContainerLogicExample
    {

        //Bu sınıfta IServiceCollection ile .NET Core un built-in (dahili) Ioc yapılanması anlatılmaktadır.
        public ContainerLogicExample() { 

            //IServiceCollection türü IoC yapılanmasının Arayüzüdür. DependencyInjectiondan gelir. 
            IServiceCollection services = new ServiceCollection(); //built - in IoC

            //services dediğimizde sistemde hazır gelen servislerin herhangi birini ekleyebiliriz. Bu şekilde servisin sınıflarını kullanılabilir vaziyette mimarinin container ına eklemek demektir.

            //Örnek => services.AddCors(); 

            //custon sınıfları/Service leri Add fonksiyonu ile ekleriz.
            services.Add(new ServiceDescriptor(typeof(ConsoleLog), new ConsoleLog()));
            /*
             *Add methodu parametre olarak serviceDescriptor alır.
             *Service descriptor hangi tür nesne koyacaksak onun tipini ve nesnesini ister.
             *typeof(ConsoleLog) => bu sınıfın tipinde , new ConsoleLog() => ConsoleLog sınıfından oluşturulan nesne)
             *Bu sayede ConsoleLog sınıfı içerisinde ki herhangi bir methoda ulaşabiliriz.
             */

            //Bu yöntem(Add ile her servisi tek tek eklemek) default olarak SINGLETON davranışıdır !

            services.Add(new ServiceDescriptor(typeof(TextLog), new TextLog()));

            //Peki Add ile container a eklediğimiz değerleri daha sonra nasıl elde ederiz ?
            ServiceProvider provider = services.BuildServiceProvider(); //BuildServiceProvider() => ilgili container/provider ı direk oluşturur. 

            //Örneğin GetService dediğimizde yukarıda belirttiğimiz generic tür e karşılık gelen nesne neyse onu döndürür.
            //Artık Newlemeye gerek yoktur !
            provider.GetService<ConsoleLog>();
            provider.GetService<TextLog>();

        }
    }
}
