using System;
using System.Numerics;

namespace ProjectEuler.Problems
{
	class Problem16 : BaseProblem
	{
		private int Extent = 1000;

		protected override void Begin()
		{
			var bigNumber = new BigInteger(2);

			for (var i = 1; i < Extent; i++)
			{
				bigNumber *= 2;
			}

			int result = 0;
			foreach (var numeral in bigNumber.ToString())
			{
				result += Convert.ToInt16(numeral.ToString());
			}

			OnShowResult(result.ToString());
		}
	}
}