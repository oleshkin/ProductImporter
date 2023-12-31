﻿using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using ProductImporter.Logic.Shared;
using ProductImporter.Logic.Source;
using ProductImporter.Logic.Target;
using ProductImporter.Logic.Transformation;
using System;

namespace ProductImporter.Logic;

public static class DIRegistrations
{
    public static IServiceCollection AddProductImporterLogic(this IServiceCollection services)
    {
        services.AddTransient<IPriceParser, PriceParser>();
        services.AddTransient<IProductFormatter, ProductFormatter>();
        services.AddTransient<IProductTarget, CsvProductTarget>();

        services.AddHttpClient<IProductSource, HttpProductSource>()
            .ConfigureHttpClient((serviceProvider, client) =>
            {
                var config = serviceProvider.GetRequiredService<IConfiguration>();
                var baseAddress = config.GetSection("BaseAddress").Value;
                client.BaseAddress = new Uri(baseAddress);
            });

        services.AddTransient<Logic.ProductImporter>();

        services.AddSingleton<IImportStatistics, ImportStatistics>();
        services.AddTransient<IProductTransformer, ProductTransformer>();

        services.AddOptions<ProductSourceOptions>()
            .Configure<IConfiguration>((options, configuration) =>
            {
                configuration.GetSection(ProductSourceOptions.SectionName).Bind(options);
            });

        services.AddOptions<CsvProductTargetOptions>()
            .Configure<IConfiguration>((options, configuration) =>
            {
                configuration.GetSection(CsvProductTargetOptions.SectionName).Bind(options);
            });

        return services;
    }
}
