# DataBinding 

Es gibt in der WPF zwei grundlegende Techniken, um einzelne Eigenschaften von Steuerelementen mit Informationen zu versorgen:  

* Werte direkt auf dem Objekt setzen
* Werte über Datenbindung setzen

Wenn wir mit C# direkt auf eine Eigenschaft eines Steuerelements zugreifen um deren Wert zu setzen, dann hat das den Nachteil einer grossen Abhängigkeit, die zwischen den Oberflächen-Elementen (XAML-Code) und der Logik (C#-Code) ensteht. 

Um den C#-Code unabhängig von der Oberfläche zu halten, können die öffentlichen Eigenschaften von Objekten direkt im XAML-Code an einzelne UI-Elementen gebunden werden. So kann z.B. eine Eigenschaft eines Steuerelements verknüpft werden mit einer Information aus einem beliebigen Objekt. 

## Elementbindung (UI-Elemente als Quelle)

 Bei der Elementbindung wird die Eigenschaft eines UI-Elements an die Eigenschaft eines anderen UI-Elements gebunden. Dies passiert über die Eigenschaft _ElementName_, d.h. wir müssen der Datenquelle einen Namen geben und können dann beim Ziel-Element das Binding einrichten. 
 
 Für die Definition einer Datenbindung gibt es eine  _Markup Extension_, namens _Binding_. Über diese wird u.a. festgelegt, welches das Quellelement sein soll und welche Information wir von der Quelle haben wollen. 

Im folgenden Beispiel wird der aktuelle Wert eines Sliders (Quelle) an eine TextBox gebunden (Ziel). Über die Eigenschaft _Path_ wird dabei definiert, welche Eigenschaft der Quelle "angezapft" werden soll. Die angezapfte Eigenschaft muss dabei  **immer** eine öffentliche (public) Eigenschaft sein, mit Getter und Setter. 

 ```XML 
<StackPanel>
    <Slider Name="mySlider" />
    <TextBox Text="{Binding ElementName=mySlider, Path=Value}" />
</StackPanel>
```

 <video width="320" height="240" controls>
    <source src="res/video01.mp4" type="video/mp4">
    Your browser does not support the video tag.
</video> 

Als Resultat dieses Bindings sehen wir sofort eine Änderung in der TextBox, wenn der Slider verschoben wird.

## Bindung benutzerdefinierter Objekte 

Es können nicht nur UI-Elemente als Datenquellen für DataBinding benutzt werden, sondern auch beliebige, selbst definierte Objekte. 

Zum Beispiel eine Klasse `Person` mit den Eigenschaften _Name_, _Wohnort_ und _Alter_. 

```CSharp 
class Person 
{
    public string Name { get; set; }
    public string Wohnort { get; set; }
    public int Alter { get; set; }
}
```

Es gibt zwei Möglichkeiten, ein Objekt vom Typ `Person` in einer WPF-Anwendung zu erzeugen:

* im XAML-Code
* mit C#-Code  

Nachfolgend werden beide Möglichkeiten erklärt.

### Ein Objekt mit XAML-Code erzeugen und binden

Innerhalb des XAML-Codes kann im Resources-Abschnitt von `Window` die Klasse Person instanziiert werden. Den Eigenschaften des Objekts kann dabei bei Bedarf ein Anfangswert übergeben werden. Allerdings sind daran zwei Bedingungen geknüpft:

1. Damit die Klasse im XAML-Code instanziiert werden kann, muss sie einen parameterlosen Konstruktor haben.
2. Die Eigenschaften müssen als _Property_ geprägt sein, d. h. sie müssen einen _set_- und einen _get_-Accessor haben.

```XML
 <Window.Resources>
    <local:Person x:Key="myPerson" Name="John Doe" Wohnort="New York" Alter="35" />
</Window.Resources>
```

Um die Eigenschaften _Name_, _Wohnort_ und _Alter_ des Objekts jeweils an die  _Text_-Eigenschaft einer TextBox zu binden, ist, ein Binding-Objekt notwendig. Dabei beschreibt die Eigenschaft _Source_ des Binding-Objekts die Datenquelle. Mit einer verschachtelten Markup-Erweiterung unter Angabe von _StaticResource_ und dem Identifier kann die Ressource angesprochen und mit _Path_ an die gewünschte Eigenschaft des Person-Objekts gebunden werden. 

```XML
<StackPanel>
    <TextBox Text="{Binding Source={StaticResource myPerson}, Path=Name}" />
    <TextBox Text="{Binding Source={StaticResource myPerson}, Path=Wohnort}" />
    <TextBox Text="{Binding Source={StaticResource myPerson}, Path=Alter}" />
</StackPanel>
```

### Ein Objekt mit C#-Code erzeugen und binden 

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

Wiederum soll die Eigenschaft _Firstname_ des Objekts an die Eigenschaft _Text_ einer TextBox gebunden werden. Dies erfolgt wie gehabt im XAML-Code. 

```XML
 <StackPanel>
    <TextBox Text="{Binding Path=Name}" />
    <TextBox Text="{Binding Path=Wohnort}" />
    <TextBox Text="{Binding Path=Alter}" />
</StackPanel>
```

Als Resultat werden die Werte der Eigenschaften des _Person_-Objektes in den Textfeldern angezeigt.

![Bild 1](res/01.jpg)