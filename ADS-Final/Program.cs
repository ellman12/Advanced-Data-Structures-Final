// string[] paths = Directory.GetFiles("D:/My Backups/Sorted Pics and Vids From Phone, Switch, and Elsewhere 3-21-2022", "*.*", SearchOption.AllDirectories);
// HashSet<string> hashSet = new(paths.Length);
// foreach(string path in paths)
// {
//     string filename = Path.GetFileName(path.Replace('\\', '/'));
//     hashSet.Add(filename);
//     Console.WriteLine($"{filename}\t{filename.GetHashCode()}\t{Math.Abs(filename.GetHashCode() % paths.Length)}");
// }

// string[] paths = Directory.GetFiles("D:/My Backups/Sorted Pics and Vids From Phone, Switch, and Elsewhere 3-21-2022", "*.*", SearchOption.AllDirectories);
// List<uint> hashes = new(paths.Length);
// uint dupeAmt = 0;
// foreach (string path in paths)
// {
//     uint hash = (uint) Math.Abs(Path.GetFileName(path).GetHashCode() % paths.Length);
//     if (hashes.Contains(hash))
//     {
//         Console.WriteLine("dupe");
//         dupeAmt++;
//     }
//     hashes.Add(hash);
// }
//
// Console.WriteLine(dupeAmt);

using System.Diagnostics;

string[] paths = Directory.GetFiles("C:/Users/Elliott/Documents/GitHub", "*.*", SearchOption.AllDirectories);
// ADS_Final.HashSet<string> hashSet = new(paths.Length);
ADS_Final.HashSet<string> hashSet = new(20);
Stopwatch s = Stopwatch.StartNew();
foreach (string path in paths)
{
    string filename = Path.GetFileName(path.Replace('\\', '/'));
    hashSet.Add(filename);
}

s.Stop();
Console.WriteLine($"HashSet has count {hashSet.Count} and capacity {hashSet.Capacity} and took {s.ElapsedMilliseconds} ms");
Console.WriteLine($"Searching for \"README.md\": {hashSet.Find("README.md")}");
Console.WriteLine($"Searching for \"asasasasasas\": {hashSet.Find("asasasasasas")}");
Console.WriteLine($"Contains() for \"README.md\": {hashSet.Contains("README.md")}");
Console.WriteLine($"Contains() for \"asasasasasas\": {hashSet.Contains("asasasasasas")}\n\n");

Console.WriteLine($"Removing \"README.md\": {hashSet.Remove("README.md")}");
Console.WriteLine($"Contains() for \"README.md\": {hashSet.Contains("README.md")}");
Console.WriteLine($"Removing \"asasasasasas\": {hashSet.Remove("asasasasasas")}");
Console.WriteLine($"Contains() for \"asasasasasas\": {hashSet.Contains("asasasasasas")}");
Console.WriteLine($"HashSet has count {hashSet.Count} and capacity {hashSet.Capacity} and took {s.ElapsedMilliseconds} ms");

ADS_Final.HashSet<int> ints = new(20);
for (int i = 0; i < ints.Capacity; i++)
    ints.Add(i);
ints.Remove(10);