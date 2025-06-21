namespace Exercise.Domain;

public interface IMessageSender {
  Task SendAsync(string message);
}