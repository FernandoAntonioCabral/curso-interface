using System;
using System.Globalization;
using Course.Entities;
using Course.Services;


namespace Course
{
    internal class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("Enter contract data:");
            Console.Write("Number: ");
            int number = int.Parse(Console.ReadLine());
            Console.Write("Date (dd/MM/yyyy): ");
            DateTime date = DateTime.ParseExact(Console.ReadLine(),"dd/MM/yyyy", CultureInfo.InvariantCulture);
            Console.Write("Contract value: ");
            double contValue = double.Parse(Console.ReadLine(), CultureInfo.InvariantCulture);
            Console.Write("Enter number of installments: ");
            int inst = int.Parse(Console.ReadLine());

            Contract contract = new Contract(number, date, contValue);

            ContractService contractService = new ContractService(new PaypalService());
            contractService.processContract(contract, inst);

            Console.WriteLine("Installments:");
            foreach (Installment installment in contract.Installments)
            {
                Console.WriteLine(installment);
            }
            { 

            }

            


        }
    }
}