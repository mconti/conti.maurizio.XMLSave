using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml.Linq;

namespace conti.maurizio._5i.WPFXmlSave
{
    public class Meteo
    {
        public string Citta { get; set; }
        public double Temperatura { get; set; }

        public Meteo() { }

        public Meteo(XElement e)
        {
            Citta = e.Attribute("Citta").Value;

            double temp = 0;

            Double.TryParse(e.Attribute(
                "Temperatura").Value,
                out temp
            );
            Temperatura = temp;
        }
    }
    public class Metei : List<Meteo>
    {
        public string FileName { get; }
        public Metei (string fileName)
        {
            Add(new Meteo { Citta="Riccione", Temperatura=20.3 });

            XElement e = new XElement("previsioni",
                new XElement("Metei",
                    new XAttribute("Data", "21/2/2017"),
                        from m in this
                        select new XElement( "Meteo", 
                            new XAttribute("Citta", m.Citta),
                            new XAttribute( "Temperatura", m.Temperatura )
                    )
                )
            );

            // Costruzione statica..
            //XElement e1 = new XElement("previsioni",
            //    new XElement("Metei",
            //        new XAttribute("Data", "21/27/2017"),
            //        new XElement("Meteo",
            //            new XAttribute("Citta", "Rimini"),
            //            new XAttribute("Temperatura", 20.5)
            //        )
            //    )
            //);

            e.Save(fileName);
        }
    }
}
