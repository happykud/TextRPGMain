using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TextRPG
{
    internal class system
    {
        public static void WrongChoice(Action function)
        {
            Console.WriteLine("잘못 된 선택 입니다.");
            function();
        }

        public static int OutMenu()
        {
            int InputMenu;
            Console.WriteLine("0. 나가기");
            Console.WriteLine();
            Console.Write(">>");
            InputMenu = int.Parse(Console.ReadLine());
            return InputMenu;
        }

    }
}
