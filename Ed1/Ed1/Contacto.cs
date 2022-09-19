using System;

namespace Contactos
{
    public class Contato : IEquatable<Contato> //Esto para que remove funque en agenda
    {
        public string Nome
        {
            get;
            private set;
        }
        public string Sobrenome
        {
            get;
            private set;
        }
        public string Endereco
        {
            get;
            private set;
        }
        public string Email
        {
            get;
            private set;
        }
        public string Telefone
        {
            get;
            private set;
        }

        public Contato()
        {
        }
        public Contato(String n, String a, String d, String e, String t)
        {
            Nome = n;
            Sobrenome = a;
            Endereco = d;
            Email = e;
            Telefone = t;
        }

        public bool Equals(Contato otro)
        {
            if (otro == null) return false;
            return (this.Nome.Equals(otro.Nome) && this.Sobrenome.Equals(otro.Sobrenome) &&
                this.Endereco.Equals(otro.Endereco) && this.Email.Equals(otro.Email) &&
                this.Telefone.Equals(otro.Telefone));
        }


        public override string ToString()
        {
            return string.Format("Nome: {0} \nSobrenome: {1} \nEndereço: {2} \nEmail: {3} \nTelefone: {4}\n\n", Nome, Sobrenome, Endereco, Email, Telefone);
        }


    }
}
