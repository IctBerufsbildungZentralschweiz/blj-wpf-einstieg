# ObservableCollection

Datenbindung ist ein sehr wichtiges Konzept der WPF und kann perfekt durch das einfache Interface `INotifyPropertyChanged` erreicht werden. Bei Klassen, die dieses Interface implementieren, aktualisieren sich Oberflächenelemente automatisch, sobald sich Werte in den gebundenen Objekten ändern. 

Um diese Technik auch für Listen zu nutzen, wird eine spezielle Collection benötigt: die `ObservableCollection<T>`.

## Hinzufügen und Löschen von Listen-Elementen 

Im vorherigen [Kapitel](../07%20Listen%20binden) wurden die  Mitarbeiter einer Firma an eine ListBox gebunden. Die Mitarbeiter vom Typ `Person` wurden dabei in einer Liste gespeichert. 

```CSharp 
public List<Person> Mitarbeiter { get; set; }
```

 Dies hat soweit gut funktioniert: die Mitarbeiter wurden in der ListBox angezeigt.
 
 Üblicherweise werden in einer Anwendung die Daten jedoch nicht nur angezeigt, sondern der Benutzer will z.B. neue Mitarbeiter hinzufügen sowie Mitarbeiter entfernen oder ersetzen. Im vorigen Kapitel wurde weder das eine noch das andere gemacht. Und es hätte auch nicht funktioniert; denn damit das Data Binding auch solche Änderungen mitbekommt, muss die Liste, in welcher die Mitarbeiter gespeichert werden, das Interface `INotifyCollectionChanged` implementieren. 

 Mit der generischen Collection-Klasse `ObservableCollection<T>` im Namespace _System.Collections.ObjectModel_ enthält die WPF bereits eine Klasse, welche das `INotifyCollectionChanged`-Interface implementiert. Damit GUI-Elemente, die an eine Liste gebunden sind, das Hinzufügen und das Löschen von Elementen mitkriegen, muss anstelle einer `List<T>` die `ObservableCollection<T>` (oder eine Ableitung davon) verwendet werden. 

```CSharp 
public ObservableCollection<Person> Mitarbeiter { get; set; }
```

Sobald Elemente zur Collection hinzugefügt oder aus der Collection entfernt werden, feuert diese das _CollectionChanged_-Event und benachrichtigt so die GUI-Elemente, die an die Liste gebunden sind. So kann z.B. ein Delete-Button direkt und einfach auf die Collection zugreifen und das Element entfernen. Das Benachrichtigen und Aktualisieren der View erledigt die die Collection respektive das Binding automatisch. 

