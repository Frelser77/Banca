using System;

namespace Banca
{
    internal class Program
    {
        static void Main(string[] args)
        {
            ContoCorrente conto1 = null;
            bool contoRegistrato = false;
            uint saldo = 0;

            Console.WriteLine("=====================================");
            Console.WriteLine("\tBANK OF APULIA");
            Console.WriteLine("=====================================");
            Console.WriteLine("Benvenuto nella nostra banca vuoi aprire un conto?(y/n)");
            string aprireConto = Console.ReadLine();
            if (aprireConto == "y")
            {
                // RACCOLTA DATI DA IMPUT
                Console.WriteLine("\n");
                Console.WriteLine("Inserisci i tuoi dati per completare la procedura");
                Console.WriteLine("Inserisci il tuo Nome");
                string intestatario = Console.ReadLine();
                Console.WriteLine("\n");

                Console.WriteLine("Inserisci il numero del conto:");
                uint numeroConto = (uint)Convert.ToInt32(Console.ReadLine());
                Console.WriteLine("\n");

                DateTime aperturaConto = DateTime.Now;

                // COSTRUTTORE CLASSE CONTOCORRENTE
                conto1 = new ContoCorrente(numeroConto, intestatario, aperturaConto, 0);
                contoRegistrato = true;

                while (true)
                {
                    Console.WriteLine("Inserisci quanto vuoi depositare (min 1000€):");
                    saldo = (uint)Convert.ToInt32(Console.ReadLine());

                    if (saldo >= 1000)
                    {
                        conto1.PrimoDepositoCC(saldo);
                        break; // Esce dal ciclo se il deposito é valido
                    }
                    else
                    {
                        Console.WriteLine("L'importo del primo deposito deve essere almeno di 1000€.");
                        Console.WriteLine("\n");
                        // Il ciclo continua 
                    }
                }

                // Dopo il while
                conto1.OpenCC();
                conto1.GetFullInfo();

                while (contoRegistrato)
                {
                    Console.WriteLine("\n");
                    Console.WriteLine("Desideri fare altre operazioni?(y/n)");
                    string start = Console.ReadLine();
                    if (start == "y")
                    {
                        Console.WriteLine("\n");

                        Console.WriteLine("Che operazione vorresti effettuare?");
                        Console.WriteLine("\n");
                        Console.WriteLine("\n1)Deposito" +
                                          "\n2)Prelievo");
                        string scelta = Console.ReadLine();

                        if (scelta == "1")
                        {
                            Console.WriteLine("Quanto vuoi depositare?");
                            saldo = (uint)Convert.ToInt32(Console.ReadLine());
                            conto1.DepositoCC(saldo);
                            Console.WriteLine("\n");
                            Console.WriteLine($"Il tuo saldo corrente é {saldo}");
                            Console.WriteLine("\n");
                            Console.WriteLine(conto1.GetFullInfo());

                        }
                        else if (scelta == "2")
                        {
                            Console.WriteLine("Quanto vuoi prelevare?");
                            saldo = (uint)Convert.ToInt32(Console.ReadLine());
                            conto1.PrelievoCC(saldo);
                            Console.WriteLine($"Il tuo saldo corrente é {saldo}");


                            Console.WriteLine(conto1.GetFullInfo());
                        }
                        else
                        {
                            Console.WriteLine("Scelta non valida");
                        }
                    }
                    else
                    {
                        break; // uscita ciclo se imput diverso da y

                    }


                    Console.WriteLine("Grazie e arrivederci!");
                    Console.WriteLine("=====================================");
                    Console.WriteLine("\tBANK OF APULIA");
                    Console.WriteLine("=====================================");

                    Console.ReadLine();
                }

            }
        }
    }
}
