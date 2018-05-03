# Elementbindung (UI-Elemente als Quelle)

 Bei der Elementbindung wird die Eigenschaft eines UI-Elements an die Eigenschaft eines anderen UI-Elements gebunden. Dies passiert über die Eigenschaft _ElementName_. Dazu müssen  wir der Datenquelle einen Namen geben und können dann beim Ziel-Element das Binding einrichten. 
 
Im folgenden Beispiel wird der aktuelle Wert eines Sliders (Quelle) an eine TextBox gebunden (Ziel). Über die Eigenschaft _Path_ wird definiert, welche Eigenschaft der Quelle "angezapft" werden soll. Die angezapfte Eigenschaft muss dabei  **immer** eine öffentliche (public) Eigenschaft sein, mit Getter und Setter. 

 ```XML 
<StackPanel>
    <Slider Name="mySlider" />
    <TextBox Text="{Binding ElementName=mySlider, Path=Value}" />
</StackPanel>
```

Als Resultat dieses Bindings sehen wir sofort eine Änderung in der TextBox, wenn der Slider verschoben wird, siehe Video:

* [![Video](http://img.youtube.com/0.jpg)](res/video01.mp4 "Video") 