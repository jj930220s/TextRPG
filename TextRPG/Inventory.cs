using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml.Linq;

namespace TextRPG
{
    internal class Inventory
    {
        public List<IItem> inventory;


        public void ShowInven()
        {
            Console.Clear();

            foreach (var item in inventory)
            {
                Console.WriteLine(item.name);
            }
        }

        public void InputItem(IItem item)
        {
            inventory.Add(item);
            SaveInvenData();
        }

        public void InputItem(int index)
        {

            inventory.Add(item);
            SaveInvenData();

        }

        public void UseItem(IItem item)
        {
            if (item.ITEMTYPE == ITEMTYPE.CONSUME)
                inventory.Remove(item);
            else
            {

            }
            SaveInvenData();
        }

        public void SaveInvenData()
        {
            StringBuilder sb = new StringBuilder();
            sb.Append(AppDomain.CurrentDomain.BaseDirectory);
            sb.Append("InvenData.txt");


            try
            {
                StreamWriter sw = new StreamWriter(sb.ToString());

                for(int i = 0; i < inventory.Count;i++)
                {
                    sw.Write(inventory.ElementAt(i).index+".");
                    sw.Write(inventory.ElementAt(i).name+".");
                    sw.Write(inventory.ElementAt(i).att+".");
                    sw.Write(inventory.ElementAt(i).def+".");
                    sw.Write(inventory.ElementAt(i).ITEMTYPE+".");
                    sw.Write(inventory.ElementAt(i).isSell+".");
                    sw.WriteLine(inventory.ElementAt(i).tip);
                }

                sw.Close();
            }
            catch (Exception e)
            {
                Console.WriteLine(e.Message);
            }
        }
        public void LoadInvenData()
        {
            string line;
            try
            {
                StringBuilder sb = new StringBuilder();
                sb.Append(AppDomain.CurrentDomain.BaseDirectory);
                sb.Append("InvenData.txt");

                StreamReader sr = new StreamReader(sb.ToString());

                line = sr.ReadLine();

                while (line != null)
                {
                    
                    Console.WriteLine(line);

                    string[] itemData = line.Split(".");
                    IItem newItem = new IItem();
                    newItem.index = int.Parse(itemData[0]);
                    newItem.name = itemData[1];
                    newItem.att = int.Parse(itemData[2]);
                    newItem.def = int.Parse(itemData[3]);
                    newItem.ITEMTYPE = (ITEMTYPE)int.Parse(itemData[4]);
                    newItem.isSell = int.Parse(itemData[5]) == 0 ? true : false;
                    newItem.tip = itemData[6];

                    inventory.Add(newItem);

                    line = sr.ReadLine();
                }
                sr.Close();
                Console.ReadLine();
            }
            catch (Exception e)
            {
                Console.WriteLine(e.Message);
            }
        }
    }
}
