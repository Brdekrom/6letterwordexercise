namespace Exercise.Domain;

public class WordCombinator(ISourceReader sourceReader, IMessageSender messageSender) : ITextCombinator
{
  public async Task CombineAsync()
  {
    var completeWords = GetFullWords().ToList();
    var builders       = completeWords.ToDictionary(w => w, _ => new List<string>());

    var occurrences = completeWords
      .GroupBy(w => w)
      .ToDictionary(g => g.Key, g => g.Count());

    await foreach (var chunk in sourceReader.ReadStreamAsync())
    {
      var cleaned = chunk.Trim();
      if (string.IsNullOrWhiteSpace(cleaned))
        continue;

      foreach (var word in completeWords.ToList())
      {
        if (occurrences[word] == 0)
          continue;

        var builder = builders[word];
        var current = string.Concat(builder) + cleaned;

        if (!word.StartsWith(current))
          continue;

        builder.Add(cleaned);

        if (current == word)
        {
          var output = $"{string.Join("+", builder)} = {word}";
          await messageSender.SendAsync(output);

          builder.Clear();
          occurrences[word]--;

          if (occurrences[word] == 0)
          {
            builders.Remove(word);
          }
        }
      }
    }
  }

    private IEnumerable<string> GetFullWords()
    {
        var words = sourceReader.ReadFile().ToList();
        if (words.Count == 0) yield break;

        var max = words.Max(w => w.Length);
        foreach (var w in words.Where(w => w.Length == max))
            yield return w;
    }
  }