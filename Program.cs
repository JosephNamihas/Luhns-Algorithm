using System;
using System.Runtime.CompilerServices;

namespace LuhnsAlgorithm
{
    internal class Program
    {
        static void Main(string[] args)
        {
            long creditCardNumber = GetCreditCard();

            Console.WriteLine(CheckSum(creditCardNumber, GetLength(creditCardNumber)));

            bool CheckSum(long cardNumber, long cardLength)
            {
                long currentDigit = 0; // Tracks the current digit
                long addedTotal = 0; // Total for the 'other' digits - The ones needing adding together
                long multipliedTotal = 0; // The even digits - the ones needing multiplied together

                for (int i = 1; i != cardLength + 1; i++)
                {
                    currentDigit = cardNumber % 10; // cycles through the digits

                    if(EvenOrOdd(i) == true)
                    {
                        currentDigit = cardNumber % 10;
                        currentDigit *= 2;

                        if (currentDigit > 9)
                        {
                            currentDigit = currentDigit % 10;
                            currentDigit += 1;
                        }

                        multipliedTotal += currentDigit;

                    } else {

                        currentDigit = cardNumber % 10;
                        addedTotal += currentDigit;
                    }

                    cardNumber /= 10;
                }

                long grandTotal = addedTotal + multipliedTotal;
                Console.WriteLine($"Total: {grandTotal}");

                if(EndInZero(grandTotal))
                {
                    return true;
                } else {
                    return false;
                }
            }

            bool EndInZero(long total)
            {
                if(total % 10 == 0)
                {
                    return true;
                } else {
                    return false;
                }
            }

            bool EvenOrOdd(long digit)
            {
                if(digit % 2  == 0)
                {
                    return true;
                } else {
                    return false;
                }
            }

            long GetLength(long cardNum)
            {
                long currentNumber = cardNum;
                long length = 0;

                do {
                   currentNumber /= 10;
                   length += 1;
                } while (currentNumber > 0);

                return length;
            }

            long GetCreditCard()
            {
                bool parsed;
                long creditCardNum;

                do {
                    Console.WriteLine("Enter the Credit Card Number");
                    string? getCreditCard = Console.ReadLine();
                    parsed = long.TryParse(getCreditCard, out creditCardNum);

                } while (parsed == false);

                return creditCardNum;
            }













            

            // Iterate through the Credit Card from the back
                // Multiply each Even Number
                    // If the even number is greater than 9. Add each individual digit

                // Add each Odd number to a total

            
        }
    }
}