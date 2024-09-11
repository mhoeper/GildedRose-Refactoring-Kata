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

    private static int? GetDays(string[] args)
    {
        if (args.Length > 0)
        {
            if (int.TryParse(args[0], out var days))
            {
                return days;
            }
        }
        return null;
    }

    public static void Main(string[] args)
    {
        var serviceCollection = new ServiceCollection();
        ConfigureServices(serviceCollection); 
        var serviceProvider = serviceCollection.BuildServiceProvider();

        var gildedRose = serviceProvider.GetService<GildedRose>(); 

        Console.WriteLine("OMGHAI!");

        var days = GetDays(args); 
        if (days == null)
        {
            Console.WriteLine("Usage: GildedRose <days>");
            return; 
        }

        for (var day = 0; day <= days; day++)
        {
            gildedRose.PrintDayInformation(day);
            gildedRose.UpdateQuality();
        }
    }
}