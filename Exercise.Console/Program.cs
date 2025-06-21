﻿using Exercise.Domain;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;

var host = Host.CreateDefaultBuilder(args)
  .ConfigureServices((context, services) => {
    services.AddApplication();
  })
  .Build();

var wordCombinator = host.Services.GetService<ITextCombinator>();
await wordCombinator!.CombineAsync();


