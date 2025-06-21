namespace Exercise.Domain;

public class ConsoleLogger : IMessageSender
{
  public Task SendAsync(string message) 
  {
    Console.WriteLine(message);
    return Task.CompletedTask;
  }
}