using System;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace OpenSchool
{
    class PrimeNumbers
    {
        /// <summary> Print prime numbers up to specified max, using specified number of threads. </summary>
        public static async Task PrintPrimeNumbersConcurrent(int max, int threads)
        {
            Console.WriteLine("=== PrintPrimeNumbersConcurrent started! ===");
            List<Task> tasks = new List<Task>();
            for( int i = 0; i < threads; i++ )
            {
                if( i > 0 && threads % (i + 1) == 0 )    // Do not execute a thread if it's starting position and increment...
                    continue;                            // ...would never find a single prime number at all.
                tasks.Add(Task.Run(() => PrintPrimeNumbersAndGetNextAsync(max, true, threads, i)));
            }
            // Executing PrintPrimeNumbersAndGetNextAsync on a "threadpool" - on some pre-allocated thread, in a loop.
            // In order to check all the numbers from 1 to infinity, by using, for example 4 `threads`,
            // we have to somehow separate this list of numbers. We can do so by the number of threads,
            // simply by starting each thread with an offset of it's number, and then incrementing the tested number
            // by the total number of threads.

            await Task.WhenAll(tasks);    // Yields until all of the threads are finished.
            Console.WriteLine("=== PrintPrimeNumbersConcurrent done! ===");
        }

        /// <summary> Print prime numbers up to specified max, and return the one above. </summary>
        public static async Task<int> PrintPrimeNumbersAndGetNextAsync(int max, bool print = true, int increment = 1, int offset = 0)
        {
            Console.WriteLine("=== PrintPrimeNumbersAndGetNextAsync started! ===");
            int number = 1 + offset;

            while( true )
            {
                number += increment;

                int denominator = 1;    // Denominator == Jmenovatel
                bool isPrime = true;
                while( ++denominator * denominator <= number )
                {
                    if( number % denominator == 0 )
                    {
                        isPrime = false;
                        break;
                    }
                }

                if( isPrime )
                {
                    if( print )
                    {
                        //Console.WriteLine(number.ToString());    // Don't actually print the spam! :D
                    }

                    //await Task.Yield();                          // Experiment ;)

                    if( number > max )
                    {
                        Console.WriteLine("=== PrintPrimeNumbersAndGetNextAsync done! ===");
                        return number;
                    }
                }
            }
        }

        /// <summary> Find n-th prime number. </summary>
        public static int FindNthPrime(int n)
        {
            int count = 0;
            int a = 1;
            while( true )
            {
                a++;
                int b = 1;
                bool isPrime = true;
                while( ++b * b <= a )
                {
                    if( a % b == 0 )
                    {
                        isPrime = false;
                        break;
                    }
                }
                if( isPrime )
                {
                    if( ++count == n )
                        break;
                }
            }

            return a;
        }
    }
}
