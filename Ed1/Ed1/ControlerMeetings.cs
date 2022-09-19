using System;

namespace Meetings
{
    public class Controler_Meetings
    {
        public Meets listaCompromisso;

        public Controler_Meetings()
        {
            listaCompromisso = new Meets("compromisso.xml");
        }

        public void ToAddNewMeet(string nome, string nomCon, string fechar, string hora, string des)
        {
            Compromisso nova = new Compromisso(nome, nomCon, fechar, hora, des);
            this.listaCompromisso.AddMeet(nova);
        }

        public void ToModifyMeet(string nom, string nomeCompromissos, string nomContato, string fechar, string hora, string des)
        {
            Compromisso nova = new Compromisso(nomeCompromissos, nomContato, fechar, hora, des);
            this.listaCompromisso.ModifyMeet(nom, nova);
        }

        public Boolean ToDeleteMeet(string nom)
        {
            return this.listaCompromisso.RemoveMeet(nom);
        }

        public String[] GetAll()
        {
            return this.listaCompromisso.GetAll();
        }

        public Compromisso ToGetMeetByName(string nom)
        {
            return this.listaCompromisso.GetByName(nom);
        }

        public string ToViewMeetByName(string nom)
        {
            return (this.listaCompromisso.GetByName(nom).ToString() + "\n");
        }

        public string ToViewMeetByContact(string nom)
        {
            return this.listaCompromisso.GetByContact(nom).ToString() + "\n";
        }

        public void ToGenerateXml()
        {
            listaCompromisso.GenerateXml();
        }

        public override string ToString()
        {
            return listaCompromisso.ToString();
        }
    }
}
