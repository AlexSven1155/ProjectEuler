namespace ProjectEuler.Problems
{
	class Problem2 : BaseProblem
	{
		private int maxRegion = 4000000;

		protected override void Go()
		{
			float first = 1;
			float second = 2;
			float result = 2;

			int flag = 0; // каждое 3 число последовательности четное

			while (true)
			{
				flag++;
				var newNumber = first + second;
				if (flag == 3)
				{
					flag = 0;
					result += newNumber;
				}
				if (newNumber >= maxRegion)
				{
					break;
				}
				first = second;
				second = newNumber;
			}
			OnShowResult(result.ToString());
		}
	}
}