namespace ProjectEuler.Problems
{
	class Problem6 : BaseProblem
	{
		private long numberRange = 100;
		protected override void Begin()
		{
			long sumSquares = 0;
			long squareSum = 0;

			for (long i = 1; i <= numberRange; i++)
			{
				sumSquares += i * i;
			}

			for (long i = 1; i <= numberRange; i++)
			{
				squareSum += i;
			}

			squareSum *= squareSum;

			OnShowResult((squareSum - sumSquares).ToString());
		}
	}
}