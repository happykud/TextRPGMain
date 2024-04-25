using System;
using System.Numerics;
using System.Xml.Linq;

namespace TextRPG
{
    internal class Program
    {
        static void Main(string[] args)
        {
            GamePlay gameplay = new GamePlay();
            bool isSaveData = false;

            if (isSaveData == false)
            {
                gameplay.NewGameStart();
            }
            else
            {
                //세이브 넣을 시 기능 넣어야뎀
            }
            gameplay.Main();
        }
    }

    class GamePlay // 전반적 게임 플레이
    {
        Player player = new Player();
        shop shop = new shop();
        Inventory inventory = new Inventory();

        public int[] playerStasts = new int[8];
        public int[] playerElement = new int[2];

        public int Testint()
        {
            return playerElement[0];
        }

        public void SetPlayerGold(int gold)
        {
            playerElement[0] = gold;
        }

        public void NewGameStart()
        {
            Console.WriteLine("------------------------------------------------------");
            Console.WriteLine();
            Console.WriteLine("스파르타 마을에 오신 것을 환영합니다.");
            Console.WriteLine("여러분은 스파르타 마을을 위헙하는 몬스터를 모두 처치 해야 합니다");
            Console.WriteLine();
            Console.WriteLine("-----------------------------------------------------");
            jopSet();
            playerStasts = player.stasts;
            playerElement = player.element;
            Console.WriteLine("이제 스파르타 마을을 구하는 여정을 시작 하세요!");
            Console.WriteLine("시작을 위해 당신의 이름을 알려주세요");
            player.name = Console.ReadLine();
            Console.Clear();
        }

        public void jopSet()
        {
            Console.WriteLine("우선 직업을 정해 주세요");
            Console.WriteLine("1.전사 2.마법사");
            string inPutJop = Console.ReadLine();
            switch (int.Parse(inPutJop))
            {
                case 1:
                    Console.Clear();
                    Console.WriteLine("전사를 선택 하셨습니다");
                    player.PlayerStastsSet(1, 0, 100, 20, 50, 10, 12, 12, "전사");
                    player.PlayerElement(1000000, 0);
                    break;
                case 2:
                    Console.Clear();
                    Console.WriteLine("마법사를 선택 하셨습니다");
                    player.PlayerStastsSet(1, 0, 60, 80, 40, 5, 6, 18, "마법사");
                    player.PlayerElement(1000000, 0);
                    break;
                default:
                    Console.Clear();
                    system.WrongChoice(jopSet);
                    break;
            }
        }

        public void Main()
        {
            Random mainRand = new Random();
            int mainStrType = mainRand.Next(1, 4);
            int playerAction;

            switch (mainStrType)
            {
                case 1:
                    Console.WriteLine("스파르타 마을을 구해주세요 {0}", player.name);
                    Console.WriteLine();
                    break;
                case 2:
                    Console.WriteLine("스파르타 마을에 어서오세요 {0}", player.name);
                    Console.WriteLine();
                    break;
                case 3:
                    Console.WriteLine("모험이 당신을 기다립니다 {0}", player.name);
                    Console.WriteLine();
                    break;
            }

            Console.WriteLine("1. 상태 보기");
            Console.WriteLine("2. 인벤토리");
            Console.WriteLine("3. 상점");
            Console.WriteLine("4. 던전");
            Console.WriteLine("원하시는 행동을 입력 해주세요.");
            Console.WriteLine();
            Console.Write(">>");
            playerAction = int.Parse(Console.ReadLine());

            switch (playerAction)
            {
                case 1:
                    player.StastsCheck(playerStasts);
                    player.ElementCheck(playerElement);
                    Console.WriteLine();
                    if (system.OutMenu() == 0)
                    {
                        Console.Clear();
                        Main();
                    }
                    else
                    {
                        system.WrongChoice(Main);
                    }
                    break;
                case 2:
                    InInventory(Inventory.inventoryEquipList);
                    Console.WriteLine();
                    if (system.OutMenu() == 0)
                    {
                        Console.Clear();
                        Main();
                    }
                    else
                    {
                        system.WrongChoice(Main);
                    }
                    break;
                case 3:
                    Console.Clear();
                    Console.WriteLine("상점 메뉴를 선택 하세요");
                    Console.WriteLine("1. 구매");
                    Console.WriteLine("2. 판매");
                    int inputMeun = int.Parse(Console.ReadLine());
                    if(inputMeun == 1)
                    {
                        shop.SetPlayerShopGold(playerElement[0]);
                        shop.InShop(shop.GetShopEquipsList());
                    }
                    else if(inputMeun == 2)
                    {
                        shop.SetPlayerShopGold(playerElement[0]);
                        shop.InSell(inventory.GetInventoryEquipsList());
                    }
                    else
                    {
                        system.WrongChoice(Main);
                    }

                    if (system.OutMenu() == 0)
                    {
                        Console.Clear();
                        Main();
                    }
                    else
                    {
                        system.WrongChoice(Main);
                    }
                    break;
                case 4:
                    Console.WriteLine("준비중 입니다.");
                    if (system.OutMenu() == 0)
                    {
                        Console.Clear();
                        Main();
                    }
                    else
                    {
                        system.WrongChoice(Main);
                    }
                    break;
                case 112233:
                    cheat(playerElement);
                    if (system.OutMenu() == 0)
                    {
                        Console.Clear();
                        Main();
                    }
                    else
                    {
                        system.WrongChoice(Main);
                    }
                    break;
                default:
                    system.WrongChoice(Main);
                    break;
            }


        }

        public void InInventory(List<equip> inventory)
        {
            Console.Clear();
            Console.WriteLine("■■■인벤토리■■■");
            Console.WriteLine("보유 중인 아이템을 관리할 수 있습니다.\n");
            Console.WriteLine();
            Console.WriteLine("[아이템 목록]");
            Console.WriteLine();
            if (Inventory.inventoryEquipList == null)
            {
                Console.WriteLine("현재 가지고 있는 장비가 없습니다.");
            }
            else
            {
                foreach (var equip in Inventory.inventoryEquipList)
                {
                    Console.WriteLine("번호 {0} : {1} : {2} : {3} : {4} +{5} \n가격 : {6}\n", equip.equipId, equip.name, equip.type, equip.taer, equip.effectType, equip.effect, equip.price);
                }
            }

            Console.WriteLine();
            Console.WriteLine("[장착 장비 목록]");
            Console.WriteLine();
            foreach (var equip in Inventory.equipEquipList)
            {
                Console.WriteLine("번호 {0} : {1} : {2} : {3} : {4} +{5} ", equip.equipId, equip.name, equip.type, equip.taer, equip.effectType, equip.effect);
            }

            Console.WriteLine();
            Console.WriteLine("1. 장비 장착");
            Console.WriteLine("0. 나가기");
            Console.Write(">>");
            int inputMenu = int.Parse(Console.ReadLine());

            if (inputMenu == 0)
            {
                return;
            }
            if(inputMenu == 1)
            {
                Console.Clear();
                foreach (var equip in Inventory.inventoryEquipList)
                {
                    Console.WriteLine("번호 {0} : {1} : {2} : {3} : {4} +{5} \n가격 : {6}\n", equip.equipId, equip.name, equip.type, equip.taer, equip.effectType, equip.effect, equip.price);
                }
                Console.WriteLine("장착할 장비의 번호를 입력 해주세요");
                Console.Write(">>");
                int inputEquipsID = int.Parse(Console.ReadLine());
                Inventory inventory1 = new Inventory();
                inventory1.Equips(inputEquipsID);
            }

        }

        public void cheat(int[] ints)
        {
            Console.WriteLine("치트 성공!");
        }
    }
}
