using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Delegate
{
    public struct DamageInfo
    {
        public Character Attacker;
        public int Damage;

        public DamageInfo(Character Atkker, int Dmg) 
        {
            Attacker = Atkker;
            Damage = Dmg;
        }
    }
}
