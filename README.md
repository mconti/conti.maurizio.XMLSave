---
description: 'Appunti e materiali per studiare C#'
---

# Appunti di C\#

Gestire file XML  
[https://github.com/mconti/conti.maurizio.XMLSave.git](https://github.com/mconti/conti.maurizio.XMLSave.git)

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

