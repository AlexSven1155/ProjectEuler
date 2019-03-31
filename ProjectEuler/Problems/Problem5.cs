namespace ProjectEuler.Problems
{
	class Problem5 : BaseProblem
	{
		private int maxDivisor = 20;

		public override void Go()
		{
			long result = 1;

			for (var i = 1; i <= maxDivisor; i++)
			{
				result *= i;
			}

			for (int i = maxDivisor; i >= 2; i--)
			{
				if (Check(result / i))
				{
					result /= i;
				}
			}

			OnShowResult(result.ToString());
		}

		private bool Check(long value)
		{
			for (long i = 1; i <= maxDivisor; i++)
			{
				if (value % i != 0)
				{
					return false;
				}
			}
			return true;
		}
	}
}