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

    interface IItem
    {
        public string Name { get; }

        public ITEMTYPE ITEMTYPE { get; }

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

    internal class Inventory
    {
        public List<IItem> inventory;





    }
}
