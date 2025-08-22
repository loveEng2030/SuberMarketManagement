using System;

internal class Program
{
    // تخزين البيانات في Arrays 
    static string[] Names = new string[10000];
    static string[] Passwords = new string[10000];
    static string[] Emails = new string[10000];
    static string[] Phones = new string[10000];
    static int accountCount = 0;
    //-----------------------------------------------\\
    static void Main(string[] args)
    {
        while (true)
        {
            ShowMenu();
            int choice = GetChoice();

            if (choice == 1) // Create Admin
            {
                CreatAccountAdmain();
                MenuAdmain(); // يفتح قائمة الأدمن على طول
                int cho = GetChoMenuAdmain();
                // هنا هتعمل العمليات الخاصة بالأدمن
            }
            else if (choice == 2) // Create Customer
            {
                CreatAccountCostumer();
                while (true)
                {
                    MenuSuber(); // يفتح قائمة المنتجات
                    int choise2 = GetChoMenuCustmer();
                    if (choise2 == 6) break; // خروج من منيو الزبون
                }
            }
            else if (choice == 3) // Login Admin
            {
                LoginAdmain();
                MenuAdmain(); // يفتح قائمة الأدمن بعد تسجيل الدخول
                int cho = GetChoMenuAdmain();
                // عمليات الأدمن
            }
            else if (choice == 4) // Login Customer
            {
                LoginCostumer();
                while (true)
                {
                    MenuSuber(); // يفتح قائمة المنتجات
                    int choise2 = GetChoMenuCustmer();
                    if (choise2 == 6) break;
                }
            }
            else if (choice == 5)
            {
                ShowAllAccounts();
            }
            else if (choice == 6)
            {
                Console.WriteLine("\t\t\t\t\t شكراً لاستخدامك النظام ❤️");
                break;
            }
        }
    }

    //------------------------------------------------------\\
    // دالة عرض القائمة
    static void ShowMenu()
    {
        //Console.Clear();
        Console.ForegroundColor = ConsoleColor.Green;
        Console.WriteLine("\t\t\t\t|------------------------------------------------|\n ");
        Console.WriteLine("\t\t\t\t|       Hello Dear In Our System Login..!        |\n");
        Console.WriteLine("\t\t\t\t|------------------------------------------------|\n ");
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

    // دالة عرض كل الحسابات

    static void ShowAllAccounts()
    {
        if (accountCount == 0)
        {
            Console.ForegroundColor = ConsoleColor.Red;
            Console.WriteLine("\t\t\t\t\t No accounts registered.");
            Console.ResetColor();
            return;
        }
        Console.ForegroundColor = ConsoleColor.Blue;
        //Console.WriteLine("\nAll Accounts:");
        Console.ForegroundColor = ConsoleColor.Green;
        for (int i = 0; i < accountCount; i++)
        {
            Console.WriteLine($"\t\t\t\t\t {i + 1} Name: {Names[i]}\n\t\t\t\t\t Email: {Emails[i]}\n\t\t\t\t\t" +
                $" Phone: {Phones[i]}\n\t\t\t\t\t Password: {Passwords[i]}\n\t\t\t\t\t ------------------------ \n\n");

        }
        Console.ResetColor();
    }
    //دالة انشاء حساب للادمن
    static void CreatAccountAdmain()
    {
        Console.WriteLine("\t\t\t\t\t hello dear to craet acount for admain   ");
        Console.ForegroundColor = ConsoleColor.Cyan;
        Console.WriteLine("\t\t\t\t\t Enter Your Name.. ");
        Console.Write("\t\t\t\t\t ");
        Console.ResetColor();
        Names[accountCount] = Console.ReadLine();
        Console.ForegroundColor = ConsoleColor.Cyan;
        Console.WriteLine("\t\t\t\t\t Enter Password.. ");
        Console.Write("\t\t\t\t\t ");
        Console.ResetColor();
        Passwords[accountCount] = Console.ReadLine();
        while (Passwords[accountCount].Length<6) 
        {
            Console.ForegroundColor = ConsoleColor.Red;
            Console.WriteLine("\t\t\t\t\t Please enter a strong password..!\n");
            Console.ResetColor();
            Console.Write("\t\t\t\t\t ");
            Passwords[accountCount] = Console.ReadLine();
        }
        Console.ForegroundColor = ConsoleColor.Cyan;
        Console.WriteLine("\t\t\t\t\t Enter Gmail.. ");
        Console.Write("\t\t\t\t\t ");
        Console.ResetColor();
        Emails[accountCount] = Console.ReadLine();

        while (!Emails[accountCount].Contains("@gmail.com"))
        {
            Console.ForegroundColor = ConsoleColor.Red;
            Console.WriteLine("\t\t\t\t\t Please enter a valid email (user@gmail.com)..!\n");
            Console.ResetColor();
            Console.Write("\t\t\t\t\t ");
            Emails[accountCount] = Console.ReadLine();
        }

        Console.ForegroundColor = ConsoleColor.Cyan;
        Console.WriteLine("\t\t\t\t\t Enter Phone Number.. ");
        Console.Write("\t\t\t\t\t ");
        Console.ResetColor();
        Phones[accountCount] = Console.ReadLine();
        //Console.Clear();
        accountCount++;
        Console.ForegroundColor = ConsoleColor.Green;
        Console.WriteLine("\t\t\t\t\t Account Created Successfully!");
        Console.ResetColor();

    }
    //دالة انشاء حساب  للزبون
    static void CreatAccountCostumer()
    {
        Console.ForegroundColor = ConsoleColor.Cyan;
        Console.WriteLine("\t\t\t\t\t Enter Your Name.. ");
        Console.Write("\t\t\t\t\t ");
        Console.ResetColor();
        Names[accountCount] = Console.ReadLine();
        Console.ForegroundColor = ConsoleColor.Cyan;
        Console.WriteLine("\t\t\t\t\t Enter Password.. ");
        Console.Write("\t\t\t\t\t ");
        Console.ResetColor();
        Passwords[accountCount] = Console.ReadLine();
        while (Passwords[accountCount].Length < 6)
        {
            Console.ForegroundColor = ConsoleColor.Red;
            Console.WriteLine("\t\t\t\t\t Please enter a strong password..!\n");
            Console.ResetColor();
            Console.Write("\t\t\t\t\t ");
            Passwords[accountCount] = Console.ReadLine();
        }
        Console.ForegroundColor = ConsoleColor.Cyan;
        Console.WriteLine("\t\t\t\t\t Enter Gmail.. ");
        Console.Write("\t\t\t\t\t ");
        Console.ResetColor();
        Emails[accountCount] = Console.ReadLine();

        while (!Emails[accountCount].Contains("@gmail.com"))
        {
            Console.ForegroundColor = ConsoleColor.Red;
            Console.WriteLine("\t\t\t\t\t Please enter a valid email (user@gmail.com)..!\n");
            Console.ResetColor();
            Console.Write("\t\t\t\t\t ");
            Emails[accountCount] = Console.ReadLine();
        }

        Console.ForegroundColor = ConsoleColor.Cyan;
        Console.WriteLine("\t\t\t\t\t Enter Phone Number.. ");
        Console.Write("\t\t\t\t\t ");
        Console.ResetColor();
        //Phones[accountCount] = Console.ReadLine();
        //Console.Clear();
        accountCount++;
        Console.ForegroundColor = ConsoleColor.Green;
        Console.Write("\t\t\t\t\t Account Created Successfully!");
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
        for (int i = 0; i < accountCount; i++)
        {
            if (Names[i] == name && Passwords[i] == password)
            {
                Console.ForegroundColor = ConsoleColor.Green;
                Console.WriteLine(" Login Successful! Welcome " + name);
                Console.ResetColor();
                found = true;
                break;
            }
        }
        if (!found)
        {
            Console.ForegroundColor = ConsoleColor.Red;
            Console.WriteLine("Wrong Name or Password!");
            Console.ResetColor();
            //Console.Clear();
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
        for (int i = 0; i < accountCount; i++)
        {
            if (Names[i] == name && Passwords[i] == password)
            {
                Console.ForegroundColor = ConsoleColor.Green;
                Console.WriteLine(" Login Successful! Welcome " + name);
                Console.ResetColor();
                found = true;
                break;
            }
        }
        if (!found)
        {
            Console.ForegroundColor = ConsoleColor.Red;
            Console.WriteLine("Wrong Name or Password!");
            Console.ResetColor();
            //Console.Clear();
        }
    }

    //------------------------------------------------\\

    //دالة قاىمة المنتجات للزبون 
    static void MenuSuber()
    {
        Console.ForegroundColor = ConsoleColor.Green;
        Console.WriteLine("\t\t\t\t|------------------------------------------------|\n ");
        Console.WriteLine("\t\t\t\t|       Hello Dear In Subermarket KHire Thman..! |\n");
        Console.WriteLine("\t\t\t\t|------------------------------------------------|\n ");
        Console.ForegroundColor = ConsoleColor.Yellow;
        Console.WriteLine("\t\t\t\t\t 1: منتجات الالبان .. ");
        Console.WriteLine("\t\t\t\t\t 2: منتجات اللحوم.. ");
        Console.WriteLine("\t\t\t\t\t 3: منتجات البقوليات .. ");
        Console.WriteLine("\t\t\t\t\t 4: منتجات .. ");
        Console.WriteLine("\t\t\t\t\t 5: منتجات التسالي ");
        //Console.WriteLine("\t\t\t\t\t 4:  ");
        Console.WriteLine("\t\t\t\t\t 6: Exit .. \n");
        Console.WriteLine("\t\t\t\t\t Please Enter Choice .. \n");
        Console.WriteLine("\t\t\t\t\t ");
        Console.Write("\t\t\t\t\t ");
        Console.ResetColor();
    }
    //دالة الحصول علي الاختيار 
    static int GetChoMenuCustmer()
    {
        int cho;
        while (!int.TryParse(Console.ReadLine(), out cho) || cho < 1 || cho > 6)
        {
            Console.ForegroundColor = ConsoleColor.Red;
            Console.WriteLine("\t\t\t\t\t Please Enter a Valid Choice (1-6) ..");
            Console.ResetColor();
            Console.Write("\t\t\t\t\t ");

        }
        return cho;
    }
    //***********************************************\\
    //دالة القاىمة للادمن 
    static void MenuAdmain()
    {
        Console.ForegroundColor = ConsoleColor.Green;
        Console.WriteLine("\t\t\t\t|------------------------------------------------|\n ");
        Console.WriteLine("\t\t\t\t|       Hello Dear In Subermarket KHire Thman..! |\n");
        Console.WriteLine("\t\t\t\t|------------------------------------------------|\n ");
        Console.ForegroundColor = ConsoleColor.Yellow;
        Console.WriteLine("\t\t\t\t\t 1: add new product .. ");
        Console.WriteLine("\t\t\t\t\t 2: delete product .. ");
        Console.WriteLine("\t\t\t\t\t 3: viw all products .. ");
        //Console.WriteLine("\t\t\t\t\t 4:  .. ");
        //Console.WriteLine("\t\t\t\t\t 5: منتجات التسالي ");
        ////Console.WriteLine("\t\t\t\t\t 4:  ");
        Console.WriteLine("\t\t\t\t\t 4: Exit .. \n");
        //Console.WriteLine("\t\t\t\t\t Please Enter Choice .. \n");
        //Console.WriteLine("\t\t\t\t\t ");
        //Console.Write("\t\t\t\t\t ");
        Console.ResetColor();
    }
    //دالة الحصول علي الاختيار من الادمن
    static int GetChoMenuAdmain()
    {
        int cho;
        while (!int.TryParse(Console.ReadLine(), out cho) || cho < 1 || cho > 4)
        {
            Console.ForegroundColor = ConsoleColor.Red;
            Console.WriteLine("\t\t\t\t\t Please Enter a Valid Choice (1-4) ..");
            Console.ResetColor();
            Console.Write("\t\t\t\t\t ");

        }
        return cho;
    }
}
