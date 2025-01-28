using System;
using System.Collections.Generic;
using System.Linq;
using System.Numerics;
using System.Text;
using System.Threading.Tasks;
using static System.Collections.Specialized.BitVector32;

namespace TextRPG
{
    internal class Stage
    {
        private Player player;

        public void StartStage(Player p)
        {
            player = p;
            Console.WriteLine("당신은 작은 마을 입구에 서 있다.\n무엇을 할까?");

            ShowOption();
    

        }


        private void ShowOption()
        { 
            Console.WriteLine("1. 안으로 들어가다\n2. 내정보\n3. 인벤토리");
            int input = int.Parse(Console.ReadLine());

            switch (input)
            {
                case 1:
                    EnterVillage();
                    break;
                case 2:
                    player.ShowCharStatus();
                    ShowOption();
                    break;
                case 3:
                    player.ShowInventory();
                    ShowOption();
                    break;
                default:
                    Console.WriteLine("범위에서 벗어났습니다.");
                    break;
            }

        }

        private void EnterVillage()
        {
            Console.WriteLine("마을에 들어왔다. 이제 무엇을 할까?");

            Console.WriteLine("1. 여관으로\n2. 상점으로\n3.내정보\n4. 인벤토리");
            int input = int.Parse(Console.ReadLine());

            switch (input)
            {
                case 1:
                    break;
                case 2:
                    ShowShop();
                    break;
                case 3:
                    player.ShowCharStatus();
                    break;
                case 4:
                    player.ShowInventory();
                    break;
                default:
                    Console.WriteLine("범위에서 벗어났습니다.");
                    break;
            }

        }

        private void ShowShop()
        {

        }

        private void BuyItem()
        {
            IItem item=null;
            //player.SetInventory(item);
        }

    }
}
