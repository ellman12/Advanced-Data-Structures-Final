namespace ADS_Final;

public class HashSet<T>
{
    private int capacity; //Size of array
    private int count; //How many indexes have a value.
    private readonly T[] array;

    public HashSet(int capacity)
    {
        this.capacity = capacity * 2;
        array = new T[this.capacity];
    }

    public void Add(T value)
    {
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
            count++;
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