using System.Text;

namespace FullBinaryTree
{
    public static class BinaryTree
    {
        public static List<string> GetTokens(string expression)
        {
            List<string> tokens = new List<string>();
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

            return tokens;
        }

        public static Queue<string> GetPostfixNotation(List<string> tokens)
        {
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
                            op.Push(c);
                            break;
                    }
                }
            }

            // 나머지 기호 추가
            while (op.Count > 0)
                result.Enqueue(op.Pop());

            return result;
        }

        public static Queue<string> GetPostfixNotation(string expression)
        {
            List<string> tokens = GetTokens(expression);
            Queue<string> result = GetPostfixNotation(tokens);
            return result;
        }

        public static List<string> PrintTokens(string expression)
        {
            List<string> tokens = GetTokens(expression);
            PrintTokens(tokens);
            return tokens;
        }

        public static void PrintTokens(List<string> tokens)
        {
            // 토큰
            foreach (var c in tokens)
                Console.Write($"{c}, ");
            Console.WriteLine();
        }

        public static int CalculatePostfixNotation(string expression)
        {
            // 후위 표기식으로 계산하기
            List<string> tokenResult = GetPostfixNotation(expression).ToList();
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

            return int.Parse(tokenResult[0]);
        }

        public static int CalculatePostfixNotation2(string expression)
        {
            Stack<int> numStack = new Stack<int>();
            Queue<string> tokens = GetPostfixNotation(expression);
            while (tokens.Count > 0)
            {
                string output = tokens.Dequeue();
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

            return numStack.Pop();
        }

        public static BinaryTreeNode<string> GetRootNode(Queue<string> tonkens)
        {
            Stack<BinaryTreeNode<string>> stack = new Stack<BinaryTreeNode<string>>();
            Queue<string> tonkensCopy = new Queue<string>(tonkens);

            while (tonkensCopy.Count > 0)
            {
                var tonken = tonkensCopy.Dequeue();
                if (tonken != null && int.TryParse(tonken, out _))
                {
                    stack.Push(new BinaryTreeNode<string> { Value = tonken });
                }
                else
                {
                    var right = stack.Pop();
                    var left = stack.Pop();

                    var node = new BinaryTreeNode<string>
                    {
                        Value = tonken,
                        Parent = null,
                        ChildLeft = left,
                        ChildRight = right,
                    };

                    left.Parent = node;
                    right.Parent = node;

                    stack.Push(node);
                }
            }
            return stack.Pop();
        }

        public static void PrintTree2D(BinaryTreeNode<string> root)
        {
            int depth = GetTreeDepth(root);
            string space = " ";
            string spaceDot = " ";

            Queue<BinaryTreeNode<string>> openNodes = new Queue<BinaryTreeNode<string>>();
            openNodes.Enqueue(root);

            BinaryTreeNode<string>[] parents = new BinaryTreeNode<string>[(1 << depth) - 1];
            // 그리기
            for (int i = 0; i < depth; i++)
            {
                StringBuilder spaceStr = new StringBuilder();
                StringBuilder edgeSpaceStr = new StringBuilder();

                // 각 파트들의 공백 산출 
                int spaceCount = GetNoneSpaceOfDepth(depth - (1 + i));
                int edgeSpaceCount = GetNoneSpaceOfDepth(depth - (2 + i));

                int count = openNodes.Count;
                for (int j = 0; j < count; j++)
                {
                    // 그려줄 노드
                    BinaryTreeNode<string> node = openNodes.Dequeue();

                    int addSpace = 0;
                    // 부모 노드가 없을 시, 루트 노드
                    if (node.Parent == null)
                    {
                        // 단순 추가
                        parents[(1 << i) - 1] = node;
                    }
                    else
                    {
                        // 부모의 산출 범위
                        int startParentPoint = (1 << i - 1) - 1;
                        int endParentPoint = startParentPoint + (1 << i - 1);

                        // 부모의 위치
                        int findParent = -1;

                        // 부모 찾기
                        for (int k = startParentPoint; k < endParentPoint; k++)
                        {
                            if (parents[k] == node.Parent)
                            {
                                findParent = k - startParentPoint;
                                break;
                            }
                        }

                        // 찾는 부모가 없을 시, 예외 처리
                        if (findParent <= -1)
                            continue;

                        // 저장 가능한 위치 범위
                        int startSavePoint = (1 << i) - 1;
                        int endSavePoint = startSavePoint + (1 << i);

                        // 몇번째에 출력할 것인지를 위해 정확한 위치 선정(좌우 판별)
                        int saveNumPoint =  (findParent * 2);
                        if (parents[startParentPoint + findParent].ChildRight == node)
                            saveNumPoint += 1;

                        // 범위 초과 체크
                        if(endSavePoint <= startSavePoint + saveNumPoint)
                            throw new Exception($"범위 초과 체크 Error / 추가하려는 곳의Index[{startSavePoint + saveNumPoint}] / 최대가능Index: [{endSavePoint - 1}], ");

                        // 초기 저장 가능 위치 + 떨어져있는 위치 < 에 현 체크 노드 저장 
                        parents[startSavePoint + saveNumPoint] = node;

                        // 몇번째로 떨어져있는지
                        addSpace = saveNumPoint;
                    }

                    int printSapce = addSpace * (spaceCount * 2 + (3 * 2)); // 몇번째 떨어져 있는지 * 빈공간 * 2 + (노드 출력, 정렬을 위한 빈공간)
                    int printEdge = addSpace * 2 * (edgeSpaceCount * 2 + (3 * 2)); // 몇번째 떨어져 있는지 * (간선은 2 방향이기에) * 빈공간 * 2 + (노드 출력, 정렬을 위한 빈공간) 
                    spaceStr.Insert(printSapce, space, spaceCount);
                    spaceStr.Insert(printSapce + spaceCount, $"[{node.Value}]");
                    spaceStr.Insert(printSapce + spaceCount + 3, space, spaceCount);
                    spaceStr.Insert(printSapce + (spaceCount * 2) + 3, spaceDot, 3);

                    // 간선 출력(왼)
                    if (node.ChildLeft != null)
                    {
                        openNodes.Enqueue(node.ChildLeft);
                        edgeSpaceStr.Insert(printEdge, space, edgeSpaceCount);
                        edgeSpaceStr.Insert(printEdge + edgeSpaceCount, "  /");
                        edgeSpaceStr.Insert(printEdge + edgeSpaceCount + 3, "-", edgeSpaceCount);
                        edgeSpaceStr.Insert(printEdge + edgeSpaceCount * 2 + 3, spaceDot, 3);
                    }

                    // 간선 출력(우)
                    if (node.ChildRight != null)
                    {
                        openNodes.Enqueue(node.ChildRight);
                        int leftUseSpace = (edgeSpaceCount + 3) * 2 ;
                        edgeSpaceStr.Insert(printEdge + leftUseSpace, "-", edgeSpaceCount);
                        edgeSpaceStr.Insert(printEdge + leftUseSpace + edgeSpaceCount, "\\  ");
                        edgeSpaceStr.Insert(printEdge + leftUseSpace + edgeSpaceCount + 3, space, edgeSpaceCount);
                        edgeSpaceStr.Insert(printEdge + leftUseSpace + edgeSpaceCount * 2 + 3, spaceDot, 3);
                    }
                }

                Console.WriteLine(spaceStr.ToString());
                Console.WriteLine(edgeSpaceStr.ToString());

                spaceStr.Clear();
                edgeSpaceStr.Clear();
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

        public static int GetTreeDepth(BinaryTreeNode<string> root)
        {
            if (root == null) return 0;

            int depth = 0;
            Queue<BinaryTreeNode<string>> openNodes = new Queue<BinaryTreeNode<string>>();
            openNodes.Enqueue(root);

            while (openNodes.Count > 0)
            {
                int levelSize = openNodes.Count; // 현재 레벨에 있는 노드 수

                for (int i = 0; i < levelSize; i++)
                {
                    var current = openNodes.Dequeue();
                    if (current.ChildLeft != null) openNodes.Enqueue(current.ChildLeft);
                    if (current.ChildRight != null) openNodes.Enqueue(current.ChildRight);
                }
                depth++; // 레벨 하나 완료
            }

            return depth;
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