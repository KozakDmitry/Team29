using Scripts.Logic;
using UnityEngine;

namespace Scripts.UI.Logic
{
    public class UIController : MonoBehaviour
    {
        public HpBar _hpBar;
        private IHealth _health;

        private void OnDestroy() => 
            _health.HealthChanged -= ChangeUI;
        public void Construct(IHealth health)
        {
            _health = health;
            _health.HealthChanged += ChangeUI;
        }

        private void ChangeUI() => 
            _hpBar.SetValue(_health.Current, _health.Max);
    }
}