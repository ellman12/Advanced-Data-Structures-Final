//Define 2 sets and print them out.
ADS_Final.HashSet<int> set1 = new(new[] {1, 2, 3, 4, 5, 6, 7});
set1.Print();
ADS_Final.HashSet<int> set2 = new(new[] {2, 5, 7, 9, 40});
set2.Print();

//Set of strings
ADS_Final.HashSet<string> strings = new();
strings.Add(new[] {"hi", "hello"});
strings.Add("i am another string");
strings.Print();