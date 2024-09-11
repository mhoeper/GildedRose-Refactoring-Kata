using GildedRoseKata.Factories;
using GildedRoseKata.Interfaces;
using GildedRoseKata.Repositories;
using Microsoft.Extensions.DependencyInjection;
using System;

namespace GildedRoseKata;

public class Program
{
    private static void ConfigureServices(IServiceCollection services)
    {
        services.AddSingleton<GildedRose>();
        services.AddSingleton<UpdateStrategyFactory>();
        services.AddSingleton<IItemRepository, ItemRepository>(); 
    }

    public static void Main(string[] args)
    {
        var serviceCollection = new ServiceCollection();
        ConfigureServices(serviceCollection); 

        var serviceProvider = serviceCollection.BuildServiceProvider();

        var gildedRose = serviceProvider.GetService<GildedRose>(); 

        Console.WriteLine("OMGHAI!");

        int days = 2;
        if (args.Length > 0)
        {
            days = int.Parse(args[0]) + 1;
        }

        for (var i = 0; i < days; i++)
        {
            gildedRose.PrintDayInformation(i);
            gildedRose.UpdateQuality();
        }
    }
}