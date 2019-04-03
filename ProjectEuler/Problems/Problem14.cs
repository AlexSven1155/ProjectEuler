using System;
using System.Collections.Generic;
using System.Linq;

namespace ProjectEuler.Problems
{
	class Problem14 : BaseProblem
	{
		private double _startNumber = 1000000;

		private class Result : IComparable<Result>
		{
			public long ChainLength;
			public long CurrentNumber;

			public int CompareTo(Result other)
			{
				if (ReferenceEquals(this, other)) return 0;
				if (ReferenceEquals(null, other)) return 1;
				return ChainLength.CompareTo(other.ChainLength);
			}
		}

		protected override void Begin()
		{
			double CalculateEven(double value)
			{
				return value / 2;
			}

			double CalculateNotEven(double value)
			{
				return 3 * value + 1;
			}

			var chainLengthList = new List<Result>();
			for (int i = (int)_startNumber; i > 0; i--)
			{
				var chainLength = 0;
				var currentNumber = (double)i;
				while (currentNumber != 1)
				{
					chainLength++;
					currentNumber = currentNumber % 2 == 0
						? CalculateEven(currentNumber)
						: CalculateNotEven(currentNumber);
				}
				chainLengthList.Add(new Result { ChainLength = chainLength, CurrentNumber = i });
			}

			var result = chainLengthList.Max();

			OnShowResult($"Длинна цепочки: {result.ChainLength} ; Стартовое число: {result.CurrentNumber}");
		}
	}
}