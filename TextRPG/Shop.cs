using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TextRPG
{
    internal class Shop
    {

        // 기본 아이템 세팅 읽어오기
        // 엑셀이 안깔려있어서 텍스트파일로 대체
        public void SetBasicItem()
        {
            StringBuilder sb = new StringBuilder();
            sb.Append(AppDomain.CurrentDomain.BaseDirectory);
            sb.Append("ItemData.txt");

            StreamReader sr = new StreamReader(sb.ToString());
            string line;

            line = sr.ReadLine();

            List<IItem> items = new List<IItem>();

            while (line != null)
            {
                string[] itemData = line.Split(".");

                IItem newItem=new IItem();
                newItem.Name= itemData[0];
                newItem.att = int.Parse(itemData[1]);
                newItem.def = int.Parse(itemData[2]);
                newItem.ITEMTYPE =(ITEMTYPE)int.Parse(itemData[3]);
                newItem.isSell = int.Parse(itemData[4]) == 0 ? true : false;
                newItem.tip = itemData[5];
            
                items.Add(newItem);

                line = sr.ReadLine();

            }


            sr.Close();


        }



    }
}
