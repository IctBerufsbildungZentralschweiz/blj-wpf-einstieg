# Aus Klein mach Gross und zurück

## Aufgabe 

Erstelle eine WPF-Anwendung mit zwei Eingabefeldern, in die der Vorname respektive der Nachname einer Person eingegeben werden können. Platziere unterhalb der beiden  Eingabefelder ein _TextBlock_- oder ein _Label_-Element und sorge dafür, dass dort der volle Name der Person in GROSSSCHRIFT ausgegeben wird und zwar "live" während der Benutzer tippt.   

![Bild 1](res/01.jpg)

### Todo-Liste

- [ ] Das GUI (MainWindow) mit XAML erstellen/designen.
- [ ] Eine Klasse `Person` erstellen mit den Eigenschaften _FirstName_, _LastName_, _FullName_ und die `INotifyPropertyChanged` implementiert.
- [ ] `Person` als _DataContext_ des MainWindow setzen.
- [ ] Das Data Binding für die Eingabefelder einrichten: Vorname bindet auf die Property _FirstName_ der Klasse Person, Nachname auf die Property _LastName_ und das UI-Element, welches den vollen Namen anzeigt, bindet auf die Property _FullName_.
- [ ] Eine Klasse `UpperCaseConverter` programmieren, welche das Interface `IValueConverter` implementiert und die dazu  verwendet werden kann, einen Text in Grossbuchstaben umzuwandeln.
- [ ] Die Konverter-Klasse `UpperCaseConverter` im MainWindow als Ressource einbinden.
- [ ] Die Konverter-Klasse `UpperCaseConverter` gemäss Anfoderung verwenden.
