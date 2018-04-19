# DataBinding

Kaum eine Anwendung kommt ohne Daten aus und jeder Programmierer sieht sich mit der Herausforderung konfrontiert, wie Daten durch GUI-Steuerelemente   angezeigt werden sollen und wie durch den Benutzer geänderte Daten zurück zur Datenquelle gelangen. 

Es gibt in der WPF zwei grundlegende Techniken, um einzelne Eigenschaften von Steuerelementen mit Informationen zu versorgen:  

* Werte direkt auf dem Objekt setzen
* Werte über Datenbindung setzen

Wenn wir mit C# direkt auf eine Eigenschaft eines Steuerelements zugreifen um deren Wert zu setzen, dann hat das den Nachteil einer grossen Abhängigkeit, die zwischen den Oberflächen-Elementen (XAML-Code) und der Logik (C#-Code) ensteht. 

Um den C#-Code unabhängig von der Oberfläche zu halten, können die öffentlichen Eigenschaften von Objekten direkt im XAML-Code an einzelne UI-Elementen gebunden werden. So kann z.B. eine Eigenschaft eines Steuerelements verknüpft werden mit einer Information aus einem beliebigen Objekt. 

## Ein DataBinding mit XAML definieren

 Für die Definition einer Datenbindung gibt es eine  _Markup Extension_, namens _Binding_. Über diese wird u.a. festgelegt, welches das Quellelement sein soll und welche Information wir von der Quelle haben wollen. 

```XML 
<TextBox Text="{Binding ElementName=MyElement, Path=Value}" />
```

In diesem Beispiel ist Ziel (Target) der Datenbindung die _Text_-Eigenschaft einer TextBox und die Quelle (Source) des Bindings ist die _Value_-Eigenschaft eines  anderen UI-Elements mit dem Namen "MyElement". 

## Ein DataBinding mit C# erzeugen 

Das Data Binding für das Beispiel oben kann auch mit C# erzeigt werden: 

```CSharp
Binding binding = new Binding();
binding.ElementName = sourceElem.Name; 
binging.Path = new PropertyPath("Value");
targetTxtBox.SetBindings(TextBox.TextProperty, binding);
```

