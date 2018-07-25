using System;

namespace SOLID._01_SingleResponsability
{
    public class Sample
    {
        public void SumAndDisplayResult(int a, int b)
        {
            int sum = Sum(a,b);
            string range = GetNumberRange(sum);
            DisplaySumAndRange(sum, range);
        }

        private int Sum(int a, int b)
        {
            return a + b;
        }

        private void DisplaySumAndRange(int sum, string range)
        {
            Console.WriteLine(string.Format("The sum is: {0} and is in range {1}", sum, range));
        }

        private string GetNumberRange(int number)
        {
            if (number > 0 && number <= 10) return "Value between 0 and 10";
            if (number > 10 && number <= 20) return "Value between 11 and 20";
            if (number > 20 && number <= 30) return "Value between 11 and 20";
            else return "Number not supported";
        }
    }
}
