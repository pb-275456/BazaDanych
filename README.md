# Aplikacja pogodowa
Projekt implementuje prostą aplikację pogodową zrealizowaną przy użyciu Entity Framework, MAUI i API. Dane z pogodą dla danego miasta pobierane są przy pomocy API OpenWeatherMap i zapisywane w bazie danych. 

## Baza Danych
<ul>
  <li>Tabela Cities - przechowuje informacje o mieście (nazwa i współrzędne geograficzne)</li>
  <li>Tabela WeatherEntries - przechowuje pojedynczy wpis pogodowy danego miasta: data z godziną, temperatura, temeratura odczuwalna, ciśnienie, wilgotność</li>
</ul>
Tabele mają relację jeden do wielu. Jedno miasto może mieć wiele wpisów pogody, a każdy wpis podlega tylko jednemu miastu.

### Operacje na bazie danych
<ul>
  <li>Dodawanie wpisów pogody danego miasta poprzez pobranie informacji z API</li>
  <li>Wyszukiwanie wszystkich wpisów pogody danego miasta z dzisiejszą datą</li>
  <li>Wyszukiwanie wszystkich wpisów pogody danego miasta w bazie</li>
  <li>Usuwanie wszystkich wpisów dla danego miasta wraz z miastem</li>
</ul>
Implementacja wszystkich operacji wraz z pobieraniem danych znajduje się w klasie Controller. Dane pogodowe pobierane są z API OpenWeatherMap w formacie JSON, a następnie deserializowane do obiektu klasy WeatherData o odpowiedniej strukturze zgodnej z plikiem.


## Graficzny interfejs użytkownika
Interfejs został wykonany za pomocą MAUI. Użytkownik ma możliwość wprowadzenia miasta i wyboru jednej z trzech opcji:
<ul>
  <li>Wyświetlenie wszystich wpisów dla tego miasta</li>
  <li>Usunięcia wszystkich wpisów tego miasta z bazy</li>
  <li>Pobranie i wyświetlenie dzisiejszych wpisów pogody dla tego miasta</li>
</ul>

W przypadku wpisania miasta, które nie istnieje w bazie danych lub braku możliwości pobrania danych z API wyświetla się odpowiedni komunikat z informacją o błędzie. 
Dane do bazy danych moga byc pobrane tylko jednarazowo dla danej godziny, czyli w ciągu godziny (16:00 - 16:59) dane z API są pobierane tylko jeden raz.
