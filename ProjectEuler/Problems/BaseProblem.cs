using System;
using System.Diagnostics;

namespace ProjectEuler.Problems
{
	public abstract class BaseProblem
	{
		private Stopwatch _stopwatch = new Stopwatch();

		public void Start()
		{
			Console.WriteLine($"{this.GetType().Name} Start\n");
			_stopwatch.Start();

			Go();

			_stopwatch.Stop();
			Console.WriteLine($"Время выполнения: {_stopwatch.Elapsed.Seconds} с {_stopwatch.Elapsed.Milliseconds / 10} мс");
			Console.ReadLine();
		}

		public abstract void Go();
	}
}
