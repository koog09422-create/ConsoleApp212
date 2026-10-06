using System;
using System.IO;

namespace ConsoleApp212
{
    // موظف التقارير يرث من Employee
    class ReportEmployee : Employee
    {
        public ReportEmployee(string username, string password) : base(username, password)
        {
        }

        public override string GetRole()
        {
            return "Report"; // ستطبع الواجهة الرئيسية: Welcome, Report!
        }

        public override void ShowMenu()
        {
            while (true)
            {
                Console.WriteLine("\n--- Report Employee Menu ---");
                Console.WriteLine("1. View All Reports (Text Files)");
                Console.WriteLine("2. Logout");
                Console.Write("Enter your choice: ");
                string choice = Console.ReadLine();

                if (choice == "1")
                {
                    ViewAllReports();
                }
                else if (choice == "2")
                {
                    Console.WriteLine("Logging out...");
                    break;
                }
                else
                {
                    Console.WriteLine("Invalid choice, please try again.");
                }
            }
        }

        private void ViewAllReports()
        {
            // الحصول على جميع الملفات النصية التي تبدأ بـ Report_
            string[] files = Directory.GetFiles(Directory.GetCurrentDirectory(), "Report_*.txt");

            if (files.Length == 0)
            {
                Console.WriteLine("No report files found.");
                return;
            }

            Console.WriteLine("\n--- Saved Reports ---");
            foreach (var filePath in files)
            {
                string fileName = Path.GetFileName(filePath);
                Console.WriteLine($"\n>>> File: {fileName} <<<");
                string content = File.ReadAllText(filePath);
                Console.WriteLine(content);
            }
        }
    }
}