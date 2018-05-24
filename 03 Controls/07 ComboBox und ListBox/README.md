# Controls zur Auswahl von Elementen

Es gibt wohl kaum eine Anwendung, in der der Benutzer nichts auswählen können muss. In der WPF gibt es fünf Klassen, die eine Auswahl von Elementen ermöglichen.

* ComboBox 
* ListBox 
* ListView 
* TabControl 
* DataGrid 

Alle fünf Klassen erben direkt oder indirekt von der abstrakten Klasse `Selector` (Namespace: _System.Windows.Controls.Primitives_), die selbst direkt von `ItemsControl` abgeleitet ist. Die folgende Tabelle zeigt die wichtigsten Eigenschaften der Klasse `Selector`. 


| Property              | Beschreigung |
| --------------------- | ----------------------------------------------------------------------------------------------- |
| _SelectedItem_        | Gibt das aktuell selektierte Element zurück.                                                    | 
| _SelectedValue_       | Setzt oder gibt den Wert der mit _SelectedValuePath_ definierten Eigenschaft zurück.            | 
| _SelectedValuePath_   | Setzt oden Property-Path zu einer Property, die dann mit _SelectedValue_ abgefragt werden kann. |
| _SelectedIndex_       | Gibt den Index des aktuelle selektieren Objekts zurück. Falls keines selektiert ist: -1.        |

Die Klasse `Selector` besitzt zudem die Attached Property _Selector.IsSelected_, die auf einem Kindelement gesetzt werden kann, damit dieses selektiert wird. 

Ausserdem definiert `Selector` die Events _Selected_, _Unselected_ und _SelectionChanged_. 

In den folgenden Kapiteln sehen wir uns am Beispiel der Klassen `ComboBox` und `ListBox` an, wie diese Eigenschaften und Events verwendet werden.

* [01 ComboBox](01%20ComboBox)
* [02 ListBox](02%20ListBox)

