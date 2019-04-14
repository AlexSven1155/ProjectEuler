namespace ProjectEuler.Problems
{
	class Problem12 : BaseProblem
	{
		private int _numberDivisors = 500;
		private bool _try = true;

		protected override void Begin()
		{
			long k = 1;
			while (_try)
			{
				CheckAnswer(GetDivisorsCount(k * (k + 1) / 2), k * (k + 1) / 2);
				k++;
			}
		}

		private void CheckAnswer(long value, long result)
		{
			if (value >= _numberDivisors)
			{
				_try = false;
				OnShowResult($"Треугольное число: {result} ; количество делителей: {value}");
			}
		}
	}
}