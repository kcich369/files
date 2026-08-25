# GPT Notes Instructions

Ten folder jest inboxem na notatki i zrzuty generowane z rozmów w ChatGPT Web.

## Przeznaczenie

- zapisywanie podsumowań rozmów jako Markdown (`.md`),
- odkładanie wniosków, researchu i roboczych notatek z ChatGPT,
- tworzenie nowych notatek bez ręcznego kopiowania treści z czatu,
- późniejsze przeglądanie, linkowanie i porządkowanie ich w Obsidianie,
- synchronizacja zmian przez Git.

## Domyślne zasady dla AI

1. Domyślnie zapisuj treść po polsku, chyba że użytkownik poprosi inaczej.
2. Używaj formatu Markdown i czytelnej struktury nagłówków.
3. Zachowuj sens rozmowy, ale usuwaj zbędne powtórzenia i dygresje.
4. Nazwy plików powinny jasno opisywać temat.
5. Jeśli użytkownik nie wskaże konkretnego miejsca docelowego, nowe zrzuty z ChatGPT zapisuj w tym folderze.
6. Jeśli istnieje już odpowiednia notatka i użytkownik prosi o jej aktualizację, najpierw odczytaj jej aktualną zawartość i unikaj duplikowania informacji.
7. Nie modyfikuj innych notatek ani folderów bez wyraźnej prośby użytkownika.
8. Nie wykonuj masowych zmian w repozytorium bez jednoznacznej zgody użytkownika.
9. Przy aktualizacji istniejącego pliku zachowuj jego dotychczasowy styl i strukturę, o ile użytkownik nie poprosi o ich zmianę.

## Typowy workflow

1. Użytkownik prowadzi rozmowę lub research w ChatGPT.
2. Użytkownik prosi o zapisanie wniosków lub podsumowania do notatek.
3. AI tworzy nowy plik `.md` w `gpt/` albo aktualizuje konkretny plik wskazany przez użytkownika.
4. Zmiana trafia do Git.
5. Obsidian pobiera ją przez synchronizację i udostępnia jak zwykłą notatkę.

## Ważna zasada

AI ma pomagać w zapisywaniu i porządkowaniu wiedzy, ale użytkownik zachowuje kontrolę nad tym, które pliki są tworzone lub modyfikowane.
