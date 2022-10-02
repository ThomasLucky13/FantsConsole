using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Fantiu
{
    internal class Program
    {
        static void Main(string[] args)
        {
            List<string> fants = new List<string>()
            { 
                " задание 1", " задание 2",  " звдвние 3",  " задание 4",  " задание 5",
                " задание 6", " задание 7", " задание 8", " задание 9", " задание 10"
            };

            FantsGame game = new FantsGame(fants);

            game.StartGame();
        }



        
    }
}
