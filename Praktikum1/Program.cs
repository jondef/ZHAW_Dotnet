/// <summary>
/// Sieb des Eratosthenes
/// Autor: Karl Rege 
/// </summary>

namespace DN1;

public enum PrimeType {
    Prime,
    NotPrime
}

public class Eratosthenes {
    public PrimeType[] Sieve(int maxPrime) {
        var primes = new PrimeType[maxPrime + 1];

        // set all numbers to prime
        for (var i = 0; i < primes.Length; i++) primes[i] = PrimeType.Prime;

        // set 0 and 1 to not prime
        primes[0] = PrimeType.NotPrime;
        primes[1] = PrimeType.NotPrime;

        // iterate over all numbers
        for (var i = 2; i < primes.Length; i++)
            // if the number is prime, set all multiples to not prime
            if (primes[i] == PrimeType.Prime)
                for (var j = i * 2; j < primes.Length; j += i)
                    primes[j] = PrimeType.NotPrime;

        return primes;
    }

    public int[] PrimesAsArray(PrimeType[] primes) {
        // 0 -> 2 (array index -> prime)
        // 1 -> 3
        return primes.Select((value, index) => new { value, index }) // transform to tuple (PrimeType, int)
            .Where(x => x.value == PrimeType.Prime)
            .Select(x => x.index) // select the index
            .ToArray();
    }

    public List<int> PrimesAsList(PrimeType[] primes) {
        return primes.Select((value, index) => new { value, index }) // transform to tuple (PrimeType, int)
            .Where(x => x.value == PrimeType.Prime)
            .Select(x => x.index) // select the index
            .ToList();
    }

    public Dictionary<int, int> PrimesAsDictionary(PrimeType[] primes) {
        return primes.Select((value, index) => new { value, index })
            .Where(x => x.value == PrimeType.Prime)
            .Select(x => new { number = x.index, x })
            .Select((x, index) => new { index, x.number })
            .ToDictionary(x => x.index, x => x.number);
    }

    public void printAll(IEnumerable<int> collection) {
        var i = 0;
        foreach (var p in collection) {
            Console.Write(i++ + "->" + p + " ");
            if ((i + 1) % 5 == 0) Console.WriteLine();
        }

        Console.WriteLine();
    }

    private static void Main(string[] args) {
        var maxPrime = 100;
        var eratosthenes = new Eratosthenes();
        if (args.Length >= 1)
            maxPrime = int.Parse(args[0]);

        var primes = eratosthenes.Sieve(maxPrime);
        Console.WriteLine("Aufgabe 1");
        for (var i = 0; i < maxPrime; i++) {
            Console.Write(i + ":" + primes[i] + " ");
            if ((i + 1) % 5 == 0) Console.WriteLine();
        }

        Console.WriteLine("\nAufgabe 2");
        eratosthenes.printAll(eratosthenes.PrimesAsArray(primes));
        Console.WriteLine("\nAufgabe 3");
        eratosthenes.printAll(eratosthenes.PrimesAsList(primes));
        Console.WriteLine("\nAufgabe 4");
        eratosthenes.printAll(eratosthenes.PrimesAsDictionary(primes).Select(z => z.Value).ToArray());

        Console.ReadLine();
    }
}