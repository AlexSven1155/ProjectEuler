using System;

namespace ProjectEuler
{
	class Program
	{
		static void Main(string[] args)
		{
			Console.WriteLine("Какую прблему тебе решить?");
			var suffix = Console.ReadLine();
			var problem = Type.GetType("ProjectEuler.Problems.Problem" + suffix, false, true);
			if (problem != null)
			{
				var ctor = problem.GetConstructor(new Type[] { });
				var problemObj = ctor?.Invoke(new object[] { });
				var start = problemObj?.GetType().GetMethod("Start");
				start?.Invoke(problemObj, null);
				Console.Clear();
				Main(null);
			}
			else
			{
				Console.WriteLine("Нет такой.");
				Main(null);
			}
		}
	}
}