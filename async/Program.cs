using System;
using System.Diagnostics;
using System.Net.Http;
using System.Threading.Tasks;

namespace OpenSchool
{
	static class Program
	{
		static async Task Main(string[] args)
		{
			Console.WriteLine("Running async code time test...\n");
			await RunTest();

			//Console.WriteLine("Running async code example...\n");
			//await RunDemo();
		}

		const int PrimeToFind = 1000000;
        const int ExamplePrime = 7654321;
        const int MaxPrimeToPrint = 32452843;
        const int ThreadsToUse = 4;

        const string ExampleUrl = "http://fedoraloves.net";

        static async Task RunDemo()
        {
            // Start concurrent work on background threads (thread pool.) using `Task.Run()`
            Task printTask = PrimeNumbers.PrintPrimeNumbersConcurrent(MaxPrimeToPrint, ThreadsToUse);

            Console.WriteLine($"Started to print all the prime numbers up to {MaxPrimeToPrint} " +
                              $"*concurrently* (using up to {ThreadsToUse} different threads) ...");


            // Start asynchronous I/O task on the main thread by awaiting an `async` method.
            Console.WriteLine("=== HttpClient().GetStringAsync() started! ===");
            Task<string> webTask = new HttpClient().GetStringAsync(ExampleUrl);

            Console.WriteLine($"Started to download web content from {ExampleUrl} *asynchronously* (on the main thread) ...");


            Console.WriteLine($"While waiting for the website data, we can calculate what would be the " +
                              $"next prime number after {ExamplePrime} fully *synchronously* (blocking the main thread) ...");

            // Start an async Task and run it completely synchronously blocking the main thread - Avoid doing this!
            Task<int> primeTask = PrimeNumbers.PrintPrimeNumbersAndGetNextAsync(ExamplePrime, false);
            int foundPrime = primeTask.Result;
            //int foundPrime = primeTask.GetAwaiter().GetResult(); // This is incorrect use for us, as the GetAwaiter
            // is meant to be used only by the compiler and not by the programmer.
            // However it will achieve the same thing - get a result of the asynchronous method, synchronously,
            // and they both block the main thread. Avoid using `.Result` as well, and correctly `await` everything :]

            Console.WriteLine($"Found the prime number: {foundPrime}");


            // Wait for the I/O task to finish, and get it's result.
            string webContent = await webTask;
            Console.WriteLine("=== HttpClient().GetStringAsync() done! ===");
            Console.WriteLine($"Downloaded web content (1st line): {webContent.Split('\n')[0]}"); //writing only the first line...


            // Wait for the concurrent CPU task to finish (it does not have a result.)
            await printTask;


            Console.WriteLine($"All done!");
        }

        static async Task RunTest()
        {
            Console.WriteLine($"Looking for {PrimeToFind} prime numbers *synchronously* (1 main thread) ...");
            Stopwatch watch = Stopwatch.StartNew();

            // Synchronous code.
            int prime = PrimeNumbers.FindNthPrime(PrimeToFind);

            watch.Stop();
            Console.WriteLine($"Synchronously found the {PrimeToFind}th prime number {prime} in {watch.ElapsedMilliseconds}ms");


            Console.WriteLine($"Looking for {PrimeToFind} prime numbers *concurrently* ({ThreadsToUse} threads) ...");
            watch.Restart();

            // Immediately awaited asynchronous code executing multiple threads concurrently.
            await PrimeNumbers.PrintPrimeNumbersConcurrent(prime, ThreadsToUse);

            watch.Stop();
            Console.WriteLine($"Concurrently found all the prime numbers up to {prime} in {watch.ElapsedMilliseconds}ms");
        }
	}
}
