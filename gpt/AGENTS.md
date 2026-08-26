# GPT Notes Instructions

Ten folder jest inboxem na notatki i zrzuty generowane z rozmów w ChatGPT Web.

## Przeznaczenie

- zapisywanie podsumowań rozmów jako Markdown (`.md`),
- odkładanie wniosków, researchu i roboczych notatek z ChatGPT,
- tworzenie nowych notatek bez ręcznego kopiowania treści z czatu,
- późniejsze przeglądanie, linkowanie i porządkowanie ich w Obsidianie,
- synchronizacja zmian przez Git.

## Skrót: `save md`

Gdy użytkownik napisze dokładnie `save md` lub użyje tego zwrotu jako polecenia, traktuj to jako żądanie zapisania bieżącej rozmowy do notatek.

Domyślne zachowanie:

1. Wyciągnij z bieżącej rozmowy najważniejsze informacje, decyzje, wnioski, przykłady i ustalenia.
2. Nie zapisuj całego czatu 1:1. Utwórz uporządkowaną, samodzielną notatkę, którą da się później zrozumieć bez czytania rozmowy.
3. Usuń zbędne powtórzenia, dygresje i elementy czysto konwersacyjne.
4. Dobierz sensowny, krótki tytuł notatki na podstawie głównego tematu rozmowy.
5. Na podstawie tytułu utwórz czytelną nazwę pliku `.md`.
6. Jeśli użytkownik nie wskazał innej lokalizacji, zapisz nowy plik do `gpt/` w repozytorium `kcich369/files` na gałęzi `main`.
7. Jeśli odpowiednia notatka już istnieje i użytkownik wyraźnie chce ją uzupełnić, najpierw ją odczytaj i dopiero potem zaktualizuj bez duplikowania treści.
8. Jeśli polecenie dotyczy tylko utworzenia zrzutu, nie modyfikuj żadnych innych plików.
9. Po zapisie krótko podaj nazwę utworzonego lub zaktualizowanego pliku oraz potwierdź wykonanie.

Przykłady:

- `save md` → automatycznie nazwij i zapisz podsumowanie bieżącej rozmowy w `gpt/`.
- `save md jako neo4j-poc` → zapisz jako `gpt/neo4j-poc.md`.
- `save md do Graphs/Neo4j.md` → zapisz lub, jeśli użytkownik tego oczekuje, zaktualizuj wskazaną notatkę.

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
2. Użytkownik wpisuje `save md` albo prosi o zapisanie wniosków lub podsumowania do notatek.
3. AI tworzy nowy plik `.md` w `gpt/` albo aktualizuje konkretny plik wskazany przez użytkownika.
4. Zmiana trafia do Git.
5. Obsidian pobiera ją przez synchronizację i udostępnia jak zwykłą notatkę.

## Ważna zasada

AI ma pomagać w zapisywaniu i porządkowaniu wiedzy, ale użytkownik zachowuje kontrolę nad tym, które pliki są tworzone lub modyfikowane.
