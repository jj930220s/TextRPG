using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TextRPG
{

    enum ITEMTYPE
    {
        EQUIP = 1,
        CONSUME
    }

    internal class IItem
    {
        public int index {  get; set; }
        public string name { get; set; }

        public int att { get; set; }

        public int def { get; set; }

        public ITEMTYPE ITEMTYPE { get; set; }

        public bool isSell {  get; set; }

        public bool isEquip {  get; set; }

        public string tip { get; set; }

        public void use(ITEMTYPE type)
        {
            switch (type)
            {
                case ITEMTYPE.EQUIP:
                    break;
                case ITEMTYPE.CONSUME:
                    break;
            }
        }

    }
    internal class Item
    {
        

    }
}
