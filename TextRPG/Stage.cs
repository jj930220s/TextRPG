using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using static System.Collections.Specialized.BitVector32;

namespace TextRPG
{
    internal class Stage
    {
        private Action showStatus;
        private Action showInven;

        public void StartStage(Action status, Action inven)
        {
            showStatus = status;
            showInven= inven;

            Console.WriteLine("당신은 작은 마을 입구에 서 있다.\n 무엇을 할까?");

            ShowOption();
    

        }


        private void ShowOption()
        {
            Console.WriteLine("1. 안으로 들어가다\n2. 내정보\n3.인벤토리");
            int input = int.Parse(Console.ReadLine());

            switch (input)
            {
                case 1:
                    break;
                case 2:
                    showStatus?.Invoke();
                    break;
                case 3:
                    showInven?.Invoke();
                    break;
                default:
                    Console.WriteLine("범위에서 벗어났습니다.");
                    break;
            }

        }


    }
}
