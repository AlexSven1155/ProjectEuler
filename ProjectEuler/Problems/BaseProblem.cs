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
		/// Решето Эратосфена.
		/// Возвращает массив простых делителей указанного числа.
		/// </summary>
		public List<long> GetPrimeDivisors(long targetNumber)
		{
			var arrayNumbers = new List<long>();
			var excludeNumbers = new List<long>();
			for (int i = 1; i <= targetNumber; i++)
			{
				arrayNumbers.Add(i);
			}

			var koef = Math.Round(Math.Sqrt(targetNumber), 0);

			for (var i = 1; i < koef; i++)
			{
				int check = 0;
				for (int j = 1; j <= i; j++)
				{
					if (i % j == 0)
					{
						check++;
					}

					if (check > 2)
					{
						break;
					}
				}

				if (check == 2)
				{
					excludeNumbers.Add(i);
				}
			}

			foreach (var excludeNumber in excludeNumbers)
			{
				var firstIndex = (int)(excludeNumber * excludeNumber) - 1;
				arrayNumbers[firstIndex] = 0;
				for (long i = firstIndex; i < targetNumber; i += excludeNumber)
				{
					arrayNumbers[(int)i] = 0;
				}
			}

			return arrayNumbers.Where(e => e > 0 && e != 1 && targetNumber % e == 0 && e != targetNumber).ToList();
		}

		#endregion
	}
}