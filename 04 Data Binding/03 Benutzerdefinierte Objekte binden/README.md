# Bindung benutzerdefinierter Objekte 

Nicht nur UI-Elemente können als Datenquellen für DataBinding benutzt werden, sondern auch beliebige, selbst definierte Objekte. 

Zum Beispiel eine Klasse `Person` mit den Eigenschaften _Name_, _Wohnort_ und _Alter_. 

```CSharp 
class Person 
{
    public string Name { get; set; }
    public string Wohnort { get; set; }
    public int Alter { get; set; }
}
```

Es gibt zwei Möglichkeiten, ein Objekt vom Typ `Person` in einer WPF-Anwendung zu [instanziieren](https://de.wikipedia.org/wiki/Instanziierung):

* im XAML-Code
* mit C#-Code  

Nachfolgend werden beide Möglichkeiten erklärt.

## Ein Objekt mit XAML-Code instanziieren und binden

Innerhalb des XAML-Codes wird im Resources-Abschnitt von `Window` die Klasse Person instanziiert:  

```XML
 <Window.Resources>
    <local:Person x:Key="myPerson" Name="John Doe" Wohnort="New York" Alter="35" />
</Window.Resources>
```

Den Eigenschaften des Objekts kann bei Bedarf ein Anfangswert übergeben werden. Daran sind zwei Bedingungen geknüpft:

1. Damit die Klasse im XAML-Code instanziiert werden kann, muss sie einen parameterlosen Konstruktor haben.
2. Die Eigenschaften müssen als _Property_ geprägt sein, d. h. sie müssen einen _set_- und einen _get_-Accessor haben.

Um nun die Eigenschaften _Name_, _Wohnort_ und _Alter_ des Objekts jeweils an die  _Text_-Eigenschaft einer TextBox zu binden, benötigen wir ein Binding-Objekt. Dabei beschreibt die Eigenschaft _Source_ des Binding-Objekts die Datenquelle. Mit einer verschachtelten Markup-Erweiterung unter Angabe von _StaticResource_ und dem Identifier kann die Ressource angesprochen und mit _Path_ an die gewünschte Eigenschaft des Person-Objekts gebunden werden. 

```XML
<StackPanel>
    <TextBox Text="{Binding Source={StaticResource myPerson}, Path=Name}" />
    <TextBox Text="{Binding Source={StaticResource myPerson}, Path=Wohnort}" />
    <TextBox Text="{Binding Source={StaticResource myPerson}, Path=Alter}" />
</StackPanel>
```

## Ein Objekt mit C#-Code instanziieren und binden 

Normalerweise werden Objekte nicht im XAML-Code erzeugt, sondern mit C#-Code. Die typische Vorgehensweise, um eine mit C# erzeugte Instanz einer Klasse zu binden, ist, diese Instanz der Eigenschaft _DataContext_ der Klasse `Window` zuzuweisen. Dies kann z.B. innerhalb des Konstruktors von `Window` passieren. 

```CSharp
public partial class MainWindow : Window
{
    Person p = new Person { Name = "John Doe", Wohnort = "New York", Alter = 35 };

    public MainWindow()
    {
        InitializeComponent();
        this.DataContext = p;
    }
}
```

Wiederum soll die Eigenschaft _Firstname_ des Objekts an die Eigenschaft _Text_ einer TextBox gebunden werden. Dies erfolgt wie gehabt im XAML-Code. Die Angabe der _Source_ ist dabei nicht nötig; es wird automatisch der _DataContext_ des Windows als Quelle verwendet. 

```XML
 <StackPanel>
    <TextBox Text="{Binding Path=Name}" />
    <TextBox Text="{Binding Path=Wohnort}" />
    <TextBox Text="{Binding Path=Alter}" />
</StackPanel>
```

Als Resultat werden die Werte der Eigenschaften des _Person_-Objektes in den Textfeldern angezeigt.

![Bild 1](res/01.jpg)

### Der DataContext

Im Beispiel oben haben wir gesehen, wie das zu im GUI bindende Objekt über die _DataContext_-Eigenschaft dem Window zugewiesen wird. 

Die _DataContext_-Eigenschaft ist vom Typ `Object` und in der WPF-Klassenhierarchie auf Stufe `FrameworkElement` und `FrameworkContentElement` implementiert. Ihr  Value wird über einen WPF-internen Vererbungsmechanismus über den Element-Tree vererbt, was bedeutet, dass der _DataContext_ auf einem höher liegenden Element gesetzt werden kann und dann auch in allen darunterliegenden Elementen zur Verfügung steht. `Binding`-Objekte auf den tiefer liegenden Elementen müssen dabei lediglich die _Path_-Property setzen, die (nochmalige) Angabe von _ElementName_ oder _Source_ ist nicht notwendig. 

**Hinweis:** Natürlich können auf tiefer liegenden Elementen auch bei gesetztem _DataContext_ die Properties _ElementName oder _Source_ gesetzt werden, um eine andere Binding-Source als jene des DataContexts zu forcieren. 

## Die Klasse `Binding`

Da die `Binding`-Klasse  nebst einem parameterlosen Konstruktor einen zweiten Konstruktor besitzt, der den für die _Path_-Property verwendeten Pfad entgegennimmt, kann ein Binding-Markup in XAML auch verkürzt dargestellt werden: 

Statt...

```XML
<TextBox Text="{Binding Path=Wohnort}" />
```

...kann das Binding wie folgt notiert werden: 

```XML
<TextBox Text="{Binding Wohnort}" />
```

### Die _Path_-Property

Die _Path_-Property ist die meistgesetzte Property beim Data Binding. Sie ist vom Typ `PropertyPath` und definiert den Pfad zur Source (Quelle), an die gebunden wird.

In XAML wird zum Setzen der _Path_-Property ein einfacher String angegeben. In C# dagegen muss explizit ein `PropertyPath`-Objekt erzeugt werden, dessen _Path_-Property den String entgegennimmt. Es mag auf den ersten Blick komisch erscheinen, warum ein einfacher String-Pfad in der Klasse `PropertyPath` gekapselt wird. Die Antwort darauf ist jedoch simpel: Ein Pfad kann relativ komplex sein und benötigt zur Auflösung im Hintergrund etwas Logik und Reflektion. 

Die _Path_-Property kann mit unterschiedlichen Pfaden umgehen. Folgend ein paar Beispiele: 

* **_Path=Propertyname_**: Es wird an die Eigenschaft _Propertyname_ im aktuellen Source-Objekt gebunden. Dabei kann _Propertyname_ eine "gewöhnliche" .NET-Property sein oder eine Dependency-Property. 

* **_Path=Propertyname.Subpropertyname_**: Es wird an eine auf dem aktuellen Source-Objekt definierte Subproperty gebunden. Dabei kann der Pfad beliebig tief verschachtelt werden. 

    Ein Beispiel: 
    
    ```XML
   <TextBox Text="{Binding Path=SelectedItem.Content}" />  
    ```

* **_Path=(OwnerType.AttachedPropertyName)_**: Es wird an eine auf dem aktuellen Source-Objekt gesetzte Attached Property gebunden. 
    
    Ein Beispiel: 

    ```XML
        <Grid> 
        ...
        <Button Name="btn" Grid.Row="0"/>
        <TextBox Text="{Binding ElementName=btn, Path=(Grid.Column)}" Grid.Row="1"  />
        ...
        </Grid>

* **_Path=Propertyname[i]_**: Es wird an einen Indexer gebunden, z.B. _Path=Items[0]_.

* **_Path=Propertyname/Propertyname_**: Diese Angabe mit Schrägstrich wird für Master-Detail Szenarien verwendet, z.B. _Path=Orders/OrderDetails_.

Die hier dargestellen Möglichkeiten zur Angabe des Pfades lassen sich beliebig verschachteln. D.h. es können mehrere verschachtelte Eigenschaften hintereinander geschrieben werden: 

```XML
<TextBox Text="{Binding ElementName=MyListBox, Path=Items[0].Content}" />
```

Dabei übernimmt WPF pratkischerweise die Typumwandlung (Casting); das heisst ein Casting in ein ContentControl ist in obigem Beispiel nicht notwendig. 