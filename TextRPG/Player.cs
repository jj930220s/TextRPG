using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.IO;
using System.Buffers;
using System.Drawing;

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

   
        public void MakePlayer()
        {
            Console.WriteLine("당신의 이름은? ");
            name = Console.ReadLine();


            Console.WriteLine("당신의 직업은? \n 1. 전사 \n 2. 마법사 \n 3. 무직");
            jobNum=int.Parse(Console.ReadLine());


            Console.WriteLine($"이름 : {name} 직업 : {jobNum}");
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
                sw.WriteLine(maxHP.ToString());
                sw.WriteLine(nowHP.ToString());
                sw.WriteLine(gold.ToString());

                sw.Close();
            }
            catch(Exception e)
            {
                Console.WriteLine(e.Message);
            }
        }

        public void LoadPlayerData()
        {
            string line;
            try
            { StreamReader sr = new StreamReader("C://CharData.txt");


                line = sr.ReadLine();

                while (line != null)
                {
                    Console.WriteLine(line);
                    line = sr.ReadLine();
                }
                sr.Close();
                Console.ReadLine();
            }
            catch(Exception e)
            {
                Console.WriteLine(e.Message);
            }

            
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
            Console.WriteLine($"공격력\t: {PlayerAtt}");
            Console.WriteLine($"방어력\t: {PlayerDef}");
            Console.WriteLine($"소지금\t: {PlayerGold}");

            Console.WriteLine("돌아가려면 아무 키나 누르세요");
            Console.ReadKey();
        }

        public void ShowInventory()
        {
            Console.Clear();

            Console.WriteLine("인벤토리");
            Console.WriteLine("돌아가려면 아무 키나 누르세요");
            Console.ReadKey();
        }
        public void SetInventory(IItem item)
        {

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
        #endregion
        
    }
}
