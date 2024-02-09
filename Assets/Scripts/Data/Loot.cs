using System;

namespace Scripts.Data
{
    [Serializable]
    public class Loot
    {

        public Loot(int value =0)
        {
            this.value = value;
        }
        public int value;
    }


}