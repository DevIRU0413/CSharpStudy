namespace List
{
    internal class Program
    {
        static void Main(string[] args)
        {
            // 리스트
            // 순서를 가지고 일렬로 나열한 원소들의 모임이다.
            // 순서가 있다는 점에서 집합과는 구별된다.
            // 갈림길이 없고, 일렬로 나열되어 처음과 끝이 각가 하나씩만 있다는 점에서 그래프와 구별된다. 

            // 리스트의 보통 연산들
            // 1. 빈 리스트를 만드는 연산
            // 2. 리스트가 비어있는지 확인하는 연산
            // 3. 리스트의 앞에 원소를 삽입하는 연산
            // 4. 리스트의 뒤에 원소를 삽입하는 연산
            // 5. 리스트의 원소를 지우는 연산
            // 6. 리스트의 제일 첫 원소를 알아보는 연산
            // 7. 리스트의 첫 원소를 제외한 나머지 리스트를 알아보는 연산

            // 배열 기반 리스트
            // 추상적 자료형인 리스트를 배열을 사용하여 구현한 자료 구조다.

            // 장점
            // 1. 데이터의 참조가 쉽다.
            // 2. 인덱스 값을 기준으로 어디든 한번에 참조가 가능하다.
            // 3. 배열을 선언할 때 정해진 크기만큼 연속된 메모리 주소를 할당 받는다.
            // 단점
            // 연속된 메모리 주소를 할당해야 하기 때문에 배열의 길이가 초기에 결정되어야 한다.
            // 배열의 길이가 변경이 불가능하다.

            // 연결 리스트
            // 데이터를 저장할 때 하나의 데이터와 그 다음 데이터로의 위치를 함께 저장하여 논리적으로 연결하는 방식으로 자료를 저장한다.

            // 단순 연결 리스트
            // 단순 연결 리스트는 각 노드에 자료 공간과 한개의 포인터 공간이 있고, 각 노드의 포인터는 다음 노드를 가리킨다.

            // 원형 연결 리스트
            // 원형 연결 리스트는 일반적인 연결 리스트의 마지막 노드의 참조가 처음 노드를 참조하여 원형 형태로 만든 구조이다.

            // 양방향 연결 리스트
            // 양방향 연결 리스트는 단일 연결 리스트와 비슷하지만, 포인터 공간이 두 개가 있고 각각의 포인터는 앞의 노드와 뒤의 노드를 가리킨다.

            // 장점
            // 1. 데이터의 추가와 삭제가 용이하다.
            // 2. 리스트의 크기를 자유롭게 조절할 수 있다. 즉, 크기를 미리 지정할 필요가 없다.
            // 단점
            // 1. 배열과 달리 연속적인 메모리 주소를 할당 받지 않기 때문에 임의 접근이 불가능하다.
            List<string> list = new List<string>();
            NewList<int> newList = new NewList<int>();
            newList.AddLast(3);
            newList.AddLast(4);
            newList.AddLast(5);
            newList.AddFirst(2);

            Console.WriteLine(newList.Count);
            Console.WriteLine();
            for (int i = 0; i < newList.Count; i++)
            {
                Console.WriteLine(newList[i]);
            }

            newList.RemoveAt(3);

            Console.WriteLine();
            Console.WriteLine(newList.Count);
            Console.WriteLine();
            for (int i = 0; i < newList.Count; i++)
            {
                Console.WriteLine(newList[i]);
            }

            var restList = newList.GetRest();
            Console.WriteLine();
            Console.WriteLine(newList.Count);
            Console.WriteLine();
            for (int i = 0; i < restList.Count; i++)
            {
                Console.WriteLine(restList[i]);
            }

        }
    }
}
