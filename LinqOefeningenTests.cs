namespace LinqOefeningenTests
{
    public class Students
    {
        public string? Name { get; set; }
        public int GradePoint { get; set; }
        public int Id { get; set; }

        public static List<Students> GtStuRec()
        {
            var students = new List<Students>
        {
            new Students { Id = 1, Name = " Joseph ", GradePoint = 800 },
            new Students { Id = 2, Name = "Alex", GradePoint = 458 },
            new Students { Id = 3, Name = "Harris", GradePoint = 900 },
            new Students { Id = 4, Name = "Taylor", GradePoint = 900 },
            new Students { Id = 5, Name = "Smith", GradePoint = 458 },
            new Students { Id = 6, Name = "Natasa", GradePoint = 700 },
            new Students { Id = 7, Name = "David", GradePoint = 750 },
            new Students { Id = 8, Name = "Harry", GradePoint = 700 },
            new Students { Id = 9, Name = "Nicolash", GradePoint = 597 },
            new Students { Id = 10, Name = "Jenny", GradePoint = 750 }
        };
            return students;
        }
    }

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
            Assert.Equal(groterDan, new List<int>() { 94, 63 });
        }

        [Fact]
        public void Opdracht11()
        {
            var list = new List<int>
            {
                5,
                7,
                13,
                24,
                6,
                9,
                8,
                7
            };

            list.Sort();
            list.Reverse();

            var subList = new List<int>();

            foreach (var p in list.Take(5))
            {
                subList.Add(p);
            }
        }

        static IEnumerable<string> FilterWord(string s)
        {
            var upWord = s.Split(' ')
                .Where(x => string.Equals(x, x.ToUpper(),
                    StringComparison.Ordinal));

            return upWord;
        }

        [Fact]
        public void Opdracht12()
        {
            var ucWord = FilterWord("The UPER CASE words are: ");
        }

        [Fact]
        public void Opdracht13()
        {
            var arr1 = new string[] { "This", "is", "a", "test" };
            var s = string.Join(", ", arr1.Select(s => s.ToString()).ToArray());
        }

        [Fact]
        public void Opdracht14()
        {
            var studentList = Students.GtStuRec();
            var students = (from stuMast in studentList
                            group stuMast by stuMast.GradePoint into g
                            orderby g.Key descending
                            select new
                            {
                                StuRecord = g.ToList()
                            }).ToList();

            students[2 - 1].StuRecord
                .ForEach(i => Console.WriteLine(" Id : {0},  Name : {1},  achieved Grade Point : {2}", i.Id, i.Name, i.GradePoint));
        }

        [Fact]
        public void Opdracht15()
        {
            string[] arr1 = { "aaa.frx", "bbb.TXT", "xyz.dbf", "abc.pdf", "aaaa.PDF", "xyz.frt", "abc.xml", "ccc.txt", "zzz.txt" };
            var fGrp = arr1.Select(file => Path.GetExtension(file).TrimStart('.').ToLower())
            .GroupBy(z => z, (fExt, extCtr) => new
            {
                Extension = fExt,
                Count = extCtr.Count()
            });

            foreach (var m in fGrp)
                Console.WriteLine("{0} File(s) with {1} Extension ", m.Count, m.Extension); ;
        }

        [Fact]
        public void Opdracht16()
        {
            var directoryFiles = Directory.GetFiles("c:/windows");
            var avgFsize = directoryFiles.Select(file => new FileInfo(file).Length).Average();
            avgFsize = Math.Round(avgFsize / 10, 1);
        }

        [Fact]
        public void Opdracht17()
        {
            var listOfString = new List<string>
        {
            "m",
            "n",
            "o",
            "p",
            "q"
        };
            var result1 = from y in listOfString
                          select y;
            var newstr = listOfString.FirstOrDefault(en => en == "o");
            listOfString.Remove(newstr);

            var result = from z in listOfString
                         select z;
        }
        [Fact]
        public void Opdracht18()
        {
            var listOfString = new List<string>
        {
            "m",
            "n",
            "o",
            "p",
            "q"
        };
            var result1 = from y in listOfString
                          select y;
            listOfString.Remove(listOfString.FirstOrDefault(en => en == "p"));


            var result = from z in listOfString
                         select z;
        }
        [Fact]
        public void Opdracht19()
        {
            var listOfString = new List<string>
        {
            "m",
            "n",
            "o",
            "p",
            "q"
        };
            var _result1 = from y in listOfString
                           select y;
            listOfString.RemoveAll(en => en == "q");

            var result = from z in listOfString
                         select z;
        }
        [Fact]
        public void Opdracht20()
        {
            var listOfString = new List<string>
        {
            "m",
            "n",
            "o",
            "p",
            "q"
        };
            var result1 = from y in listOfString
                          select y;
            listOfString.RemoveAt(3);

            var result = from z in listOfString
                         select z;
        }
        [Fact]
        public void Opdracht21()
        {
        }
        [Fact]
        public void Opdracht22()
        {
        }
        [Fact]
        public void Opdracht23()
        {
        }
        [Fact]
        public void Opdracht24()
        {
        }
        [Fact]
        public void Opdracht25()
        {
        }
        [Fact]
        public void Opdracht26()
        {
        }
        [Fact]
        public void Opdracht27()
        {
        }
        [Fact]
        public void Opdracht28()
        {
        }
        [Fact]
        public void Opdracht29()
        {
        }
        [Fact]
        public void Opdracht30()
        {
        }

    }
}