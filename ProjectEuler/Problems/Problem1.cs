namespace ProjectEuler.Problems
{
	class Problem1 : BaseProblem
	{
		private int maxNumber = 1000;

		protected override void Go()
		{
			long result = 0;
			for (int i = 0; i < maxNumber; i++)
			{
				if (i % 3 == 0 || i % 5 == 0)
				{
					result += i;
				}
			}
			OnShowResult(result.ToString());
		}
	}
}