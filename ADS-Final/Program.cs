string[] paths = Directory.GetFiles("D:/My Backups/Sorted Pics and Vids From Phone, Switch, and Elsewhere 3-21-2022", "*.*", SearchOption.AllDirectories);
HashSet<string> hashSet = new(paths.Length);
foreach(string path in paths)
{
    string filename = Path.GetFileName(path.Replace('\\', '/'));
    hashSet.Add(filename);
    Console.WriteLine($"{filename}\t{filename.GetHashCode()}\t{Math.Abs(filename.GetHashCode() % paths.Length)}");
}

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