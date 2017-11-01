using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;

namespace statisticheparole
{
	public class Parole
	{
		List<Parola> parole;
		int totaleparole;

		public Parole()
		{
			this.parole = new List<Parola>();
		}

		public void Aggiungi(Parola parola)
		{
			// Cerca se la parola esiste già
			var par = this.parole.FirstOrDefault(p => p.testo == parola.testo);
			if (par == null)
			{
				// non esiste allora aggiungila
				this.parole.Add(parola);
			}
			else {
				// esiste allora incrementa
				this.parole.Where(p => p.testo == parola.testo).ToList().ForEach(i => i.Incrementa());
			}

		}

		public void Esporta(string filename)
		{
			string filePath = filename + ".csv";
			if (!File.Exists(filePath))
			{
				File.Create(filePath).Close();
			}
			string delimiter = ",";
			int length = this.parole.Count;
			using (System.IO.TextWriter writer = File.CreateText(filePath))
			{
				for (int index = 0; index < length; index++)
				{
					writer.WriteLine(string.Join(delimiter, this.parole[index].GetParola()));
				}
			}
		}

		public void Visualizza(int num)
		{
			for (var c = 0; c < this.parole.Count; c++)
			{
				parole[c].Visualizza();
				if (c >= num)
				{
					break;
				}
			}

			Console.WriteLine("TOTALE PAROLE: " + this.getTotaleParole());
		}

		public void Ordina()
		{
			this.parole = this.parole.OrderByDescending(o => o.conteggio).ToList();
		}

		public void setTotaleParole(int num)
		{
			this.totaleparole = num;
		}

		public int getTotaleParole()
		{
			return this.totaleparole;
		}
	}
}
