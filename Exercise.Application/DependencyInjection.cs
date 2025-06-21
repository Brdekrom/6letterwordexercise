using Exercise.Domain;

namespace Microsoft.Extensions.DependencyInjection;

public static class DependencyInjection {

  public static IServiceCollection AddApplication(this IServiceCollection services) {
    services.AddScoped<ISourceReader, TextFileReader>();
    services.AddScoped<ITextCombinator, WordCombinator>();
    services.AddScoped<IMessageSender, ConsoleLogger>();
    
    return services;
  }
}