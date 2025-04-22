using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Delegate.Passive
{
    public class Thorns
    {
        private readonly int _thornsDamage;

        public Thorns(Character owner, int thornsDamage)
        {
            _thornsDamage = thornsDamage;
            owner.OnDamaged += HandleDamaged;
        }

        private void HandleDamaged(Character self, DamageInfo dmgInfo)
        {
            Console.WriteLine($"{self.Name}의 Thorns! 공격자에게 {_thornsDamage} 반사 피해.");
            dmgInfo.Attacker.TakeDamage(new DamageInfo(self, _thornsDamage));
        }
    }
}
