ool checkSum(long cardNumber, int cardLength) // E.G - 4003600000000014
{
    int currentDigit = 0;    // Tracks the current digit
    int addedTotal = 0;      // Total for the other digits (the ones that need adding together)
    int multipliedTotal = 0; // Total for the multiplied digits
    int grandTotal = 0;      // The two totals added together

    for (int i = 1; i != cardLength + 1; i++) // 16, continue until zero, decrement by 1
    {
        currentDigit = cardNumber % 10; // Cycles through the numbers

        if (i % 2 == 0) // Even
        {
            currentDigit = cardNumber % 10; // Assigns the number
            currentDigit = currentDigit * 2;

            if (currentDigit > 9)
            {
                // Split the digits in half
                currentDigit = currentDigit % 10;
                currentDigit += 1;
            }

            multipliedTotal += currentDigit;
        }

        if (i % 2 != 0) // Odd
        {
            currentDigit = cardNumber % 10;
            addedTotal += currentDigit;
        }

        cardNumber /= 10;
    }

    grandTotal = multipliedTotal + addedTotal;

    if (endInZero(grandTotal))
    {
        return true;
    }
    else
    {
        return false;
    }
}