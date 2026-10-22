// EXP-02: wpływ zero-shot, one-shot i few-shot na jakość ekstrakcji
public static class Prompting
{
    private const string Model = "GLM-5.3-Flash";

    public static async Task RunAsync(IClient client)
    {
        var examples = TestData.PromptExamples;

        var randomOneShot = new[] { examples[Random.Shared.Next(examples.Count)] };
        var variants = new (string Name, Func<string, string> Prompt)[]
        {
            ("zero-shot", note => Extraction.Prompt(note)),
            ("one-shot", note => Extraction.Prompt(note, randomOneShot)),
            ("few-shot", note => Extraction.Prompt(note, examples))
        };

        foreach (var (name, buildPrompt) in variants)
        {
            Console.WriteLine($"\nWariant: {name}");

            var metrics = await Extraction.EvaluateAsync(
                client,
                Model,
                TestData.Examples,
                buildPrompt);

            ResultsCsv.Append("EXP-02", Model, name, 0, metrics);
        }
    }
}
