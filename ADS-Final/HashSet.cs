namespace ADS_Final;

public class HashSet<T>
{
	public int Capacity; //Size of array
	public int Count; //How many indexes have a value.
	private LinkedList<T>?[] array;

	public HashSet(int capacity)
	{
		Capacity = capacity;
		array = new LinkedList<T>?[Capacity];
		for (int i = 0; i < array.Length; i++)
			array[i] = new LinkedList<T>();
	}

	private int Hash(T value) => Math.Abs(value!.GetHashCode() % array.Length);

	///<summary>Returns true if the HashSet contains this value.</summary>
	public bool Contains(T value) => array[Hash(value)]!.Contains(value);

	///<summary>Resizes array if necessary.</summary>
	private void ResizeArray()
	{
		if (Capacity == 0)
			Capacity = 6;
		else if (Count > array.Length)
			Capacity *= 2;

		Array.Resize(ref array, Capacity);
		for (int i = 0; i < array.Length; i++) //Create new Lists at new indexes (i.e., if any indexes null, make new lists at those indexes).
			array[i] ??= new LinkedList<T>();
	}

	///<summary>Adds a value to the HashSet.</summary>
	///<returns>True if the value was added, false if it was already in the HashSet and thus wasn't added.</returns>
	public bool Add(T value)
	{
		ResizeArray();
		if (Contains(value)) return false;

		Count++;

		int insertIndex = Hash(value);
		if (!array[insertIndex]!.Contains(value))
			array[insertIndex]!.AddLast(value);

		return true;
	}

	///<summary>Remove the value from the HashSet.</summary>
	///<returns>True if removed, false if wasn't found and thus nothing to remove.</returns>
	public bool Remove(T value)
	{
		if (!Contains(value)) return false;

		int removeIndex = Hash(value);
		array[removeIndex]!.Remove(value);
		Count--;
		return true;
	}

	///<summary>Remove everything from HashSet and shrink it.</summary>
	public void Clear()
	{
		Count = 0;
		Capacity = 4;
		array = new LinkedList<T>?[Capacity];
		for (int i = 0; i < array.Length; i++)
			array[i] = new LinkedList<T>();
	}

	///<summary>Print all elements of the HashSet, starting at startIndex.</summary>
	public void Print(bool newLine = true, int startIndex = 0)
	{
		if (startIndex < 0 || startIndex > array.Length) throw new ArgumentOutOfRangeException(nameof(startIndex));

		if (newLine)
		{
			foreach (LinkedList<T>? linkedList in array)
			{
				foreach (T T in linkedList!) Console.WriteLine(T);
			}
		}
		else
		{
			foreach (LinkedList<T>? linkedList in array)
			{
				foreach (T T in linkedList!) Console.Write($"{T} ");
			}

			Console.WriteLine();
		}
	}

	///<summary>Performs union set operation, adding everything from HashSet other to this set.</summary>
	///<param name="other">The set with elements to add to this one.</param>
	///<exception cref="ArgumentException">Thrown if sets aren't of the same type.</exception>
	public void UnionWith(HashSet<T> other)
	{
		if (GetType() != other.GetType()) throw new ArgumentException("Both HashSets need to be of the same type.");

		foreach (LinkedList<T>? list in other.array)
		{
			if (list == null) continue;
			foreach (T item in list) Add(item);
		}
	}
}