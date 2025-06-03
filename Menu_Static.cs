using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Project_idf___
{
    static class Menu_Static
    {
        public static void HandleAttackMenu(List<Attack_options> weapons, List<Terrorist> terrorists)
        {
            Console.WriteLine("\nSelect a weapon:");
            for (int i = 0; i < weapons.Count; i++)
            {
                Console.WriteLine($"{i + 1} - {weapons[i].GetType().Name} ({weapons[i].AuniqueName})");
            }

            int weaponIndex;
            while (!int.TryParse(Console.ReadLine(), out weaponIndex) || weaponIndex < 1 || weaponIndex > weapons.Count)
            {
                Console.WriteLine("Invalid choice. Try again:");
            }

            Attack_options selectedWeapon = weapons[weaponIndex - 1];

            Console.WriteLine("\nSelect a terrorist to attack:");
            for (int i = 0; i < terrorists.Count; i++)
            {
                Console.WriteLine($"{i + 1} - {terrorists[i].Get_Full_Name()}");
            }

            int terroristIndex;
            while (!int.TryParse(Console.ReadLine(), out terroristIndex) || terroristIndex < 1 || terroristIndex > terrorists.Count)
            {
                Console.WriteLine("Invalid choice. Try again:");
            }

            Terrorist selectedTerrorist = terrorists[terroristIndex - 1];



            selectedWeapon.Attack(selectedTerrorist, selectedTerrorist.Last_location);
        }

    }
}
