# Data Binding

Kaum eine Anwendung kommt ohne Daten aus und so mancher Programmierer sieht sich mit der Herausforderung konfrontiert, wie die Daten durch GUI-Steuerelemente angezeigt werden sollen. 

Es gibt in der WPF zwei grundlegende Techniken, um einzelne Eigenschaften von Steuerelementen mit Informationen zu versorgen:  

* Werte direkt auf dem Objekt setzen
* Werte über Datenbindung setzen

Wenn wir mit C# direkt auf eine Eigenschaft eines Steuerelements zugreifen um deren Wert zu setzen, dann hat das den Nachteil einer grossen Abhängigkeit, die zwischen den Oberflächen-Elementen (XAML-Code) und der Logik (C#-Code) entsteht. 

Um den C#-Code unabhängig von der Oberfläche zu halten, können darum bei der WPF mittels _DataBinding_ öffentliche Eigenschaften von Objekten direkt im XAML-Code an einzelne UI-Elementen gebunden werden. So kann z.B. eine Eigenschaft eines Steuerelements verknüpft werden mit einer Information aus einem beliebigen Objekt. 

## Ein Data Binding mit XAML definieren

 Für die Definition einer Datenbindung gibt es eine  _Markup Extension_, namens _Binding_. Über diese wird u.a. festgelegt, welches das Quellelement sein soll und welche Information wir von der Quelle binden wollen. 

 In folgenden Beispiel ist das Ziel (Target) der Datenbindung die _Text_-Eigenschaft einer TextBox und die Quelle (Source) des Bindings ist die _Value_-Eigenschaft eines  anderen UI-Elements mit dem Namen "MyElement". 

```XML 
<TextBox Text="{Binding ElementName=MyElement, Path=Value}" />
```

## Ein Data Binding mit C# erzeugen 

Das Binding für das obstehende Beispiel kann natürlich auch mit C# erzeugt werden: 

```CSharp
Binding binding = new Binding();
binding.ElementName = sourceElem.Name; 
binging.Path = new PropertyPath("Value");
targetTxtBox.SetBindings(TextBox.TextProperty, binding);
```
## Mehr Informationen

Mehr und detaillierte Informationen zur Datenbindung in der WPF finden in der Microsoft-Dokumentation: [Übersicht über die Datenbindung](https://docs.microsoft.com/de-de/dotnet/framework/wpf/data/data-binding-overview)
