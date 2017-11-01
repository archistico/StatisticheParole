using System;

namespace statisticheparole
{
	class MainClass
	{
		
		public static void Main(string[] args)
		{
			if (args.Length < 2)
			{
				System.Console.WriteLine("Inserire il nome del file di testo e il numero di parole visualizzate");
				System.Console.WriteLine("Esempio: ./statisticheparole.exe <file> <num>");
				Environment.Exit(1);
			}

			int num;
			bool test = int.TryParse(args[1], out num);
			if (test == false)
			{
				System.Console.WriteLine("Il secondo parametro non è un numero");
				System.Console.WriteLine("Esempio: ./statisticheparole.exe <file> <num>");
				Environment.Exit(1);
			}

			Statistiche stat = new Statistiche();
			stat.Run(args[0], num);
		}
	}
}
