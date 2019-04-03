using System;
using System.Threading;

namespace ProjectEuler
{
	class Program
	{
		public static void Main(string[] args)
		{
			Console.Clear();
			Console.WriteLine("Какую прблему тебе решить?");
			var suffix = Console.ReadLine();
			var problem = Type.GetType("ProjectEuler.Problems.Problem" + suffix, false, true);
			if (problem != null)
			{
				var ctor = problem.GetConstructor(new Type[] { });
				var start = problem.GetMethod("Start");
				var dispose = problem.GetMethod("Dispose");

				try
				{
					var problemObj = ctor?.Invoke(new object[] { });
					start?.Invoke(problemObj, null);
					dispose?.Invoke(problemObj, null);
				}
				catch (Exception e)
				{
					Console.WriteLine("При запуске возникла ошибка: " + e.Message + Environment.NewLine + e.StackTrace);
				}

				Console.Clear();
				Main(null);
			}
			else
			{
				Console.WriteLine("Нет такой.");
				Thread.Sleep(500);
				Main(null);
			}
		}
	}
}