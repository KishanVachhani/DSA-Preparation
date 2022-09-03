// See https://aka.ms/new-console-template for more information

/*
 * Problem: Given an array of integers arr[] of size N and an integer, the task is to rotate the array 
 *          elements to the left by d positions.
 *          
 * Source: https://practice.geeksforgeeks.org/problems/rotate-array-by-n-elements-1587115621/1
 *          
 * Input: arr[] = {1, 2, 3, 4, 5, 6, 7}, d = 2
 * Output: 3 4 5 6 7 1 2
 * 
 * Input: arr[] = {3, 4, 5, 6, 7, 1, 2}, d = 2
 * Output: 5 6 7 1 2 3 4
 */

/*
 * Approach: Juggling Algorithm
 * We will find GCD of the Length of arry and provided input d
 * We need to interate n type where n = GCD
 * 
 * Input: arr[] = {1, 2, 3, 4, 5, 6, 7, 8, 9, 10, 11, 12} and d = 3
 * Output: {4, 5, 6, 7, 8, 9, 10, 11, 12, 1, 2, 3}
 * 
 * Here Length of arr = 12 and d = 3
 * GCD = 3 Hence required iteration for output = 3
 * 
 * First step:
 *      => First set is {1, 4, 7, 10}.
 *      => Rotate this set by one position to the left.
 *      => This set becomes {4, 7, 10, 1}
 *      => Array arr[] = {4, 2, 3, 7, 5, 6, 10, 8, 9, 1, 11, 12}
 *      
 * Second step:
 *      => Second set is {2, 5, 8, 11}.
 *      => Rotate this set by one position to the left.
 *      => This set becomes {5, 8, 11, 2}
 *      => Array arr[] = {4, 5, 3, 7, 8, 6, 10, 11, 9, 1, 2, 12}
 *      
 * Third step:
 *      => Third set is {3, 6, 9, 12}.
 *      => Rotate this set by one position to the left.
 *      => This set becomes {6, 9, 12, 3}
 *      => Array arr[] = {4, 5, 6, 7, 8, 9, 10, 11, 12, 1, 2, 3}
 *      
 * Time complexity : O(N)
 * Auxiliary Space : O(1)
 */

/*
 * If you want to understand this solution and see visual change in each iteration please uncomment Console statments.
 */

// Input initilization
int[] arr = { 1, 2, 3, 4, 5, 6, 7, 8, 9, 10, 11, 12 };
int d = 3;
int n = arr.Length;

// Variable declaration that will be needed in the solution.
int i, j, k, temp, GCDResult;

// Edge Case check where d > Length of array: if n = 12 and d = 25 => d will be 1
d = d % n;

GCDResult = GetGCD(n, d);

for (i = 0; i < GCDResult; i++)
{
    //Console.WriteLine($"Value of i is {i}");
    temp = arr[i];
    //Console.WriteLine($"Value of temp is {temp}");
    j = i;
    //Console.WriteLine($"Value of j is {j}");

    while (true)
    {
        k = j + d;
        //Console.WriteLine($"Value of k is {k}");

        if (k >= n)
        {
            // Preparing value for loop break
            k = k - n;
            //Console.WriteLine($" k >= n => Value of k is {k}");
        }
        if (k == i)
        {
            // It is the j is set to index value where temp needs to be assigned so beraking the condition
            break;
        }
        arr[j] = arr[k];
        //Console.WriteLine($"Value of arr[{j}] is {arr[j]}");
        j = k;
        //Console.WriteLine($"Value of j => is {j}");
    }
    arr[j] = temp;
    //Console.WriteLine($"Value of arr[{j}] is {arr[j]}");
}


// Static function to get GCD using recursion
static int GetGCD(int largeNumber, int smallNumber)
{
    if (smallNumber == 0)
    {
        // Tarminating condition.
        return largeNumber;
    }
    else
    {
        /* 
         * Here while calling again suffled input
         * purpuse is we will try to devide larger number with smaller number to check the modulo.
         * If modulo is 0 GCD is smaller number 
         */

        return GetGCD(smallNumber, largeNumber % smallNumber);
    }
}
