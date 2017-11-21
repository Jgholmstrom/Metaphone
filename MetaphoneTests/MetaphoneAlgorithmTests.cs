using Microsoft.VisualStudio.TestTools.UnitTesting;
using Metaphone.Program;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Metaphone.Program.Tests
{
	[TestClass()]
	public class MetaphoneAlgorithmTests
	{
		Dictionary<string, string> TestData = new Dictionary<string, string>()
		{
			{ "solitude", "SLTT" },
			{ "debunker", "TBNKR" },
			{ "aardvark", "ARTFRK" }, 
			{ "cutlass", "KTLSS" } ,
			{ "metaphone", "MTFN" },
			{ "kiss", "KSS" },
			{ "roosevelt", "RSFLT" },
			{ "knock", "NK" },
			{ "xanadu", "SNT" } 
		};

		[TestMethod()]
		public void TranslateToPhoneticTest()
		{
			//arrange
			List<string> input = new List<string>(TestData.Keys);
			List<string> expected = new List<string>(TestData.Values);
			var algorithm = new MetaphoneAlgorithm();
			List<string> actual = new List<string>();
			//act
			foreach (var entry in input)
			{
				actual.Add(algorithm.TranslateToPhonetic(entry));
			}
			//assert
			CollectionAssert.AreEqual(expected, actual);
		}
	}
}