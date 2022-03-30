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

    public void Add(T value)
    {
        Count++;
        if (Count > array.Length)
        {
            Capacity *= 2;
            Array.Resize(ref array, Capacity);
        }
        
        int index = Math.Abs(value!.GetHashCode() % array.Length);
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

    public int Search(string value)
    {
        return 1;
    }
}