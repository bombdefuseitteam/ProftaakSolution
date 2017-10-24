## Forms
- Init.cs: Initializes StartForm.cs
- StartForm.cs: Is het StartScherm vanuit deze Form kan men door middel van de Start Game button naar ControlForm.cs gaan.
- ControlForm.cs: Control scherm, initializes connection met de TCP server en stuurt controller output naar de server indien er een kleur gedecteerd wordt wordt het KeuzeForm/EndForm aangeroepen.
- KeuzeForm.cs: Het Trivia Menu, randomized vraag via SQL + antwoorden, gebruiker kan door middel van de controller een antwoord. kiezen en krijgt score indien het antwoord goed is.
- [ToDo] EndForm.cs: Het EindMenu hier kan de gebruiker zijn naam submitten en de score opsturen.

## Etc
- XInput > Gamepad.cs: Checkt controller connectie en luisterd naar de controller voor input/output.
- Sockets > SocketConnection.cs: Maakt de connectie naar de TCP server en stuurd de gamepad informatie er naar toe.
- GameEvents > ScoreManager.cs: Houdt de score van de gebruiker bij.
- [ToDO] SQL > SQLConnection.cs: Houdt de SQL connectie staande

## Dependencies
- Firefox 57
- Windows 8+
