# Werte konvertieren

Oftmals muss man im GUI Werte anders  anzeigen, als sie in der gebundenen Model-Klasse zur Verfügung stehen. Manchmal soll zum Beispiel _Ja_ und _Nein_ angezeigt werden, statt _true_ und _false_. Oder die Anrede in einer Adresse ist codiert in der Datenbank abgelegt und aus dem Code 1 respektive 2 soll im GUI "Herr" bzw. "Frau" werden. 

Um Werte in gebundenen Objekte für das GUI umzuwandeln und wieder zurückzuwandeln, musst du eine Klasse erstellen, die das Interface `IValueConverter` implementiert.

## Das Interface `IValueConverter`

Das `IValueConverter`-Interface schreibt zwei Methoden vor. Die Methode _Convert_, die für die Umwandlung des Wertes aus der Model-Klasse verantwortlich ist.

```CSharp
public object Convert(object value, Type targetType, object parameter, CultureInfo culture) 
```

Und die Methode _ConvertBack_, die für die Rückumwandlung zuständig ist. 

```CSharp
public object ConvertBack(object value, Type targetType, object parameter, CultureInfo culture)
```

Die Parameter sind bei beiden Methoden die gleichen. Sie bedeuten folgendes: 

* **_value_** > der konkrete Wert, der umgewandelt werden soll (8-ung: der Wert kann auch null sein!) 
* **_targetType_** > der gewünschte Zieltyp, in den konvertiert werden soll
* **_parameter_** > zusätzliche Parameter, die verwendet werden können (z.B. ein bestimmtes Nummernformat)
* **_culture_** > die Länder- bzw. Spracheinstellung, in der das Ergebnis ausgegeben werden soll (so können sprachspezifische Konvertierungen durchegeführt werden, z.B. ja/nein, yes/no) 

## Beispiel: Umwandlung eines Zahlencodes in einen Text

Eine Konverter-Klasse für die Umwandlung eines Anrede-Codes (1=Herr, 2=Frau) einer Adresse kann wie folgt aussehen: 

```CSharp
public class AnredeConverter : IValueConverter
{
    public object Convert(object value, Type targetType, object parameter, CultureInfo culture)
    {
        if (value == null)
            return "";
        else if (System.Convert.ToInt32(value) == 1)
            return "Herr";
        else
            return "Frau";
    }

    ...
}
```

### Einbinden der Konverter-Klasse in XAML

Die Konverter-Klasse wird in XAML bei der Datenbindung angegeben. Dabei empfiehlt es sich, die Konverter-Variable als Ressource anzugeben. 

```XML
    <Window.Resources>
        <local:AnredeConverter x:Key="anredeConverter" />
    </Window.Resources>

```

Anschliessend kann die Variable bei der Datenbindung angegeben werden.

```XML
<TextBlock Name="anredeTb" Text="{Binding Anrede, Converter={StaticResource ResourceKey=anredeConverter}}" />
```

### Download

* Visual Studio Solution mit dem Quellcode des Konverter-Beispiels: [ValueConverter_Sample.zip](res/ValueConverter_Sample.zip)  

<!--

## MultiValueConverter

Erklären von: 

* MultiValueConverter


* Aufgabe: `UpperCaseConverter` (Schrödinger Seite 609) 
* optional das `VisibilityControl` einführen (kann über NuGet geholt werden -> Schrödinger, Seite 612)
-->