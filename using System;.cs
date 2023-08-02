using System;

class Program
{
    static void Main()
    {
        Console.Write("Telefon numarasını girin: ");
        string i = Console.ReadLine();

        Customer customer = new Customer
        {
            first_name = "CustomerFirstName" + i,
            last_name = "CustomerLastName" + i,
            email = String.Format("customer{0}@example.com", i),
            phone_number = "XXX-XXX-XXXX" + i
        };

        Console.WriteLine("Customer Oluşturuldu: ");
        Console.WriteLine("Ad: " + customer.first_name);
        Console.WriteLine("Soyad: " + customer.last_name);
        Console.WriteLine("E-posta: " + customer.email);
        Console.WriteLine("Telefon Numarası: " + customer.phone_number);
    }
}

class Customer
{
    public string first_name;
    public string last_name;
    public string email;
    public string phone_number;
}


public static class DatabaseHelper
{
    private static string connectionString = "Data Source=mydatabase.db;Version=3;";

    public static IDbConnection GetConnection()
    {
        return new SQLiteConnection(connectionString);
    }

    public static void CreateTables()
    {
        using (IDbConnection connection = GetConnection())
        {
            connection.Open();

            string createCustomerTableQuery = @"
                CREATE TABLE IF NOT EXISTS Customer (
                    customer_id INTEGER PRIMARY KEY,
                    first_name TEXT NOT NULL,
                    last_name TEXT NOT NULL,
                    email TEXT NOT NULL,
                    phone_number TEXT NOT NULL
                );";

            connection.Execute(createCustomerTableQuery);
        }
    }

    public static void InsertCustomer(Customer customer)
    {
        using (IDbConnection connection = GetConnection())
        {
            connection.Open();

            string insertQuery = @"
                INSERT INTO Customer (first_name, last_name, email, phone_number)
                VALUES (@first_name, @last_name, @email, @phone_number);";

            connection.Execute(insertQuery, customer);
        }
    }

    public static List<Customer> GetCustomers()
    {
        using (IDbConnection connection = GetConnection())
        {
            connection.Open();

            string query = "SELECT * FROM Customer;";
            return connection.Query<Customer>(query).ToList();
        }
    }

    // (Update, Delete, etc.)için
}

class Program
{
    static void Main()
    {
        // database tablosu oluşturmak için
        if (!DatabaseHelper.TablesExist())
{
    DatabaseHelper.CreateTables();
}

        // Insert 5 sample customers
        for (int i = 1; i <= 5; i++)
        {
            Customer customer = new Customer
            {
                first_name = "CustomerFirstName" + i,
                last_name = "CustomerLastName" + i,
                email = "customer" + i + "@example.com",
                phone_number = "054444444" + i
            };
            DatabaseHelper.InsertCustomer(customer);
        }

        // müşterileri listelemek için
        List<Customer> allCustomers = DatabaseHelper.GetCustomers();
        Console.WriteLine("All customers:");
        foreach (var customer in allCustomers)
        {
            Console.WriteLine($"{customer.first_name} {customer.last_name} - {customer.email}");
        }
    }
}
class Program
{
    static void Main()
    {
        // tablo oluturmak için
       // DatabaseHelper.CreateTables();
//ya da
       if (!DatabaseHelper.TablesExist())
{
    DatabaseHelper.CreateTables();
}
        // Insert 10 sample customers
        for (int i = 1; i <= 10; i++)
        {
            Customer customer = new Customer
            {
                first_name = "CustomerFirstName" + i,
                last_name = "CustomerLastName" + i,
                email = "customer" + i + "@example.com",
                phone_number = "123-456-789" + i
            };
            DatabaseHelper.InsertCustomer(customer);
        }

        // müşteri listemelemek için
        
        List<Customer> allCustomers = DatabaseHelper.GetCustomers();
        Console.WriteLine("All customers:");
        foreach (var customer in allCustomers)
        {
            Console.WriteLine($"{customer.first_name} {customer.last_name} - {customer.email}");
        }
    }
}
class Program
{
    static void Main()
    {
        // Create the tables if they don't exist
        DatabaseHelper.CreateTables();

        // Insert 10 sample products
        for (int i = 1; i <= 10; i++)
        {
            Product product = new Product
            {
                product_name = "Product" + i,
                description = "Description of Product" + i,
                //fiyat konusunda  nasıl yapıyorduk
                price = 50.25 + i,
                brand = "Brand" + i,
                category_id = i, // Assuming you have 10 categories (1 to 10)
                supplier_id = i // Assuming you have 10 suppliers (1 to 10)
            };
            DatabaseHelper.InsertProduct(product);
        }

        // List all products
        List<Product> allProducts = DatabaseHelper.GetProducts();
        Console.WriteLine("All products:");
        foreach (var product in allProducts)
        {
            Console.WriteLine($"{product.product_name} - {product.price}");
        }
    }
}
class Program
{
    static void Main()
    {
        // Create the tables if they don't exist
        DatabaseHelper.CreateTables();

        // Insert 10 sample categories
        for (int i = 1; i <= 10; i++)
        {
            Category category = new Category
            {
                category_name = "Category" + i
            };
            DatabaseHelper.InsertCategory(category);
        }

        // List all categories
        List<Category> allCategories = DatabaseHelper.GetCategories();
        Console.WriteLine("All categories:");
        foreach (var category in allCategories)
        {
            Console.WriteLine($"{category.category_name}");
        }
    }
}
class Program
{
    static void Main()
    {
        // Create the tables if they don't exist
        DatabaseHelper.CreateTables();

        // Insert 10 sample suppliers
        for (int i = 1; i <= 10; i++)
        {
            Supplier supplier = new Supplier
            {
                supplier_name = "Supplier" + i,
                contact_person = "ContactPerson" + i,
                email = "supplier" + i + "@example.com",
                phone_number = "987-654-321" + i
            };
            DatabaseHelper.InsertSupplier(supplier);
        }

        // List all suppliers
        List<Supplier> allSuppliers = DatabaseHelper.GetSuppliers();
        Console.WriteLine("All suppliers:");
        foreach (var supplier in allSuppliers)
        {
            Console.WriteLine($"{supplier.supplier_name} - {supplier.phone_number}");
        }
    }
}
class Program
{
    static void Main()
    {
        // Create the tables if they don't exist
        DatabaseHelper.CreateTables();

        // Insert 10 sample orders
        for (int i = 1; i <= 10; i++)
        {
            Order order = new Order
            {
                customer_id = i, // Assuming you have 10 customers (1 to 10)
                order_date = DateTime.Now.AddDays(-i),
                total_amount = 50.25m + i,
                shipping_address = "ShippingAddress" + i,
                payment_status = "Paid",
                fulfillment_status = "Fulfilled"
            };
            DatabaseHelper.InsertOrder(order);
        }

        // List all orders
        List<Order> allOrders = DatabaseHelper.GetOrders();
        Console.WriteLine("All orders:");
        foreach (var order in allOrders)
        {
            Console.WriteLine($"Order ID: {order.order_id}, Customer ID: {order.customer_id}, Order Date: {order.order_date}, Total Amount: {order.total_amount}");
        }
    }
}