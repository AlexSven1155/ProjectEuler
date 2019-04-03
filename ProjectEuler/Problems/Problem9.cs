using System;

namespace ProjectEuler.Problems
{
	class Problem9 : BaseProblem
	{
		private long TargetValue = 1000;

		protected override void Begin()
		{
			long result = 0;
			long a = 0;
			long b = 0;
			long c = 0;

			bool flag = false;

			for (a = 1; a < TargetValue; a++)
			{
				for (b = 1; b < TargetValue; b++)
				{
					c = a * a + b * b;
					var sqrtC = Math.Sqrt(c);
					if ((long)sqrtC == sqrtC)
					{
						c = (long)sqrtC;
						if (a + b + c == TargetValue)
						{
							result = a * b * c;
							flag = true;
							break;
						}
					}
				}

				if (flag)
				{
					break;
				}
			}

			OnShowResult(result.ToString());
		}
	}
}