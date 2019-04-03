using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;

namespace ProjectEuler.Problems
{
	class Problem11 : BaseProblem
	{
		private int _calculateRange = 4;
		private string _fileExamplePath = "F:\\problem11.txt";

		private class Result : IComparable<Result>
		{
			public string NumbersValue;
			public long MultiplicationResult;

			public int CompareTo(Result other)
			{
				if (ReferenceEquals(this, other)) return 0;
				if (ReferenceEquals(null, other)) return 1;
				return MultiplicationResult.CompareTo(other.MultiplicationResult);
			}
		}

		/// <summary>
		/// Стандарный мссив.
		/// </summary>
		private List<List<int>> _exampleArray
		{
			get
			{
				var array = File.ReadAllLines(_fileExamplePath);
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
				var array = File.ReadAllLines(_fileExamplePath);
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
				var array = File.ReadAllLines(_fileExamplePath);
				var result = new List<List<int>>();
				for (var i = 0; i < 20; i++)
				{
					result.Add(array[i].Split(' ').Select(e => Convert.ToInt32(e)).Reverse().ToList());
				}
				return result;
			}
		}

		protected override void Begin()
		{
			var resultList = new List<Result>();

			// идём по строкам
			foreach (var row in _exampleArray)
			{
				for (int i = 0; i < 20; i += _calculateRange)
				{
					var resultHorizontal = new Result()
					{
						MultiplicationResult = 1,
						NumbersValue = ""
					};

					for (int j = 0; j < _calculateRange; j++)
					{
						resultHorizontal.NumbersValue += row[i + j] + ", ";
						resultHorizontal.MultiplicationResult *= row[i + j];
					}
					resultHorizontal.NumbersValue += " horizontal";
					resultList.Add(resultHorizontal);
				}
			}

			// идём по колонкам
			foreach (var row in _transposeExampleArray)
			{
				for (int i = 0; i < 20; i += _calculateRange)
				{
					var resultVertical = new Result()
					{
						MultiplicationResult = 1,
						NumbersValue = ""
					};

					for (int j = 0; j < _calculateRange; j++)
					{
						resultVertical.NumbersValue += row[i + j] + ", ";
						resultVertical.MultiplicationResult *= row[i + j];
					}

					resultVertical.NumbersValue += " vertical";
					resultList.Add(resultVertical);
				}
			}

			// идём по диагонали слева направо
			for (int q = 0; q < 16; q++)
			{
				for (int j = 16; j >= 0; j--)
				{
					var resultDiagonal = new Result()
					{
						MultiplicationResult = 1,
						NumbersValue = ""
					};

					for (int i = 0; i < _calculateRange; i++)
					{
						resultDiagonal.NumbersValue += _exampleArray[j + i][i + q] + ", ";
						resultDiagonal.MultiplicationResult *= _exampleArray[j + i][i + q];
					}

					resultDiagonal.NumbersValue += " diagonal left to right";
					resultList.Add(resultDiagonal);
				}
			}

			// идём по диагонали справа налево
			for (int q = 0; q < 16; q++)
			{
				for (int j = 16; j >= 0; j--)
				{
					var resultDiagonal = new Result()
					{
						MultiplicationResult = 1,
						NumbersValue = ""
					};

					for (int i = 0; i < _calculateRange; i++)
					{
						resultDiagonal.NumbersValue += _reflectedExampleArray[j + i][i + q] + ", ";
						resultDiagonal.MultiplicationResult *= _reflectedExampleArray[j + i][i + q];
					}
					resultDiagonal.NumbersValue += " diagonal right to left";
					resultList.Add(resultDiagonal);
				}
			}

			var result = resultList.Max();

			OnShowResult($"\nЧисла: {result.NumbersValue} ; Результат уножения: {result.MultiplicationResult}");
		}
	}
}