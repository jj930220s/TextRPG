using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace TextRPG
{
    internal class StartScene
    {
        public void Logo(Action action)
        {
            action?.Invoke();   //로고 보여줄 때 로드 미리 해두기
            ShowLogo();
        }

        public void ShowLogo()
        {
            Console.WriteLine("Show Logo \n 아무키나 누르세요");
            Console.ReadKey();
            Console.Clear();
        }


    }
}

