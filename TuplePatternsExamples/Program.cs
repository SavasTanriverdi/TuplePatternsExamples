using System;

namespace TuplePatternsExamples
{
    class Program
    {
        static void Main(string[] args)
        {
            // Hava durumu ve sıcaklık durumuna göre bir öneri veren tuple deseni
            Console.WriteLine("Weather and Temperature Advice:");
            Console.WriteLine(GetWeatherAdvice("sunny", 25));  // Güneşli bir hava için
            Console.WriteLine(GetWeatherAdvice("rainy", 10));  // Yağmurlu bir hava için
            Console.WriteLine(GetWeatherAdvice("cloudy", 15)); // Bulutlu bir hava için
            Console.WriteLine(GetWeatherAdvice("snowy", -5));  // Karlı bir hava için
            Console.WriteLine(GetWeatherAdvice("sunny", 35));  // Aşırı sıcak bir hava için
        }

        // Tuple pattern kullanarak hava durumuna göre öneri veren metot
        static string GetWeatherAdvice(string weather, int temperature) => (weather, temperature) switch
        {
            ("sunny", < 30) => "It's sunny and pleasant. Enjoy your day outside!",
            ("sunny", >= 30) => "It's sunny but very hot. Stay hydrated!",
            ("rainy", _) => "It's rainy. Don't forget your umbrella!",
            ("cloudy", _) => "It's cloudy. It might rain, so take a jacket.",
            ("snowy", < 0) => "It's snowy and freezing. Dress warmly!",
            (_, < 0) => "It's freezing outside. Stay warm!",
            _ => "Weather condition not recognized. Check the forecast for details."
        };

        // Farklı bir örnek: İki sayının işlemine göre sonuç döndüren tuple pattern kullanımı
        static void MathOperationExample()
        {
            Console.Write("Enter the first number: ");
            int num1 = int.Parse(Console.ReadLine());

            Console.Write("Enter the second number: ");
            int num2 = int.Parse(Console.ReadLine());

            Console.Write("Enter an operator (+, -, *, /): ");
            char operation = Console.ReadLine()[0];

            var result = (num1, num2, operation) switch
            {
                (_, _, '/') when num2 == 0 => "Cannot divide by zero.",
                (_, _, '+') => $"Result: {num1 + num2}",
                (_, _, '-') => $"Result: {num1 - num2}",
                (_, _, '*') => $"Result: {num1 * num2}",
                (_, _, '/') => $"Result: {num1 / num2}",
                _ => "Unknown operation."
            };

            Console.WriteLine(result);
        }
    }
}
