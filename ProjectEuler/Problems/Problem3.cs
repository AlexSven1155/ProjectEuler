using System.Collections.Generic;
using System.Linq;

namespace ProjectEuler.Problems
{
	class Problem3 : BaseProblem
	{
		private long _number = 600851475143;

		protected override void Go()
		{
			var listResult = new List<long>();
			long divisor = 2;

			while (true)
			{
				if (_number % divisor == 0)
				{
					_number /= divisor;
					listResult.Add(divisor);
				}
				else
				{
					divisor++;
				}

				if (_number == 1)
				{
					break;
				}
			}
			OnShowResult(listResult.Max().ToString());
		}
	}
}