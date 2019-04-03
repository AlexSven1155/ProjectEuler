namespace ProjectEuler.Problems
{
	class Problem10 : BaseProblem
	{
		private long TargetPrimeNumber = 2000000;

		protected override void Begin()
		{
			long result = 0;
			for (long i = 2; i < TargetPrimeNumber; i++)
			{
				if (Check(i))
				{
					result += i;
				}
			}
			OnShowResult(result.ToString());
		}

		/// <summary>
		/// спиздил
		/// Проверяет число на простоту
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