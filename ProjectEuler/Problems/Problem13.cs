using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Numerics;

namespace ProjectEuler.Problems
{
	class Problem13 : BaseProblem
	{
		private string _fileExamplePath = "F:\\problem13.txt";

		private List<string> ListNumbers
		{
			get
			{
				try
				{
					var exampleArray = File.ReadAllLines(_fileExamplePath);

					if (exampleArray.Length != 1 &&
						exampleArray[0].Length != 100 * 50)
					{
						return null;
					}

					var result = new List<string>();
					for (int i = 0; i < exampleArray[0].Length; i += 50)
					{
						result.Add(exampleArray[0].Substring(i, 50));
					}

					return result;
				}
				catch
				{
					throw new Exception("Ошибка получения исходных данных.");
				}
			}
		}

		protected override void Begin()
		{
			var result = new BigInteger();
			foreach (var bigIntegerNumber in ListNumbers.Select(BigInteger.Parse).ToList())
			{
				result += bigIntegerNumber;
			}

			OnShowResult(result.ToString().Substring(0, 10));
		}
	}
}