using System;
using System.Reflection;
using Microsoft.Extensions.DependencyInjection;
using StaticDependencyInjection;

namespace Sample
{
    class Program
    {
        private readonly IHelloService _hello;

        public Program(IHelloService hello)
        {
            _hello = hello;
        }

        public void Run()
        {
            _hello.Hello();
        }

        static void Main(string[] args)
        {
            var program = new ServiceCollection()
                .AddStaticServices(Assembly.GetExecutingAssembly())
                .AddSingleton(typeof(Program))
                .BuildServiceProvider()
                .GetService<Program>();

            program.Run();
        }
    }

    [SingletonServiceWithImpl(typeof(HelloService))]
    public interface IHelloService
    {
        void Hello();
    }
    
    public class HelloService : IHelloService
    {
        public void Hello() => Console.WriteLine("Hello");
    }
}