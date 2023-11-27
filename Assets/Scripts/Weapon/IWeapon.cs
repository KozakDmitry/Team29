using Scripts.StaticData;

namespace Scripts.Weapon
{
    public interface IWeapon
    {
    
        public string name { get; set; }
        public int level { get; set; }

        public void LevelUp();
        public void Activate();
        
        public void Deactivate();

        public void Construct();

       

    }
}