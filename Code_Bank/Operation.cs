using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace UI_Bank
{
    public abstract class Operation
    {
        int Num_Op;
        static int Compt_Num_Op = 0;
        double Montant;
		string date ;
		string libelle;
		Compte C;

		public Operation(Compte C, double m, string lib, string date)
		{
			this.Num_Op = ++Operation.Compt_Num_Op;
			this.Montant = m;
			this.C = C;
			this.libelle = lib;
			this.date = date;
		}
		public abstract void afficher();
		protected void detail_op()
		{
			Console.Write("      Numero de l'operation : ");
			Console.Write(this.Num_Op);
			Console.Write("\n");
			Console.Write("Montant de l'operation est "+ this.Montant);
			Console.Write("      Date :");
			Console.Write(this.date);
			Console.Write("\n");
		}

	}
	public class OperationR : Operation
	{
		public OperationR(Compte C, double D, string lib, string date) : base(C, D, lib, date)
		{
		}
		public override void afficher()
		{
			Console.Write("****************");
			Console.Write("Operation de Retrait");
			Console.Write("*********************");
			Console.Write("\n");
			this.detail_op();
		}
	}
	public class OperationV : Operation
	{
		public OperationV(Compte C, double D, string lib, string date) : base(C, D, lib, date)
		{
		}
		public override void afficher()
		{
			Console.Write("****************");
			Console.Write("Operation de Versement");
			Console.Write("*********************");
			Console.Write("\n");
			this.detail_op();
		}
	}

}
