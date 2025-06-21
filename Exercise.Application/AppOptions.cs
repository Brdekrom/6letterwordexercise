namespace Exercise.Domain;

//For showing best practices. not adding any config or secret to this app for simplicity.
public class AppOptions 
{
  public required string Position = "AppOptions";
  public required string SourcePath { get; init; } = "input.txt";
}