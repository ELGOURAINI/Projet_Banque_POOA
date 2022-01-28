using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace UI_Bank
{
    public abstract class Compte
    {
        //les attributs
        int idC;
        static int comptId=1;
        Client titulaire;
		private double Solde;
		private static double plafond = 20000;
		private List<Operation> listOp ;

		//les methodes
		public Compte(Client titu,double solde)
        {
			this.Solde = solde;
            this.titulaire = titu;
            this.idC= Compte.comptId++;
			listOp = new List<Operation>();
		}
        public void print_Compte()
        {
            Console.WriteLine("id Compte"+this.idC);
        }
		public abstract void print();
		public virtual void Crediter(double M)
		{
			this.Solde=this.Solde+ M;
			//OperationV op = new OperationV(this, M, type, __DATE__);
			//this.addOp(op);
		}
		public virtual bool Debiter(double M)
		{
			bool TF = false;
			//retrait
			if ((this.Solde) >= M && M <= Compte.plafond)
			{
				this.Solde = this.Solde - M;
				//OperationR op = new OperationR(this, M, type, __DATE__);
				//this.addOp(op);
				TF = true;
			}
			//ajouter operation
			return TF;
		}
		public virtual bool Verser(Compte C, double D)
		{
			if (this.Debiter(D))
			{
				this.Debiter(D);
				 C.Crediter(D);
				return true;
			}
			return false;
		}

		public void addOp(Operation c)
		{
			this.listOp.Add(c);
		}

	}
	public class CompteEpargne : Compte
	{
		public double TauxInteret;

		public CompteEpargne(Client titu,double sold,double Taux ) :base(titu,sold)
		{
			this.TauxInteret = Taux;
		}
		public override void print()
		{
			Console.Write("Compte Epargne ");
			Console.Write("\n");
			this.print_Compte();
			Console.Write("le taux d'interet: ");
			Console.Write(this.TauxInteret);
			Console.Write("\n");
		}
	}
	public class CompteCrt : Compte
	{
		private static double Decouvert=100;

		public CompteCrt(Client c, double d) : base(c, d)
		{
		}
		public override void print()
		{
			Console.Write("Compte courant ");
			Console.Write("\n");
			this.print_Compte();
		}
	}
	public class ComptePayant : CompteCrt
	{
		public ComptePayant(Client c, double d) : base(c, d)
		{
		}

		public override bool Debiter(double M)
		{
			return this.Debiter((M * 1.05));
		}

		public override bool Verser(Compte C, double D)
		{
			return this.Verser(C, (D * 1.05));
		}
		public override void print()
		{
			Console.Write("Compte Payant ");
			Console.Write("\n");
			this.print_Compte();
		}
	}
}
