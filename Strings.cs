namespace Strings
{	
	using System.Collections.Generic;
	public class Strings
	{
		public static List<string> Permutations(string input)
		{
			if(string.IsNullOrEmpty(input))
			{
				return new List<string>();
			}
			
			if(input.Length == 1)
			{
				return new List<string>(1) { input };
			}
								
			// determine capacity for each least based on Factorial
			var permuts = new List<string>(Factorial(input.Length));
			
			for(int i=0; i < input.Length; ++i)
			{
				// check if it is repeated char
				bool isRepeated = false;
				for(int j = 0; j < i; j++)
				{
					if(input[i] == input[j])
					{
						isRepeated = true;
						break;
					}
				}	
				
				if(isRepeated)
				{
					continue;
				}
										
				// fix i, and create new input string  without char at i, and calc permutations						
				var i_permuts = Permutations(input.Substring(0, i) + input.Substring(i+1, input.Length - i - 1));
				
				// append char i to the various permuts that come from remaining input
				foreach(var permut in i_permuts)
				{					
					permuts.Add(input[i] + permut);					
				}								
			}
			
			return permuts;			
		}
		
		public static int Factorial(int n)
		{
			if(n == 1)
			{
				return 1;
			}
			
			if(n == 0)
			{
				return 0;
			}
						
			var res = n * Factorial(n-1);
			
			return res;
		}
	} 	
}