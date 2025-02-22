﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml.Linq;

namespace TextRPG
{
    internal class Inventory
    {
        public List<Item> inven=new List<Item>();


        public void ShowInven()
        {
            Console.Clear();

            foreach (var item in inven)
            {
                Console.ForegroundColor = ConsoleColor.Blue;
                Console.Write(item.isEquip == true ? "[E]" :"   ");
                Console.ResetColor();

                Console.Write(item.name + " | ");
                switch (item.ITEMTYPE)
                {
                    case ITEMTYPE.EQUIP:
                        Console.Write("공격력 : "+item.att + " | ");
                        Console.Write("방어력 : "+item.def + " | ");
                        break;
                    case ITEMTYPE.CONSUME:
                        Console.Write("회복량 :"+item.att + " | ");
                        break;
                } 
                Console.WriteLine(item.tip + " ");
            }
        }

        public void InputItem(Item item)
        {
            inven.Add(item);
            SaveInvenData();
        }

        public void InputItem(int index)
        {
            Item item = Shop.items[index];

            inven.Add(item);

            SaveInvenData();
        }

        public void UseItem(Item item)
        {
            if (item.ITEMTYPE == ITEMTYPE.CONSUME)
            {
                GameManager.instance.Player.GetHP(item.att);
                inven.Remove(item);
            }
            else
            {
                EquipItem(item);
            }
            SaveInvenData();
        }

        public void UseItem(int index)
        {
            UseItem(inven.ElementAt(index));
        }

        private void EquipItem(Item item)
        {
            switch(item.isEquip)
            {
                case true:
                    GameManager.instance.Player.PlayerAtt -= item.att;
                    GameManager.instance.Player.PlayerDef -= item.def;
                    GameManager.instance.Player.PlayerItemAtt -= item.att;
                    GameManager.instance.Player.PlayerItemDef -= item.def;
                    item.isEquip = !item.isEquip;
                    break;
                case false:
                    GameManager.instance.Player.PlayerAtt += item.att;
                    GameManager.instance.Player.PlayerDef += item.def;
                    GameManager.instance.Player.PlayerItemAtt += item.att;
                    GameManager.instance.Player.PlayerItemDef += item.def;
                    item.isEquip = !item.isEquip;
                    break;
            }
            GameManager.instance.Player.SavePlayerData();
        }

        public void SaveInvenData()
        {
            StringBuilder sb = new StringBuilder();
            sb.Append(AppDomain.CurrentDomain.BaseDirectory);
            sb.Append("InvenData.txt");

            inven.OrderBy(i => i.index);

            try
            {
                StreamWriter sw = new StreamWriter(sb.ToString());

                for(int i = 0; i < inven.Count;i++)
                {
                    sw.Write(inven.ElementAt(i).index+".");
                    sw.Write(inven.ElementAt(i).name+".");
                    sw.Write(inven.ElementAt(i).att+".");
                    sw.Write(inven.ElementAt(i).def+".");
                    sw.Write((int)inven.ElementAt(i).ITEMTYPE+".");
                    sw.Write((inven.ElementAt(i).isSell == true ? 1 : 0) + ".");
                    sw.Write((inven.ElementAt(i).isEquip == true ? 1 : 0) + ".");
                    sw.WriteLine(inven.ElementAt(i).tip);
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
            StringBuilder sb = new StringBuilder();
            sb.Append(AppDomain.CurrentDomain.BaseDirectory);
            sb.Append("InvenData.txt");
            try
            {

                StreamReader sr = new StreamReader(sb.ToString());

                line = sr.ReadLine();

                while (line != null)
                {
                    string[] itemData = line.Split(".");
                    Item newItem = new Item();
                    newItem.index = int.Parse(itemData[0]);
                    newItem.name = itemData[1];
                    newItem.att = int.Parse(itemData[2]);
                    newItem.def = int.Parse(itemData[3]);
                    newItem.ITEMTYPE = (ITEMTYPE)int.Parse(itemData[4]);
                    newItem.isSell = int.Parse(itemData[5]) == 1 ? true : false;
                    newItem.isEquip = int.Parse(itemData[6]) == 1 ? true : false;
                    newItem.tip = itemData[7];

                    inven.Add(newItem);

                    line = sr.ReadLine();
                }
                sr.Close();
            }
            catch (Exception e)
            {
                // 첫 실행시 파일이 없는 경우 파일 생성
                StreamWriter sw = new StreamWriter(sb.ToString());
                sw.Write("");
            }
        }
    }
}
