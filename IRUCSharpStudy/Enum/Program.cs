namespace Enum
{
    internal class Program
    {
        // 기본 선언
        public enum EquipmentType
        {
            Weapon,    // 무기    0
            Armor,     // 방어구  1
            Accessory  // 장신구  2
        }

        // 이런식으로 작성할 수 있고 에러도 나지 않는다. 
        // 대신 정수 10을 해당 형으로 변형 한다면, 무조건 앞에 오는 Weapon으로 판별도니다.
        public enum TestAEnum
        {
            Weapon = 10,     // 무기 10
            Armor,      // 방어구 11
            Accessory = 10   // 장신구 10
        }

        // 이러한 식으로 작성하면, 이러한 식으로 중간에 값을 작성하면 그 뒤는 해당 값을 기준으로 1씩 늘어나 지정된다.
        public enum TestBEnum
        {
            A = 900, // 900
            B,       // 901
            C = 10,  // 10
            D,       // 11
        }

        public enum TestCEnum : long
        {
            A = 900, // 900
            B,       // 901
            C = 10,  // 10
            D,       // 11
        }

        [Flags]
        public enum Equipment2Type
        {
            None       = 0,
            Weapon     = 1 << 0,   // 1
            Armor      = 1 << 1,   // 2
            Accessory  = 1 << 2,   // 4
            Shield     = 1 << 3,   // 8
            Ring       = 1 << 4    // 16
        }

        static void Main(string[] args)
        {
            Console.WriteLine("얻고 싶은 장비 번호를 선택하시요.");
            Console.WriteLine("0. 무기");
            Console.WriteLine("1. 방어구");
            Console.WriteLine("2. 장신구");
            
            Console.Write("[입력]: ");
            int inputValue;
            int.TryParse(Console.ReadLine(), out inputValue);
            Console.WriteLine($"획득한 장비: {GetEquipment(inputValue)}");



            Equipment2Type equippedItems = Equipment2Type.Weapon | Equipment2Type.Armor;

            Console.WriteLine($"현재 장비: {equippedItems}");

            // 장비 확인
            Console.WriteLine($"무기 착용 여부: {equippedItems.HasFlag(Equipment2Type.Weapon)}");
            Console.WriteLine($"반지 착용 여부: {equippedItems.HasFlag(Equipment2Type.Ring)}");

            // 장비 추가
            equippedItems |= Equipment2Type.Ring;
            Console.WriteLine($"[반지 장착 후] 현재 장비: {equippedItems}");

            // 장비 제거
            equippedItems &= ~Equipment2Type.Weapon;
            Console.WriteLine($"[무기 제거 후] 현재 장비: {equippedItems}");
        }

        public static EquipmentType GetEquipment(int value)
        {
            return (EquipmentType)value;
        }
    }
}
