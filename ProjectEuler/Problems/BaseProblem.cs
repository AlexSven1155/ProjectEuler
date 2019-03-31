using System;
using System.Diagnostics;
using System.Threading;
using System.Threading.Tasks;

namespace ProjectEuler.Problems
{
	public abstract class BaseProblem
	{
		private Stopwatch _stopwatch = new Stopwatch();

		protected bool _isAnimationWorking = true;

		protected delegate void ResultDelegate(string value);

		protected event ResultDelegate ShowResult;

		public void Start()
		{
			Console.Write($"{this.GetType().Name} Start ");
			Task.Factory.StartNew(StartAnimationWaiting, TaskCreationOptions.AttachedToParent);
			ShowResult += ResultHandler;
			_stopwatch.Start();

			Go();

			_stopwatch.Stop();
			Console.WriteLine($"Время выполнения: {_stopwatch.Elapsed.Seconds} с {_stopwatch.Elapsed.Milliseconds / 10} мс");
			Console.ReadLine();
		}

		protected void StartAnimationWaiting()
		{
			var counter = 1;
			Console.CursorVisible = false;
			while (_isAnimationWorking)
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

		protected void ResultHandler(string value)
		{
			_isAnimationWorking = false;
			Console.WriteLine();
			Console.WriteLine($"Результат: {value}");
		}

		protected virtual void OnShowResult(string value)
		{
			ShowResult?.Invoke(value);
		}

		protected abstract void Go();
	}
}