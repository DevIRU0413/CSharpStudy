using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Delegate.Passive
{
    public class Regeneration
    {
        private readonly int _healAmount;

        public Regeneration(Character owner, int healAmount)
        {
            _healAmount = healAmount;
            owner.OnTurnStart += HandleTurnStart;
        }

        private void HandleTurnStart(Character self)
        {
            Console.WriteLine($"{self.Name}의 Regeneration! {_healAmount} 회복.");
            self.Recovery(_healAmount);
        }
    }
}
