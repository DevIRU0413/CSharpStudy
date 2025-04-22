namespace Delegate
{
    // 이벤트 시그니처 정의
    public delegate void TurnHandler(Character sender);
    public delegate void DamageHandler(Character sender, DamageInfo damageInfo);
    public delegate void AttackHandler(Character sender, Character target, DamageInfo damageInfo);

    // Character 클래스
    public class Character
    {
        public string Name { get; }
        public int HP { get; private set; }
        public int ATK { get; private set; }

        // 4가지 이벤트
        public event TurnHandler OnTurnStart;
        public event TurnHandler OnTurnEnd;
        public event DamageHandler OnDamaged;
        public event AttackHandler OnAttacked;

        public Character(string name, int hp, int atk)
        {
            Name = name;
            HP = hp;
            ATK = atk;
        }

        // 턴 시작
        public void StartTurn()
        {
            Console.WriteLine($"\n>> {Name}의 턴이 시작됩니다.");
            OnTurnStart?.Invoke(this);
        }

        // 턴 종료
        public void EndTurn()
        {
            OnTurnEnd?.Invoke(this);
            Console.WriteLine($">> {Name}의 턴이 종료되었습니다.\n");
        }

        // 공격 메서드
        public void Attack(Character target)
        {
            Console.WriteLine($"{Name}이 {target.Name}에게 {ATK}의 피해를 줍니다.");
            var dmgInfo = new DamageInfo(this, ATK);
            target.TakeDamage(dmgInfo);
            OnAttacked?.Invoke(this, target, dmgInfo);
        }

        // 피해 처리
        public void TakeDamage(DamageInfo dmgInfo)
        {
            HP -= dmgInfo.Damage;
            Console.WriteLine($"{Name}이 {dmgInfo.Damage}만큼 피해를 받았습니다. (남은 HP: {HP})");
            OnDamaged?.Invoke(this, dmgInfo);
        }

        public void Recovery(int recoveryHp)
        {
            HP += recoveryHp;
            Console.WriteLine($"{Name} 체력회복 (남은 HP: {HP})");
        }
    }

}
