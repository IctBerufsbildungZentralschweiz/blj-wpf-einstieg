# Das Interface `INotifyPropertyChanged`

## Aktualisieren gebundener Objekte

In der Realität möchten Anwender Daten nicht nur angezeigt haben, sondern sie wollen die Daten auch ändern können. Mal angenommen, es sei zu diesem Zweck in XAML einen `Button` definiert: 

```XML
<Button Content="Objektdaten ändern" Name="button1" Click="button1_Click" />
```
...und passend dazu in der Code-Behind Datei ein Ereignishandler mit C#. 

```CSharp 
private void button1_Click(object sender, RoutedEventArgs e)
{
    p.Name = "Hans Muster";
    p.Alter = 55;
    p.Wohnort = "Berlin";
}
```

Wer dieses Beispiel ausprobiert, wird feststellen, dass die Textboxen nicht aktualisiert werden, wenn auf den Button geklickt wird. Diese zeigen immer noch die alten und nun nicht mehr aktuellen Daten an. Den Textboxen fehlt die Information, dass sich das Objekt geändert hat.

Um dieses Problem zu lösen, bieten sich drei Alternativen an:

* Jede Eigenschaft als Abhängigkeitseigenschaft implementieren. Diese Variante ist mit viel Aufwand verbunden und wird bevorzugt bei Objekten benutzt, die eine grafische Präsentation haben. 
* In jeder Eigenschaft des Objekts ein separates Ereignis bereitstellen, das gefeuert wird, wenn der Eigenschaftswert ändert. In Beispiel oben würden diese drei Events z.B. _NameChanged_, _AlterChanged_ und _WohnortChanged_ lauten. Auch diese Alternative ist relativ aufwendig.
* Die Schnittstelle `INotifyPropertyChanged` implementieren. Dies ist die bevorzugte Lösung.

## Das `INotifyPropertyChanged` Interface

Dieses Interface gehört zum Namespace _System.ComponentModel_ und schreibt das Ereignis _PropertyChanged_ vor, das nach jeder Eigenschaftsänderung ausgelöst werden muss. Über dieses Ereignis werden gebundene Elemente über die Änderung benachrichtigt. 

Zum Beispiel sieht die Implementation von `INotifyPropertyChanged` in einer Klasse `Person` so aus: 

```CSharp 
public class Person : INotifyPropertyChanged 
{
    public event PropertyChangedEventHandler PropertyChanged;

    protected virtual void OnPropertyChanged(string propertyName) 
    {
        if (PropertyChanged != null)
            PropertyChanged(this, new PropertyChangedEventArgs(propertyName));
    }
    // [...]
}
```

Jetzt muss noch dafür gesorgt werden, dass  _PropertyChanged_ auch ausgelöst wird, wenn sich eine Eigenschaft ändert. Dies wird innerhalb des Setters einer Eigenschaft gemacht. Damit die Datenbindung effizient bleibt, wird dem Konstruktor des _PropertyChangedEventArgs_-Objekts der Name der Eigenschaft mitgeteilt, deren Wert gerade geändert worden ist. Dadurch wird nur auch nur dieser Wert in der Oberfläche aktualisiert. 

```CSharp
class Person : INotifyPropertyChanged
{
    public event PropertyChangedEventHandler PropertyChanged;

    protected virtual void OnPropertyChanged(string propertyName) 
    {
        if (PropertyChanged != null)
            PropertyChanged(this, new PropertyChangedEventArgs(propertyName));
    }

    private string _name;
    private string _wohnort;
    private int _alter; 

    public string Name
    {
        get { return _name; }
        set { _name = value; OnPropertyChanged("Name"); }
    }

    public string Wohnort
    {
        get { return _wohnort; }
        set { _wohnort = value; OnPropertyChanged("Wohnort"); }
    }

    public int Alter
    {
        get { return _alter; }
        set { _alter = value; OnPropertyChanged("Alter"); }
    }
}
``` 

Die an das `Person`-Objekt gebundenen UI-Elemente werden nun via  _PropertyChanged_-Event über jede Änderung einer Eigenschaft informiert. Das beste daran: am XAML-Code muss nichts verändert werden.

## Eine Basisklasse für alle Model-Klassen

Da in einem WPF-Projekt die meisten Model-Klassen das Interface `INotifyPropertyChanged` sowie die Methode _OnPropertyChanged_ implementieren werden, ist es ratsam, dies in eine Basisklasse auszulagern, um Copy-Paste-Code zu vermeiden.

```CSharp
public class ModelBase : INotifyPropertyChanged 
{
    public event PropertyChangedEventHandler PropertyChanged;

    protected virtual void OnPropertyChanged(string propertyName) 
    {
        if (PropertyChanged != null)
            PropertyChanged(this, new PropertyChangedEventArgs(propertyName));
    }
}
``` 

Eine Model-Klasse, wie z.B. `Person` implementiert durch die Vererbung automatisch das Interface und kann gleichzeitig die _OnPropertyChanged_-Methode der Basisklasse verwenden. 

```CSharp
public class Person : ModelBase 
{
    private string _name;
    private string _wohnort;
    private int _alter; 

    public string Name
    {
        get { return _name; }
        set { _name = value; OnPropertyChanged("Name"); }
    }
    // [...]
}
```
