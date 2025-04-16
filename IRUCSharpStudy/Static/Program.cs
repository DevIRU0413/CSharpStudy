using System.Text;

namespace Static
{
    public static class MathHelper
    {
        public static int Add(int a, int b)
        {
            return a + b;
        }

        public static double SquareRoot(double x)
        {
            return Math.Sqrt(x);
        }
    }

    public class Game
    {
        public static int PlayerCount = 0;

        public static void AddPlayer()
        {
            PlayerCount++;
            Console.WriteLine($"현재 플레이어 수: {PlayerCount}");
        }
    }

    public class Logger
    {
        public static string FilePath;

        // static 생성자
        static Logger()
        {
            FilePath = "log.txt";
            Console.WriteLine("Logger 초기화됨!");
        }

        public static void Log(string message)
        {
            Console.WriteLine($"[{FilePath}] {message}");
        }

        // ETC...
    }

    public static class GameConfig
    {
        public static readonly int MaxPlayer = 4;
        public static readonly string GameName = "드래곤 슬레이어";
    }

    public class GameManager
    {
        private static GameManager _instance = null;
        public static GameManager Instance
        {
            get
            {
                if (_instance == null)
                    _instance = new GameManager();
                return _instance;
            }
        }

        private GameManager()
        {
            Console.WriteLine("GameManager 생성됨!");
        }

        public void StartGame()
        {
            Console.WriteLine("게임 시작!");
        }
    }

    


    internal class Program
    {
        public static void ProcessLogFile(string path, bool summaryOnly)
        {
            if (!File.Exists(path))
            {
                Console.WriteLine("❌ 파일을 찾을 수 없습니다.");
                return;
            }

            var lines = File.ReadAllLines(path);

            if (summaryOnly)
            {
                Console.WriteLine($"✅ 로그 줄 수: {lines.Length}");
            }
            else
            {
                Console.WriteLine("📄 전체 로그 내용:");
                foreach (var line in lines)
                {
                    Console.WriteLine(line);
                }
            }
        }

        // static void Main(string[] args) — 왜 static일까?
        // 프로그램이 실행될 때, Main 메서드를 호출할 인스턴스가 아직 존재해지 않기 때문이다.
        static void Main(string[] args)
        {
            Console.OutputEncoding = Encoding.Unicode; // UTF-16 (LE)

            if (args.Length == 0)
            {
                Console.WriteLine("사용법: LogProcessor.exe <파일경로> [--summary-only]");
                return;
            }

            string filePath = args[0];
            bool summaryOnly = args.Contains("--summary-only");

            ProcessLogFile(filePath, summaryOnly);
            return;


            // 인스턴스 없이 바로 호출이 가능
            int sum = MathHelper.Add(3, 5);
            double root = MathHelper.SquareRoot(sum);

            // 공유 상태를 `static` 필드로 관리할 수 있다
            Game.AddPlayer();
            Game.AddPlayer();

            // 스태틱 클래스의 생성자는 클래스가 처음 참조될 때 한 번만 실행되는 초기화 로직
            Logger.Log("첫 번째 로그 메시지");

            // 글로벌하게 사용한다면 `static realonly` 처럼 사용하여 글로벌 상수로 만들어주는 방법도 존재
            Console.WriteLine(GameConfig.GameName);
            Console.WriteLine($"최대 플레이어 수: {GameConfig.MaxPlayer}");

            // 단 하나의 인스턴스만 존재하는 싱글톤 패턴 사용
            GameManager.Instance.StartGame();
        }
    }
}
