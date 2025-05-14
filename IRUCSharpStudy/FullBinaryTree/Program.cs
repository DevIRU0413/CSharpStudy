using System.Text;

namespace FullBinaryTree
{
    public class Node<T>
    {
        public T Value;
        public Node<T> Parent;
        public Node<T> ChildLeft;
        public Node<T> ChildRight;
    }
    internal class Program
    {
        static void Main(string[] args)
        {
            List<string> tokens = new List<string>();
            // "(1 * 2 - 2) * (1 * 10 - 2)"
            string expression = "((((((((((((((((1 + 2) + (3 + 4)) + ((5 + 6) + (7 + 8))) + (((9 + 1) + (1 + 1)) + ((3 + 4) + (5 + 6)))) + ((((7 + 8) + (9 + 0)) + ((1 + 2) + (3 + 4))) + (((5 + 6) + (7 +28)) + ((9 + 0) + (1 + 2))))))))";

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

            // 후위 표기식으로 계산하기
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

            // 후위 표기식의 결과
            Console.WriteLine(tokenResult[0]);

            // 후위 표기식으로 계산하기 2
            Stack<int> numStack = new Stack<int>();
            Queue<string> coypResult = new Queue<string>();
            while (coypResult.Count > 0)
            {
                string output = coypResult.Dequeue();
                if (output != null && int.TryParse(output, out int outPutNum))
                {
                    numStack.Push(outPutNum);
                }
                else
                {
                    int num2 = numStack.Pop();
                    int num1 = numStack.Pop();
                    switch (output)
                    {
                        case "+":
                            numStack.Push(num1 + num2);
                            break;
                        case "-":
                            numStack.Push(num1 - num2);
                            break;
                        case "*":
                            numStack.Push(num1 * num2);
                            break;
                        case "/":
                            numStack.Push(num1 / num2);
                            break;
                        default:
                            continue;
                    }
                }
            }

            // 트리 생성기 구조
            Stack<Node<string>> nodeStack = new Stack<Node<string>>();
            Queue<string> pResult = new Queue<string>(result);
            while (pResult.Count > 0)
            {
                string output = pResult.Dequeue();
                if (output != null && int.TryParse(output, out int outPutNum))
                {
                    nodeStack.Push(new Node<string>() { Value = output });
                }
                else
                {
                    if (nodeStack.Count < 2)
                    {
                        Console.WriteLine($"❗ 오류: 연산 '{output}' 처리 중 피연산자가 부족합니다.");
                        break; // 또는 throw
                    }

                    var num2 = nodeStack.Pop();
                    var num1 = nodeStack.Pop();

                    Node<string> opNode = new Node<string>
                    {
                        Value = output,
                        ChildLeft = num1,
                        ChildRight = num2
                    };

                    num1.Parent = opNode;
                    num2.Parent = opNode;

                    nodeStack.Push(opNode);
                }
            }

            Node<string> root = nodeStack.Pop();
            PrintInOrder(root);
            Console.WriteLine();
            PrintTree2D(root);
            Console.WriteLine();

            Console.WriteLine(GetNoneSpaceOfDepth(5 - 1));
            Console.WriteLine(GetNoneSpaceOfDepth(4 - 1));
            Console.WriteLine(GetNoneSpaceOfDepth(3 - 1));
            Console.WriteLine(GetNoneSpaceOfDepth(2 - 1));
            Console.WriteLine(GetNoneSpaceOfDepth(1 - 1));
        }

        public static void PrintInOrder(Node<string> node)
        {
            if (node == null) return;

            bool isOperator = node.Value == "+" || node.Value == "-" || node.Value == "*" || node.Value == "/";

            if (isOperator) Console.Write("(");
            PrintInOrder(node.ChildLeft);
            Console.Write(node.Value);
            PrintInOrder(node.ChildRight);
            if (isOperator) Console.Write(")");
        }

        // 이진 트리는 depth^2 - 1 가 이하의 노드를 가진다.
        public static void PrintTree2D(Node<string> root)
        {

            int depth = 1; // 1인데 편의상 0으로 시작
            Queue<Node<string>> openNodes = new Queue<Node<string>>();
            openNodes.Enqueue(root);

            while (openNodes.Count > 0)
            {
                int levelSize = openNodes.Count; // 현재 레벨에 있는 노드 수

                for (int i = 0; i < levelSize; i++)
                {
                    var current = openNodes.Dequeue();

                    if (current.ChildLeft != null)
                        openNodes.Enqueue(current.ChildLeft);
                    if (current.ChildRight != null)
                        openNodes.Enqueue(current.ChildRight);
                }

                depth++; // 레벨 하나 완료
            }

            // 클리어
            openNodes.Clear();
            // 루트 다시 넣어주기
            openNodes.Enqueue(root);

            // 그리기
            for (int i = 0; i < depth; i++)
            {
                // 시작 빈 공간 및 노드 출력
                StringBuilder spaceStr = new StringBuilder();
                int spaceCount = GetNoneSpaceOfDepth(depth - (1 + i));

                // 간선 출력
                StringBuilder edgeSpaceStr = new StringBuilder();
                int edgeSpaceCount = GetNoneSpaceOfDepth(depth - (2 + i));

                int count = openNodes.Count;
                while (count > 0)
                {
                    Node<string> node = openNodes.Dequeue();
                    spaceStr.Append(' ', spaceCount);
                    spaceStr.Append($"[{node.Value}]");
                    spaceStr.Append(' ', spaceCount + 3);

                    edgeSpaceStr.Append(' ', edgeSpaceCount);

                    // 간선 출력(왼)
                    if (node.ChildLeft != null)
                    {
                        openNodes.Enqueue(node.ChildLeft);
                        edgeSpaceStr.Append("  /");
                        edgeSpaceStr.Append('-', edgeSpaceCount);
                    }


                    // 간선 출력(우)
                    if (node.ChildRight != null)
                    {
                        edgeSpaceStr.Append('-', edgeSpaceCount + 3);
                        openNodes.Enqueue(node.ChildRight);
                        edgeSpaceStr.Append("\\  ");
                        
                    }

                    edgeSpaceStr.Append(' ', edgeSpaceCount);
                    edgeSpaceStr.Append(' ', 3);
                    count--;
                }

                Console.WriteLine(spaceStr.ToString());
                Console.WriteLine(edgeSpaceStr.ToString());
            }
        }

        public static int GetNoneSpaceOfDepth(int depth)
        {
            if (depth == 1)
                return (depth - 1) * 2 + 3;
            else if (depth <= 0)
                return 0;

            int result = GetNoneSpaceOfDepth(depth - 1) * 2 + 3;
            return result;
        }
    }
}

/*

depth 1
[+]

depth 2
...[+]
../...\
[+]...[+]

depth 3
.........[+]
...../.........\
...[+].........[+]
../...\......./...\
[1]...[*]...[1]...[*]

depth 4
.....................[+] 21 / 0 / 0
................................\ 
.........[+].....................[+] 9 / 15 / 0 
...../.........\............./.........\
...[1].........[*].........[1].........[*] 3 / 9 / 9
../...\......./...\......./...\......./...\ 
[1]...[*]...[1]...[*]...[1]...[*]...[1]...[*] 0 / 3 / 3

depth 5
.............................................[+]                                                > 45
......................./.............................................\                          > 23(21+2) / 45(21 * 2 + 3)

.....................[+].............................................[+]                        > 21 / 45(21 * 2 + 3)
.........../.....................\........................./.....................\              > 11(9 + 2) / 21(9 * 2 + 3)

.........[+].....................[+].....................[+].....................[+]            > 9 / 21(9 * 2 + 3) / 0 
...../.........\............./.........\............./.........\............./.........\.....   > 5(3+2) / 9 (3 * 2 + 3)

...[1].........[*].........[1].........[*].........[1].........[*].........[1].........[*]...   > 3 / 9(3 * 2 + 3)
../...\......./...\......./...\......./...\......./...\......./...\......./...\......./...\..   > 2(0+2) / 3(0 * 2 + 3)

[1]...[*]...[1]...[*]...[1]...[*]...[1]...[*]...[1]...[*]...[1]...[*]...[1]...[*]...[1]...[*]   > 0 / 3(0 * 2 + 3)

*/

