using System;
using System.Collections.Generic;
using System.Xml;
using System.Text;
using System.Linq;
using System.Diagnostics.Contracts;

namespace Contactos
{
    public class Agenda
    {
        private List<Contato> contatos;
        public const string nomeArquivo = "contatos.xml";
        public const string EtqContatos = "contatos";
        public const string EtqContato = "contato";
        public const string EtqNome = "nome";
        public const string EtqSobrenome = "sobrenome";
        public const string EtqEndereco = "endereço";
        public const string EtqEmail = "email";
        public const string EtqTelefone = "telefone";

        //Constructor
        public Agenda()
        {
            contatos = new List<Contato>();
        }

        //Metodo static para pillar una agenda desde XML
        public static Agenda Get()
        {
            var toret = new Agenda();
            toret.OverrideContatos(GetContatosFromXml());
            return toret;
        }

        public bool IsEmpty()
        {
            return contatos.Count == 0;
        }

        public void OverrideContatos(List<Contato> c)
        {
            contatos = c;
        }

        public void AddContato(Contato c)
        {
            contatos.Add(c);
        }
        public void AddContato(String n, String a, String d, String e, String t)
        {
            contatos.Add(new Contato(n, a, d, e, t));
        }

        public Boolean DelContato(Contato c)
        {
            return contatos.Remove(c); //Puesto como return for debugging purposes
        }

        public int GetPosicion(Contato c)
        {
            return contatos.IndexOf(c);
            //return null;
        }

        public Contato GetContatoByIndex(int i)
        {
            return contatos.ElementAt(i);
        }

        public Contato GetContatoByNomeCompleto(String nom, String ap)
        {
            return contatos.Find(x => x.Nome == nom && x.Sobrenome == ap);
        }

        public Contato GetContatoByEmail(String email)
        {
            return contatos.Find(x => x.Email == email);
        }

        public void ModificarContato(int i, String nom, String ap, String d, String e, String t)
        {
            this.DelContato(contatos.ElementAt(i));
            this.AddContato(nom, ap, d, e, t);
        }

        //Devuelve una lista de contactos para crear la Agenda con ellos en "get"
        public static List<Contato> GetContatosFromXml()
        {
            var toret = new List<Contato>();
            var docXml = new XmlDocument();

            try
            {
                docXml.Load(nomeArquivo);

                if (docXml.DocumentElement.Name == EtqContatos)
                {
                    string nome = "";
                    string sobrenome = "";
                    string endereco = "";
                    string telefone = "";
                    string email = "";


                    foreach (XmlNode nodo in docXml.DocumentElement.ChildNodes)
                    {
                        if (nodo.Name == EtqContato)
                        {
                            foreach (XmlNode nodoHijo in nodo.ChildNodes)
                            {
                                if (nodoHijo.Name == EtqNome)
                                {
                                    nome = nodoHijo.InnerText.Trim();
                                }
                                if (nodoHijo.Name == EtqSobrenome)
                                {
                                    sobrenome = nodoHijo.InnerText.Trim();
                                }
                                if (nodoHijo.Name == EtqEndereco)
                                {
                                    endereco = nodoHijo.InnerText.Trim();
                                }
                                if (nodoHijo.Name == EtqTelefone)
                                {
                                    telefone = nodoHijo.InnerText.Trim();
                                }
                                if (nodoHijo.Name == EtqEmail)
                                {
                                    email = nodoHijo.InnerText.Trim();
                                }
                            }
                        }
                        toret.Add(new Contato(nome, sobrenome, endereco, telefone, email)); //Si algun dato no existe lo escribe vacio	
                    }

                }

            }
            catch (Exception)
            {//TODO
            }

            return toret;
        }

        //A continuacion metodos sobrecargados para evitar la especificacion de un nombre de archivo
        //Sobrecargable
        public void SaveXML()
        {
            this.SaveXML(nomeArquivo);
        }

        //Sobrecargado
        public void SaveXML(String name)
        {
            //Creación de escribidor y documento
            var writer = new XmlTextWriter(name, Encoding.UTF8);
            writer.WriteStartDocument();

            //Primera linea
            writer.WriteStartElement(EtqContatos);
            //Escribimos cada contacto
            foreach (var e in contatos)
            {

                writer.WriteStartElement(EtqContato);

                //Escribimos nombre
                writer.WriteStartElement(EtqNome);
                writer.WriteString(e.Nome);
                writer.WriteEndElement();

                //Escribimos apellidos
                writer.WriteStartElement(EtqSobrenome);
                writer.WriteString(e.Sobrenome);
                writer.WriteEndElement();

                //Escribimos direccion
                writer.WriteStartElement(EtqEndereco);
                writer.WriteString(e.Endereco);
                writer.WriteEndElement();

                //Escribimos email
                writer.WriteStartElement(EtqEmail);
                writer.WriteString(e.Email);
                writer.WriteEndElement();

                //Escribimos telefono
                writer.WriteStartElement(EtqTelefone);
                writer.WriteString(e.Telefone);
                writer.WriteEndElement();

                //Cerramos el contacto
                writer.WriteEndElement();
            }

            writer.WriteEndElement();
            writer.WriteEndDocument();
            writer.Close();
        }


        //TOSTRING
        public override string ToString()
        {
            var toret = new StringBuilder();
            foreach (var entry in this.contatos)
            {
                toret.AppendLine(entry.ToString());
            }
            return toret.ToString();
        }

        //VERSION DE TOSTRING PARA COMBOBOX
        public String[] ToStringCB()
        {
            var toret = new String[this.contatos.Capacity];
            int it = 0;
            foreach (var entry in this.contatos)
            {
                toret[it++] = (entry.Nome.ToString() + "," + entry.Sobrenome.ToString());
            }
            return toret;
        }
    }
}