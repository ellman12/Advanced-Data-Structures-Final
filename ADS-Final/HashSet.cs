namespace ADS_Final;

public class HashSet<T>
{
	public int Capacity { get; private set; } //Size of array
	public int Count { get; private set; } //How many indexes have a value.
	private LinkedList<T>[] array; //Array is fixed size but the LinkedLists are not.
	private const int DEFAULT_CAPACITY = 20;

	public HashSet()
	{
		Capacity = DEFAULT_CAPACITY;
		array = new LinkedList<T>[Capacity];
		for (int i = 0; i < array.Length; i++)
			array[i] = new LinkedList<T>();
	}

	public HashSet(int capacity)
	{
		Capacity = capacity;
		array = new LinkedList<T>[Capacity];
		for (int i = 0; i < array.Length; i++)
			array[i] = new LinkedList<T>();
	}

	public HashSet(IEnumerable<T> items)
	{
		Capacity = DEFAULT_CAPACITY;
		array = new LinkedList<T>[Capacity];
		for (int i = 0; i < array.Length; i++)
			array[i] = new LinkedList<T>();

		foreach (T item in items) Add(item);
	}

	///Get the index of the LinkedList where this item should be stored.
	private int Hash(T value) => Math.Abs(value!.GetHashCode() % array.Length);

	///<summary>Returns true if the HashSet contains this value.</summary>
	public bool Contains(T value) => array[Hash(value)].Contains(value);

	///<summary>Adds a value to the HashSet.</summary>
	///<returns>True if the value was added, false if it was already in the HashSet and thus wasn't added.</returns>
	public bool Add(T value)
	{
		if (Contains(value)) return false;
		Count++;
		array[Hash(value)].AddLast(value);
		return true;
	}

	///<summary>Add a range of items to the HashSet.</summary>
	public void Add(IEnumerable<T> items)
	{
		foreach (T item in items) Add(item);
	}

	///<summary>Remove the value from the HashSet.</summary>
	///<returns>True if removed, false if wasn't found and thus nothing to remove.</returns>
	public bool Remove(T value)
	{
		if (!Contains(value)) return false;
		array[Hash(value)].Remove(value);
		Count--;
		return true;
	}

	///<summary>Remove everything from HashSet and shrink it.</summary>
	public void Clear()
	{
		Count = 0;
		array = new LinkedList<T>[Capacity];
		for (int i = 0; i < array.Length; i++)
			array[i] = new LinkedList<T>();
	}

	///<summary>Print all elements of the HashSet</summary>
	public void Print(bool newLine = false)
	{
		if (newLine)
		{
			foreach (LinkedList<T> linkedList in array)
				foreach (T value in linkedList) Console.WriteLine(value);
		}
		else
		{
			foreach (LinkedList<T> linkedList in array)
				foreach (T value in linkedList) Console.Write($"{value} ");
			Console.WriteLine();
		}
	}

	///<summary>Performs union set operation, adding everything from HashSet other to this set.</summary>
	///<param name="other">The set with elements to add to this one.</param>
	///<exception cref="ArgumentException">Thrown if sets aren't of the same type.</exception>
	public HashSet<T> UnionWith(HashSet<T> other)
	{
		if (GetType() != other.GetType()) throw new ArgumentException("Both HashSets need to be of the same type.");

		HashSet<T> union = new();

		//Add items from both HashSet to the one returned.
		foreach (LinkedList<T> list in array)
			foreach (T item in list) union.Add(item);

		foreach (LinkedList<T> list in other.array)
			foreach (T item in list) union.Add(item);

		return union;
	}

	///<summary>Performs intersection set operation, creating and returning a new HashSet with only the values in both HashSets.</summary>
	///<param name="other">The other set to use for intersection.</param>
	///<returns>A new HashSet with the intersection of the other HashSet and this HashSet.</returns>
	///<exception cref="ArgumentException">Thrown if sets aren't of the same type.</exception>
	public HashSet<T> IntersectWith(HashSet<T> other)
	{
		if (GetType() != other.GetType()) throw new ArgumentException("Both HashSets need to be of the same type.");

		HashSet<T> intersection = new();

		foreach (LinkedList<T> list in array)
		{
			foreach (T item in list)
				if (other.Contains(item))
					intersection.Add(item);
		}

		return intersection;
	}

	///<summary>Returns a new HashSet with all the items from the first set that are NOT in the other set.</summary>
	///<param name="other">The other set to use.</param>
	///<exception cref="ArgumentException">Thrown if sets aren't of the same type.</exception>
	public HashSet<T> DifferenceWith(HashSet<T> other)
	{
		if (GetType() != other.GetType()) throw new ArgumentException("Both HashSets need to be of the same type.");

		HashSet<T> difference = new();

		foreach (LinkedList<T> list in array)
		{
			foreach (T item in list)
				if (!other.Contains(item))
					difference.Add(item);
		}

		return difference;
	}

	///<summary>Returns a new HashSet with all of the elements in at least one of the sets this-other or other-this. Basically xor of the 2 sets.</summary>
	///<param name="other">The other set to use.</param>
	///<exception cref="ArgumentException">Thrown if sets aren't of the same type.</exception>
	///<remarks>Symmetric difference can be thought of as the union of A-B and B-A (i.e., A-B ∪ B-A). This is what this method does.</remarks>
	public HashSet<T> SymmetricDifferenceWith(HashSet<T> other) => DifferenceWith(other).UnionWith(other.DifferenceWith(this));

	///<summary>Compare the 2 HashSets and if they both contain the same values (regardless of where in the arrays they are), return true. False otherwise.</summary>
	public static bool operator ==(HashSet<T> a, HashSet<T> b)
	{
		if (a.Count != b.Count) return false;

		foreach (LinkedList<T> list in a.array)
		{
			foreach (T item in list)
				if (!list.Contains(item))
					return false;
		}

		foreach (LinkedList<T> list in b.array)
		{
			foreach (T item in list)
				if (!list.Contains(item))
					return false;
		}

		return true;
	}

	public static bool operator !=(HashSet<T> a, HashSet<T> b) => !(a == b);

	///<summary>Returns all the values in this HashSet as an unsorted IEnumerable.</summary>
	public IEnumerable<T> GetEnumerable()
	{
		List<T> returnedList = new();

		foreach (LinkedList<T> linkedList in array)
		foreach (T value in linkedList)
			returnedList.Add(value);

		return returnedList;
	}
}