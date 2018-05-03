# UI-Elemente binden 

## Aufgabe 

Erstelle deine erste Elementbindung.

### Schritt 1

Erstelle eine WPF-Anwendung mit einem Fenster, auf dem du eine `TextBox` und eine `ListBox` platzierst. Die ListBox soll drei Items enthalten, die du direkt in XAML notierst (`ListBoxItem`), mit dem Content "Rot", "Grün", "Blau", sodass sich folgende Benutzerobefläche ergibt.

![Bild 1](res/01.jpg)

### Schritt 2 

Erstelle im XAML-Code ein Binding für die _Text_-Property der TextBox, , sodass die in der ListBox aisgewählte Farbe sofort in der TextBox angezeigt wird. Dazu wird als Datenquelle des Bindings der _Content_ des jeweils gerade ausgewählten Items der ListBox (_SelectedItem.Content_) benötigt. 

```xml 
<TextBox Text="{Binding ElementName=myListBox, Path=SelectedItem.Content}" />
```

## Zusatzaufgabe

Zusätzlich zum Text "Rot", "Grün" oder "Blau" soll auch der Hintergrund (_Background_) der TextBox entsprechend gefärbt werden. 
 
![Bild 2](res/02.jpg)