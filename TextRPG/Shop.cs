using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TextRPG
{
    internal class Shop
    {
        public static List<Item> items = new List<Item>();

        // 기본 아이템 세팅 읽어오기
        // 엑셀이 안깔려있어서 텍스트파일로 대체
        public void SetSellItem()
        {
            StringBuilder sb = new StringBuilder();
            sb.Append(GameManager.instance.PATH);

            StreamReader sr = new StreamReader(sb.ToString());
            string line;

            items.Clear();

            line = sr.ReadLine();

            while (line != null)
            {
                string[] itemData = line.Split(".");

                Item newItem=new Item();
                newItem.index = int.Parse(itemData[0]);
                newItem.name= itemData[1];
                newItem.att = int.Parse(itemData[2]);
                newItem.def = int.Parse(itemData[3]);
                newItem.ITEMTYPE =(ITEMTYPE)int.Parse(itemData[4]);
                newItem.isSell = int.Parse(itemData[5]) == 1 ? true : false;
                newItem.isEquip = int.Parse(itemData[6]) == 1 ? true : false;
                newItem.price = int.Parse(itemData[7]);
                newItem.tip = itemData[8];
            
                items.Add(newItem);

                line = sr.ReadLine();

            }
            sr.Close();
        }

        public void SaveSellItem()
        {
            StringBuilder sb = new StringBuilder();
            sb.Append(GameManager.instance.PATH);


            try
            {
                StreamWriter sw = new StreamWriter(sb.ToString());

                for (int i = 0; i < items.Count; i++)
                {
                    sw.Write(items.ElementAt(i).index + ".");
                    sw.Write(items.ElementAt(i).name + ".");
                    sw.Write(items.ElementAt(i).att + ".");
                    sw.Write(items.ElementAt(i).def + ".");
                    sw.Write((int)items.ElementAt(i).ITEMTYPE + ".");
                    sw.Write((items.ElementAt(i).isSell == true ? 1 : 0) + ".");
                    sw.Write((items.ElementAt(i).isEquip == true ? 1 : 0) + ".");
                    sw.Write((items.ElementAt(i).price) + ".");
                    sw.WriteLine(items.ElementAt(i).tip);
                }

                sw.Close();
            }
            catch (Exception e)
            {
                Console.WriteLine(e.Message);
            }
        }

        public void ShowSellItem(int gold)
        {
            Console.Clear();
            Console.WriteLine("상점");

            Console.WriteLine("보유 골드 : " + gold + "G");
            Console.WriteLine();

            foreach (var item in items)
            {

                if (item.isSell == true)
                {
                    // 이미 판매된 아이템은 어두운 글자로
                    Console.ForegroundColor = ConsoleColor.DarkGray;
                }

                Console.Write(item.index + " | ");
                Console.Write(item.name + " | ");
                switch (item.ITEMTYPE)
                {
                    case ITEMTYPE.EQUIP:
                        Console.Write("공격력 : " + item.att + " | ");
                        Console.Write("방어력 : " + item.def + " | ");
                        break;
                    case ITEMTYPE.CONSUME:
                        Console.Write("회복량 :" + item.att + " | ");
                        break;
                }
                Console.Write(item.price + "G | ");
                Console.WriteLine(item.tip + " ");
                Console.ResetColor();

            }
            Console.WriteLine("무엇을 할까?");
            Console.WriteLine("1. 구매하기 \n2. 돌아가기");

            int input = GameManager.instance.InputReadLine();

            switch (input)
            {
                case 1:
                    ShowSellItemList();
                    break;
                case 2:
                    break;
                default:
                    GameManager.instance.ExitConsole();
                    break;
            }
        }

        private void ShowSellItemList()
        {
            List<Item> itemList = items.Where(x => x.isSell == false ).ToList();

            Console.Clear();
            foreach (var item in itemList)
            {
                Console.Write(item.index + " | ");
                Console.Write(item.name + " | ");
                switch (item.ITEMTYPE)
                {
                    case ITEMTYPE.EQUIP:
                        Console.Write("공격력 : " + item.att + " | ");
                        Console.Write("방어력 : " + item.def + " | ");
                        break;
                    case ITEMTYPE.CONSUME:
                        Console.Write("회복량 :" + item.att + " | ");
                        break;
                }
                Console.Write(item.price + "G | ");

                Console.WriteLine(item.tip + " ");
            }
            Console.WriteLine("구매할 아이템 번호를 입력하세요.");
            int input = GameManager.instance.InputReadLine();

            SellItem(input-1);
        }

        public void SellItem(int index)
        {
            Item item= items.ElementAt(index);

            // 이미 팔린 물건 재구매 시도
            if(item.isSell==true)
            {
                Console.WriteLine("이미 판매된 물건입니다.");
                Console.ReadKey();
                ShowSellItem(GameManager.instance.Player.PlayerGold);
                return;
            }

            // 돈 모자란 상황에서 구매 시도
            if (GameManager.instance.Player.UseGold(item.price)==false)
            {
                ShowSellItem(GameManager.instance.Player.PlayerGold);
                return;
            }

            item.isSell = !item.isSell;
            GameManager.instance.Player.PlayerGold -= item.price;
            GameManager.instance.Player.InputItem(item);

            SaveSellItem();
            ShowSellItem(GameManager.instance.Player.PlayerGold);
        }
    }
}
