namespace _09_GPT
{
    internal class Program
    {
        static void Main(string[] args)
        {
            GPT gpt = new GPT();
            gpt.Train("The quick brown fox jumps over the lazy dog near the river bank.");
            string generatedText = GenerateText(gpt, startChar: 't', length: 5);
            Console.WriteLine($"Generated text: {generatedText}");
        }

        static string GenerateText(GPT nn, char startChar, int length)
        {
            string text = startChar.ToString();
            char nextChar = startChar;

            for (int i = 0; i < length; i++)
            {
                nextChar = nn.PredictNextChar(nextChar);
                text += nextChar;
            }

            return text;
        }
    }
}
