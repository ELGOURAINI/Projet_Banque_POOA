using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace UI_Bank
{
    public class Client
    {
        //les attributs
        public string nomC;
        public string prenomC;
        public string adresse;
        public string login;
        private string password;
        private List<Compte> listComptes ;

        //les methodes
        public Client(string N, string P, string A, string L, string PS)
        {
            this.nomC = N;
            this.prenomC = P;
            this.adresse = A;
            this.login = L;
            this.password = PS;
            listComptes = new List<Compte>();
        }
        public void addCompte(Compte c)
        {
            this.listComptes.Add(c);
        }
        public void print_Client()
        {
            Console.Write("---------------------------------------------------------");
            Console.Write("\n");
            Console.Write("      Nom de : ");
            Console.Write(this.nomC);
            Console.Write("\n");
            Console.Write("      Prenom  :");
            Console.Write(this.prenomC);
            Console.Write("\n");
            Console.Write("      Adresse :");
            Console.Write(this.adresse);
            Console.Write("\n");
            for (int i = 0; i < this.listComptes.Count; i++)
            {
                this.listComptes[i].print_Compte();
            }
            Console.Write("---------------------------------------------------------");
            Console.Write("\n");
        }
        public bool auth(string login, string password)
        {
            if (this.login == login && this.password == password)
                return true;
            return false;
        }
        public string afficher()
        {
            string s = "Nom    : " + this.nomC + "\nPrenom : " + this.prenomC + "\nAdresse    : " + this.adresse + "\nLogin  : " + this.login;
            return s;
        }
    }
}
