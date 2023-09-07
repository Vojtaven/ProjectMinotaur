# Project Minotaur

---

Project Minotaur je zápočtový program na předmět Programování 2 NPRG031.
Tento program má ukázat rozdíly mezi různými algoritmy pro generování bludiště.
Program byl naprogramován v jazyce C# za pomocí Windows Forms

### Implementované algoritmy
- Randomized Prim algorithm
- Tessellation algorithm
- Randomized depth-first search algorithm
- Randomized Kruskal algorithm
- Wilson

---

## GUI

GUI je rozděleno na dvě části. Veprostřed se na nachází samotná plocha pro zobrazení bludiště a vlevo se nachází nastavení pro generování bludiště. Aplikace se po spuštění automaticky zobrazí přes celou obrazovku s prázdnou plochou bludiště.

### Nastavení
- Výběr algoritmu
	- Uživatel může vybírat z algoritmů, které se ukáží po kliknutí v dropdown menu.
- Velikost bludiště
	- Uživatel může zadávat jakoukoliv hodnotu v rozsahu 3 až 500. Některé algoritmy mají specifické nároky na velikost. Pokud tedy po stisknutí tlačítka Generovat nebude hodnota dobrá pro vybraný algoritmus, budou uživateli zobrazeny dvě nebo jedna hodnota, kterou může odsouhlasit.
- Tlačítko pro vygenerování bludiště
	- Tímto tlačítkem se zahájí generace bludiště.
- Tlačítko pro uložení bludiště
	- Tímto tlačítkem se uloží momentálně zobrazované bludiště do souboru.

## Pohyb
Po vygenerování bludiště bude v levém horním rohu bludiště zobrazen hráč (zelený čtvereček ), kterým pomocí WSAD může uživatel pohybovat. Cílem je dostat se na žluté políčko v pravém dolním rohu.









