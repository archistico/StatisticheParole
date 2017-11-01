using System;
namespace statisticheparole
{
	public class Parola
	{
		public string testo;
		public int conteggio;
		public float percentuale;

		public Parola(string testo)
		{
			this.testo = testo;
			this.conteggio = 1;
		}

		public void Visualizza()
		{
			Console.WriteLine(this.testo + " : " + this.conteggio.ToString() + " : " + this.getPercentuale());
		}

		public void Incrementa()
		{
			this.conteggio++;
		}

		public string[] GetParola()
		{
			return new string[] { this.testo, this.conteggio.ToString(), this.getPercentuale() };
		}

		public void CalcolaPercentuale(int paroletotali)
		{
			this.percentuale = (float)this.conteggio / paroletotali;
		}

		public string getPercentuale()
		{
			return ((this.percentuale*100).ToString("0.00")+"%");
		}
	}
}
