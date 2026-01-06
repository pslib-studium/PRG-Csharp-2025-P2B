using Interface;


Reader tonda = new Reader("Antonín");

Book babicka = new Book("Babička", "Něco o nějaké staré paní");
Book lotr = new Book("Pán Prstenů", "Něco o prstenu");
Magazine blesk = new Magazine("Další skandál", 30);

// Reader pracuje s libovolným IReadable bez ohledu na konkrétní typ
tonda.Reading(blesk);
tonda.Reading(lotr);
tonda.Reading(babicka);

