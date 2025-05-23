﻿using System;
using System.Runtime.CompilerServices;

namespace LuhnsAlgorithm
{
    internal class Program
    {
        static void Main(string[] args)
        {
            long creditCardNumber = GetCreditCard();
            int cardLength = GetLength(creditCardNumber);

            if(CheckSum(creditCardNumber, cardLength) == true) {
                
                CheckForVisa();
                CheckForMastercard();
                CheckForAMEX();

            } else {
                Console.WriteLine("Invalid Card Number");
            }

            Console.WriteLine("Press Any Key To Close");
            Console.ReadKey(); // Stops automatic closur

            // Function to cycle digits
            int CycleDigits(long creditCard, int chosenDigit)
            {

                for(int i = 1; i != chosenDigit; i++)
                {
                    creditCard /= 10;
                }

                long chosenNumber = creditCard % 10;

                int correctNumber = Convert.ToInt32(chosenNumber);
                return correctNumber;
            }

            // Function to check digits

            void CheckForVisa()
            {
                if(cardLength == 13)
                {
                    if (CycleDigits(creditCardNumber, 13) == 4)
                    {
                        Console.WriteLine("VISA");
                    }
                } else {

                    if(cardLength == 16)
                    {
                        if(CycleDigits(creditCardNumber, 16) == 4)
                        {
                            Console.WriteLine("VISA");
                        }
                    }
                };
            }

            void CheckForMastercard()
            {
                if (CycleDigits(creditCardNumber, 16) == 5)
                {
                    switch(CycleDigits(creditCardNumber, 15))
                    {
                        case 1: case 2: case 3: case 4: case 5: case 6:
                        Console.WriteLine("Mastercard");
                        break;
                    }

                }
            }

            void CheckForAMEX()
            {
                if (CycleDigits(creditCardNumber, 15) == 3)
                {
                    switch(CycleDigits(creditCardNumber, 14))
                    {
                        case 4: case 7:
                        Console.WriteLine("AMEX");
                        break;
                    }
                }
            }

            bool CheckSum(long cardNumber, long cardLength) // 4003600000000014
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

            int GetLength(long cardNum)
            {
                long currentNumber = cardNum;
                int length = 0;

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
        }
    }
}