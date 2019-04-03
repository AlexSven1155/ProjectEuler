using System.Collections.Generic;
using System.Linq;

namespace ProjectEuler.Problems
{
	class Problem7 : BaseProblem
	{
		private long TargetPrimeNumber = 10001;

		protected override void Begin()
		{
			var listPrimeNumbers = new List<long>();
			for (long i = 2; i < long.MaxValue; i++)
			{
				if (Check(i))
				{
					listPrimeNumbers.Add(i);
				}

				if (listPrimeNumbers.Count == TargetPrimeNumber)
				{
					break;
				}
			}

			OnShowResult(listPrimeNumbers.Max().ToString());
		}

		/// <summary>
		/// спиздил
		/// </summary>
		private bool Check(long value)
		{
			if (value == 2)
			{
				return true;
			}

			if (value == 3)
			{
				return true;
			}

			if (value == 5)
			{
				return true;
			}

			if (value % 2 == 0)
			{
				return false;
			}

			long i = 3;
			while (i * i <= value)
			{
				if (value % i == 0)
				{
					return false;
				}

				i += 2;
			}

			return true;
		}
	}
}
