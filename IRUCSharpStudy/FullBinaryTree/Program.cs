using System.Text;

namespace FullBinaryTree
{

    internal class Program
    {
        static void Main(string[] args)
        {
            List<string> tokens = new List<string>();
            // "(1 * 2 - 2) * (1 * 10 - 2)"
            string expression = "(1 * 2 - 2) * (1 * 10 - 2)";

            StringBuilder number = new StringBuilder();

            foreach (char c in expression)
            {
                if (char.IsWhiteSpace(c)) continue;

                if (char.IsDigit(c))
                {
                    number.Append(c); // 숫자 계속 누적
                }
                else
                {
                    if (number.Length > 0)
                    {
                        tokens.Add(number.ToString()); // 숫자 하나 토큰으로 저장
                        number.Clear();
                    }

                    // 연산자나 괄호는 별도 토큰
                    tokens.Add(c.ToString());
                }
            }

            // 마지막 숫자가 남아 있다면 추가
            if (number.Length > 0)
                tokens.Add(number.ToString());

            // 후위 표기식 처리
            Stack<string> op = new Stack<string>();
            Queue<string> result = new Queue<string>();

            foreach (var c in tokens)
            {
                if (int.TryParse(c, out int a))
                {
                    result.Enqueue(c);
                }
                else
                {
                    if (op.Count > 0 && c != "(" && (op.Peek() == "*" || op.Peek() == "/"))
                    {
                        result.Enqueue(op.Pop());
                    }
                    else if (c == ")")
                    {
                        while (op.Count > 0 && op.Peek() != "(")
                            result.Enqueue(op.Pop());

                        if (op.Count > 0) op.Pop();
                    }

                    switch (c)
                    {
                        case "+":
                        case "-":
                        case "*":
                        case "/":
                        case "(":
                            op.Push(c);
                            break;
                    }
                }
            }

            // 나머지 기호 추가
            while (op.Count > 0)
                result.Enqueue(op.Pop());

            // 토큰
            foreach (var c in tokens)
                Console.Write($"{c}, ");
            Console.WriteLine();

            // 후위 표기식 출력
            foreach (var c in result)
                Console.Write($"{c}, ");
            Console.WriteLine();

            List<string> tokenResult = result.ToList();
            for (int i = 0; i < tokenResult.Count; i++)
            {
                string token = tokenResult[i];

                int idx1 = i - 1;
                int idx2 = i - 2;
                if (idx1 >= 1 && idx2 >= 0 &&
                    int.TryParse(tokenResult[idx1], out int num1) &&
                    int.TryParse(tokenResult[idx2], out int num2) &&
                    !int.TryParse(token, out int x))
                {
                    int numResult = 0;
                    switch (token)
                    {
                        case "+":
                            numResult = num1 + num2;
                            break;
                        case "-":
                            numResult = num1 - num2;
                            break;
                        case "*":
                            numResult = num1 * num2;
                            break;
                        case "/":
                            numResult = num1 / num2;
                            break;
                    }

                    tokenResult[idx2] = numResult.ToString();
                    tokenResult.RemoveAt(i);
                    tokenResult.RemoveAt(idx1);
                    i -= 2;
                }
            }

            Console.WriteLine(tokenResult[0]);
        }
    }
}
