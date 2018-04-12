# Dependency Properties 

Dependency Properties ähneln normalen .NET Eigenschaften, jedoch ist das Konzept dahinter komplexer und mächtiger. Dependency Properties können nur in Klassen definiert werden, die von der Klasse `DependencyObject` abgeleitet sind. Der Hautpunterschied ist, dass der Wert einer normalen .NET Property direkt aus einer privaten Member-Variablen deiner Klasse gelesen wird, wohingegen der Wert einer Dependency Property dynamisch ermittelt wird durch Aufruf der Methode _GetValue()_, die von der Klasse `DependencyObject` geerbt wird.

Wenn der Wert für eine Dependency Property gesetzt wird, dann wird dieser nicht in einem privaten Feld deines Objektes gespeichert, sondern in einem Dictionary (mit Keys und Values). Dieses Dictionary wird von der Basisklasse  `DependencyObject` zur Verfügung gestellt und verwaltet. Dabei ist der _Key_ eines Eintrages der Name der Property und der _Value_ ist der Wert der Property.

## Work in Progress 

TODO: weiterer Input ggf. von hier: 
* https://www.wpftutorial.net/DependencyProperties.html
* http://openbook.rheinwerk-verlag.de/visual_csharp_2012/1997_26_003.html
* http://www.codemag.com/Article/1405061/XAML-Magic--Attached-Properties 


