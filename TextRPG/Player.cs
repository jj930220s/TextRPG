using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.IO;
using System.Buffers;

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


            Console.WriteLine("당신의 직업은? \n 1. 전사 \n 2. 마법사 \n 3. 백수");
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
            string str = AppDomain.CurrentDomain.BaseDirectory;
            StringBuilder sb = new StringBuilder();
            sb.Append(str);
            sb.Append("CharData.txt");
            Console.WriteLine(sb.ToString());

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


        #region SetCharStatus

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
