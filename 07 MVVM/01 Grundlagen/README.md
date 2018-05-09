# Das Model-View-ViewModel Pattern (MVVM)

> Model-View-ViewModel (MVVM) ist ein Entwurfsmuster und eine moderne Variante des Model-View-Controller Pattern (MVC). MVVM  dient der Trennung von Darstellung und Logik der Benutzerschnittstelle (UI). Es zielt auf moderne UI-Plattformen wie Windows Presentation Foundation (WPF), JavaFX und HTML5 ab, da ein Datenbindungsmechanismus erforderlich ist. Gegenüber dem MVC-Muster kann die Testbarkeit verbessert und der Implementierungsaufwand reduziert werden, da keine separaten Controller-Instanzen erforderlich sind. MVVM erlaubt ausserdem eine Rollentrennung von UI-Designern und Entwicklern, wodurch Anwendungsschichten von verschiedenen Arbeitsgruppen entwickelt werden können. 

[Wikipedia](https://de.wikipedia.org/wiki/Model_View_ViewModel)

## Datenbindung 

Das MVVM-Muster kann als technologie-spezifisch bezeichnet werden, da für die lose Kopplung von View und ViewModel ein Datenbindungsmechanismus benötigt wird. Diese Infrastruktur wird häufig als _Binding_ oder _Binder_ bezeichnet. Im Detail handelt es sich hierbei um einen bidirektionalen Einsatz des Beobachter-Musters.

## Komponenten 

Die Abbildung zeigt die MVVM-Komponenten und deren Abhängigkeiten. Das ViewModel kennt das Model, aber nicht die View. Die View kennt das ViewModel. Das Model kennt weder die View noch das ViewModel. 

![Bild 1](res/01.png)

### View 

Die View beinhaltet alle grafischen Elemente der Benutzeroberfläche (UI). Die GUI-Elemente binden sich dabei an Eigenschaften des ViewModel, um ihre Inhalte darzustellen und um Benutzereingaben weiterzuleiten. Damit ist die View einfach austauschbar und ihr Code-Behind gering. 

In WPF wird die View deklarativ durch XAML definiert.

### ViewModel 

Das ViewModel ist das Bindeglied zwischen View und Model. Es beinhaltet die UI-Logik und stellt alle Informationen bereit, die von der View benötigt werden. Dazu gehören die Daten des Models und auch UI-nahe Informationen, wie zum Beispiel ob ein Button ausgegraut (disabled) ist oder nicht. 

ViewModel-Klassen sollten so implementiert werden, dass sie sich auch ohne die View instantiieren und damit einfach testen lassen. Das heisst, ein ViewModel hat keine Kenntnis der View.

### Model 

Das Datenmodell respektive die Datenzugriffsschicht, welche die Daten kapselt. Üblicherweise sind das Klassen, die lediglich Daten enthalten. 


<!-- 
Einführungstext ggf. auch vom Rheinwerk-Ebook nehmen: http://openbook.rheinwerk-verlag.de/visual_csharp_2012/1997_28_005.html#dodtpa8342005-172b-4576-8718-22adb0bcac1e

Bei WPF gibt es wie beim Vorgänger WindowsForms die Möglichkeit, C#-Code in einer Code-Behind-Datei zu schreiben. Zum Beispiele die Implementation von Event-Handlern. Auf diese Weise  wird eine Trennung von XAML-Code für die Darstellung der Benutzeroberfläche und C#-Code für die Funktionalität erreicht. Diese Trennung von View und Logik ist schon mal gut, aber bei weitem noch nicht perfekt; denn die Abhängigkeiten zwischen GUI und einzelnen Logikkomponenten bleibt und die Testbarkeit ist nicht optimal. Das MVVM-Entwurfsmuster reduziert diese Abhängigkeiten deutlich. Das sieht man daran, dass die Model-Klassen nichts vom ViewModel wissen (müssen) und das ViewModel selbst weiss nichts von der View. Und wer sich nicht kennt, hat auch keine Abhängigkeiten zueinander. 


Input von hier: https://www.codeproject.com/Articles/1052346/ICommand-Interface-in-WPF

if we are using MVVM Pattern then generally we should not write code in code-behind files. So we cannot use RoutedEvents because RoutedEvents are not accessible in ViewModels. That is why we have to use Commands to execute desired code block written in ViewModel. Thus Commands provides glue between View and ViewModel for interactivity.



# ViewModel einbinden 

```xml
<Window  xmlns:vm="clr-namespace:TextBox_und_ListBox_MVVM.ViewModels" >

<Window.Resources>
    <vm:MainWindowViewModel x:Key="viewModel" />
</Window.Resources>

</Window>
```

und dann: 
1. Grid (Hauptlayout-Container oder alternativ: das Window) mit Maus markieren 
2. Im Eigenschaftenfenster: > Common > DataContext > Default > Create DataBinding > StaticResource 

-->