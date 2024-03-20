using System;
using System.Globalization;
using System.Net.Http.Headers;

class Program
{
    static void Main(string[] args)
    {
        Console.WriteLine("Sorting!\n\nPlease choose avaiable option for input:\n\n1. Random numbers(enter length of array)\n2. Your array\n\nPlease write 1 or 2: ");
        string input = Console.ReadLine();
        string Input = null;
        int[] ints = null; 

        switch(input)
        {
            case "1":
            Console.WriteLine("Please enter length of array to sortout: ");
            string len = Console.ReadLine();
            ints = randomiInts(Convert.ToInt32(len));
            break;
            case "2":
            Console.WriteLine("Please enter numbers to sortout: ");
            Input = Console.ReadLine();
            break;
            default:
            Console.WriteLine("Please enter numbers to sortout: ");
            Input = Console.ReadLine();
            break;
        }

        if(input != "1")
        {
            string[] parts = Input.Split(' ');
            ints = ConvertArrayToInt(parts);
        }

        Console.WriteLine("Choose type of sorting\n\n1. BubbleSort\n2. QuickSort\n");
        Console.Write("Enter number: ");
        
        string Enter = Console.ReadLine();

        DateTime aTime = DateTime.Now;
        switch(Enter){
            case "1":
            bubbleSort(ints);
            // foreach(int i in ints){
            //     Console.Write(i + " ");
            // }
            Console.WriteLine("Completed in: " + (DateTime.Now - aTime));
            break;
            case "2":
            QuickSort(ints, 0, ints.Length - 1);
            // foreach(int i in ints){
            //     Console.Write(i + " ");
            // }
            Console.WriteLine("Completed in: " + (DateTime.Now - aTime));
            break;
        }   

    }

    static int[] randomiInts(int qty)
    {
        int[] i = new int[qty];
        for(int q = 0; q < i.Length; q++)
        {
            Random ran = new Random();
            i[q] = ran.Next(1, 100);
        }
        return i;
    }

    public static int[] ConvertArrayToInt(string[] parts)
    {
        int[] numArr;
        numArr = new int[parts.Length];
        for(int i = 0; i < parts.Length; i++)
        {
            if(int.TryParse(parts[i], out int b))
            {
                numArr[i] = b;
            }
        }
        return numArr;
    }

    static void bubbleSort(int[] intArray)
    {
        for(int i = 0; i < intArray.Length; i++)
        {
            for(int j = 0; j < intArray.Length - i - 1; j++)
            {
                if(intArray[j]>intArray[j+1])
                {
                    int temp = intArray[j];
                    intArray[j] = intArray[j+1];
                    intArray[j+1] = temp;
                }
            }
        }
    }

    static void quickSort(int[] intArray, int start, int end)    {
        if(end <= start) return;
        int pivot = partition(intArray, start, end);
        quickSort(intArray, start, pivot - 1);
        quickSort(intArray, pivot + 1, end);
    }

    static int partition(int[] intArray, int start, int end)    {
        int pivot = intArray[end];
        int i = start - 1;
        for(int j = start; j <= end; j++){
            if(intArray[j] < pivot){
                i++;
                int Temp = intArray[i];
                intArray[i] = intArray[j];
                intArray[j] = Temp;
            }
        }
        i++;
        int temp = intArray[i];
        intArray[i] = intArray[end];
        intArray[end] = temp;
        return i;
    }

    static void QuickSort(int[] array, int start, int end){
        if(end <= start) return;
        int pivot = Partition(array, start, end);        
        QuickSort(array, start, pivot - 1);
        QuickSort(array, pivot + 1, end);
    }

    static int Partition(int[] array, int start, int end){
        int pivot = array[end];
        int i = start - 1;
        for(int j = start; j <= end; j++){
            if(array[j]<pivot){
                i++;
                int temp = array[j];
                array[j] = array[i];
                array[i] = temp;
            }
        }
        return i;
    }
}
