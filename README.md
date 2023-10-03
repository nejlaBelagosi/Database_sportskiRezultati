# Database_sportskiRezultati

## Opis problema

Praćenje sportskih rezultata i utakmica postala je svakodnevnica te korisnicima omogućuje praćenje sportskih rezultata u realnom vremenu bez emitovanja istih. Svrha je omogućiti korisnicima koji nemaju trenutačnu mogućnost praćenje rezultata te njihove detalje. 
Značaj ovakvog vida baze podataka je ogroman za sve ljubitelje sportova jer u bilo koje vrijeme i sa bilo kojeg mjesta mogu pratiti sportske rezultate.
Ovaj vid ER dijagrama može se koristiti za više sportova, gdje postoje različite utakmice, igrači, timovi te pohraniti njihove rezultate. Svaka liga se sastoji od jednog ili više timova, dok tim može da pripada samo jednoj ligi, a podaci koji su bitni za svaki tim jesu zapravo koliko igrača pripada jednom timu i koji je naziv tima. Timove čine igrači za koje bilježimo njihova imena, prezimena, datum rođenja, njihovu poziciju na utakmicama, tim kojem pripada, s tim da jedan igrač može igrati samo u jednom timu. Utakmice se igraju između timova, a svaka utakmica ima svoje vrijeme održavanja, stadion na kojem se igra kao i datum održavanja. Tim može igrati samo jednu utakmicu u tom terminu održavanja. Svaka utakmica bilježi rezultat odnosno vrijeme u kojem se desio pogodak, koji se prenosi iz minute u minutu na aplikacijama za praćenje sportskih rezultata, a svaka utakmica odnosno tim može imati samo jedan rezultat.

## Konceptualni model
### Dijagram entiteta

![image](https://github.com/nejlaBelagosi/Database_sportskiRezultati/assets/122165597/fd98b992-523e-4793-bdef-c52c5fd4745b) 

### ER veze
![image](https://github.com/nejlaBelagosi/Database_sportskiRezultati/assets/122165597/0751747a-8270-4b7f-9b97-30cd76ac666b)

### ER dijagram


![image](https://github.com/nejlaBelagosi/Database_sportskiRezultati/assets/122165597/718aff56-7055-44c2-bfb3-cee4c369a05c)

## Relacijski model
![image](https://github.com/nejlaBelagosi/Database_sportskiRezultati/assets/122165597/018f97b0-467e-45e3-914e-4390024bb759)


