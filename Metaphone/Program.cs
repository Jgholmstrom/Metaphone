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
			while (true)
			{
				string input = Console.ReadLine();
				string output = m.TranslateToPhonetic(input);
				Console.WriteLine(output);
			}
		}	
	}

	public class MetaphoneAlgorithm
	{
		public string TranslateToPhonetic(string word)
		{
			//init
			var linkedChars = new LinkedList<char>(word.ToUpper().ToCharArray());
			var finalResult = new StringBuilder();
			var currentChar = linkedChars.First;

			//first char
			switch (currentChar.Value)
			{
				case 'A':
					if (IsNext(currentChar, 'C'))
					{
						currentChar = currentChar.Next;
					}
					else
					{
						finalResult.Append(currentChar.Value);
						currentChar = currentChar.Next;
					}
					break;
				case 'E':
					finalResult.Append(currentChar.Value);
					currentChar = currentChar.Next;
					break;
				case 'I':
					finalResult.Append(currentChar.Value);
					currentChar = currentChar.Next;
					break;
				case 'O':
					finalResult.Append(currentChar.Value);
					currentChar = currentChar.Next;
					break;
				case 'U':
					finalResult.Append(currentChar.Value);
					currentChar = currentChar.Next;
					break;
				case 'X':
					finalResult.Append('S');
					break;
				case 'K':
					if (IsNext(currentChar, 'N'))
					{
						currentChar = currentChar.Next;
					}
					else
					{
						finalResult.Append(currentChar.Value);
						currentChar = currentChar.Next;
					}
					break;
				case 'G':
					if (IsNext(currentChar, 'N'))
					{
						currentChar = currentChar.Next;
					}
					else
					{
						finalResult.Append(currentChar.Value);
						currentChar = currentChar.Next; //TODO fix exceptions for G, can be J or K here
					}
					break;
				case 'P':
					if (IsNext(currentChar, 'N'))
					{
						currentChar = currentChar.Next;
					}
					else
					{
						finalResult.Append(currentChar.Value);
						currentChar = currentChar.Next;
					}
					break;
				case 'W':
					if (IsNext(currentChar, 'A') || IsNext(currentChar, 'E') || IsNext(currentChar, 'I') || IsNext(currentChar, 'O') || IsNext(currentChar, 'U')) //TODO fix ugly
					{
						finalResult.Append(currentChar.Value);
					}
					else if (IsNext(currentChar, 'H'))
					{
						finalResult.Append(currentChar.Value);
						currentChar = currentChar.Next.Next; //jump twice to skip H
					}
					else
					{
						currentChar = currentChar.Next; //initial wr- exception included at this step
					}
					break;
			}

			//first non-exception char and following chars
			while (currentChar != null) //bad practice?
			{
				switch (currentChar.Value)
				{
					case 'B':
						if (IsPrevious(currentChar, 'M') && currentChar == currentChar.List.Last)
						{
							break;
						}
						else
						{
							finalResult.Append(currentChar.Value);
						}
						break;
					case 'C':
						if (IsNext(currentChar, 'H'))
						{
							if (IsPrevious(currentChar, 'S'))
							{
								finalResult.Append('K');
							}
							else
							{
								finalResult.Append('X');
							}
						}
						else if (IsNext(currentChar, 'I'))
						{
							if (currentChar.Next.Next.Value == 'A') //TODO can point to null
							{
								finalResult.Append('X');
							}
							else
							{
								finalResult.Append('S');
							}
						}
						else if (IsNext(currentChar, 'E') || IsNext(currentChar, 'Y'))
						{
							finalResult.Append('S');
						}
						else
						{
							finalResult.Append('K');
						}
						break;
					case 'D':
						if (IsNext(currentChar, 'G'))
						{
							if (currentChar.Next.Next.Value == 'E' || currentChar.Next.Next.Value == 'Y' || currentChar.Next.Next.Value == 'I') //TODO can point to null
							{
								finalResult.Append('J');
							}
							else
							{
								finalResult.Append('T');
							}
						}
						else
						{
							finalResult.Append('T');
						}
						break;
					case 'F':
						finalResult.Append(currentChar.Value);
						break;

				}
				currentChar = currentChar.Next;
			}

			return finalResult.ToString();
		}

		bool IsPrevious(LinkedListNode<char> linkedListNode, char c)
		{
			if (linkedListNode.Previous != null && linkedListNode.Previous.Value == c)
			{
				return true;
			}
			else
			{
				return false;
			}	
		}

		bool IsNext(LinkedListNode<char> linkedListNode, char c)
		{
			if (linkedListNode.Next != null && linkedListNode.Next.Value == c)
			{
				return true;
			}
			else
			{
				return false;
			}
		}
	}
}
