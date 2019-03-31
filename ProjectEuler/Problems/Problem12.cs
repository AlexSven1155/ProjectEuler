namespace ProjectEuler.Problems
{
	class Problem12 : BaseProblem
	{
		private int numberDivisors = 500;

		protected override void Go()
		{
			long k = 1;
			long resultNumber = 0;
			while (true)
			{
				resultNumber += k;
				k++;

				if (GetNumberDivisors(resultNumber) > numberDivisors)
				{
					OnShowResult(resultNumber.ToString());
					break;
				}
			}
		}

		private int GetNumberDivisors(long value)
		{
			var result = 0;
			for (long i = 1; i <= value; i++)
			{
				if (value % i == 0)
				{
					result++;
				}
			}

			return result;
		}
	}
}