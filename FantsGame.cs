using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Fantiu
{
    internal class FantsGame
    {
        private List<String> fants; //сами фанты

        private List<int> ids;      // id доступных фант

        public FantsGame(List<String> _fants)
        {
            fants = new List<String>();
            ids = new List<int>();

            InitGame(_fants);

        }


        // ----------------------- Инициализация игры ----------------------- //
        private void InitGame(List<String> _fants)
        {

            fants = _fants;

            // ---------------- Шаффл фантов ---------------- //
            int n = fants.Count;
            Random rng = new Random((int)DateTime.Now.Ticks & 0x0000FFFF);
            while (n > 1)
            {
                n--;
                int k = rng.Next(n + 1);
                string value = fants[k];
                fants[k] = fants[n];
                fants[n] = value;
            }

            // --------- Инициализация нумерации --------- //
            for (int i = 0; i < fants.Count; i++)
            {
                ids.Add(i + 1);
            }
        }
        //--------------------------------------------------------------------//

        // --------------------------- Старт игры --------------------------- //
        public void StartGame()
        {
            GameStep();
        }
        //--------------------------------------------------------------------//

        // ---------------------- Вывод доступных фант ---------------------- //
        private void ShowEnabledIds()
        {
            System.Console.WriteLine("Доступные фанты: ");
            foreach (var id in ids)
            {
                System.Console.Write(id + "  ");
            }
            System.Console.Write("\n");
        }
        //--------------------------------------------------------------------//

        // ------------------------ Ввод номера фанта ----------------------- //
        private int GetId()
        {
            int id = 0;
            System.Console.WriteLine("Введите номер фанта: ");
            id = Convert.ToInt32(Console.ReadLine());
            return id;
        }
        //--------------------------------------------------------------------//

        // ------------------------ Вывод самого фанта ---------------------- //
        private void ShowFant(int id)
        {
            string fant = fants[id - 1];
            ids.Remove(id);
            Console.WriteLine(fant);
            Console.ReadLine();
        }
        //--------------------------------------------------------------------//

        // --------------------------- Игровой шаг -------------------------- //
        private void GameStep()
        {
            if (ids.Count > 0) // если еще остались фанты
            {
                ShowEnabledIds();
                int id = GetId();
                if (!ids.Contains(id)) //фант не доступен
                {
                    System.Console.WriteLine("Данный фант не доступен.");
                } else                 //фант доступен
                {
                    ShowFant(id);
                }
                GameStep();
            }
            else // кончились фанты - конец
                return;
        }
        //--------------------------------------------------------------------//
    }
}
