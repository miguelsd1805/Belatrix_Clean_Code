using CleanCode.Comments;
using System;
using System.Collections.Generic;

namespace CleanCode.OutputParameters
{
    public class OutputParameters
    {
        public void DisplayCustomers()
        {
            var customers = GetCustomers(out int totalCount);
            PrintCustomers(customers, totalCount);
        }

        public IEnumerable<Customer> GetCustomers(out int totalCount, int pageIndex = 1)
        {
            totalCount = 100;
            return new List<Customer>();
        }
        
        private void PrintCustomers(IEnumerable<Customer> customers, int totalCustomersCount)
        {
            Console.WriteLine("Total customers: " + totalCustomersCount);
            foreach (var c in customers)
                Console.WriteLine(c);
        }
    }
}
