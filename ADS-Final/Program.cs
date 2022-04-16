//Define 2 sets and print them out.
ADS_Final.HashSet<int> set1 = new(new[] {1, 2, 3, 4, 5, 6, 7});
Console.Write("Set 1: ");
set1.Print();
ADS_Final.HashSet<int> set2 = new(new[] {2, 5, 7, 9, 40});
Console.Write("Set 2: ");
set2.Print();
Console.Write("Union: ");
set1.UnionWith(set2).Print();
Console.Write("Intersection: ");
set1.IntersectWith(set2).Print();
Console.Write("Difference: ");
set1.DifferenceWith(set2).Print();
Console.Write("Symm Difference: ");
set1.SymmetricDifferenceWith(set2).Print();

//Sets of strings
Console.WriteLine();
ADS_Final.HashSet<string> strings1 = new();
strings1.Add(new[] {"hi", "hello"});
strings1.Add("i am another string");
strings1.Print(true);
Console.WriteLine();
Console.WriteLine();
ADS_Final.HashSet<string> strings2 = new(6);
strings2.Add(new[] {"hi", "i am another string", "this is another string", "a sequence of characters"});
strings2.Print(true);
Console.WriteLine();
Console.WriteLine("Union: ");
strings1.UnionWith(strings2).Print(true);
Console.WriteLine();

Console.WriteLine("Intersection: ");
strings1.IntersectWith(strings2).Print(true);
Console.WriteLine();

Console.WriteLine("Difference: ");
strings1.DifferenceWith(strings2).Print(true);
Console.WriteLine();

Console.WriteLine("Symm Difference: ");
strings1.SymmetricDifferenceWith(strings2).Print(true);
Console.WriteLine();

Console.WriteLine("Set 1: ");
set1.Print();
set1.Clear();
Console.WriteLine("\nSet 1 Cleared: ");
set1.Print();
Console.WriteLine("Set 2: ");
set2.Print();
set2.Remove(40);
set2.Print();

ADS_Final.HashSet<double> set3 = new(new[] {3.14, 6.78, 23.05, 90.54});
List<double> setAsList = set3.GetEnumerable().ToList();
double[] setAsArray = set3.GetEnumerable().ToArray();