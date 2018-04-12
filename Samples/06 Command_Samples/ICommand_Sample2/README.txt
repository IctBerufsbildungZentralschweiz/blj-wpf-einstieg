
************************************************************
Das Porjekt zeigt die Verwendung der ICommand-Schnittstelle.
Datum: 21.03.2018
Autor: Urs Nussbaumer
************************************************************

Die ICommand-Schnittstelle ermöglicht im Zusammenspiel mit dem MVVM-Pattern 
das Binden von Commands an Steuerelemente. So kann auf RoutedEvents verzichtet 
werden, mit dem Nutzen, dass die Code-Behind-Datei frei von Code bleibt. So 
sinkt die Abhängigkeit von GUI und Logik auf null. 

Das Beispiel ist allerdings unschön, 
weil 
a) ein Hilfsklasse benötigt wird (UpDownTextItem) 
und 
b) das UpDownItem und der Command sich kennen müssen 
   (siehe Constructor der Klasse 'MainWindowViewModel')

Ein bessere und generische Lösung ist es, Commands mit Delegates auszustatten. 
--> siehe Projekt 04 DelegateCommand_Sample1 

