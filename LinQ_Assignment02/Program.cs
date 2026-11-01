namespace LinQ_Assignment02
{
    public class Program
    {
        #region Data Lists
        public static List<Product> ProductList = new List<Product>
        {
            new Product { ProductID = 1, ProductName = "Chai", Category = "Beverages", UnitPrice = 18.00M, UnitsInStock = 39 },
            new Product { ProductID = 2, ProductName = "Chang", Category = "Beverages", UnitPrice = 19.00M, UnitsInStock = 17 },
            new Product { ProductID = 3, ProductName = "Aniseed Syrup", Category = "Condiments", UnitPrice = 10.00M, UnitsInStock = 13 },
            new Product { ProductID = 4, ProductName = "Ikura", Category = "Seafood", UnitPrice = 31.00M, UnitsInStock = 31 },
            new Product { ProductID = 5, ProductName = "Konbu", Category = "Seafood", UnitPrice = 6.00M, UnitsInStock = 24 },
            new Product { ProductID = 6, ProductName = "Carnarvon Tigers", Category = "Seafood", UnitPrice = 62.50M, UnitsInStock = 42 },
            new Product { ProductID = 7, ProductName = "Escargots", Category = "Seafood", UnitPrice = 13.25M, UnitsInStock = 62 },
            new Product { ProductID = 18, ProductName = "Cote de Blaye", Category = "Beverages", UnitPrice = 263.50M, UnitsInStock = 17 }
        };

        public static List<Customer> CustomerList = new List<Customer>
        {
            new Customer { CustomerID = "ALFKI", CompanyName = "Alfreds Futterkiste", Country = "Germany", Orders = new List<Order> { new Order { OrderID = 1, Total = 500 }, new Order { OrderID = 2, Total = 300 } } },
            new Customer { CustomerID = "ANATR", CompanyName = "Ana Trujillo", Country = "Mexico", Orders = new List<Order> { new Order { OrderID = 3, Total = 150 } } },
            new Customer { CustomerID = "ANTON", CompanyName = "Antonio Moreno", Country = "Mexico", Orders = new List<Order> { new Order { OrderID = 4, Total = 900 } } },
            new Customer { CustomerID = "AROUT", CompanyName = "Around the Horn", Country = "UK", Orders = new List<Order> { new Order { OrderID = 5, Total = 450 } } }
        }; 
        #endregion
        static void Main(string[] args)
        {

            #region Q1
            Console.WriteLine("---Q1---");
            var top3Expensive = ProductList
                .OrderByDescending(p => p.UnitPrice)
                .Take(3);

            foreach (var item in top3Expensive)
                Console.WriteLine(item);
            Console.WriteLine();
            #endregion

            #region Q2
            Console.WriteLine("---Q2---");
            int pageNumber = 2;
            int pageSize = 5;

            var page2Products = ProductList
                .Skip((pageNumber - 1) * pageSize)
                .Take(pageSize);

            foreach (var item in page2Products)
                Console.WriteLine(item);
            Console.WriteLine();
            #endregion

            #region Q3
            Console.WriteLine("---Q3---");
            var cheapProducts = ProductList
                .OrderBy(p => p.UnitPrice)
                .TakeWhile(p => p.UnitPrice < 25);

            foreach (var item in cheapProducts)
                Console.WriteLine(item);
            Console.WriteLine();
            #endregion

            #region Q4
            Console.WriteLine("---Q4---");
            bool allSeafoodInStock = ProductList
                .Where(p => p.Category == "Seafood")
                .All(p => p.UnitsInStock > 0);

            Console.WriteLine($"All Seafood in Stock: {allSeafoodInStock}");
            Console.WriteLine();
            #endregion

            #region Q5
            Console.WriteLine("---Q5---");
            int[] ids = { 3, 9, 13, 18 };
            bool containsNine = ids.Contains(9);

            Console.WriteLine($"Contains 9: {containsNine}");
            Console.WriteLine();
            #endregion

            #region Q6
            Console.WriteLine("---Q6---");
            var categoriesCount = ProductList
                .GroupBy(p => p.Category);

            foreach (var group in categoriesCount)
            {
                Console.WriteLine($"Category: {group.Key} | Count: {group.Count()}");
            }
            Console.WriteLine();
            #endregion

            #region Q7
            Console.WriteLine("---Q7---");
            var categoryProductNames = ProductList
                .GroupBy(
                    p => p.Category,
                    p => p.ProductName,
                    (category, names) => new
                    {
                        Category = category,
                        ProductNames = names
                    });

            foreach (var group in categoryProductNames)
            {
                Console.WriteLine($"Category: {group.Category}");
                foreach (var name in group.ProductNames)
                {
                    Console.WriteLine($"   - {name}");
                }
            }
            Console.WriteLine();
            #endregion

            #region Q8
            Console.WriteLine("---Q8---");
            var categoriesMoreThan3 = ProductList
                .GroupBy(p => p.Category)
                .Where(g => g.Count() > 3)
                .Select(g => g.Key);

            foreach (var category in categoriesMoreThan3)
                Console.WriteLine(category);
            Console.WriteLine();
            #endregion

            #region Q9
            Console.WriteLine("---Q9---");
            var customerStatsByCountry =
                from c in CustomerList
                group c by c.Country into countryGroup
                select new
                {
                    Country = countryGroup.Key,
                    Count = countryGroup.Count(),
                    TotalOrderValue = countryGroup.SelectMany(c => c.Orders).Sum(o => o.Total)
                };

            foreach (var stat in customerStatsByCountry)
            {
                Console.WriteLine($"Country: {stat.Country} | Customers: {stat.Count} | Total Order Value: ${stat.TotalOrderValue}");
            }
            Console.WriteLine();
            #endregion

            #region Q10
            Console.WriteLine("---Q10---");
            int totalUnitsInStock = ProductList.Sum(p => p.UnitsInStock);

            Console.WriteLine($"Total Units in Stock: {totalUnitsInStock}");
            Console.WriteLine();
            #endregion

            #region Q11
            Console.WriteLine("--- Q11---");
            decimal cheapestPrice = ProductList.Min(p => p.UnitPrice);
            decimal mostExpensivePrice = ProductList.Max(p => p.UnitPrice);

            Console.WriteLine($"Cheapest Price: ${cheapestPrice}");
            Console.WriteLine($"Most Expensive Price: ${mostExpensivePrice}");
            Console.WriteLine();
            #endregion

            #region Q12
            Console.WriteLine("---Q12---");
            var distinctCategories = ProductList
                .Select(p => p.Category)
                .Distinct();

            foreach (var category in distinctCategories)
                Console.WriteLine(category);
            Console.WriteLine();
            #endregion

            #region Q13
            Console.WriteLine("--- Q13---");
            int[] setA = { 1, 3, 5, 7, 9, 11, 13 };
            int[] setB = { 3, 6, 9, 12, 15, 13 };

            var inAButNotB = setA.Except(setB);

            foreach (var id in inAButNotB)
                Console.WriteLine(id);
            Console.WriteLine();
            #endregion

            #region Q14
            Console.WriteLine("---Q14---");
            string[] list1 = { "Germany", "France", "UK", "Spain" };
            string[] list2 = { "france", "SPAIN", "Italy" };

            var diffCountries = list1.Except(list2, StringComparer.OrdinalIgnoreCase);

            foreach (var country in diffCountries)
                Console.WriteLine(country);
            Console.WriteLine();
            #endregion

            #region Q15
            Console.WriteLine("---Q15---");
            Dictionary<int, Product> productDict = ProductList.ToDictionary(p => p.ProductID);

            if (productDict.TryGetValue(18, out Product product18))
            {
                Console.WriteLine(product18);
            }
            else
            {
                Console.WriteLine("Product with ID 18 not found.");
            }
            Console.WriteLine();
            #endregion

            #region Q16
            Console.WriteLine("---Q16---");
            var firstOver50 = ProductList.First(p => p.UnitPrice > 50);

            Console.WriteLine(firstOver50);
            Console.WriteLine();
            #endregion

            #region Q17
            Console.WriteLine("--- Q17---");
            var firstOver500 = ProductList.FirstOrDefault(p => p.UnitPrice > 500);

            Console.WriteLine(firstOver500 != null ? firstOver500.ToString() : "Null (No product > $500 found)");
            Console.WriteLine();
            #endregion

            #region Q18
            Console.WriteLine("---Q18---");
            var tableOf7 = Enumerable.Range(1, 12)
                .Select(n => $"7 x {n} = {7 * n}");

            foreach (var row in tableOf7)
                Console.WriteLine(row);
            Console.WriteLine();
            #endregion

            #region Q19
            Console.WriteLine("--- Q19---");
            var evenNumbers = Enumerable.Range(1, 30)
                .Where(n => n % 2 == 0);

            Console.WriteLine(string.Join(", ", evenNumbers));
            Console.WriteLine();
            #endregion

            #region Q20
            Console.WriteLine("--- Q20---");
            var combinedNames = ProductList.Select(p => p.ProductName).Take(3)
                .Concat(CustomerList.Select(c => c.CompanyName).Take(3));

            foreach (var name in combinedNames)
                Console.WriteLine(name);
            Console.WriteLine();
            #endregion

            #region Q21
            Console.WriteLine("---Q21---");
            var pairedSequence = ProductList.Zip(
                CustomerList,
                (product, customer) => $"{product.ProductName} sold to {customer.CompanyName}");

            foreach (var pair in pairedSequence)
                Console.WriteLine(pair);
            Console.WriteLine();
            #endregion
        }
    }
}
