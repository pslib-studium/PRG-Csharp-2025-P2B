using _08_trida;
// -------------------------------------------------------------------------
// TESTOVACÍ PROGRAM
// -------------------------------------------------------------------------

Kruh kruh = new Kruh(10.0);
Console.WriteLine(kruh.info());       
kruh.Polomer = 15;                    // změna poloměru
Console.WriteLine(kruh.Polomer);      // výpis aktuálního poloměru
Console.WriteLine(kruh.info());       
kruh.zmenVelikost(2);                 // zvětšení kruhu 2x
Console.WriteLine(kruh.info());  

// kruh.Polomer = -11; → vyvolá chybu (výjimku ArgumentException)

Kruh zakladniKruh = new Kruh();       // vytvoření s výchozím poloměrem (1.0)
