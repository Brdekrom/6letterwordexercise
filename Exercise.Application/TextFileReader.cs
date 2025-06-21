using Microsoft.Extensions.Options;

namespace Exercise.Domain;

public class TextFileReader(IOptions<AppOptions> options) : ISourceReader 
{
  public async IAsyncEnumerable<string> ReadStreamAsync()
  {
    var path = options.Value.SourcePath;
    if (!File.Exists(path))
      throw new FileNotFoundException($"The file at '{path}' was not found.");

    await using var stream = File.OpenRead(path);

    using var reader = new StreamReader(stream);

    string? line;
    while ((line = await reader.ReadLineAsync()) != null)
    {
      yield return line;
    }
  }

  public IEnumerable<string> ReadFile()
  {
    var path = options.Value.SourcePath;
    if (!File.Exists(path))
      throw new FileNotFoundException($"The file at '{path}' was not found.");

    var lines = File.ReadLines(path);
    var uniqueLines = lines.Where(l => !string.IsNullOrWhiteSpace(l)).ToHashSet();

    if (!uniqueLines.Any())
      throw new InvalidDataException("File is empty or contains only blank lines.");

    return uniqueLines;
  }
}