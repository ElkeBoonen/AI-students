List<string> spam = new List<string>();
List<string> ham = new List<string>();

foreach (string line in File.ReadAllLines("sample_spam_ham_subset.csv"))
{
    if (line.StartsWith("spam")) spam.Add(line.Substring(5));
    else ham.Add(line.Substring(4));
}

Console.WriteLine(String.Join(" ", spam));

Console.WriteLine(String.Join(" ", ham));
NB nb = new NB();
nb.Train(spam, ham);
