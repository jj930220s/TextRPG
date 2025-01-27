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


        }

}
