using System;

namespace Scripts.Data
{
    [Serializable]
    public class Loot
    {

        public Loot(int value =10)
        {
            this.value = value;
        }
        public int value;
    }


}