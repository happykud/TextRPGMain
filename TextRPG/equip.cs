using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TextRPG
{
    enum Type
    {
        무기,
        방어구
    }

    enum Taer
    {
        커먼,
        레어,
        유니크
    }

    enum EffectType
    {
        공격력,
        방어력
    }

    internal class equip
    {
        public int equipId;
        public string name;
        public Type type;
        public Taer taer;
        public EffectType effectType;
        public int effect;
        public int price;
        public bool IsBuy;

        public equip clone()
        {
            return this.MemberwiseClone() as equip;
        }

        public equip(int equipId, string name, Type type, Taer taer, EffectType effectType, int effect, int price, bool isBuy)
        {
            this.equipId = equipId;
            this.name = name;
            this.type = type;
            this.taer = taer;
            this.effectType = effectType;
            this.effect = effect;
            this.price = price;
            IsBuy = isBuy;
        }

    }

    class Inventory
    {
        public static List<equip> inventoryEquipList = new List<equip>();
        public static List<equip> equipEquipList = new List<equip> ();
        //GamePlay gamePlay1 = new GamePlay ();


        public List<equip> GetInventoryEquipsList()
        {
            return inventoryEquipList;
        }

        public List<equip> GetEquipsList()
        {
            return equipEquipList;
        }

        public void Equips(int equipsId)
        {
            GamePlay gamePlay = new GamePlay();
            Player player = new Player(); 
            equip foundItem = inventoryEquipList.Find(x => x.equipId == equipsId);
            equipEquipList.Add(foundItem);
            inventoryEquipList.Remove(foundItem);


            if (foundItem.effectType == EffectType.공격력)
            {
                player.addStasts(foundItem.effect, 1);
                gamePlay.SetEquip(foundItem.effect, 4);
            }
            else
            {
                player.addStasts(foundItem.effect, 2);
                gamePlay.SetEquip(foundItem.effect, 5);
            }
            Console.Clear();
            Console.WriteLine("{0} 장착 완료!", foundItem.name);
        }
    }

    class shop
    {
        public List <equip> shopEquipsList;
        public int playerGold;
        public void SetPlayerShopGold(int gold)
        {
            this.playerGold =gold;
        }

        
        public shop()
        {
            shopEquipsList = new List<equip>();
            shopEquipsList.Add(new equip(1, "낡은 검", Type.무기, Taer.커먼, EffectType.공격력, 3, 15, false));
            shopEquipsList.Add(new equip(2, "낡은 지팡이", Type.무기, Taer.커먼, EffectType.공격력, 2, 15, false));
            shopEquipsList.Add(new equip(3, "새련된 검", Type.무기, Taer.레어, EffectType.공격력, 10, 30, false));
            shopEquipsList.Add(new equip(4, "새련된 지팡이", Type.무기, Taer.레어, EffectType.공격력, 8, 28, false));
            shopEquipsList.Add(new equip(5, "스파르탄 소드", Type.무기, Taer.유니크, EffectType.공격력, 55, 120, false));
            shopEquipsList.Add(new equip(6, "스파르타의 가호를 받은 지팡이", Type.무기, Taer.유니크, EffectType.공격력, 42, 118, false));
            shopEquipsList.Add(new equip(7, "낡은 갑옷", Type.방어구, Taer.커먼, EffectType.방어력, 5, 5, false));
            shopEquipsList.Add(new equip(8, "새련된 갑옷", Type.방어구, Taer.레어, EffectType.방어력, 18, 25, false));
            shopEquipsList.Add(new equip(9, "전설의 스파르탄 갑옷", Type.방어구, Taer.유니크, EffectType.방어력, 99999, 999999999, false));
        }

        public List<equip> GetShopEquipsList()
        {
            return shopEquipsList;
        }

        public void InSell(List<equip> inventoryList)
        {
            GamePlay gamePlay = new GamePlay();

            Console.Clear();
            foreach (var equip in inventoryList)
            {
                Console.WriteLine("번호 {0} : {1} : {2} : {3} : {4} +{5}\n가격 : {6}\n", equip.equipId, equip.name, equip.type, equip.taer, equip.effectType, equip.effect, equip.price);
            }
            Console.WriteLine("\n------------------");
            Console.WriteLine("소지 골드: {0}", playerGold);
            Console.WriteLine("------------------\n");
            Console.WriteLine();
            Console.WriteLine("판매할 장비의 번호를 입력하세요.");
            Console.WriteLine("0. 나가기");
            Console.Write(">>");
            int InputMenu = int.Parse(Console.ReadLine());
            if (InputMenu == 0)
            {
                Console.Clear();
                gamePlay.Main();
            }
            else
            {
                equip foundItem = inventoryList.Find(x => x.equipId == InputMenu);
                if (foundItem == null)
                {
                    Console.Clear();
                    Console.WriteLine("잘못 입력하셨습니다.");
                }
                else
                {
                    Console.Clear();
                    equipSell(foundItem);
                    gamePlay.SellGold(foundItem.price);
                    Console.WriteLine("{0} 판매 완료!", foundItem.name);
                }
            }
        }

        public void InShop(List<equip> shopEquipsList)
        {

            GamePlay gamePlay = new GamePlay();
            

            Console.Clear();
            foreach (var equip in shopEquipsList)
            {
                string buyPossible;
                if (equip.IsBuy == false)
                {
                    buyPossible = "구매 가능";
                }
                else
                {
                    buyPossible = "품절";
                }
                Console.WriteLine("번호 {0} : {1} : {2} : {3} : {4} +{5}\n가격 : {6} {7}\n", equip.equipId, equip.name, equip.type, equip.taer, equip.effectType, equip.effect, equip.price ,buyPossible);
            }

            Console.WriteLine("\n------------------");
            Console.WriteLine("소지 골드: {0}", playerGold);
            Console.WriteLine("------------------\n");

            Console.WriteLine("----------------------------------");
            Console.WriteLine("구매 하실 장비의 번호를 입력 해주세요");
            Console.WriteLine("0. 나가기");
            Console.Write(">>");
            int InputMenu = int.Parse(Console.ReadLine());
            if(InputMenu == 0)
            {
                Console.Clear();
                gamePlay.Main();
            }
            else
            {
                equip foundItem = shopEquipsList.Find(x => x.equipId == InputMenu);
                if (foundItem == null)
                {
                    Console.Clear();
                    Console.WriteLine("잘못 입력하셨습니다.");
                }
                else if(foundItem.IsBuy == true)
                {
                    Console.Clear();
                    Console.WriteLine("품절된 상품 입니다.");
                }
                else if (playerGold > foundItem.price)
                {
                    Console.Clear();
                    equipBuy(foundItem);
                    foundItem.IsBuy = true;
                    gamePlay.BuyGold(foundItem.price);
                    Console.WriteLine("{0} 구매 완료!", foundItem.name);
                }
                else
                {
                    Console.Clear();
                    Console.WriteLine("골드가 부족합니다.");
                }
            }
        }

        public void equipBuy(equip foundItem)
        {
            Inventory.inventoryEquipList.Add(foundItem);
        }
        public void equipSell(equip foundItem)
        {
            Inventory.inventoryEquipList.Remove(foundItem);
        }


    }
}
