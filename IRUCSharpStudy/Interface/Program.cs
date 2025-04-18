using System;
using System.Collections.Generic;

namespace Interface
{
    #region UnitManager
    /// <summary>
    /// 생성된 모든 유닛을 한곳에서 관리하는 싱글톤 매니저
    /// </summary>
    public class UnitManager
    {
        private static readonly Lazy<UnitManager> _inst = new(() => new UnitManager());
        public static UnitManager Instance => _inst.Value;

        private readonly List<UnitBase> _units = new();
        public IReadOnlyList<UnitBase> Units => _units.AsReadOnly();

        private UnitManager() { }

        internal void Register(UnitBase u) => _units.Add(u);
    }
    #endregion

    #region 추상 클래스: UnitBase
    public abstract class UnitBase
    {
        public string Name { get; }
        public Guid Id { get; }

        protected UnitManager Manager => UnitManager.Instance;

        protected UnitBase(string name)
        {
            Name = name;
            Id = Guid.NewGuid();

            // 생성 즉시 매니저에 등록
            Manager.Register(this);
        }

        // 모든 유닛이 반드시 구현해야 할 기본 동작
        public abstract void Tick();
    }
    #endregion

    #region 행동 인터페이스들
    /// <summary>위치 이동</summary>
    public interface IMovable
    {
        void Move(int deltaX, int deltaY);
    }

    /// <summary>공격</summary>
    public interface IAttackable
    {
        void Attack(UnitBase target);
    }

    /// <summary>치유</summary>
    public interface IHealable
    {
        void Heal(int amount);
    }
    #endregion

    #region 구체 유닛 클래스들
    /// <summary>보병: 이동 + 공격</summary>
    public class Soldier : UnitBase, IMovable, IAttackable
    {
        private int _x, _y;

        public Soldier(string name) : base(name) { }

        public override void Tick()
        {
            // 매 프레임마다 AI나 입력 처리...
        }

        public void Move(int dx, int dy)
        {
            _x += dx; _y += dy;
            Console.WriteLine($"{Name}이 ({dx},{dy}) 만큼 이동 → 현재({_x},{_y})");
        }

        public void Attack(UnitBase target)
        {
            Console.WriteLine($"{Name}이 {target.Name}에게 총을 발사!");
        }
    }

    /// <summary>치유사: 이동 + 치유</summary>
    public class Healer : UnitBase, IMovable, IHealable
    {
        private int _x, _y;
        public Healer(string name) : base(name) { }

        public override void Tick() { }

        public void Move(int dx, int dy)
        {
            _x += dx; _y += dy;
            Console.WriteLine($"{Name}이 ({dx},{dy}) 만큼 이동 → 현재({_x},{_y})");
        }

        public void Heal(int amount)
        {
            Console.WriteLine($"{Name}이 아군 유닛을 {amount}만큼 치유!");
        }
    }

    /// <summary>전차: 이동 + 공격 + 치유(지원탄) 복합</summary>
    public class Tank : UnitBase, IMovable, IAttackable, IHealable
    {
        private int _x, _y;

        public Tank(string name) : base(name) { }

        public override void Tick() { }

        public void Move(int dx, int dy)
        {
            _x += dx; _y += dy;
            Console.WriteLine($"{Name} 전차가 바퀴로 이동 → 현재({_x},{_y})");
        }

        public void Attack(UnitBase target)
        {
            Console.WriteLine($"{Name} 전차가 포탄을 발사 → {target.Name} 타격!");
        }

        public void Heal(int amount)
        {
            Console.WriteLine($"{Name} 전차가 지원탄 공급 → 아군 {amount} 회복!");
        }
    }
    #endregion

    #region 실행 예제
    class Program
    {
        static void Main()
        {
            // 유닛 생성 시 자동으로 UnitManager.Instance.Register(this) 호출됨
            var s1 = new Soldier("보병-1");
            var h1 = new Healer ("치유사-1");
            var t1 = new Tank   ("탱크-1");

            Console.WriteLine("\n=== 전체 유닛 목록 ===");
            foreach (var u in UnitManager.Instance.Units)
                Console.WriteLine($"- {u.Name} (ID: {u.Id})");

            Console.WriteLine("\n=== 행동 시연 ===");
            s1.Move(1, 0);
            s1.Attack(h1);

            h1.Move(0, 1);
            h1.Heal(1);

            t1.Move(-1, 0);
            t1.Attack(s1);
            t1.Heal(1);
        }
    }
    #endregion
}
