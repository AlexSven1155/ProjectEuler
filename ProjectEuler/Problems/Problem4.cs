using System;
using System.Collections.Generic;
using System.Linq;

namespace ProjectEuler.Problems
{
	class Problem4 : BaseProblem
	{
		public override void Go()
		{
			var resultList = new List<long>();
			for (var a = 100; a < 999; a++)
			{
				for (var b = 100; b < 999; b++)
				{
					var c = a * b;
					if (c.ToString().Length % 2 == 0)
					{
						var strC = c.ToString();
						var polC = strC.Length / 2;
						if (Convert.ToInt64(strC.Substring(0, polC)) ==
							Convert.ToInt64(new string(strC.Substring(polC, polC).Reverse().ToArray())))
						{
							resultList.Add(c);
						}
					}
				}
			}

			Console.WriteLine($"Результат: {resultList.Max()}");
		}
	}
}