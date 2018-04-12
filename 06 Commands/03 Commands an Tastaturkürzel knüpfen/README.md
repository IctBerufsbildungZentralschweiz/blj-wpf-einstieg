# Befehle über Tastaturkürzel aufrufen

In Windows-Anwendungen sind häufig bestimmte Befehle mit Tastenkombinationen ausführbar. Zum Beispiel die Taste `Esc`, um eine laufende Aktion abzubrechen oder ein Fenster zu schliessen. 

WPF gestattet es, einen Command entweder mit einer Taste bzw. Tastenkombination auszuführen oder durch Betätigung Maus. 

## Die Klassen `KeyBinding` und `MouseBinding`

Um zum Beispiel die Tastenkombination Alt + F10 mit dem Befehl Help zu verbinden, genügt der folgende XAML-Code.

```XML
<KeyBinding Key="F10" Modifiers="Alt" Command="ApplicationCommands.Help" />
```

Der Eigenschaft _Key_ wird ein Member der [`Key`-Enumeration](https://msdn.microsoft.com/en-us/library/system.windows.input.key(v=vs.110).aspx) übergeben. _Modifiers_ gibt die Modifiziertaste an, die der Enumeration [ModifierKeys](https://msdn.microsoft.com/de-de/library/system.windows.input.modifierkeys(v=vs.110).aspx) entstammt. 

Sehr ähnlich können Mausaktionen mit einem Command verknüpft werden. 

```XML 
<MouseBinding Gesture="Alt+RightClick" Command="ApplicationCommands.Help" />
```
Hier wird der _Help_-Command ausgeführt, wenn beim Klicken auf die rechte Maustaste gleichzeitig die `Alt`-Taste gedrückt ist. In der [`MouseAction`-Enumeration](https://msdn.microsoft.com/de-de/library/system.windows.input.mouseaction(v=vs.110).aspx) sind die möglichen Mausaktionen beschrieben, die sich wiederum mit einer Modifizierertaste kombinieren lassen und der Eigenschaft _Gesture_ zugewiesen werden. 

Die Zuordnungen für Tastaturkürzel und Mausaktionen werden in der `InputBindingsCollection` zusammengefasst. Diese Collection wird am besten dem `Window` zugeordnet. 

```XML
<Window.CommandBindings>
    <CommandBinding Command="ApplicationCommands.Help" CanExecute="Help_CanExecute" Executed="Help_Executed" />
</Window.CommandBindings>

<Window.InputBindings> 
    <!-- Help-Befehl an die Tastenkombination {Alt}+{F10} knüpfen -->
    <KeyBinding Key="F10" Modifiers="Alt" Command="ApplicationCommands.Help" />
    <!-- Help-Befehl an eine Mausaktion knüpfen {Alt}+{rechte Maustaste}  -->
    <MouseBinding Gesture="Alt+RightClick" Command="ApplicationCommands.Help"  />
</Window.InputBindings>
```
