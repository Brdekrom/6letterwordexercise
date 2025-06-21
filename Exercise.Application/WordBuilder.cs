namespace Exercise.Domain;

public class WordBuilder
{
  public string Target { get; }
  public List<string> Chunks { get; }
  
  public WordBuilder(string target, List<string> chunks)
  {
    Target = target;
    Chunks = chunks;
  }

  private string Current => string.Concat(Chunks);

  public bool IsMatch => Current == Target;
  public bool IsStillPossible => Target.StartsWith(Current);

  public WordBuilder CloneWith(string nextChunk)
  {
    return new WordBuilder(Target, [..Chunks, nextChunk]);
  }
}
