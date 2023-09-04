- Zápočtový program na NPRG031 Programování 2 2022/23
- Vedoucí cvičení: Mgr. Jiří Šejnoha
- Student: Vojtěch Venzara
- Program: Project Minotaur
---

## Programátorská dokumentace

### Zadání
Program zobrazuje rozdíl mezi různými algoritmy na generování bludiště. Následně zobrazuje vygenerované bludiště v aplikaci, aby si ho uživatel mohl projít.

### Algoritmy 
Program používá 5 algoritmů mezi, kterými si uživatel může vybrat.

1. Randomized depth-first search
	  Pomocí rekurze generuje bludiště. Začne s první buňkou, označí ji za navštívenou a následně náhodně vybere nenavštíveného souseda, pokud nějakého má, odebere zeď mezi nimi a rekurzivně se zavolá na souseda. 
2. Randomized Kruskal’s algorithm
	  Na začátku vytvoříme seznam stěn a set pro každou buňku obsahující právě tu buňku.
	  Poté náhodně budeme vybírat stěny ze seznamu dokud seznam nebude prázdný.
	  Pokud stěna odděluje dva různé sety buněk, tak jí odstraníme a sety spojíme.	  
3. Randomized Prim’s algorithm
	  Nejprve všechny buňky nastavíme jako stěny a poté náhodně vybereme startovní buňku, kterou přidáme do seznamu nenavštívených buněk. 
	  Dokud tento seznam není prázdný:
	  Vybereme náhodnou buňku ze seznamu, označíme ji jako navštívenou a přidáme všechny její nenavštívené sousedy do seznamu nenavštívených buněk. Pokud buňka měla nějaké již navštívené sousedy, tak mezi nimi náhodně vybereme a odstraníme zeď mezi vybranou buňkou a naší buňkou
4. Wilson’s algorithm
	  Na začátku určíme náhodnou buňku jako součást bludiště. Poté z další náhodně zvolené buňky se snažíme dostat na buňku, která je již součástí bludiště. Jakmile, ale při hledání cesty, narazíme na svoji vlastní cestu, tedy vytvoříme smyčku, vymažeme celou smyčku a pokračujeme v generování. Jakmile narazíme na buňku která je součástí bludiště přidáme celou cestu do bludiště a zvolíme další bod odkud začneme tvořit cestu. Takto pokračujeme dokud nepokryjeme celé bludiště. 
5. Tesselation
	  Na startu máme jeden chunk v bludišti, který třikrát nakopírujeme kolem sebe a následně náhodně vytvoříme 3 cesty mezi 4 menšími nakopírovanými chunky. Tímto získáme bludiště 2 větší, něž jsme měli na začátku a můžeme tento proces opakovat než získáme bludiště dané velikosti.
	  Omezením algoritmu je, že umí generovat jen bludiště o velikosti mocnin dvojky.


### Program

Program je naprogramován v jazyce C# a používá prostředí Windows Form, převážně kvůli potřebě pro grafické prostředí na zobrazování bludiště.

Program se skládá ze 4 hlavních částí
- Algoritmů pro generování bludiště
- Generování bludiště
- Zobrazování bludiště
- Interakce uživatele s bludištěm

**Algoritmy pro generování bludiště**
Všechny naprogramované algoritmy dědí základní strukturu z abstraktní classy *MazeGeneretingAlgoritm*.
Ta obsahuje základní funkce, které dědí všechny její potomci:
- Construktor()
- ValidSize()
- ToString()
- GenerateMaze()
	 Tuto funkci si každý Algoritmus upravuje podle toho jak bylo napsáno výše.
- StartingConfiguration()
- IsInBoundaries()

**Generování bludiště**
O generování bludiště se stará classa MazeManager. Proces generování začne poté co uživatel zvolí parametry pro generaci a stiskne tlačítko.  Po té proběhne kontrola velikosti bludiště, zda je vhodná pro daný algoritmus, pomocí metody `ValidSize()` a případně se upraví velikost bludiště. Poté se zavolá metoda `GenerateMaze()`, která vrátí bludiště jako 2D pole bool, hodnota true značí stěnu a false značí volné místo. Toto pole se poté předá do metody `CreateMazeFromMap()` z classy GraphicsManager, která ho zobrazí.

**Zobrazení bludiště**
Bludiště se zobrazuje pomocí metod z classy *GraphicsManager*. Bludiště se zobrazuje na Picture Box jako obrázek a aktualizuje se každých 15 ms pomocí metody `Update`.  Nejdůležitější funkcí je zde `CreateMazeFromMap()` té je předáno bludiště jako 2D pole bool a ona zobrazí do obrazu.
Nejdříve vytvoří základ pro bludiště pomocí `CreateMazeBase()`. Zde se vypočítá kolik pixelů mají být široké zdi a hráč, aby dobře pokryli plochu Picture Boxu. Dále vytvoří ohraničení bludiště. Poté projdeme pole a za každou hodnotu true přidáme stěnu na její pozici metodou `AddWallPiece()`.

**Interakce uživatele s bludištěm**
Uživatel může procházet bludiště svým hráčem, který se po generování bludiště nachází vždy v levém horním rohu a snaží se dostat do cíle v pravém dolním rohu. Pohyb je možný pomocí kláves WSAD. 
Hráč je ovládán pomocí classy *PlayerControler*. Z formuláře je mu vždy předána stisknutá klávesa, která rozhodne kam se hráč pohne. Hráč zkontroluje metodou `IsFree()` z classy *Maze manager* zda je pozice, na kterou se chce pohnout volná a pokud ano, tak změní pozici. Svoji zobrazovanou pozici pak změní metodou `ChangePlayerPosition()` z classy *Graphics Manager*. Po každém pohybu také zkontroluje zda nevyhrál.




