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
        private Shop shop;

        public void StartStage(Player p,Shop s)
        {
            player = p;
            shop = s;
            Console.WriteLine("당신은 작은 마을 입구에 서 있다.\n무엇을 할까?");

            ShowOption();
    

        }


        private void ShowOption()
        { 
            Console.WriteLine("1. 안으로 들어가다\n2. 내정보\n3. 인벤토리");
            int input = GameManager.instance.InputReadLine();

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
                    GameManager.instance.ExitConsole();
                    break;
            }

        }

        private void EnterVillage()
        {
            Console.Clear();
            Console.WriteLine("마을에 들어왔다. 이제 무엇을 할까?");

            Console.WriteLine("1. 여관으로\n2. 상점으로\n3. 내정보\n4. 인벤토리");
            int input = GameManager.instance.InputReadLine();

            switch (input)
            {
                case 1:
                    ShowINNOption();
                    EnterVillage(); 
                    break;
                case 2:
                    ShowShop();
                    EnterVillage();
                    break;
                case 3:
                    player.ShowCharStatus();
                    EnterVillage();
                    break;
                case 4:
                    player.ShowInventory();
                    EnterVillage();
                    break;
                default:
                    GameManager.instance.ExitConsole();
                    break;
            }

        }

        private void ShowINNOption()
        {
            Console.Clear();
            Console.WriteLine("여관에 서 무엇을 할까?\n1. 휴식 \n2. 나가기");

            int input = GameManager.instance.InputReadLine();

            switch(input)
            {
                case 1:
                    ShowRest();
                    ShowINNOption();
                    break;
                case 2:
                    EnterVillage();
                    break;
                default:
                    GameManager.instance.ExitConsole();
                    break;
            }
        }

        private void ShowRest()
        {
            Console.Clear();
            Console.WriteLine("여관");

            Console.WriteLine("보유 골드 : " + player.PlayerGold + "G");
            Console.WriteLine("현재 체략 : " + player.PlayerHp + " / " + player.PlayerMaxHp);
            Console.WriteLine();
            Console.WriteLine("휴식시 체력이 3 회복되며 비용은 100G입니다");
            Console.WriteLine("1. 휴식하기 \n2. 나가기");

            int input = GameManager.instance.InputReadLine();

            switch (input)
            {
                case 1:
                    player.PlayerGold -= 100;
                    player.GetHP(3);
                    ShowRest();
                    break;
                case 2:
                    ShowINNOption();
                    break;
                default:
                    break;
            }
        }

        private void ShowShop()
        {
            shop.ShowSellItem(player.PlayerGold);
        }
    }
}
