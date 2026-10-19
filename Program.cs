using System;
using System.Linq;
using LINQ.DataSources;

// ============================================================
// Question 1
// Get all products from the Seafood category.
// ============================================================

Console.WriteLine("\n========== Question 1 ==========");

var seafoodProducts = Source.ProductList
    .Where(p => p.Category == "Seafood");

foreach (var product in seafoodProducts)
{
    Console.WriteLine($"{product.ProductName} - {product.UnitPrice:F2}");
}


// ============================================================
// Question 2
// Get only the product names from ProductList.
// ============================================================

Console.WriteLine("\n========== Question 2 ==========");

var productNames = Source.ProductList
    .Select(p => p.ProductName);

foreach (var name in productNames)
{
    Console.WriteLine(name);
}


// ============================================================
// Question 3
// Sort all products by UnitPrice ascending.
// ============================================================

Console.WriteLine("\n========== Question 3 ==========");

var sortedProducts = Source.ProductList
    .OrderBy(p => p.UnitPrice);

foreach (var product in sortedProducts)
{
    Console.WriteLine($"{product.ProductName} - {product.UnitPrice:F2}");
}


// ============================================================
// Question 4
// Get all products where UnitPrice is between 10 and 30.
// ============================================================

Console.WriteLine("\n========== Question 4 ==========");

var productsBetween10And30 = Source.ProductList
    .Where(p => p.UnitPrice >= 10 && p.UnitPrice <= 30);

foreach (var product in productsBetween10And30)
{
    Console.WriteLine($"{product.ProductName} - {product.UnitPrice:F2}");
}


// ============================================================
// Question 5
// Get in-stock products from the Condiments category.
// ============================================================

Console.WriteLine("\n========== Question 5 ==========");

var availableCondiments = Source.ProductList
    .Where(p => p.UnitsInStock > 0 &&
                p.Category == "Spices & Condiments");

foreach (var product in availableCondiments)
{
    Console.WriteLine(
        $"{product.ProductName} - Stock: {product.UnitsInStock}"
    );
}


// ============================================================
// Question 6
// Create an anonymous type with Name, Price, and StockStatus.
// ============================================================

Console.WriteLine("\n========== Question 6 ==========");

var productDetails = Source.ProductList
    .Select(p => new
    {
        Name = p.ProductName,
        Price = p.UnitPrice,
        StockStatus = p.UnitsInStock > 0
            ? "Available"
            : "Out of Stock"
    });

foreach (var product in productDetails)
{
    Console.WriteLine(
        $"{product.Name} - {product.Price:F2} - {product.StockStatus}"
    );
}


// ============================================================
// Question 7
// Print product name with its 1-based position.
// ============================================================

Console.WriteLine("\n========== Question 7 ==========");

var indexedProducts = Source.ProductList
    .Select((p, index) => new
    {
        Position = index + 1,
        Name = p.ProductName
    });

foreach (var product in indexedProducts)
{
    Console.WriteLine($"{product.Position}. {product.Name}");
}


// ============================================================
// Question 8
// Sort by Category ascending, then UnitPrice descending.
// ============================================================

Console.WriteLine("\n========== Question 8 ==========");

var productsSortedByCategoryAndPrice = Source.ProductList
    .OrderBy(p => p.Category)
    .ThenByDescending(p => p.UnitPrice);

foreach (var product in productsSortedByCategoryAndPrice)
{
    Console.WriteLine(
        $"{product.Category} - {product.ProductName} - {product.UnitPrice:F2}"
    );
}


// ============================================================
// Question 9
// Get Beverages sorted by UnitsInStock descending.
// ============================================================

Console.WriteLine("\n========== Question 9 ==========");

var beverages = Source.ProductList
    .Where(p => p.Category == "Beverages")
    .OrderByDescending(p => p.UnitsInStock);

foreach (var product in beverages)
{
    Console.WriteLine(
        $"{product.ProductName} - Stock: {product.UnitsInStock}"
    );
}


// ============================================================
// Question 10
// QUERY SYNTAX with compound from clause.
// Get orders placed in 1997 or later.
// ============================================================

Console.WriteLine("\n========== Question 10 ==========");

var ordersFrom1997 =
    from customer in Source.CustomerList
    from order in customer.Orders
    where order.OrderDate.Year >= 1997
    select new
    {
        customer.CustomerID,
        order.OrderDate
    };

foreach (var order in ordersFrom1997)
{
    Console.WriteLine(
        $"{order.CustomerID} - {order.OrderDate:yyyy-MM-dd}"
    );
}


// ============================================================
// Question 11
// Show position number alongside ProductName.
// ============================================================

Console.WriteLine("\n========== Question 11 ==========");

var productsWithPosition = Source.ProductList
    .Select((p, index) => new
    {
        Position = index + 1,
        ProductName = p.ProductName
    });

foreach (var product in productsWithPosition)
{
    Console.WriteLine(
        $"{product.Position}. {product.ProductName}"
    );
}


// ============================================================
// Question 12
// Sort words by length, then case-insensitively.
// ============================================================

Console.WriteLine("\n========== Question 12 ==========");

string[] arr =
{
    "aPPLE",
    "AbAcUs",
    "bRaNcH",
    "BlUeBeRrY",
    "ClOvEr",
    "cHeRry"
};

var sortedWords = arr
    .OrderBy(word => word.Length)
    .ThenBy(word => word, StringComparer.OrdinalIgnoreCase);

foreach (var word in sortedWords)
{
    Console.WriteLine(word);
}


// ============================================================
// Question 13
// Get words whose second letter is 'i', in reverse order.
// ============================================================

Console.WriteLine("\n========== Question 13 ==========");

// The question does not provide a specific array.
// Example array used to demonstrate the required operation.

string[] words =
{
    "apple",
    "fish",
    "bird",
    "milk",
    "tiger",
    "lion",
    "river",
    "kiwi"
};

var wordsWithSecondLetterI = words
    .Where(word => word.Length > 1 &&
                   char.ToLowerInvariant(word[1]) == 'i')
    .Reverse()
    .ToList();

foreach (var word in wordsWithSecondLetterI)
{
    Console.WriteLine(word);
}