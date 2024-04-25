using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection.Emit;
using System.Runtime.InteropServices;
using System.Text;
using System.Threading.Tasks;

namespace TextRPG
{
    enum Stasts
    {
        레벨,
        경험치,
        체력,
        마나,
        공격력,
        방어력,
        회피율,
        명중률
    }

    enum Element
    {
        골드,
        스텟포인트
    }


    class Player // 플레이어 직업 및 구성 요소를 저장, 부여
    {
        //public int level;
        //public int Exp;
        //public int hp;
        //public int mp;
        //public int power;
        //public int defense;
        //public int evasion;
        //public int accuracy;
        //public string jop;

        //public Player(int level, int Exp, int hp, int mp, int power, int defense, int evasion, int accuracy, string jop)
        //{
        //    this.level = level;
        //    this.Exp = Exp;
        //    this.hp = hp;
        //    this.mp = mp;
        //    this.power = power;
        //    this.defense = defense;
        //    this.evasion = evasion;
        //    this.accuracy = accuracy;
        //    this.jop = jop;
        //}

        public int[] stasts = new int[8];
        public int[] element = new int[2];
        public string chad;
        public string name;

        public void PlayerStastsSet(int level, int Exp, int hp, int mp, int power, int defense, int evasion, int accuracy, string jop)
        {
            stasts[0] = level;
            stasts[1] = Exp;
            stasts[2] = hp;
            stasts[3] = mp;
            stasts[4] = power;
            stasts[5] = defense;
            stasts[6] = evasion;
            stasts[7] = accuracy;
            chad = jop;
        }

        public void PlayerElement(int Gold, int StastPoint)
        {
            element[0] = Gold;
            element[1] = StastPoint;
        }


        public void StastsCheck(int[] playerStasts)
        {
           
            Inventory inventory = new Inventory();
            List<equip> equipList = inventory.GetEquipsList();
            int addPower;
            int addDefense;

            foreach (equip equip in equipList)
            {
                
            }

            


            Console.WriteLine("■■■캐릭터 정보■■■");
            Console.WriteLine("------------");
            Console.WriteLine("이름: {0}", name);
            Console.WriteLine("직업: {0}", chad);
            Console.WriteLine("{0}: {1}", (Stasts)0, playerStasts[0]);
            Console.WriteLine("{0}: {1}", (Stasts)1, playerStasts[1]);
            for (int i = 2; i < stasts.Length; i++)
            {
                if(i == 4 || i == 5) // 장비 장착 시 스텟
                {
                    Console.WriteLine("------------");
                    Console.WriteLine("{0}: {1}", (Stasts)i, playerStasts[i]);
                }
                else
                {
                    Console.WriteLine("------------");
                    Console.WriteLine("{0}: {1}", (Stasts)i, playerStasts[i]);
                }
            }
            Console.WriteLine("------------");
        }

        public void ElementCheck(int[] playerElement)
        {
            for (int i = 0; i < element.Length; i++)
            {
                Console.WriteLine("------------");
                Console.WriteLine("{0}: {1}", (Element)i, playerElement[i]);
            }
            Console.WriteLine("------------");
        }
    }
}
