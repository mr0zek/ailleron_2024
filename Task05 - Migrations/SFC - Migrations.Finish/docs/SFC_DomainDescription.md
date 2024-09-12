# Opis
W związku z rosnącym poziomem SMOGu w Polsce rozpoczynasz projekt który ma pomóc ludności w walce z tym zagrożeniem.

Celem jest realizacja aplikacji która zbiera informacje o poziomu smogu i ostrzegania użytkowników o przekroczonych progach zanieczyszczenia.
Głównymi aspektami jest:
- monitorowanie poziomów zanieczyszczeń w powietrzu z ogólnopolskiej sieci czujników jak i pobieranie danych z baz publicznych 
- informowanie o przekroczeniu dopuszczalnych poziomów po tym jak użytkownik zarejestruje czujkę monitorującą dany obszar.

# Funkcjonalności:

## Rejestracja użytkownika:
Aplikacja pozwala na zarejestrowanie konta użytkownika. Do użytkownika zostaje wysłany email z linkiem potwierdzającym. Jeżeli użytkownik nie potwierdzi emaila w ciągu 3 dni to konto jest usuwane. Po zarejestrowaniu zakładana jest alarm (patrz niżej) na adres który użytkownik poda w formularzu rejestracyjnym. Formularz ten zawiera również domyślny sposób komunikacji z użytkownikiem - Email/Sms.

## Alarmy:
Zarejestrowani użytkownicy mogą rejestrować dowolną ilość alarmów. 
Alarm jest uruchamiany jeżeli parametry smogu dla danego obszaru zostana przekroczone. 
Uruchomienie alarmu skutkuje powiadomieniem użytkownika (według domyślnego sposobu komunikacji). 
Po uruchomieniu alarmu dla danego obszaru użytkownik dostaje powiadomienie mailowe potwierdzające włączenie.

## Panel administracyjny:
Dla administratora udostępniony jest specjalny dashboard prezentujący : dane użytkownika, ilość założonych czujek, ilość wysłanych powiadomień. W razie wątpliwości administrator może zablokować konto użytkownika.

## Rejestracja czujników smogu :
Każdy z użytkowników może zarejestrować fizyczny czujnik smogu i podłączyć go do aplikacji. Rejestracja polega na wygenerowaniu unikalnego kodu z poziomu aplikacji. Czujniki mogą się komunikować z aplikacja za pomocą REST'owego API. Podczas przekazywania pomiarów czujnik wysyła również swój unikalny identyfikator.
Użytkownicy mogą zarejestrować wiele czujników w różnych lokalizacjach.

# Wymagania techniczne:
- Dla całej aplikacji dostępne jest API Rest'owe
- Aplikacja jest podzielona na moduły
- Aplikacja wdrażana jest jako jeden element (jedna jednostka deploymentu)
  