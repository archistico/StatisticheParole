using System;
using System.Collections.Generic;
using System.Text.RegularExpressions;

namespace statisticheparole
{
	public class Statistiche
	{
		string testo = "";
		Parole parole;

		public Statistiche()
		{
			Console.WriteLine("STATISTICHE PAROLE");
			this.parole = new Parole();
		}

		public void Run(string filename, int num)
		{
			Console.Write("CARICAMENTO FILE: ");
			CaricaFile(filename);
			Console.WriteLine("OK");

			Console.Write("PULIZIA TESTO: ");
			PulisciTesto();
			Console.WriteLine("OK");

			Console.WriteLine("INIZIO DIVISIONE PAROLE");
			SpitIntoWords();
			Console.WriteLine("FINE DIVISIONE PAROLE");

			Console.Write("ORDINAMENTO STATISTICHE: ");
			parole.Ordina();
			Console.WriteLine("OK");

			Console.Write("CALCOLO PERCENTUALI: ");
			parole.Percentuali();
			Console.WriteLine("OK");

			Console.Write("EXPORT: ");
			parole.Esporta(filename);
			Console.WriteLine("OK");

			Console.WriteLine("LISTA "+num+" PAROLE");
			parole.Visualizza(num);
			Console.WriteLine("FINE LISTA");
			Console.WriteLine("TOTALE PAROLE DIFFERENTI: " + this.parole.getParoleDifferenti());
		}

		void PulisciTesto()
		{
			this.testo = Regex.Replace(this.testo.ToLower(), "[^a-zA-Zàéèìòù]", " ");
		}

		public void CaricaFile(string filename)
		{
			this.testo = System.IO.File.ReadAllText(filename);
		}

		public void SpitIntoWords()
		{
			var matches = Regex.Matches(this.testo, @"[a-zA-Zàéèìòù]+[^\s\']*[a-zA-Zàéèìòù]+|[a-zA-Zàéèìòù]");

			int paroleTotali = matches.Count;
			var step = 10;
			var bloccoparole = DividiStep(paroleTotali, step);
			int parolaCorrente = 0;
			int bloccocorrente = bloccoparole;
			int percentuale = 0;

			foreach (Match match in matches)
			{
				parolaCorrente++;

				if (parolaCorrente==bloccocorrente)
				{
					percentuale += step;
					bloccocorrente += bloccoparole;
					if (percentuale < 100)
					{
						Console.Write(percentuale + "% ");
					}
					else {
						Console.WriteLine(percentuale + "% ");
					}

				} 

				this.parole.Aggiungi(new Parola(match.Value));
			}

			this.parole.setTotaleParole(parolaCorrente);
		}

		public int DividiStep(int paroleTotali, int step)
		{
			return (int)Math.Floor((float)paroleTotali/step);
		}
}
}
