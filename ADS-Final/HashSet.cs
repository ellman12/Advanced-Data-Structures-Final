namespace ADS_Final;

public class HashSet
{
    private int capacity;
    private readonly string[] array;

    public HashSet(int capacity)
    {
        this.capacity = capacity * 2;
        array = new string[this.capacity];
    }

    public void Add(string value)
    {
        int index = Math.Abs(value.GetHashCode() % array.Length);
        if (String.IsNullOrWhiteSpace(array[index])) //If nothing there fair game to store it there.
            array[index] = value;
        else //Find empty index
        {
            while (!String.IsNullOrWhiteSpace(array[index]))
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