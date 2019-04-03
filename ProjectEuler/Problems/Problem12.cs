namespace ProjectEuler.Problems
{
	class Problem12 : BaseProblem
	{
		private int numberDivisors = 500;

		protected override void Begin()
		{
			long k = 1000;
			while (true)
			{
				var resultNumber = k * (k + 1) / 2;
				k++;
				var q = GetNumberDivisors(resultNumber);
				OnShowResult($"resultNumber: {resultNumber} ; GetNumberDivisors {q}");
				if (q > numberDivisors)
				{
					OnShowResult(resultNumber.ToString());
					break;
				}
			}
		}

		private int GetNumberDivisors(long value)
		{
			int result = 0;
			var primeList = GetPrimeDivisors(value);
			primeList.Add(value);
			primeList.Add(1);
			result += primeList.Count;

			foreach (var primeDivisor in primeList)
			{
				var divisor = value / primeDivisor;
				if (!primeList.Contains(divisor))
				{
					result++;
				}
			}

			return result;
		}
	}
}