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
foreach(string path in paths)
{
    string filename = Path.GetFileName(path.Replace('\\', '/'));
    hashSet.Add(filename);
    // Console.WriteLine($"{filename}\t{filename.GetHashCode()}\t{Math.Abs(filename.GetHashCode() % paths.Length)}");
}
s.Stop();
Console.WriteLine($"HashSet has count {hashSet.Count} and capacity {hashSet.Capacity} and took {s.ElapsedMilliseconds} ms");