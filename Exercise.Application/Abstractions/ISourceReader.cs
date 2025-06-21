namespace Exercise.Domain;

public interface ISourceReader {
  
  public IAsyncEnumerable<string> ReadStreamAsync();

  public IEnumerable<string> ReadFile();
}