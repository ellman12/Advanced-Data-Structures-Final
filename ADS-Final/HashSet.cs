namespace ADS_Final;

public class HashSet<T>
{
	public int Capacity; //Size of array
	public int Count; //How many indexes have a value.
	private T[] array;

	public HashSet(int capacity)
	{
		Capacity = capacity;
		array = new T[Capacity];
	}

	private int Hash(T value) => Math.Abs(value!.GetHashCode() % array.Length);

	///<summary>Adds a value to the HashSet.</summary>
	///<returns>True if the value was added, false if it was already in the HashSet and thus wasn't added.</returns>
	public bool Add(T value)
	{
		if (Contains(value)) return false;

		Count++;
		if (Count > array.Length)
		{
			Capacity *= 2;
			Array.Resize(ref array, Capacity);
		}

		int index = Hash(value);
		if (array[index] != null) //If nothing there fair game to store it there.
			array[index] = value;
		else //Find empty index
		{
			while (array[index] != null)
			{
				index++;
				if (index > array.Length - 1)
					index = 0;
			}

			array[index] = value;
		}

		return true;
	}

	///<summary>Remove the value from the HashSet.</summary>
	///<returns>True if removed, false if wasn't found and thus nothing to remove.</returns>
	public bool Remove(T value)
	{
		int index = Find(value);
		if (index == -1) return false;

		array[index] = default!;
		Count--;

		return true;
	}

	///<summary>Find index where value is located. Returns -1 if can't find.</summary>
	public int Find(T value)
	{
		bool loopedAround = false; //If start index all the way to the end of the array didn't contain value, start at front and mark this so don't get infinite loop.
		int index = Hash(value); //Where we start our search. Because of potential for collisions, may or may not be where 'value' is located.

		while (!Equals(array[index], value))
		{
			index++;
			if (index > array.Length - 1)
			{
				if (!loopedAround)
				{
					index = 0;
					loopedAround = true;
				}
				else
					return -1;
			}
		}

		return index;
	}

	///<summary>Remove everything from HashSet and shrink it.</summary>
	public void Clear()
	{
		Count = 0;
		Capacity = 4;
		array = new T[Capacity];
	}

	///<summary>Print all elements of the HashSet, starting at startIndex.</summary>
	public void Print(bool newLine = true, int startIndex = 0)
	{
		if (startIndex < 0 || startIndex > array.Length) throw new ArgumentOutOfRangeException(nameof(startIndex));

		if (newLine)
		{
			for (int i = startIndex; i < array.Length; i++)
				Console.WriteLine(array[i]);
		}
		else
		{
			for (int i = startIndex; i < array.Length; i++)
				Console.Write($"{array[i]} ");
			Console.WriteLine();
		}
	}

	public bool Contains(T value) => Find(value) != -1;
}