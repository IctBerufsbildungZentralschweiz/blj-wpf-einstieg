# Labels

Ein Label wird üblicherweise dazu verwendet, um TextBoxen mit einem Text zu kennzeichnen, damit der Benutzer weiss, was er in welche TextBox eingeben muss. Die _Focusable_-Property des Labels ist dabei per Default _false_, wodurch es selbst nicht fokussierbar ist. 

## Einen Access-Key definieren

Über ein Label kann ein Tastatur-Zugriffsschlüssel (auch als _Mnemonic_ oder _Access Key_ bezeichnet) definiert werden, indem seiner _Content_-Eigenschaft ein `String` zugewiesen wird und demjenigen Buchstaben des Strings, der als Zugriffsschlüssel dienen soll, ein Unterstrich vorangestellt wird. Drückt der Benutzer die {Alt}-Taste, wird der entsprechende Buchstabe unterstrichen anzeigt und weist den Benutzer so auf den hinterlegten Zugriffschlüssel hin. Klick der Benutzer zusätzlich den entsprechenden Buchstaben, wird der Fokus auf dasjenige UI-Element gelegt, das zum Label gehört. 

Um das UI-Element, das beim Betätigen des Access-Keys fokussiert werden soll, dem entsprechenden Label zuzuweisen, muss es der _Target_-Property des Lables zugewiesen werden. Dazu muss in XAML ein Data Binding eingerichtet werden. 

```xml
<Label Content="_Vorname" Target="{Binding ElementName=tbVorname}" />
<TextBox Name="tbVorname" Width="120" />
```

In C# wird dagegen kein Data Binding benötigt, da die Referenz auf ein Objekt typischerweise in einer Variablen gespeichert ist. Hier genügt es, die Variable der _Target_-Property direkt zuzuweisen. 

```csharp
TextBox tbVorname = new TextBox();
Label lbl = new Label();
lbl.Content = "_Vorname";
lbl.Target = tbVorname; 
```

Obwohl ein Label einen beliebigen Inhalt haben kann, ist es nur dann wirklich nützlich, wenn es einen String mit einem Zugriffsschlüssel enthält. 