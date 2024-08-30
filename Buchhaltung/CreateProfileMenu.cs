using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Buchhaltung
{
    internal class CreateProfileMenu : Menu
    {
        public override void DisplayMenu()
        {
            Console.WriteLine("Profile erstellen");
            Console.WriteLine();

            string profileName = InputName();
            decimal profileStartBalance = InputStartBalance();

            ProfileManager.CreateProfile(profileName, profileStartBalance);

            Menu nextMenu = new MainMenu();

            
        }
        private string InputName()
        {
            while(true)
            {
                string input = "";
                Console.Write("Profilename: ");
                input = Console.ReadLine();

                if (ValidateName(input))
                {
                    return input;
                }
                else
                {
                    Console.ForegroundColor = ConsoleColor.Red;
                    Console.WriteLine("FEHLER: Ungültiger Name");
                    Console.ForegroundColor= ConsoleColor.White;
                }
            }
        }
        private bool ValidateName(string name) 
        {
            if (ProfileManager.CheckIfProfileExists(name))
                return false;

            foreach (char c in name)
            {
                if(!char.IsLetterOrDigit(c))
                {
                    return false;
                }
                
            }
            return true;
        }

        private decimal InputStartBalance()
        {
            while (true)
            {
                Console.Write("Start Kontostand: ");
                decimal input;
                string strInput = Console.ReadLine();
                if(!decimal.TryParse(strInput, out input))
                {
                    Console.ForegroundColor = ConsoleColor.Red;
                    Console.WriteLine("FEHLER: Ungültiger Geldbetrag!");
                    Console.ForegroundColor= ConsoleColor.White; 
                    continue;
                }
                return input;
            }
        }
    }
}
