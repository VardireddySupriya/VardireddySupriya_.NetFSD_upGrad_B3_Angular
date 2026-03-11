//Accept a number N from user.
//• Use loops to:
//   -Count even numbers
//   -Count odd numbers
//   - Calculate sum of all numbers
//• Display results.

namespace Problem4
{
    internal class Numberanalysis
    {
        static void Main(string[] args)
        {
            Console.WriteLine("enter number:");
            int n = int.Parse(Console.ReadLine());
            int evenCount = 0;
            int oddCount = 0;
            int sum = 0;
            for(int i=1;i<=n;i++)
            {
                sum = sum + i;
                if(i%2==0)
                {
                    evenCount++;
                }
                else
                {
                    oddCount++;
                }
            }
            Console.WriteLine("sum:" + sum);
            Console.WriteLine("even count:" + evenCount);
            Console.WriteLine("odd count:" + oddCount);
            Console.ReadLine();

        }
    }
}
