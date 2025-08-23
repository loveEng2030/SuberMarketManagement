using System;

internal class Program
{
    // تخزين البيانات في Arrays 
    static string[] NamesCustmer = new string[10000];
    static string[] PasswordsCustmer = new string[10000];
    static string[] EmailsCustmer = new string[10000];
    static string[] PhonesCustmer = new string[10000];
    static int accountCountCustmer = 0;

    //-----**-**-*-**-*-*-*--***-*--***-*-*-*-*-*-*-*-*-*-*-*-*--**-*-*--**----\\
    // متغيرات الادمن (حساب واحد بس)
    static string AdminName;
    static string AdminPassword;
    static string AdminEmail;
    static string AdminPhone;
    static int accountCountAdmin = 0;
    ///*************************************************************************\\
    ///ارري فيها المنتجات 
    static string[] productNames = new string[1000];
    static int[] productPrices = new int[1000];
    static int[] productQuantities = new int[1000];
    static int productCount = 0;

    //static int productCount = productNames.Length;
    //--------------------------

    static string[] Cart = new string[productNames.Length];
    static int cartCount = 0;

    //*//*/*/*/*/*/*//*//*//*/*/*/*/*/*/*/*/*/*/**//*/*/*/*//*/*/*/*/*/*////*/*/*/*/*//*/*/*/*/*/*/*/*/*/*/*/*/*\\
    static void Main(string[] args)

    {
        AddInitialProducts();
        while (true)
        {
            ShowMenu();
            int choice = GetChoice();

            if (choice == 1) // Create Admin
            {
                Console.Clear();
                CreateAccountAdmin();
                AdminMenu(); //  استدعاء القائمة الجديدة
            }
            else if (choice == 2) // Create Customer
            {
                Console.Clear();
                CreatAccountCostumer();
                while (true)
                {
                    Console.Clear();
                    MenuSuber();
                    int choise2 = GetChoMenuCustmer();
                    if (choise2 == 8) break; //  الخروج عند 8
                    product(choise2); //  تمرير الاختيار
                }
            }
            else if (choice == 3) // Login Admin
            {
                Console.Clear();
                LoginAdmain();
                AdminMenu(); //  القائمة بعد تسجيل الدخول
            }
            else if (choice == 4) // Login Customer
            {
                Console.Clear();
                LoginCostumer();
                while (true)
                {
                    Console.Clear();
                    MenuSuber();
                    int choise2 = GetChoMenuCustmer();
                    if (choise2 == 8) break;
                    product(choise2); //  تمرير الاختيار
                }
            }
            else if (choice == 5)
            {
                Console.Clear();
                ShowAllAccountsCustmer();
            }
            else if (choice == 6)
            {
                Console.Clear();
                Console.WriteLine("\t\t\t\t\t thank you for using our supermarket ");
                break;
            }
            Console.Clear();
        }
    }
    //--/**//*/**/*//*/**//*/*/*/*/*/*/*/*/*/*/*/*/*/*/*/*/*/*/*/*/*/*/*/**//*/*/*/*/*/*/*/*/*/*/*/*/*/*/*/*/*/*/*/*/*/*/*/*///*--\\

    // دالة عرض القائمة
    static void ShowMenu()
    {
        //Console.Clear();
        Console.ForegroundColor = ConsoleColor.Green;
        Console.WriteLine("\t\t\t\t|---------------------------------------------------|\n ");
        Console.WriteLine("\t\t\t\t|       Hello Dear In Our Supermaket managment ...! |\n");
        Console.WriteLine("\t\t\t\t|---------------------------------------------------|\n ");
        Console.ForegroundColor = ConsoleColor.Yellow;
        Console.WriteLine("\t\t\t\t\t 1: Register New Account (admin).. ");
        Console.WriteLine("\t\t\t\t\t 2: Register New Account (custmer).. ");
        Console.WriteLine("\t\t\t\t\t 3: Login Your Account(admain).. ");
        Console.WriteLine("\t\t\t\t\t 4: Login Your Account(custmer).. ");
        Console.WriteLine("\t\t\t\t\t 5: View Accounts Data.. ");
        //Console.WriteLine("\t\t\t\t\t 4:  ");
        Console.WriteLine("\t\t\t\t\t 6: Exit .. \n");
        Console.WriteLine("\t\t\t\t\t Please Enter Choice .. \n");
        Console.WriteLine("\t\t\t\t\t ");
        Console.Write("\t\t\t\t\t ");
        Console.ResetColor();
    }

    // دالة الحصول على اختيار المستخدم
    static int GetChoice()
    {
        int choice;
        while (!int.TryParse(Console.ReadLine(), out choice) || choice < 1 || choice > 6)
        {
            Console.ForegroundColor = ConsoleColor.Red;
            Console.WriteLine("\t\t\t\t\t Please Enter a Valid Choice (1-6) ..");
            Console.ResetColor();
            Console.Write("\t\t\t\t\t ");

        }
        return choice;
    }

    // للزباىن دالة عرض كل الحسابات

    static void ShowAllAccountsCustmer()
    {
        if (accountCountCustmer == 0)
        {
            Console.ForegroundColor = ConsoleColor.Red;
            Console.WriteLine("\t\t\t\t\t No accounts registered.");
            Console.ResetColor();
            return;
        }
        Console.ForegroundColor = ConsoleColor.Blue;
        //Console.WriteLine("\nAll Accounts:");
        Console.ForegroundColor = ConsoleColor.Green;
        for (int i = 0; i < accountCountCustmer; i++)
        {
            Console.WriteLine($"\t\t\t\t\t  حسابات الزباىن \n {i + 1} Name: {NamesCustmer[i]}\n\t\t\t\t\t Email: {EmailsCustmer[i]}\n\t\t\t\t\t" +
                $" Phone: {PhonesCustmer[i]}\n\t\t\t\t\t Password: {PasswordsCustmer[i]}\n\t\t\t\t\t ------------------------ \n\n");

        }
        Console.ResetColor();
    }

    //*-*-*-*-*-*-*--******-**-*--**-*--**-*-*-*-**-*-*-*--*--**-**-*-*-*-*-*-*---\\

    //دالة انشاء حساب للادمن
    static void CreateAccountAdmin()
    {
        Console.WriteLine("\t\t\t\t\t Hello dear to create account for admin");

        Console.ForegroundColor = ConsoleColor.Cyan;
        Console.WriteLine("\t\t\t\t\t Enter Your Name.. ");
        Console.Write("\t\t\t\t\t ");
        Console.ResetColor();
        AdminName = Console.ReadLine();

        Console.ForegroundColor = ConsoleColor.Cyan;
        Console.WriteLine("\t\t\t\t\t Enter Password.. ");
        Console.Write("\t\t\t\t\t ");
        Console.ResetColor();
        AdminPassword = Console.ReadLine();

        while (AdminPassword.Length < 6)
        {
            Console.ForegroundColor = ConsoleColor.Red;
            Console.WriteLine("\t\t\t\t\t Please enter a strong password..!\n");
            Console.ResetColor();
            Console.Write("\t\t\t\t\t ");
            AdminPassword = Console.ReadLine();
        }

        Console.ForegroundColor = ConsoleColor.Cyan;
        Console.WriteLine("\t\t\t\t\t Enter Gmail.. ");
        Console.Write("\t\t\t\t\t ");
        Console.ResetColor();
        AdminEmail = Console.ReadLine();

        while (!AdminEmail.Contains("@gmail.com"))
        {
            Console.ForegroundColor = ConsoleColor.Red;
            Console.WriteLine("\t\t\t\t\t Please enter a valid email (user@gmail.com)..!\n");
            Console.ResetColor();
            Console.Write("\t\t\t\t\t ");
            AdminEmail = Console.ReadLine();
        }

        Console.ForegroundColor = ConsoleColor.Cyan;
        Console.WriteLine("\t\t\t\t\t Enter Phone Number.. ");
        Console.Write("\t\t\t\t\t ");
        Console.ResetColor();
        AdminPhone = Console.ReadLine();

        Console.ForegroundColor = ConsoleColor.Green;
        Console.Write("\t\t\t\t\t Account Created Successfully!");
        Console.ResetColor();
        accountCountAdmin++;

    }
    //دالة انشاء حساب  للزبون
    static void CreatAccountCostumer()
    {
        Console.ForegroundColor = ConsoleColor.Cyan;
        Console.WriteLine("\t\t\t\t\t Enter Your Name.. ");
        Console.Write("\t\t\t\t\t ");
        Console.ResetColor();
        NamesCustmer[accountCountCustmer] = Console.ReadLine();
        Console.ForegroundColor = ConsoleColor.Cyan;
        Console.WriteLine("\t\t\t\t\t Enter Password.. ");
        Console.Write("\t\t\t\t\t ");
        Console.ResetColor();
        PasswordsCustmer[accountCountCustmer] = Console.ReadLine();
        while (PasswordsCustmer[accountCountCustmer].Length < 6)
        {
            Console.ForegroundColor = ConsoleColor.Red;
            Console.WriteLine("\t\t\t\t\t Please enter a strong password..!\n");
            Console.ResetColor();
            Console.Write("\t\t\t\t\t ");
            PasswordsCustmer[accountCountCustmer] = Console.ReadLine();
        }
        Console.ForegroundColor = ConsoleColor.Cyan;
        Console.WriteLine("\t\t\t\t\t Enter Gmail.. ");
        Console.Write("\t\t\t\t\t ");
        Console.ResetColor();
        EmailsCustmer[accountCountCustmer] = Console.ReadLine();

        while (!EmailsCustmer[accountCountCustmer].Contains("@gmail.com"))
        {
            Console.ForegroundColor = ConsoleColor.Red;
            Console.WriteLine("\t\t\t\t\t Please enter a valid email (user@gmail.com)..!\n");
            Console.ResetColor();
            Console.Write("\t\t\t\t\t ");
            EmailsCustmer[accountCountCustmer] = Console.ReadLine();
        }

        Console.ForegroundColor = ConsoleColor.Cyan;
        //Console.WriteLine("\t\t\t\t\t Enter Phone Number.. ");
        //Console.Write("\t\t\t\t\t ");
        Console.ResetColor();
        //Phones[accountCount] = Console.ReadLine();
        //Console.Clear();
        accountCountCustmer++;
        Console.ForegroundColor = ConsoleColor.Green;
        Console.Write(" Account Created Successfully!\n");
        Console.ResetColor();
    }
    //دالة تسجيل الدخول للادمن
    static void LoginAdmain()
    {
        Console.ForegroundColor = ConsoleColor.Cyan;
        Console.WriteLine("\t\t\t\t\t Enter Your Name.. ");
        Console.Write("\t\t\t\t\t ");
        Console.ResetColor();
        string name = Console.ReadLine();

        Console.ForegroundColor = ConsoleColor.Cyan;
        Console.WriteLine("\t\t\t\t\t Enter Password.. ");
        Console.Write("\t\t\t\t\t ");
        Console.ResetColor();
        string password = Console.ReadLine();
        Console.Write("\t\t\t\t\t ");

        bool found = false;
        for (int i = 0; i < accountCountAdmin; i++)
        {
            if (AdminName == name && AdminPassword == password)
            {
                Console.ForegroundColor = ConsoleColor.Green;
                Console.WriteLine(" \t\t\t\t\t Login Successful! Welcome " + name);
                Console.ResetColor();
                found = true;
                break;
            }
        }

        if (!found)
        {
            Console.ForegroundColor = ConsoleColor.Red;
            Console.WriteLine("\t\t\t\t\t Wrong Name or Password!");
            Console.ResetColor();

            Console.WriteLine("\t\t\t\t\t Do you want to create a new Admin account? (y/n)");
            Console.Write("\t\t\t\t\t ");
            string choice = Console.ReadLine().ToLower();
            if (choice == "y")
            {
                CreateAccountAdmin();
            }
            else
            {
                LoginAdmain(); // يرجع يحاول تاني
            }
        }
    }
    //دالة تسجيل الدخول للزبون
    static void LoginCostumer()
    {
        Console.ForegroundColor = ConsoleColor.Cyan;
        Console.WriteLine("\t\t\t\t\t Enter Your Name.. ");
        Console.Write("\t\t\t\t\t ");
        Console.ResetColor();
        string name = Console.ReadLine();

        Console.ForegroundColor = ConsoleColor.Cyan;
        Console.WriteLine("\t\t\t\t\t Enter Password.. ");
        Console.Write("\t\t\t\t\t ");
        Console.ResetColor();
        string password = Console.ReadLine();
        Console.Write("\t\t\t\t\t ");

        bool found = false;
        for (int i = 0; i < accountCountCustmer; i++)
        {
            if (NamesCustmer[i] == name && PasswordsCustmer[i] == password)
            {
                Console.ForegroundColor = ConsoleColor.Green;
                Console.WriteLine(" \t\t\t\t\t Login Successful! Welcome " + name);
                Console.ResetColor();
                found = true;
                break;
            }
        }

        if (!found)
        {
            Console.ForegroundColor = ConsoleColor.Red;
            Console.WriteLine("\t\t\t\t\t Wrong Name or Password!");
            Console.ResetColor();

            Console.WriteLine("\t\t\t\t\t Do you want to create a new Customer account? (y/n)");
            Console.Write("\t\t\t\t\t ");
            string choice = Console.ReadLine().ToLower();
            if (choice == "y")
            {
                CreatAccountCostumer();
            }
            else
            {
                LoginCostumer(); // يرجع يحاول تاني
            }
        }
    }


    //---/*/*/*/*/**/*//*/*/*/*/*/*/*/*/*/*/*/*/*/*/*/*/*/*/*/*/*/*/*/*/*/*/*/*/*---\\

    //دالة قاىمة المنتجات للزبون 
    static void MenuSuber()
    {
        Console.ForegroundColor = ConsoleColor.Green;
        Console.WriteLine("\t\t\t\t|------------------------------------------------|\n ");
        Console.WriteLine("\t\t\t\t|       Hello Dear In Subermarket KHire Thman..! |\n");
        Console.WriteLine("\t\t\t\t|------------------------------------------------|\n ");
        Console.ForegroundColor = ConsoleColor.Red;
        Console.WriteLine("\t\t\t\t\t Note: We do not support or sell any Israeli products!!!!!!! ");
        Console.ForegroundColor = ConsoleColor.Yellow;
        Console.WriteLine("\t\t\t\t\t 1: Fruits & Vegetables .. ");
        Console.WriteLine("\t\t\t\t\t 2: Beverages.. ");
        Console.WriteLine("\t\t\t\t\t 3: Canned Foods .. ");
        Console.WriteLine("\t\t\t\t\t 4: Dairy Products .. ");
        Console.WriteLine("\t\t\t\t\t 5: Bakery ");
        Console.WriteLine("\t\t\t\t\t 6: Meat & Fish ");
        //Console.WriteLine("\t\t\t\t\t 4:  ");
        Console.WriteLine("\t\t\t\t\t 7: Cleaning Products ");
        Console.WriteLine("\t\t\t\t\t 8: buy product .. \n");
        Console.WriteLine("\t\t\t\t\t 9: Exit .. \n");

        Console.WriteLine("\t\t\t\t\t Please Enter Choice .. \n");
        Console.WriteLine("\t\t\t\t\t ");
        Console.Write("\t\t\t\t\t ");
        Console.ResetColor();
    }
    //دالة الحصول علي الاختيار 
    static int GetChoMenuCustmer()
    {
        int cho;
        while (!int.TryParse(Console.ReadLine(), out cho) || cho < 1 || cho > 9)
        {
            Console.ForegroundColor = ConsoleColor.Red;
            Console.WriteLine("\t\t\t\t\t Please Enter a Valid Choice (1-9) ..");
            Console.ResetColor();
            Console.Write("\t\t\t\t\t ");

        }
        return cho;
    }
    static void product(int choice)
    {
        switch (choice)
        {
            case 1:
                Console.WriteLine("\t\t\t\t\t Fruits & Vegetables:");
                Console.WriteLine("\t\t\t\t\t Apple - 50 EGP - Qty: 30");
                Console.WriteLine("\t\t\t\t\t Banana - 25 EGP - Qty: 50");
                Console.WriteLine("\t\t\t\t\t Orange - 30 EGP - Qty: 40");
                Console.WriteLine("\t\t\t\t\t Mango - 60 EGP - Qty: 20");
                Console.WriteLine("\t\t\t\t\t Tomato - 15 EGP - Qty: 100");
                Console.WriteLine("\t\t\t\t\t Carrot - 20 EGP - Qty: 70");
                Console.WriteLine("\t\t\t\t\t Cucumber - 18 EGP - Qty: 80");
                BuyProducts();
                break;

            case 2:
                Console.WriteLine("\t\t\t\t\t Beverages:");
                Console.WriteLine("\t\t\t\t\t Water Bottle - 10 EGP - Qty: 200");
                Console.WriteLine("\t\t\t\t\t Coca Cola - 15 EGP - Qty: 100");
                Console.WriteLine("\t\t\t\t\t Pepsi - 15 EGP - Qty: 100");
                Console.WriteLine("\t\t\t\t\t Orange Juice - 25 EGP - Qty: 60");
                Console.WriteLine("\t\t\t\t\t Milk - 20 EGP - Qty: 80");
                Console.WriteLine("\t\t\t\t\t Coffee - 50 EGP - Qty: 40");
                Console.WriteLine("\t\t\t\t\t Tea - 30 EGP - Qty: 50");
                BuyProducts();
                break;

            case 3:
                Console.WriteLine("\t\t\t\t\t Canned Foods:");
                Console.WriteLine("\t\t\t\t\t Canned Beans - 18 EGP - Qty: 50");
                Console.WriteLine("\t\t\t\t\t Tuna Can - 25 EGP - Qty: 40");
                Console.WriteLine("\t\t\t\t\t Tomato Paste - 12 EGP - Qty: 70");
                Console.WriteLine("\t\t\t\t\t Sweet Corn - 20 EGP - Qty: 60");
                BuyProducts();
                break;

            case 4:
                Console.WriteLine("\t\t\t\t\t Dairy Products:");
                Console.WriteLine("\t\t\t\t\t Cheese - 40 EGP - Qty: 50");
                Console.WriteLine("\t\t\t\t\t Yogurt - 10 EGP - Qty: 100");
                Console.WriteLine("\t\t\t\t\t Butter - 30 EGP - Qty: 40");
                Console.WriteLine("\t\t\t\t\t Cream - 35 EGP - Qty: 30");
                BuyProducts();
                break;

            case 5:
                Console.WriteLine("\t\t\t\t\t Bakery:");
                Console.WriteLine("\t\t\t\t\t Bread - 5 EGP - Qty: 200");
                Console.WriteLine("\t\t\t\t\t Croissant - 12 EGP - Qty: 100");
                Console.WriteLine("\t\t\t\t\t Cake - 50 EGP - Qty: 40");
                Console.WriteLine("\t\t\t\t\t Biscuits - 15 EGP - Qty: 80");
                BuyProducts();
                break;

            case 6:
                Console.WriteLine("\t\t\t\t\t Meat & Fish:");
                Console.WriteLine("\t\t\t\t\t Chicken Breast - 120 EGP - Qty: 30");
                Console.WriteLine("\t\t\t\t\t Beef - 250 EGP - Qty: 20");
                Console.WriteLine("\t\t\t\t\t Fish Fillet - 180 EGP - Qty: 25");
                Console.WriteLine("\t\t\t\t\t Sausages - 90 EGP - Qty: 35");
                BuyProducts();
                break;

            case 7:
                Console.WriteLine("\t\t\t\t\t Cleaning Products:");
                Console.WriteLine("\t\t\t\t\t Dishwashing Liquid - 25 EGP - Qty: 50");
                Console.WriteLine("\t\t\t\t\t Laundry Detergent - 70 EGP - Qty: 40");
                Console.WriteLine("\t\t\t\t\t Soap - 10 EGP - Qty: 100");
                Console.WriteLine("\t\t\t\t\t Shampoo - 50 EGP - Qty: 30");
                BuyProducts();
                break;
                case 8:
                BuyProducts();
                    break;
                case 9:
                  return ;

            default:
                Console.ForegroundColor = ConsoleColor.Red;
                Console.WriteLine("\t\t\t\t\t Invalid choice, please try again.");
                Console.ResetColor();
                break;
        }
    }

    //****-**-*-*-*-*-*-*-*-*-*-*-*-**-*-*-*-*-*-*-*-*-*-*-*-*-*-*-*-*-*-*-***\\

    //دالة القاىمة للادمن
    static void AdminMenu()

    {
        int choice;
        do
        {
            Console.Clear();
            Console.ForegroundColor = ConsoleColor.Yellow;
            Console.WriteLine("\t\t\t\t\t Admin Menu ");
            Console.WriteLine("\t\t\t\t\t 1. Add Product");
            Console.WriteLine("\t\t\t\t\t 2. Remove Product");
            Console.WriteLine("\t\t\t\t\t 3. View All Products");
            Console.WriteLine("\t\t\t\t\t 4. Back to Main Menu");
            Console.Write("\t\t\t\t\t Enter your choice: ");

            while (!int.TryParse(Console.ReadLine(), out choice) || choice < 1 || choice > 4)
            {
                Console.ForegroundColor = ConsoleColor.Red;
                Console.WriteLine("\t\t\t\t\t Please Enter a Valid Choice (1-4) ..");
                Console.ResetColor();
                Console.Write("\t\t\t\t\t ");

            }
            //return choice;

            switch (choice)
            {
                case 1:
                    AddProduct();
                    break;
                case 2:
                    RemoveProduct();
                    break;
                case 3:
                    DisplayProducts();
                    break;
                case 4:
                    Console.WriteLine("\t\t\t\t\t Returning to main menu...");
                    break;
                default:
                    Console.ForegroundColor = ConsoleColor.Red;
                    Console.WriteLine("\t\t\t\t\t Invalid choice!");
                    Console.ResetColor();
                    break;
            }

            Console.WriteLine("\n \t\t\t\t\t Press Enter to continue...");
            Console.ReadKey();

        } while (choice != 4);
    }
    static void AddInitialProducts()
    {
        string[] names = { "Apple", "Banana", "Orange", "Mango", "Tomato", "Carrot", "Cucumber",
    "Water Bottle", "Coca Cola", "Pepsi", "Orange Juice", "Milk", "Coffee", "Tea",
    "Canned Beans", "Tuna Can", "Tomato Paste", "Sweet Corn",
    "Cheese", "Yogurt", "Butter", "Cream",
    "Bread", "Croissant", "Cake", "Biscuits",
    "Chicken Breast", "Beef", "Fish Fillet", "Sausages",
    "Dishwashing Liquid", "Laundry Detergent", "Soap", "Shampoo" };

        int[] prices = { 50, 25, 30, 60, 15, 20, 18,
    10, 15, 15, 25, 20, 50, 30,
    18, 25, 12, 20,
    40, 10, 30, 35,
    5, 12, 50, 15,
    120, 250, 180, 90,
    25, 70, 10, 50 };

        int[] quantities = { 30, 50, 40, 20, 100, 70, 80,
    200, 100, 100, 60, 80, 40, 50,
    50, 40, 70, 60,
    50, 100, 40, 30,
    200, 100, 40, 80,
    30, 20, 25, 35,
    50, 40, 100, 30 };

        for (int i = 0; i < names.Length; i++)
        {
            productNames[productCount] = names[i];
            productPrices[productCount] = prices[i];
            productQuantities[productCount] = quantities[i];
            productCount++;
        }
    }

    //دالة اضافة منتج خاصة بالادمن
    static void AddProduct()
    {
        Console.Write("\t\t\t\t\t Enter product name: ");
        string name = Console.ReadLine();

        Console.Write("\t\t\t\t\t Enter price: ");
        int price = int.Parse(Console.ReadLine());

        Console.Write("\t\t\t\t\t Enter quantity (1-100): ");
        int quantity = int.Parse(Console.ReadLine());

        while (quantity < 1 || quantity > 100) //  الكمية تبقى من 1 لحد 100
        {
            Console.ForegroundColor = ConsoleColor.Red;
            Console.WriteLine("\t\t\t\t\t Please Enter a Valid Quantity (1-100) ..");
            Console.ResetColor();
            Console.Write("\t\t\t\t\t Enter quantity again: ");
            quantity = int.Parse(Console.ReadLine()); 
        }

        // حفظ المنتج
        productNames[productCount] = name;
        productPrices[productCount] = price;
        productQuantities[productCount] = quantity;
        productCount++;

        Console.ForegroundColor = ConsoleColor.Green;
        Console.WriteLine("\t\t\t\t\t Product Added Successfully!");
        Console.ResetColor();
    }

    //دالة حذف منتج خاصى بالادمن
    static void RemoveProduct()
    {
        Console.ForegroundColor = ConsoleColor.Red;
        Console.Write("\t\t\t\t\t Enter product name to remove: ");
        string name = Console.ReadLine();
        int index = -1;

        for (int i = 0; i < productCount; i++)
        {
            if (productNames[i].Equals(name, StringComparison.OrdinalIgnoreCase))
            {
                index = i;
                break;
            }
        }

        if (index != -1)
        {
            for (int i = index; i < productCount - 1; i++)
            {
                productNames[i] = productNames[i + 1];
                productPrices[i] = productPrices[i + 1];
                productQuantities[i] = productQuantities[i + 1];
            }
            productCount--;
            Console.WriteLine($"\t\t\t\t\t Product '{name}' removed successfully!");
        }
        else
        {
            Console.WriteLine("\t\t\t\t\t Product not found!");
        }
        Console.ResetColor ();
    }
    // للادمن دالة عرض كل المنتجات
    static void DisplayProducts()
    {
        Console.WriteLine("\t\t\t\t\t Available Products:");
        for (int i = 0; i < productCount; i++)
        {
            Console.WriteLine($"{i + 1}. {productNames[i]} - {productPrices[i]} EGP - Qty: {productQuantities[i]}");
        }
    }
    //عرض المنتجات للزبون
    static void ShowProducts()
    {
        Console.WriteLine("\n\t\t\t\t Product List:\n");

        for (int i = 0; i < productNames.Length; i++)
        {
            Console.WriteLine($"\t\t\t\t {i + 1}: {productNames[i]}");
        }
        Console.WriteLine("\t\t\t\t 0: Show Cart & Exit\n");
    }
    //دالة شراء المنتجات
    static void BuyProducts()
    {
        //while (true)
        {
            ShowProducts();
            Console.Write("\t\t\t\t Choose Product Number: ");
            int choice;
            if (!int.TryParse(Console.ReadLine(), out choice))
                //continue;

            if (choice == 0) // Show cart & exit
            {
                ShowCart();
                //break;
            }
            else if (choice >= 1 && choice <= productNames.Length)
            {
                Cart[cartCount] = productNames[choice - 1];
                cartCount++;

                Console.ForegroundColor = ConsoleColor.Green;
                Console.WriteLine($"\t\t\t\t {productNames[choice - 1]} Added to Cart.");
                Console.ResetColor();
            }
            else
            {
                Console.ForegroundColor = ConsoleColor.Red;
                Console.WriteLine("\t\t\t\t Invalid Choice!");
                Console.ResetColor();
            }
        }
    }
    //دالة رؤية السلة
    static void ShowCart()
    {
        Console.WriteLine("\n\t\t\t\t Your Cart:\n");
        for (int i = 0; i < cartCount; i++)
        {
            Console.WriteLine($"\t\t\t\t {i + 1}: {Cart[i]}");
        }
        Console.WriteLine($"\t\t\t\t -------------------------");
        Console.WriteLine($"\t\t\t\t Total Items: {cartCount}\n");
    }
}