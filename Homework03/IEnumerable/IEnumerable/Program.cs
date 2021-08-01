using System;
using System.Collections.Generic;
using System.Linq;

namespace IEnumerable
{
    class Program
    {
        static void Main(string[] args)
        {
            List<Client> clientList = new List<Client>();
            Random rnd = new Random();
            int i = 0;

            do
            {
                var client = new Client("Surname" + rnd.Next(1, 100), "Name" + rnd.Next(1, 100),
                    "Patronymic" + rnd.Next(1, 100), rnd.Next(1000000, 10000000), rnd.Next(0, 10000000) / 100);
                if (!(clientList.Contains(client)))
                {
                    clientList.Add(client);
                }
            } while (i < 1000000);

            var searchedClient1 = SearchClientByPassportID(1975348, clientList);

            var searchedClients2 = SearchClientByName("Name76", clientList);

            var searchedClients3 = SearchClientsMoneyBalanceLowerThan(10000, clientList);

            var searchedClient4 = SearchLowestMoneyBalanseClient(clientList);

            var TotalMoneyBalance = CalculateTotalMoneyBalance(clientList);
        }

        public static IEnumerable<Client> SearchClientByPassportID(int pointedPassportID, List<Client> clientList)
        {
            return clientList.Where(client => client.PasspotID == pointedPassportID);
        }

        public static IEnumerable<Client> SearchClientByName(string pointedName, List<Client> clientList)
        {
            return clientList.Where(client => client.Name == pointedName);
        }

        public static IEnumerable<Client> SearchClientsMoneyBalanceLowerThan(double pointedBalance, List<Client> clientList)
        {
            return clientList.Where(client => client.MoneyBalance < pointedBalance);
        }

        public static IEnumerable<Client> SearchLowestMoneyBalanseClient(List<Client> clientList)
        {
            var LowestBalance = clientList.Min(client => client.MoneyBalance);
            return clientList.Where(client => client.MoneyBalance == LowestBalance);
        }

        public static double CalculateTotalMoneyBalance(List<Client> clientList)
        {
            return clientList.Sum(client => client.MoneyBalance);
        }
    }
}
