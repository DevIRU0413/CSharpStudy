using System.Text;

namespace FullBinaryTree
{
    internal class Program
    {
        static void Main(string[] args)
        {
            List<string> tokens = new List<string>();
            // "(1 * 2 - 2) * (1 * 10 - 2)"
            // ((((((((((((((((1 + 2) + (3 + 4)) + ((5 + 6) + (7 + 8))) + (((9 + 1) + (2 + 3)) + ((4 + 5) + (6 + 7)))) + ((((8 + 9) + (1 + 2)) + ((3 + 4) + (5 + 6))) + (((7 + 8) + (9 + 1)) + ((2 + 3) + (4 + 5))))))))
            string expression = "((((1 * 2) + (3 * 4)) + ((5 * 6) + (7 * 8))))";

            Queue<string> result = BinaryTree.GetPostfixNotation(expression);

            // 후위 표기식 출력
            foreach (var c in result)
                Console.Write($"{c}, ");
            Console.WriteLine();

            BinaryTreeNode<string> root = BinaryTree.GetRootNode(result); 
            
            // 중위 연산 첸지
            PrintInOrder(root);
            Console.WriteLine();

            // 후위 표기식의 결과
            Console.WriteLine(BinaryTree.CalculatePostfixNotation(expression));
            Console.WriteLine(BinaryTree.CalculatePostfixNotation2(expression));

            // 트리 출력
            BinaryTree.PrintTree2D(root);
            Console.WriteLine();

            // 재귀 테스트
            for (int i = 0; i < result.Count; i++) 
                Console.WriteLine(BinaryTree.GetNoneSpaceOfDepth(5 - (i + 1)));
        }

        public static void PrintInOrder(BinaryTreeNode<string> node)
        {
            if (node == null) return;

            bool isOperator = node.Value == "+" || node.Value == "-" || node.Value == "*" || node.Value == "/";

            if (isOperator) Console.Write("(");
            PrintInOrder(node.ChildLeft);
            Console.Write(node.Value);
            PrintInOrder(node.ChildRight);
            if (isOperator) Console.Write(")");
        }
    }
}