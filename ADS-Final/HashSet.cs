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

    public void Add(T value)
    {
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
    }

    public void Remove(string value)
    {
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

    public bool Contains(T value) => Find(value) != -1;
}