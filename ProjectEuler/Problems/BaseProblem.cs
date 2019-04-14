using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Threading;
using System.Threading.Tasks;

namespace ProjectEuler.Problems
{
	public abstract class BaseProblem : IDisposable
	{
		private readonly Stopwatch _stopwatch = new Stopwatch();

		protected bool IsAnimationWorking = true;

		protected delegate void ResultDelegate(string value, bool stopWatch);

		protected event ResultDelegate ShowResult;

		/// <summary>
		/// Массив простых чисел до 199.
		/// </summary>
		protected readonly int[] SimpleDividers =
		{
			2, 3, 5, 7, 11, 13, 17, 19, 23, 29, 31, 37, 41, 43,

			47, 53, 59, 61, 67, 71, 73, 79, 83, 89, 97, 101,

			103, 107, 109, 113, 127, 131, 137, 139, 149, 151,

			157, 163, 167, 173, 179, 181, 191, 193, 197, 199
		};

		public void Start()
		{
			Console.Write($"{GetType().Name} Start ");
			Task.Factory.StartNew(StartAnimationWaiting, TaskCreationOptions.AttachedToParent);
			ShowResult += ResultHandler;
			_stopwatch.Start();

			try
			{
				Begin();
			}
			catch (Exception e)
			{
				OnShowResult(e.Message + "\n" + e.StackTrace);
			}

			if (_stopwatch.IsRunning)
			{
				_stopwatch.Stop();
			}

			Console.WriteLine($"Время выполнения: {_stopwatch.Elapsed.Seconds} с {_stopwatch.Elapsed.Milliseconds} мс {_stopwatch.Elapsed.Ticks} ticks");
			Console.ReadLine();
		}

		protected void StartAnimationWaiting()
		{
			var counter = 1;
			Console.CursorVisible = false;
			while (IsAnimationWorking)
			{
				counter++;
				switch (counter % 4)
				{
					case 0: Console.Write("/"); break;
					case 1: Console.Write("-"); break;
					case 2: Console.Write("\\"); break;
					case 3: Console.Write("|"); break;
				}
				Console.SetCursorPosition(Console.CursorLeft - 1, Console.CursorTop);
				Thread.Sleep(150);
			}
			Console.CursorVisible = true;
		}

		protected void ResultHandler(string value, bool stopWatch = false)
		{
			if (stopWatch)
			{
				_stopwatch.Stop();
			}
			IsAnimationWorking = false;
			Console.WriteLine();
			Console.WriteLine($"Результат: {value}");
		}

		protected virtual void OnShowResult(string value, bool stopWatch = false)
		{
			ShowResult?.Invoke(value, stopWatch);
		}

		protected abstract void Begin();

		public virtual void Dispose() { }

		#region PLUHI

		/// <summary>
		/// Возвращает количество множителей указанного числа.
		/// </summary>
		/// <param name="value">Число.</param>
		/// <returns>Количество множителей.</returns>
		public long GetDivisorsCount(long value)
		{
			if (value == 0) { return 0; }
			if (value == 1) { return 1; }
			if (value == 2) { return 2; }

			var result = 1;
			var primeGroupList = GetPrimeDivisors(value).GroupBy(e => e);

			foreach (var group in primeGroupList)
			{
				result *= group.Count() + 1;
			}

			return result;
		}

		/// <summary>
		/// Возвращает каноническое разложение на множители указанного числа.
		/// </summary>
		/// <returns></returns>
		public List<long> GetPrimeDivisors(long value)
		{
			var result = new List<long>();
			foreach (var divider in SimpleDividers)
			{
				if (value == 1) { break; }

				void Calculate()
				{
					if (value % divider == 0)
					{
						result.Add(divider);
						value /= divider;
						Calculate();
					}
				}

				Calculate();
			}
			return result;
		}

		#endregion
	}
}