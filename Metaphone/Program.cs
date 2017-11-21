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
			Console.WriteLine(m.TranslateToPhonetic(input));
			Console.ReadKey();
		}	
	}

	public class MetaphoneAlgorithm
	{
		public string TranslateToPhonetic(string input)
		{
			return input;
		}
	}
}
