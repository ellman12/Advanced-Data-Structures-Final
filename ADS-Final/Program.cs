using System.Diagnostics;

Stopwatch s = Stopwatch.StartNew();
string[] paths = Directory.GetFiles("C:/Users/Elliott/Videos/tmp/GitHub Backup 3-27-2022 5;30;28 PM", "*.*", SearchOption.AllDirectories);
s.Stop();
Console.WriteLine($"Took {s.ElapsedMilliseconds} ms to get all {paths.Length} paths");

HashSet<string> hashSet = new(paths.Length);
s = Stopwatch.StartNew();
foreach(string path in paths)
{
    hashSet.Add(path.Replace('\\', '/'));
}
s.Stop();
Console.WriteLine($"Took {s.ElapsedMilliseconds} ms to add all {paths.Length} paths");

Console.WriteLine(hashSet.Contains("C:/Users/Elliott/Videos/tmp/GitHub Backup 3-27-2022 5;30;28 PM"));
Console.WriteLine(hashSet.Contains("C:/Users/Elliott/Videos/tmp/GitHub Backup 3-27-2022 5;30;28 PM/Graphical-Photo-Organizer/README.md"));