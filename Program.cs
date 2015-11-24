namespace CodingProblems
{
	using System;
	
	using Strings;	
	using Sorting;
	
    public class Program
	{
		
		public static void Main(string[] args)
		{						
			// var g = Sorting.FindNGreatestElement(new int[] {1,3}, new int[] {1,8,10}, 4);
            // Console.WriteLine(g);    
            //                                    
            // var o = Sorting.SortNumbers(new int[2][] {new int[] {1,4,6}, new int[] {2,3,10,15}});
            // foreach(var i in o)
            // {
            //     Console.WriteLine(i);
            // }
            
            var o = Sorting.SelectionSort(new int[] {4,7,3,1,9});
            foreach(var i in o)
            {
                Console.WriteLine(i);
            }
                       
		}
		
		public static void TestStrings()
		{
			var input = "sdfljad";
			Console.WriteLine(Strings.Factorial(input.Length));
			
			var permuts = Strings.Permutations(input);
			foreach(var permut in permuts)
			{
				Console.WriteLine(permut);
			}	
			
			Console.WriteLine(permuts.Count);
		}
		
		public static void TestSorting()
		{
			int[] output = null;

            output = Sorting.MergeSort(new int[] { 4, 6, 1, 3, 5, 2 });
            foreach (var c in output)
            {
                Console.Write(c);
            }

            Console.WriteLine();

            output = Sorting.QuickSort(new int[] { 6, 4, 1, 3, 2, 5 });
            foreach (var c in output)
            {
                Console.Write(c);
            }

            Console.WriteLine();

            output = Sorting.QuickSort(new int[] { 1, 2, 3, 4, 5, 6 });
            foreach (var c in output)
            {
                Console.Write(c);
            }

            Console.WriteLine();

            output = Sorting.BubbleSort(new int[] { 6, 5, 4, 3, 2, 1 });
            foreach (var c in output)
            {
                Console.Write(c);
            }

            Console.WriteLine();

            output = Sorting.BubbleSort(new int[] { 6, 4, 1, 3, 2, 5 });
            foreach (var c in output)
            {
                Console.Write(c);
            }

            Console.WriteLine();

            output = Sorting.BubbleSort(new int[] { 1, 2, 3, 4, 5, 6 });
            foreach (var c in output)
            {
                Console.Write(c);
            }

            Console.WriteLine();

            output = Sorting.QuickSort(new int[] { 6, 5, 4, 3, 2, 1 });
            foreach (var c in output)
            {
                Console.Write(c);
            }

            Console.WriteLine();
		}
	}	
}