# Wypożyczalnia Sprzętu - Projekt APBD

## Uruchomienie
Aplikacja jest konsolowa. Aby ją uruchomić, wystarczy skompilować projekt i uruchomić plik Program.cs.

## Decyzje projektowe i Architektura
1. **Separacja odpowiedzialności i Kohezja:** Kod został podzielony na warstwy `Models` oraz `Services`. Modele przechowują wyłącznie stan, a logika wypożyczeń, sprawdzania limitów i kar znajduje się w jednej klasie `RentalService`.
2. **Niskie sprzężenie (Coupling):** Serwis `RentalService` przyjmuje jako argumenty klasy bazowe (`User`, `Equipment`), co pozwala na łatwe dodawanie nowych typów sprzętu bez modyfikacji logiki biznesowej.
3. **Dziedziczenie:** Zastosowano polimorfizm dla modeli `Equipment` i `User`, aby współdzielić unikalne ID oraz statusy.