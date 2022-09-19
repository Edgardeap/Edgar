using System;

namespace Meetings
{
    public class Compromisso : IEquatable<Compromisso>
    {
        public Compromisso(string nome, string nomContato, string fechar, string hora, string des)
        {
            Nome = nome;
            NomeContato = nomContato;
            Fechar = fechar;
            Hora = hora;
            Descricao = des;
        }

        public string Nome
        {
            get; private set;
        }

        public string NomeContato
        {
            get; private set;
        }

        public string Fechar
        {
            get; private set;
        }

        public string Hora
        {
            get; private set;
        }

        public string Descricao
        {
            get; private set;
        }
        public string Endereco { get; internal set; }

        public bool Equals(Compromisso otro)
        {
            if (otro == null) return false;
            return (this.Nome.Equals(otro.Nome) && this.NomeContato.Equals(otro.NomeContato) &&
                this.Fechar.Equals(otro.Fechar) && this.Hora.Equals(otro.Hora) &&
                this.Descricao.Equals(otro.Descricao));
        }

        public override string ToString()
        {
            return string.Format("Compromisso:\nNome: {0}\nNomeContato: {1}\nFechar: {2}\nHora: {3}\nDescricao: {4}", Nome, NomeContato, Fechar, Hora, Descricao);
        }

        public string ToString(int actual)
        {
            return string.Format("Compromisso#{0}:\nNome: {1}\nNomeContato: {2}\nFechar: {3}\nHora: {4}\nDescricao: {5}", actual, Nome, NomeContato, Fechar, Hora, Descricao);
        }

        internal void Add(Compromisso compromisso)
        {
            throw new NotImplementedException();
        }
    }
}
