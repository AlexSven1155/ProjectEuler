using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;

namespace ProjectEuler.Problems
{
	class Problem11 : BaseProblem
	{
		private int _calculateRange = 4;

		/// <summary>
		/// Стандарный мссив.
		/// </summary>
		private List<List<int>> _exampleArray
		{
			get
			{
				var array = File.ReadAllLines("F:\\problem11.txt");
				var result = new List<List<int>>();
				for (var i = 0; i < 20; i++)
				{
					result.Add(array[i].Split(' ').Select(e => Convert.ToInt32(e)).ToList());
				}
				return result;
			}
		}

		/// <summary>
		/// Транспонированный массив.
		/// </summary>
		private List<List<int>> _transposeExampleArray
		{
			get
			{
				var array = File.ReadAllLines("F:\\problem11.txt");
				var transposeArray = new List<string[]>();
				var result = new List<List<int>>();
				for (var i = 0; i < 20; i++)
				{
					transposeArray.Add(array[i].Split(' '));
				}

				for (int j = 0; j < 20; j++)
				{
					var newColumn = new List<int>();
					for (int i = 0; i < 20; i++)
					{
						newColumn.Add(Convert.ToInt32(transposeArray[i][j]));
					}
					result.Add(newColumn);
				}
				return result;
			}
		}

		/// <summary>
		/// Отраженный массив по горизонтали.
		/// </summary>
		private List<List<int>> _reflectedExampleArray
		{
			get
			{
				var array = File.ReadAllLines("F:\\problem11.txt");
				var result = new List<List<int>>();
				for (var i = 0; i < 20; i++)
				{
					result.Add(array[i].Split(' ').Select(e => Convert.ToInt32(e)).Reverse().ToList());
				}
				return result;
			}
		}

		protected override void Go()
		{
			var resultList = new List<int>();
			// идём по строкам
			foreach (var row in _exampleArray)
			{
				resultList.Add(CalculateRow(row).Max());
			}

			// идём по колонкам
			foreach (var row in _transposeExampleArray)
			{
				resultList.Add(CalculateRow(row).Max());
			}

			// идём по диагонали слева направо
			for (int q = 0; q < 16; q++)
			{
				for (int j = 16; j >= 0; j--)
				{
					var resultDiagonal = 1;
					for (int i = 0; i < _calculateRange; i++)
					{
						resultDiagonal *= _exampleArray[j + i][i + q];
					}
					resultList.Add(resultDiagonal);
				}
			}

			// идём по диагонали справа налево
			for (int q = 0; q < 16; q++)
			{
				for (int j = 16; j >= 0; j--)
				{
					var resultDiagonal = 1;
					for (int i = 0; i < _calculateRange; i++)
					{
						resultDiagonal *= _reflectedExampleArray[j + i][i + q];
					}
					resultList.Add(resultDiagonal);
				}
			}

			OnShowResult(resultList.Max().ToString());
		}

		private IEnumerable<int> CalculateRow(List<int> locations)
		{
			for (var i = 0; i < locations.Count; i += _calculateRange)
			{
				var result = 0;
				for (var j = 0; j < _calculateRange; j++)
				{
					result *= locations[i];
				}
				yield return result;
			}
		}
	}
}