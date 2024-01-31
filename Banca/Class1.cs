using System;

namespace Banca
{
    internal class ContoCorrente
    {
        // PROPRIETÁ
        public uint NumeroConto { get; set; }
        public string Intestatario { get; set; }
        public DateTime AperturaConto { get; set; }
        public uint SaldoConto { get; set; }

        //COSTRUTTORE
        public ContoCorrente(uint numeroConto, string intestatario, DateTime aperturaConto, uint saldo)
        {
            NumeroConto = numeroConto;
            Intestatario = intestatario;
            AperturaConto = aperturaConto;
            SaldoConto = saldo;
        }
        /*    public ContoCorrente(decimal conto)
            {
                SaldoConto = conto;
            }*/

        //METODI
        public string OpenCC()
        {
            return ($"Numero del ContoCorrente {NumeroConto}\n " +
                    $"intestato al Sg.{Intestatario}\n " +
                    $"in data {AperturaConto}\n " +
                    $"con saldo al momento dell'apertura {SaldoConto}");
        }

        public void PrelievoCC(uint importo)
        {
            if (importo <= SaldoConto && importo > 0)
            {
                SaldoConto -= importo;
            }
            else
            {
                Console.WriteLine("Importo non valido o saldo insufficiente");
            }
        }

        public bool PrimoDepositoCC(uint importo)
        {
            if (importo >= 1000)
            {
                SaldoConto = importo;
                return true;
            }
            else
            {
                SaldoConto = 0;
                Console.WriteLine("L'importo del primo deposito deve essere almeno di 1000€ \no momentaneamente fuori servizio");
                return false;
            }
        }

        public void DepositoCC(uint importo)
        {
            if (importo > 0)
            {
                SaldoConto += importo;
            }
            else
            {
                Console.WriteLine("L'importo del deposito non é corretto \no momentaneamente fuori servizio");
            }
        }

        public string GetFullInfo()
        {
            return $"Info principali del conto: " +
                   $"\nNumero CC: {NumeroConto}" +
                   $"\nIntestato a: {Intestatario}" +
                   $"\nin data: {AperturaConto}" +
                   $"\nIStantanea saldo contabile: {SaldoConto}";
        }

    }

}
