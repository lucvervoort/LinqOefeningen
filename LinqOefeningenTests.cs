namespace LinqOefeningenTests
{
    public class LinqOefeningenTestSuite
    {
        [Fact]
        public void Opdracht1()
        {
            // AAA: Arrange, Act, Assert

            // Arrange
            // Stap 1: data source
            int[] n1 = { 0, 1, 2, 3, 4, 5, 6, 7, 8, 9 };
            int[] controle = { 0, 2, 4, 6, 8 };

            // Act
            // Stap 2: query creatie
            var query = n1
                .Where(n => n % 2 == 0)
                .Select(n => n);

            // from n in n1 where (n % 2) == 0 select n;

            // Stap 3: uitvoering
            var result = query.ToList();

            // Assert
            Assert.Equal(controle, result);
        }

        [Fact]
        public void Opdracht2()
        {
            List<int> numbers = new() { 1, 3, -2, -4, -7, -3, -8, 12, 19, 6, 9, 10, 14 };

            var result = numbers.Where(x => x >= 1 && x <= 11).Select(x => x).ToList();

            // var result2 = from x in numbers where x >= 1 && x <= 11 select x;
        }

        [Fact]
        public void Opdracht3()
        {
            var arr1 = new[] { 3, 9, 2, 8, 6, 5 };
            var sqrNrQuery = from int number in arr1
                             let sqrNr = number * number
                             where sqrNr > 20
                             select new { Number = number, SqrNr = sqrNr };

            var result = sqrNrQuery.ToList();

            /*
            Array.Sort(arr1);
            Array.Reverse(arr1);

            foreach (var number in arr1)
            {
                int kwadraat = number * number;
            }
            */
        }

        [Fact]
        public void Opdracht4()
        {
            //Oef 4
            var arr1 = new[] { 5, 9, 1, 2, 3, 7, 5, 6, 7, 3, 7, 6, 8, 5, 4, 9, 6, 2 };

            var q = arr1.GroupBy(x => x)
            .Select(g => new { Value = g.Key, Count = g.Count() });
        }

        [Fact]
        public void Opdracht8()
        {
            var cities = new List<string>()
{
    "ROME",
    "LONDON",
    "NAIROBI",
    "CALIFORNIA",
    "ZURICH",
    "NEW DELHI",
    "AMSTERDAM",
    "ABU DHABI",
    "PARIS"
};
            var selectedCity = from city in cities where city.StartsWith('A') where city.EndsWith('M') select city;
            var selectedCityMethod = cities.Where(c => c.StartsWith('A') && c.EndsWith('M')).Select(c => c);
            selectedCityMethod = cities.Where(c => c.StartsWith('A') && c.EndsWith('M'));
            Assert.Equal(selectedCity, selectedCityMethod);
        }

        [Fact]
        public void Opdracht9()
        {
            var mijnLijst = new List<int>() { 55, 200, 740, 76, 230, 482, 95 };

            var result = mijnLijst.Where(x => x > 80);
            var alternative = mijnLijst.FindAll(x => x > 80);
            Assert.Equal(result, alternative);
        }

        [Fact]
        public void Opdracht10()
        {
            List<int> leden = new() { 10, 48, 52, 94, 63 };
            var groterDan = leden.Where(x => x > 59);
        }
    }
}