using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Metaphone
{
	class Program
	{
		static void Main(string[] args)
		{
			var m = new MetaphoneAlgorithm();
			string input = Console.ReadLine();
			string output = m.TranslateToPhonetic(input);
			Console.WriteLine(output);
			Console.ReadKey();
		}	
	}

	public class MetaphoneAlgorithm
	{
		public string TranslateToPhonetic(string input)
		{
			//init
			var linkedChars = new LinkedList<char>(input.ToUpper().ToCharArray());
			var finalResult = new StringBuilder();
			var currentChar = linkedChars.First;

			//first char
			switch (currentChar.Value)
			{
				case 'A':
					if (currentChar.Next.Value == 'C')
					{
						finalResult.Append('C');
						currentChar = currentChar.Next;
					}
					else
					{
						finalResult.Append(currentChar);
					}
					break;
				case 'E':
					finalResult.Append(currentChar);
					break;
				case 'I':
					finalResult.Append(currentChar);
					break;
				case 'O':
					finalResult.Append(currentChar);
					break;
				case 'U':
					finalResult.Append(currentChar);
					break;
				case 'Y':
					finalResult.Append(currentChar);
					break;
				case 'X':
					finalResult.Append('S');
					break;
				case 'K':
					if (currentChar.Next.Value == 'N')
					{
						finalResult.Append('N');
						currentChar = currentChar.Next;
					}
					else
					{
						finalResult.Append(currentChar);
					}
					break;
				case 'G':
					if (currentChar.Next.Value == 'N')
					{
						finalResult.Append('N');
						currentChar = currentChar.Next;
					}
					else
					{
						finalResult.Append(currentChar); //TODO fix exceptions for G, can be J or K here
					}
					break;
				case 'P':
					if (currentChar.Next.Value == 'N')
					{
						finalResult.Append('N');
						currentChar = currentChar.Next;
					}
					else
					{
						finalResult.Append(currentChar);
					}
					break;
				case 'W':
					if (currentChar.Next.Value == 'R')
					{
						finalResult.Append('R');
						currentChar = currentChar.Next;
					}
					else
					{
						finalResult.Append(currentChar); //TODO fix exceptions for W, can be silent or W here
					}
					break;
			}

			return finalResult.ToString();
		}
	}
}
