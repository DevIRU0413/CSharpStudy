using System;

namespace Operator
{
    internal class Program
    {
        static void Main(string[] args)
        {
            int iFirstNum = 10;
            int iSecondNum = 3;

            Console.WriteLine("\n= 정수 출력 결과 =");
            Console.WriteLine("{0} + {1} = {2}", iFirstNum, iSecondNum, iFirstNum + iSecondNum);
            Console.WriteLine("{0} - {1} = {2}", iFirstNum, iSecondNum, iFirstNum - iSecondNum);
            Console.WriteLine("{0} * {1} = {2}", iFirstNum, iSecondNum, iFirstNum * iSecondNum);
            Console.WriteLine("{0} / {1} = {2}", iFirstNum, iSecondNum, iFirstNum / iSecondNum);
            Console.WriteLine("{0} % {1} = {2}", iFirstNum, iSecondNum, iFirstNum % iSecondNum);


            float fFirstNum2 = 10.0f;
            float fSecondNum2 = 3.0f;

            Console.WriteLine("\n= 실수 출력 결과 =");
            Console.WriteLine("{0} + {1} = {2}", fFirstNum2, fSecondNum2, fFirstNum2 + fSecondNum2);
            Console.WriteLine("{0} - {1} = {2}", fFirstNum2, fSecondNum2, fFirstNum2 - fSecondNum2);
            Console.WriteLine("{0} * {1} = {2}", fFirstNum2, fSecondNum2, fFirstNum2 * fSecondNum2);
            Console.WriteLine("{0} / {1} = {2}", fFirstNum2, fSecondNum2, fFirstNum2 / fSecondNum2);
            Console.WriteLine("{0} % {1} = {2}", fFirstNum2, fSecondNum2, fFirstNum2 % fSecondNum2);


            int iFixedNum = 10;
            int iSecondNum3 = 3;

            int numA = iFixedNum;
            int numB = iFixedNum;
            int numC = iFixedNum;
            int numD = iFixedNum;
            int numE = iFixedNum;

            numA += iSecondNum3; // numA = 10 + iSecondNum 와 같은 기능을 한다.
            numB -= iSecondNum3; // numB = 10 - iSecondNum 와 같은 기능을 한다.
            numC *= iSecondNum3; // numC = 10 * iSecondNum 와 같은 기능을 한다.
            numD /= iSecondNum3; // numD = 10 / iSecondNum 와 같은 기능을 한다.
            numE %= iSecondNum3; // numE = 10 % iSecondNum 와 같은 기능을 한다.
            
            Console.WriteLine("\n= 대입 연산자 사용 출력 결과(정수 사용) =");
            Console.WriteLine("{0} + {1} = {2}", iFirstNum, iSecondNum3, numA);
            Console.WriteLine("{0} - {1} = {2}", iFirstNum, iSecondNum3, numB);
            Console.WriteLine("{0} * {1} = {2}", iFirstNum, iSecondNum3, numC);
            Console.WriteLine("{0} / {1} = {2}", iFirstNum, iSecondNum3, numD);
            Console.WriteLine("{0} % {1} = {2}", iFirstNum, iSecondNum3, numE);

            /*
            위의 대입 연산자와 같은 결과 출력한다.
            Console.WriteLine("{0} + {1} = {2}", iFirstNum, iSecondNum3, iFirstNum + iSecondNum3);
            Console.WriteLine("{0} - {1} = {2}", iFirstNum, iSecondNum3, iFirstNum - iSecondNum3);
            Console.WriteLine("{0} * {1} = {2}", iFirstNum, iSecondNum3, iFirstNum * iSecondNum3);
            Console.WriteLine("{0} / {1} = {2}", iFirstNum, iSecondNum3, iFirstNum / iSecondNum3);
            Console.WriteLine("{0} % {1} = {2}", iFirstNum, iSecondNum3, iFirstNum % iSecondNum3);
            */

            string id = "HelloWorld!";
            string pw = "No!Hello";

            string inputID = "HelloWorld!";
            string inputPW = "Yes!Hello";

            bool equalsID = id == inputID;
            bool equalsPW = pw == inputPW;

            Console.WriteLine("\n= 비교 연산자 사용 출력 결과1 =");
            Console.WriteLine("내 아이디: {0}", id);
            Console.WriteLine("내 비밀번호: {0}", pw);

            Console.WriteLine("내가 입력한 아이디: {0}", inputID);
            Console.WriteLine("내가 입력한 비밀번호: {0}", inputPW);

            Console.WriteLine("내가 입력한 아이디와 내 아이디가 같은지 여부: {0}", equalsID);
            Console.WriteLine("내가 입력한 비밀번호와 내 비밀번호가 같은지 여부: {0}", equalsPW);

            int totalAppleCount = 10;
            int eatAppleCount = 6;

            Console.WriteLine("\n= 비교 연산자 사용 출력 결과2 =");
            Console.WriteLine("내가 가지고 있는 사과 개수: {0}", totalAppleCount);
            Console.WriteLine("내가 먹은 사과 개수: {0}", eatAppleCount);

            Console.WriteLine("총 사과 {0}, 먹은 사과 {1}, 총 사과 != 먹은 사과 >> {2}", totalAppleCount, eatAppleCount, totalAppleCount != eatAppleCount);
            Console.WriteLine("총 사과 {0}, 먹은 사과 {1}, 총 사과 < 먹은 사과 >> {2}", totalAppleCount, eatAppleCount, totalAppleCount < eatAppleCount);
            Console.WriteLine("총 사과 {0}, 먹은 사과 {1}, 총 사과 > 먹은 사과 >> {2}", totalAppleCount, eatAppleCount, totalAppleCount > eatAppleCount);
            Console.WriteLine("총 사과 {0}, 먹은 사과 {1}, 총 사과 <= 먹은 사과 >> {2}", totalAppleCount, eatAppleCount, totalAppleCount <= eatAppleCount);
            Console.WriteLine("총 사과 {0}, 먹은 사과 {1}, 총 사과 >= 먹은 사과 >> {2}", totalAppleCount, eatAppleCount, totalAppleCount >= eatAppleCount);

            int totalChicken = 10;
            int soldChicken = 6;

            Console.WriteLine("\n= 논리 연산자 사용 출력 결과 =");
            Console.WriteLine("오늘 판매한 치킨 개수 {0}, 오늘 만든 총 치킨 {1}", soldChicken, totalChicken);
            Console.WriteLine("오늘 만든 치킨은 10개이면서 판매한 치킨이 만든 치킨의 50%를 넘었는가? {0}", totalChicken == 10 && ((float)soldChicken / (float)totalChicken) > 0.5f);
            Console.WriteLine("오늘 만든 치킨은 10개이거나 판매한 치킨이 만든 치킨의 50%를 넘었는가? {0}", totalChicken == 10 || ((float)soldChicken / (float)totalChicken) > 0.5f);
            Console.WriteLine("오늘 만든 치킨은 10개도 아니면서 판매한 치킨이 만든 치킨의 50%를 못 넘었는가? {0}", !(totalChicken == 10 && ((float)soldChicken / (float)totalChicken) > 0.5f));


            int OneHundredMillion = 1; // 1억이 있다고 가정하자. (그냥 이건 1억이다. 환율 안친다.)

            // 이런 식으로 처리되면 은행 전화 폭주 할듯
            /*Console.WriteLine("\n= 증감 연산자 사용 출력 결과 =");
            Console.WriteLine("통장의 잔고: {0}억", OneHundredMillion);
            Console.WriteLine("{0}억 입금", 1);
            Console.WriteLine("입금 후, 통장의 잔고: {0}억", OneHundredMillion++);
            Console.WriteLine("최종 변수안 값: {0}", OneHundredMillion);*/

            // 증가 연산자의 위치를 정상적으로!!
            Console.WriteLine("\n= 증감 연산자 사용 출력 결과 =");
            Console.WriteLine("통장의 잔고: {0}억", OneHundredMillion);
            Console.WriteLine("{0}억 입금", 1);
            Console.WriteLine("입금 후, 통장의 잔고: {0}억", ++OneHundredMillion);
            Console.WriteLine("최종 변수안 값: {0}", OneHundredMillion);

            OneHundredMillion = 1;
            Console.WriteLine("현재 값: {0}", OneHundredMillion);
            Console.WriteLine("++OneHundredMillion: {0}", ++OneHundredMillion);
            Console.WriteLine("변경 후 값: {0}", OneHundredMillion);

            Console.WriteLine("현재 값: {0}", OneHundredMillion);
            Console.WriteLine("OneHundredMillion++: {0}", OneHundredMillion++);
            Console.WriteLine("변경 후 값: {0}", OneHundredMillion);

            Console.WriteLine("현재 값: {0}", OneHundredMillion);
            Console.WriteLine("--OneHundredMillion: {0}", --OneHundredMillion);
            Console.WriteLine("변경 후 값: {0}", OneHundredMillion);

            Console.WriteLine("현재 값: {0}", OneHundredMillion);
            Console.WriteLine("OneHundredMillion--: {0}", OneHundredMillion--);
            Console.WriteLine("변경 후 값: {0}", OneHundredMillion);
        }
    }
}
