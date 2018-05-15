# Bindungsprobleme und deren Lösungen

Beim Data Binding kann es dann zu Problemen kommen, wenn eine Eigenschaft, auf der eine Datenbindung aufsetzt, den Wert _null_ hat. Oder es wird aus einem anderen Grund ein Fehler ausgelöst. 

Es gibt zwei praktische Möglichkeiten, auf solche Fehlerszenarien beim Data Binding zu reagieren. 

* _TargetNullValue_ 
* _FallbackValue_

## TargetNullValue 

Der Wert, der der Eigenschaft _TargetNullValue_ zugewiesen ist, wird beim Binding verwendet, falls ein null-Wert gebunden wird. Im folgenden Beispiel also dann, wenn _FirstName_ null ist.  

```XML
<TextBox Text={Binding MyPerson.FirstName, Mode=TwoWay, TargetNullValue=unbekannt}" />
```

## FallbackValue 

Der _FallBackValue_ wird im Fehlerfall verwendet und wird durch das Binding angezeigt, statt dass ein Fehler geworfen wird. Im folgenden Beispiel also z.B. dann, wenn _MyPerson_ null ist. 

```XML
<TextBox Text={Binding MyPerson.FirstName, Mode=TwoWay, TargetNullValue=unbekannt, FallbackValue=keine Person vorhanden}" />
```