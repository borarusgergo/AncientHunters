# Modern szoftverfejlesztési eszközök (GKNB_INTM006) 2024/25 1.Félév

---

## Ancient Hunters

### A játék rövid leírása

A játékosnak egy űrhajóval kell legyőznie az ellenséges hajókat 3 különböző pályán.

## Történetleírás

2077-ben járunk, amikor is már a Föld pusztulásnak indult. Az emberiség felfedezte, hogy egy rég elfeledett civilizáció titokzatos technológiát hagyott hátra az univerzum különböző bolygóin, amely képes lehet megfordítani az időt és megállítani a föld pusztulását. A főhősünk Orion Ventaris. Őt bízták meg ezzel a feladattal, hogy találja meg ezt az idegen technológiát. A Vándorfény nevű űrhajóval indul neki viszont nincs a legtökéletesebb állapotban, de egy elit csapat segíti a főhősünket, akiknek az idővel kell versenyt futniuk. 
Az út során a csapatnak több bolygón  kell áthaladnia, ahol különböző kihívások várnak rájuk. Elsőként a Zhurak nevű sivatagos planétán landolnak, ahol a romok között ősi gépezetek várnak rájuk. A csapat elkezdi kutatni, ám az egyik katona véletlenül aktiválja az ősi védelmi rendszert és egy heves csata alakul ki az automata robotokkal. Itt találják meg az idegen technológia első darabját.
A következő célpont a Kryos, egy jéggel borított bolygó, ahol egy hatalmas föld alatti bázison rejtőzik a második darab. Azonban amikor megérkeznek, szembetalálják magukat egy rivális emberi flottával, a Void Syndicate nevű zsoldosokkal, akik szintén meg akarják szerezni az ősi erőt csak hogy ők nem a Föld pusztulását akarják megakadályozni.. A jeges mezőkön kirobbanó intenzív űrharcban Ventaris és csapata mindent belead, és a Vándorfény gyors manőverezésének köszönhetően végül sikeresen elhárítják a zsoldosok támadását és a második darabot is megkaparintják.
Az utolsó állomás a Vespera, egy dzsungel borította, élő bolygó, ahol az ősi technológia szinte eggyé vált a természettel. Itt a csapatnak nem csak a bolygó ragadozóival és veszélyes környezetével kell megküzdenie, hanem az idegen lényekkel is találkoznak akik ezt a technológiát megalkották. Az utolsó nagy csatában Ventaris szembenéz az idegenek vezérével, miközben a bolygó is ellenük fordul. 
Miután legyőzik az ellenséget és megszerzik az utolsó darabot, visszatérnek a Földre, de a csapat tudja: az igazi harc még csak most kezdődik, amikor a technológiát aktiválni kell, hogy megmentsék a Földet a közelgő végzet elől.

---

## A játék működése

A játkos a main menűből elindítja a játékot és betölti az első pályát. Ha legyőzte az összes ellenséget akkor a következő pályát betölti. Ha az ellenségek megölik a játékost akkor vége a játéknak és kezdheti elölről.

## Technikai Specifikációk

### A játék által kezelt könyvtár

A program a játék pályáit JSON fájlban tárolja ami Unity-ben egyszerűen betölthető a JsonUtility segítségével.

### Tesztesetek

A megírt tesztesetek az Assets\Tests\EditMode és a PlayMode mappában találhatók.

