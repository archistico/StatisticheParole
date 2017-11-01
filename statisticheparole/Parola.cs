using System;
namespace statisticheparole
{
	public class Parola
	{
		public string testo;
		public int conteggio;

		public Parola(string testo)
		{
			this.testo = testo;
			this.conteggio = 1;
		}

		public void Visualizza()
		{
			Console.WriteLine(this.testo + " : " + this.conteggio.ToString());
		}

		public void Incrementa()
		{
			this.conteggio++;
		}

		public string[] GetParola()
		{
			return new string[] { this.testo, this.conteggio.ToString() };
		}
	}
}
