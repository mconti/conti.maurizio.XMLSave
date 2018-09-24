# Appunti di C\#

Scritto con GitBook   
[https://www.gitbook.com/@itts/spaces](https://www.gitbook.com/@itts/spaces)  
  
Questa pagina la trovi qui  
[https://itts.gitbook.io/5i/](https://itts.gitbook.io/5i/)

## Appunti di C\#

### Argomento: Lettura di file XML

Using C\# necessari

```csharp
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml.Linq;
```

Sorgenti qui:  
[https://github.com/mconti/conti.maurizio.XMLSave.git](https://github.com/mconti/conti.maurizio.XMLSave.git)

Classe Meteo

```csharp
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
```

Classe Metei \(contenitore di oggetti Meteo\)

```csharp
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

        e.Save(fileName);
    }
}
```

