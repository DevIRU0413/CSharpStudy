using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Annotation
{
    internal class Program
    {
        static void Main(string[] args)
        {
            // 한줄 쓰기 기능입니다.
            Console.WriteLine("Hello, World!");

            // 한줄 주석 : 실행 시키지 않을 코드나 설명을 코드 상에 넣어서 유용하게 사용할 수 있는 기능

            /* 
            범위 주석: 시작(/*)에서 끝(* /)까지 주석으로 취급 할수 있는 기능
            1
            22
            333
            */

            /// <summary>
            /// 이건 XML 주석이며
            /// 문서 파일로 추출할 수 있습니다
            /// </summary>
        }
    }
}
