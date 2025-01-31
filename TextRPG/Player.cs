using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.IO;
using System.Buffers;
using System.Drawing;
using System.ComponentModel;

namespace TextRPG
{
    enum JOB
    {
        WARRIOR = 1,
        MAGE,
        JOBLESS
    }

    internal class Player
    {
        private string name;
        private int jobNum;

        private int lv;
        private string job;
        private int att;
        private int def;
        private int maxHP;
        private int nowHP;
        private int gold;

        public int itemAtt;
        public int itemDef;
        private Inventory inventory;

        public void DataLoad()
        {
            // 처음에 해야 하는것
            inventory = new Inventory();

        }
   
        public void MakePlayer()
        {
            Console.WriteLine("당신의 이름은? ");
            name = Console.ReadLine();


            Console.WriteLine("당신의 직업은? \n 1. 전사 \n 2. 마법사 \n 3. 무직");
            jobNum=int.Parse(Console.ReadLine());


            Console.WriteLine($"이름 : {name} 직업 : {Enum.GetName(typeof(JOB), (JOB)jobNum)}");
            SetDefaultChar(name, jobNum);

            Console.WriteLine("아무 키나 누르면 시작합니다");
            Console.ReadKey();
            Console.Clear();
        }

        private void SetDefaultChar(string str, int num)
        {
            JOB j = (JOB)num;

            lv = 1;
            name = str;
            job= Enum.GetName(typeof(JOB), j);
            att = 10;
            def = 5;
            nowHP = 100;
            maxHP = 100;
            gold = 1500;

            // 직업별 추가 능력치
            switch (num)
            {
                case 1:
                    {
                        att += 1;
                        break;
                    }
                case 2:
                    {
                        nowHP += 10;
                        maxHP += 10;
                        break;
                    }
                case 3:
                    {
                        gold -= 500;
                        break;
                    }
            }


            SavePlayerData();
        }

        public void SavePlayerData()
        {
            StringBuilder sb = new StringBuilder();
            sb.Append(AppDomain.CurrentDomain.BaseDirectory);
            sb.Append("CharData.txt");

            try 
            { 
                StreamWriter sw=new StreamWriter(sb.ToString());

                sw.WriteLine(name);
                sw.WriteLine(lv.ToString());
                sw.WriteLine(job);
                sw.WriteLine(att.ToString());
                sw.WriteLine(def.ToString());
                sw.WriteLine(nowHP.ToString());
                sw.WriteLine(maxHP.ToString());
                sw.WriteLine(gold.ToString());
                sw.WriteLine(itemAtt.ToString());
                sw.WriteLine(itemDef.ToString());

                sw.Close();
            }
            catch(Exception e)
            {
                Console.WriteLine(e.Message);
            }
        }

        public void LoadPlayerData()
        {
            List<string> list = new List<string>();
            string line;
            try
            { 
                StringBuilder sb = new StringBuilder();
                sb.Append(AppDomain.CurrentDomain.BaseDirectory);
                sb.Append("CharData.txt");

                StreamReader sr = new StreamReader(sb.ToString());

                line = sr.ReadLine();
                list.Add(line);

                while (line != null)
                {
                    line = sr.ReadLine();
                    list.Add(line);
                }
                sr.Close();


                name = list[0];
                lv = int.Parse(list[1]);
                job = list[2];
                att = int.Parse(list[3]);
                def = int.Parse(list[4]);
                nowHP = int.Parse(list[5]);
                maxHP = int.Parse(list[6]);
                gold = int.Parse(list[7]);
                itemAtt = int.Parse(list[8]);
                itemDef = int.Parse(list[9]);

            }
            catch(Exception e)
            {
                MakePlayer();
            }
        }

        public void SaveInvenData()
        {
            inventory.SaveInvenData();
        }
        public void LoadInvenData()
        {
            inventory.LoadInvenData();
        }

        public void ShowCharStatus()
        {
            Console.Clear();

            Console.WriteLine($"이름\t: {name}");
            Console.WriteLine($"레벨\t: {PlayerLv}");
            Console.WriteLine($"직업\t: {job}");
            Console.ForegroundColor = ConsoleColor.Red;
            Console.WriteLine($"HP\t: {PlayerHp}/{PlayerMaxHp}");
            Console.ResetColor();
            if(PlayerItemAtt!=0)
                Console.WriteLine($"공격력\t: {PlayerAtt} (+{PlayerItemAtt})");
            else
                Console.WriteLine($"공격력\t: {PlayerAtt}");

            if(PlayerItemDef!=0)
                Console.WriteLine($"방어력\t: {PlayerDef} (+{PlayerItemDef})");
            else
                Console.WriteLine($"방어력\t: {PlayerDef}");
            
            Console.WriteLine($"소지금\t: {PlayerGold}");

            Console.WriteLine("돌아가려면 아무 키나 누르세요");
            Console.ReadKey();
            Console.Clear();
        }

        public void ShowInventory()
        {
            Console.Clear();

            Console.WriteLine("인벤토리");

            inventory.ShowInven();

            Console.WriteLine("1. 아이템 장착/사용\n2. 돌아가기");

            int input = GameManager.instance.InputReadLine();

            switch (input)
            {
                case 1:
                    ShowEquipItem();
                    break;
                case 2:
                    break;
                default:
                    GameManager.instance.ExitConsole();
                    break;

            }


            Console.Clear();
        }

        private void ShowEquipItem()
        {
            int i = 0;
            Console.Clear();

            foreach (var item in inventory.inven)
            {
                Console.WriteLine(i + ". " + item.name);
                i++;
            }
            Console.WriteLine("사용할 아이템 번호를 입력하세요.");
            int input = GameManager.instance.InputReadLine();

            inventory.UseItem(input);

        }

        public void InputItem(Item item)
        {
            inventory.InputItem(item);
        }
        public void InputItem(int index)
        {
            inventory.InputItem(index);
        }

        public void UseItem(Item item)
        {
            inventory.UseItem(item);
        }

        public bool UseGold(int i)
        {
            if (PlayerGold < i)
            {
                Console.WriteLine("돈이 모자랍니다!");
                Console.ReadKey();
                return false;
            }
            PlayerGold -= i;
            return true;
        }

        public void GetHP(int i)
        {
            PlayerHp += i;
            if (PlayerHp > PlayerMaxHp)
                PlayerHp = PlayerMaxHp;

            SavePlayerData();
        }

        #region SetCharStatus
        public int PlayerLv
        {
            get { return lv; }
            set { lv = value; }
        }
        public int PlayerHp
        {
            get { return nowHP; }
            set { nowHP = value; }
        }
        public int PlayerMaxHp
        {
            get { return maxHP; }
            set { maxHP = value; }
        }

        public int PlayerAtt
        {
            get { return att; }
            set { att = value; }
        }
        public int PlayerDef
        {
            get { return def; }
            set { def = value; }
        }

        public int PlayerGold
        {
            get { return gold; }
            set { gold = value; }
        }
        public int PlayerItemAtt
        {
            get { return itemAtt; }
            set { itemAtt = value; }
        }
        public int PlayerItemDef
        {
            get { return itemDef; }
            set { itemDef = value; }
        }
        #endregion

    }
}
