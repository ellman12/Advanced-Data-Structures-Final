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

// using System.Diagnostics;
//
// string[] paths = Directory.GetFiles("C:/Users/Elliott/Documents/GitHub/", "*.*", SearchOption.AllDirectories);
// ADS_Final.HashSet<string> hashSet = new(paths.Length);
// Stopwatch s = Stopwatch.StartNew();
// foreach (string path in paths)
// {
//     string filename = Path.GetFileName(path.Replace('\\', '/'));
//     hashSet.Add(filename);
// }
//
// s.Stop();
// Console.WriteLine($"HashSet has count {hashSet.Count} and capacity {hashSet.Capacity} and took {s.ElapsedMilliseconds} ms.");

/*
ADS_Final.HashSet<int> ints = new(20);

for (int i = 0; i < 20; i++) ints.Add(i);
ints.Print(false);
ints.Clear();
ints.Print(false);

for (int i = 0; i < 20; i++) ints.Add(i);
ints.Print(false);
// ints.Clear();
// ints.Print(false);

ints.Remove(5);
ints.Remove(5);
ints.Remove(30);
ints.Remove(0);
ints.Remove(16);
ints.Print(false);

ints.Add(30);
ints.Add(-10);
ints.Add(-69);
ints.Add(-0);
ints.Add(0);
ints.Add(0);
ints.Add(0);
ints.Print(false);
*/

using System.Diagnostics;

// ADS_Final.HashSet<int> set1 = new(10);
// set1.Add(0);
// set1.Add(2);
// set1.Add(4);
// set1.Add(6);
// set1.Add(8);
// set1.Add(10);
//
// ADS_Final.HashSet<int> set2 = new(10);
// set2.Add(1);
// set2.Add(3);
// set2.Add(5);
// set2.Add(7);
// set2.Add(9);
// set2.Add(11);
//
// set1.Print(false);
// set2.Print(false);
// set1.UnionWith(set2);
// set1.Print(false);
//
// ADS_Final.HashSet<string> strings1 = new(5);
// strings1.Add("a");
// strings1.Add("b");
// strings1.Add("c");
// strings1.Add("d");
// strings1.Add("e");
// strings1.Print(false);
// ADS_Final.HashSet<string> strings2 = new(0);
// strings2.Add("e");
// strings2.Add("f");
// strings2.Add("g");
// strings2.Print(false);
// strings1.UnionWith(strings2);
// strings1.Print(false);
//
Stopwatch yes = Stopwatch.StartNew();
// set1.Add(new[] {20, 30, 40, 50, 60, 70, 80, 90, 100, 110, 293829, 32844, 9883298});
// // strings2.Contains("f");
// Console.WriteLine(yes.Elapsed);
// Console.WriteLine(yes.ElapsedMilliseconds);
// set1.Print(false);

ADS_Final.HashSet<int> set1 = new(new []{4, 5, 6, 7, 8, 9, 10, 11, 12, 13, 14, 15});
ADS_Final.HashSet<int> set2 = new(new []{2, 3, 4, 5, 6});
set1.Print(false);
set2.Print(false);
ADS_Final.HashSet<int> newSet = set1.SymmetricDifferenceWith(set2);
newSet.Print(false);
yes.Stop();
Console.WriteLine(yes.Elapsed);