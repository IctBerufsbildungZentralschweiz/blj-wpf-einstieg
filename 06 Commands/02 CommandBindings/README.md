# CommandBindings  

Hinter einem WPF-Command steckt Programmlogik. Textboxen sind bereits so ausgestattet, dass sie mit den Commands _Copy_, _Cut_, _Paste_, und auch mit _Redo_ und _Undo_ umgehen können. Klickt der Anwender auf eine Schaltfläche oder ein Menüelement, wird der Befehl automatisch ausgeführt und von der TextBox behandelt, die in diesem Moment den Fokus hat. Bei diesen Operationen handelt es sich um Standardoperationen, die auf dem fokussierten Steuerelement ausgeführt werden. 

Andere Befehle wie bspw. _Open_ oder _New_ kennen solche allgemeingültigen Operationen nicht. Daher bieten diese Commands keine Programmlogik an. Diese muss der Programmierer selbst schreiben. Und dazu sind Befehlsbindungen (`CommandBindings`) notwendig, die im folgenden erklärt werden. 

## Command-Bindungen einrichten 

Wie wir schon im vorigen Kapitel gesehen haben, haben Command-fähige UI-Elemente die Eigenschaft _Command_, über die das Element mit einem Command verbunden werden kann. 

```XML
 <Button Command="Help" Content="Hilfe" />
```

Obwohl der Button im obigen Beispiel mit dem _Help_-Befehl verknüpft ist, wird der Anwender den Button nicht nutzen können, da er zu diesem Zeitpunkt deaktiviert (disabled) ist. Der Grund dafür ist, _Help_ einer jener vordefinierten Befehle ist, für die (noch) keine Programmlogik implementiert ist. 

Es muss daher ein Ereignishandler implementieren werden, der auf den Command _ApplicationCommands.Help_ reagiert. Dazu ist eine Instanz der Klasse `CommandBinding` erforderlich. 

Da innerhalb eines Windows in der Regel mehr als ein Command benötigt wird, werden die Commands in der `CommandBindings`-Collection zusammengefasst. Diese Collection wird mit dem `Window` verknüpft. 

```XML
<Window.CommandBindings>
    <CommandBinding Command="Help" CanExecute="Help_CanExecute" Executed="Help_Executed" />
</Window.CommandBindings>
```

### Die Events _Executed_ und _CanExecute_

_Executed_ und _CanExecute_ sind zwei Events des `CommandBinding`-Objekts. _Executed_ wird ausgelöst, wenn auf des betreffende Element gelickt wird. In diesem Event-Handler wird also die Programmlogik des Commands implementiert.

```CSharp
 private void Help_Executed(object sender, ExecutedRoutedEventArgs e)
{
    MessageBox.Show("Help executed.");
}
```

_CanExecute_ wird von einem Element ausgelöst, um zu prüfen, ob der gebundene Command ausgeführt werden darf/kann. In diesem Event-Handler erfolgt i.d.R. die Überprüfung einer Bedingung, die feststellt, ob die mit dem Command verknüpften Controls aktiviert oder deaktiviert werden sollen. 

Um den Button zu aktivieren, muss im _CanExecute_ Event-Handler  die Eigenschaft _CanExecute_ des `CanExecuteEventArgs`-Parameters auf _true_ gesetzt werden. 

```CSharp
private void Help_CanExecute(object sender, CanExecuteRoutedEventArgs e)
{
     e.CanExecute = true;
}
```
## Lokalität der Command-Bindung 

Die Bindung von Commands muss nicht zwingend an das `Window` geknüpft sein. Denn die  Eigenschaft `CommandBindings` besitzen alle Elemente, die entweder von `UIElement`, `UIElement3D` oder `ContentElement` abgeleitet sind. Dazu gehört z.B. auch die Klasse `Button`. Folglich kann die Befehlsbindung auch am Button selbst erfolgen: 

```XML
<Button Command="ApplicationCommands.Help">
    <Button.CommandBindings>
        <CommandBinding Command="Help" CanExecute="Help_CanExecute" Executed="Help_Executed" />
    <Button.CommandBindings>
</Button>
```

Andere UI-Elemente, die sich ebenfalls mit dem _Help_-Befehl verknüpfen, können  diese Befehlsbindung dann allerdings nicht nutzen, da sie so exklusiv für den Button reserviert ist. 

## Zusätzliche Daten bereitstellen mit _CommandParameter_ 

UI-Elemente, die ein WPF-Command abonnieren, implementieren die Schnittstelle `ICommandSource`. Das Interface schreibt u.a. auch die Eigenschaft _CommandParameter_ vor. _CommandParameter_ dient dazu, dem Event-Handler zusätzliche Daten zu übermitteln. Die Eigenschaft ist vom Typ Object. 

```XML
<Window.CommandBindings>
    <CommandBinding Command="Help" CanExecute="Help_CanExecute" Executed="Help_Executed" />
</Window.CommandBindings>
 <Button Command="ApplicationCommands.Help" CommandParameter="Guten Morgen, liebe Sorgen."  Content="Hilfe" />
```

Entgegengenommen wird das Objekt im `ExecutedRoutedEventArgs`-Parameter des Ereignishandlers. 

```CSharp 
private void Help_Executed(object sender, ExecutedRoutedEventArgs e) 
{
    MessageBox.Show(e.Parameter.ToString());
}
```

## Benutzerdefinierte Commands 

Es sei darauf hingewiesen, dass die bisher verwendete (Kurz-)Form der Command-Registrierung nur im Zusammenhang mit vordefinierten WPF-Commands benutzt werden kann. Für benutzerdefinierte Commands muss folgende Syntax verwenden.

```XML
<Button Command="{x:Static MyUserdefinedCommands.DoIt}" Content="Klick mich" />
```

Dazu später mehr.