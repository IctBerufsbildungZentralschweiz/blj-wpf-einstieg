# Ressourcen 

## WORK IN PROGRESS

* Key-/Value-Liste 
* Oberste Ebene: App.xaml 
* Bereitstellung beliebiger Objekte (ich muss einfach jedem Objekt einen Key zuweisen)
* Einbindung über die Markup-Extensions {StaticResource} oder {DynamicResource} 




## Suche nach Resourcen

* zunächst beim Element selber, dann beim übergeordneten, dann beim übergeordneten, etc. etc. 
* wie ist es nun mit der Eindeutigkeit der Keys für Resourcen?
  * innerhalb eines Resourcen-Knotens muss der Key immer eindeutig sein, doch es können ja mehrere Resourcen-Knoten definiert sein (z.B. lokal für das Window oder anwendungsweit im App.xaml) 
    * hier gewinnt der erste


## DynamicResource vs. StaticResource 

* Unterschied wird erklärt ab Minute 19 im Video-Tutorial Kap2-Ressourcen.mp4