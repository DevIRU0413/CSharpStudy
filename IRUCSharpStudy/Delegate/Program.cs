using Delegate.Passive;

namespace Delegate
{
    class Program
    {
        static void Main()
        {
            // 캐릭터 생성
            var hero = new Character("영웅", 100, 10);
            var monster = new Character("몬스터", 50, 5);

            // 패시브 부여
            var regen = new Regeneration(hero, 5);
            var thorns = new Thorns(monster, 3);

            // 턴 진행
            hero.StartTurn();
            hero.Attack(monster);
            hero.EndTurn();

            monster.StartTurn();
            monster.Attack(hero);
            monster.EndTurn();
        }
    }
}
