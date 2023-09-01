using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

/* EXERCISE

Scrivere una classe ‘Contribuente’ che abbia le seguenti proprietà: [Nome, Cognome, DataNascita, CodiceFiscale, Sesso, ComuneResidenza, RedditoAnnuale]; costruire uno o 
più costruttori (a scelta del candidato) ed un metodo che applichi al reddito le seguenti aliquote per scaglioni e ne determini l’imposta da pagare:

SCAGLIONI DI REDDITO ALIQUOTA E IMPOSTA DOVUTA

Reddito da 0 a 15.000 aliquota 23%
Reddito da 15.001 a 28.000 3.450 + aliquota 27% sulla parte eccedente i 15.000
Reddito da 28.001 a 55.000 6.960 + 38% sulla parte eccedente i 28.000
Reddito da 55.001 a 75.000 17.220 + 41% sulla parte eccedente i 55.000
Redduti oltre i 75.001 25.420 + 43% sulla parte eccedente i 75.000

Esecuzione del programma:

Il programma (console application) deve richiedere, un menu con due funzioni ben distinte:

1) Inserimento di una nuova dichiarazione di un contribuente
2) La lista completa di tutti i contribuenti che sono stati analizzati.

La prima scelta dovrà consentire di reperire da tastiera, uno per volta, tutte le proprietà del contribuente, verranno immesse e memorizzate nelle relative proprietà 
dell’oggetto; infine proponga un risultato riepilogativo simile al seguente:
==================================================

CALCOLO DELL’IMPOSTA DA VERSARE:

Contribuente: Mario Rossi,
nato il 15/07/1961 (M),
residente in Palermo,
codice fiscale: MRORSI61LIKSNNNS
Reddito dichiarato: 17.850,00
IMPOSTA DA VERSARE: € 4.219,50

La seconda scelta invece deve stampare a schermo tutti i dettagli di tutti i contribuenti già analizzati.

*/


namespace MyTaxes
{
    internal class Program
    {
        static void Main(string[] args)
        {
            // Lista dei contributori
            List<Contributor> allContributors = new List<Contributor>();

            // Thank you: https://www.codeproject.com/Questions/455766/Euro-symbol-does-not-show-up-in-Console-WriteLine
            // These two lines of code allow the print of th euro symbol in the console :)
            Console.OutputEncoding = System.Text.Encoding.UTF8;
            System.Console.Out.WriteLine("œil");

            string euro = " €";


            while (true)
            {
                Console.WriteLine("------------------------- MENU ---------------------------");
                Console.WriteLine("                                                          ");
                Console.WriteLine("Type '1' to enter new contributor data:");
                Console.WriteLine("                                                          ");
                Console.WriteLine("Type '2' to show all registered contributors:");
                Console.WriteLine("                                                          ");
                Console.WriteLine("Type '3' to quit:");
                Console.WriteLine("                                                          ");
                Console.WriteLine("------------------------- MENU ---------------------------");


                Console.Write("Option: ");
                string option = Console.ReadLine();

                // Se input è "1" lascia l'user mettere nuovi dati di un contributore
                if (option == "1")
                { }

                // Se input è "2" fa vedere i contributori, e torna alle opzioni
                if (option == "2") {
                    Console.WriteLine("List of Contributors:");
                    foreach (var contributorList in allContributors)
                    {
                        Console.WriteLine("================== CONTRIBUTOR ====================");
                        Console.WriteLine("Name: "+ contributorList.name);
                        Console.WriteLine("Surname: "+ contributorList.surname);
                        Console.WriteLine("Birth: " + contributorList.birth);
                        Console.WriteLine("SSN: " + contributorList.ssn);
                        Console.WriteLine("Sex: " + contributorList.sex);
                        Console.WriteLine("Residency: " + contributorList.residency);
                        Console.WriteLine("Income: " + contributorList.income + euro);
                        Console.WriteLine("Taxes: " + contributorList.taxes + euro);
                        Console.WriteLine();
                    }
                    continue;
               
                }

                // Se input è "3" ferma il codice e stampa un messaggio di saluti
                if (option == "3")
                    break;

                Console.Write("Name: ");
                string name = Console.ReadLine();

                Console.Write("Surname: ");
                string surname = Console.ReadLine();

                Console.Write("Birth as dd/mm/yyyy: ");
                string birth = Console.ReadLine();

                Console.Write("SSN: ");
                string ssn = Console.ReadLine();

                Console.Write("Sex: ");
                string sex = Console.ReadLine();

                Console.Write("Residency: ");
                string residency = Console.ReadLine();

                //controlla il tipo di dato di income, se non à un decimal ricomincia l'input da capo
                Console.Write("Income: ");
                decimal income;
                

                if (!decimal.TryParse(Console.ReadLine(), out income))
                {
                    Console.WriteLine("You have not entered a valid number. Plese user dot '.' for thusands; comma ',' for decimal place. ");
                    continue;
                }

                // impostazione tasse a 0, a ogni if controlla l'income che user ha messo dentro input, e calcola le tasse
                decimal taxes = 0;

                if (income >= 0 && income <= 15000)
                { 
                     taxes = income * 0.23M;
                }
                if (income >= 15001 && income <= 28000)
                {
                    taxes = (((income -15000) * 0.27M)+3450);
                }
                if (income >= 28001 && income <= 55000)
                {
                    taxes = (((income - 28000) * 0.38M) + 6960);
                }
                if (income >= 55001 && income <= 75000)
                {
                    taxes = (((income - 55000) * 0.41M) + 17220);
                }
                if (income >= 75001)
                {
                    taxes = (((income - 75000) * 0.43M) + 25420);
                }


                // crea contributor 
                Contributor contributor = new Contributor
                {
                    name = name,
                    surname = surname,
                    birth = birth,
                    ssn = ssn,
                    sex = sex,
                    residency = residency,
                    income = income,
                    taxes = taxes
                };

                // fa vedere gli input prima di ricominciare il menu
                Console.WriteLine("======================================================");
                Console.WriteLine("Details of the last contributor:");
                Console.WriteLine($"Name: " + name);
                Console.WriteLine($"Surname: " + surname);
                Console.WriteLine($"Birth: " + birth);
                Console.WriteLine($"SSN: " + ssn);
                Console.WriteLine($"Sex: " + sex);
                Console.WriteLine($"Residency: " + residency);
                Console.WriteLine($"Income: " + income + euro);
                Console.WriteLine($"Taxes: " + taxes + euro);
                Console.WriteLine("======================================================");


                // aggiunge l'ultimo contributor alla lista allContributor
                allContributors.Add(contributor);

            }

            // quando user input exit, scrive la seguente e l'app si ferma
            Console.WriteLine("Thank you for using this tax and contributor listing app. ");
            Console.ReadKey();

        }
    }
}
