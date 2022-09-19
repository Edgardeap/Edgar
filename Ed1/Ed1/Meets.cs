using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Xml;
using System.Xml.Linq;
using Ed1;


namespace Meetings
{
    public class Meets
    {
        public List<Compromisso> todosOsCompromisso;
        public string nombreXmlDoc;
        private Stream nomeXmlDoc;

        public Meets(string xml)    //Direccion del archivo XML de Citas
        {
            nombreXmlDoc = xml;
            todosOsCompromisso = RecuperaXml(xml);
        }

        public List<Compromisso> RecuperaXml(string f)
        {
            var toret = new List<Compromisso>();
            var docXml = new XmlDocument();

            try
            {
                docXml.Load(f);

                if (docXml.DocumentElement.Name == "Citação")
                {
                    string nome = "";
                    string nomeContato = "";
                    string fechar = "";
                    string hora = "";
                    string descrip = "";

                    foreach (XmlNode nodo in docXml.DocumentElement.ChildNodes)
                    {
                        if (nodo.Name == "citação")
                        {
                            foreach (XmlNode subNodo in nodo.ChildNodes)
                            {
                                if (subNodo.Name == "nomeCitação")
                                {
                                    nome = subNodo.InnerText.Trim(); //Trim quita los espacios en blanco
                                }
                                if (subNodo.Name == "nomeContato")
                                {
                                    nomeContato = subNodo.InnerText.Trim();
                                }
                                if (subNodo.Name == "fechar")
                                {
                                    fechar = subNodo.InnerText.Trim();
                                }
                                if (subNodo.Name == "hora")
                                {
                                    hora = subNodo.InnerText.Trim();
                                }
                                if (subNodo.Name == "Descricao")
                                {
                                    descrip = subNodo.InnerText.Trim();
                                }
                            }

                            if (nome != "") //En caso de que el documento este vacio
                            {
                                toret.Add(new Compromisso(nome, nomeContato, fechar, hora, descrip));
                            }
                        }
                    }
                }
            }
            catch (Exception)
            {
                toret.Clear();
                Console.WriteLine("Exceção");
            }

            return toret;
        }

        public void AddMeet(Compromisso compromisso)
        {
            todosOsCompromisso.Add(compromisso);    //Añado la cita a todas las anteriores
        }

        public Boolean RemoveMeet(string nom)
        {
            Compromisso compromisso = this.GetByName(nom);

            if (todosOsCompromisso.Remove(compromisso))
                return true;
            else
                return false;
        }

        public void ModifyMeet(string nom, Compromisso compromisso) //Le pasas el nombre de la cita a modificar y la cita nueva
        {
            Compromisso aux = this.GetByName(nom);
            int position = todosOsCompromisso.IndexOf(aux);
            todosOsCompromisso.Remove(aux);
            todosOsCompromisso.Insert(position, compromisso);   //Vuelve a insertarla en la misma posicion
        }

        public String[] GetAll()
        {
            String[] toret = new string[todosOsCompromisso.Count];
            int j = 0;

            foreach (var i in todosOsCompromisso)
            {
                toret[j++] = i.Nome;
            }
            return toret;
        }

        public Compromisso GetByName(string nom)
        {
            return todosOsCompromisso.Find(x => x.Nome == nom);
        }

        public Compromisso GetByContact(string nom)
        {
            return todosOsCompromisso.Find(x => x.NomeContato == nom);
        }

        public void GenerateXml()
        {
            int j = 0; //Contador Actual

            XmlTextWriter textWriter = new XmlTextWriter(nomeXmlDoc, Encoding.UTF8);

            textWriter.WriteStartDocument();
            textWriter.WriteStartElement("Compromisso");

            foreach (var i in todosOsCompromisso)
            {
                textWriter.WriteStartElement("citação");
                textWriter.WriteStartElement("nomeCita");
                textWriter.WriteString(todosOsCompromisso.ElementAt(j).Nome);
                textWriter.WriteEndElement();
                textWriter.WriteStartElement("nomeContato");
                textWriter.WriteString(todosOsCompromisso.ElementAt(j).NomeContato);
                textWriter.WriteEndElement();
                textWriter.WriteStartElement("fechar");
                textWriter.WriteString(todosOsCompromisso.ElementAt(j).Fechar);
                textWriter.WriteEndElement();
                textWriter.WriteStartElement("hora");
                textWriter.WriteString(todosOsCompromisso.ElementAt(j).Hora);
                textWriter.WriteEndElement();
                textWriter.WriteStartElement("descrição");
                textWriter.WriteString(todosOsCompromisso.ElementAt(j).Descricao);
                textWriter.WriteEndElement();
                textWriter.WriteEndElement();

                j++;
            }

            textWriter.WriteEndElement(); //Cerrar Citas
            textWriter.WriteEndDocument();
            textWriter.Close();

        }

        public override string ToString()
        {
            StringBuilder toret = new StringBuilder();
            int j = 0;

            //System.Console.WriteLine (todasLasCitas.Count);

            if (todosOsCompromisso.Count == 0)
            {
                toret.Append("");
            }
            else
            {
                foreach (var i in todosOsCompromisso)
                {
                    toret.Append(i.ToString(++j) + " \n\n");
                }
            }
            return toret.ToString();
        }
    }
}
