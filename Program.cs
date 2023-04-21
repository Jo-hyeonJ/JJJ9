// static이란?
// 상수화 : const, readonly
// namespace
// partial
// object 자료형

using System;
using System.Data.SqlTypes;

namespace A
{
    class A
    {

    }
}



// object 자료형
// => C#의 모든 자료형은 object를 상속한다.
// 때문에 선언하지 않는 변수들도 object에 내포된 함수는 사용이 가능하다.

// object내부에는 Tostring()함수가 존재한다.
// 따라서 어떠한 함수라도 문자열로 바꿀수 있다.

namespace JJJ9
{
    class A // 네임스페이스.A 형식이니 동일한 클래스명도 충돌하지 않는다.
    {

    }
    // partial 의 접근지정자가 다를 경우 따로 작동하는가?

    // internal : 같은 어셈블리 내에서만 사용할 수 있다. 시작점을 제한하는 용도
    internal class Program
    {
        // 상수 : 변하지 않는 수 (통상적으로 모두 대문자로 표기한다.)

        // static 키워드
        // C++과 다르게 전역함수화가 아닌 클래스에 귀속시키는 키워드이다.
        // 클레스로 인해 생성 된 인스턴스들은 static 요소들에 접근이 불가능하다.

        // static 함수 내에서는 static 변수만이 사용 가능하다.
        // '객체가 만들어 질 때 생성되는 멤버 변수'들을 'class 내부에서만 존재하는 static 요소'들이 사용 할 수 없기 때문이다.
        // 해당 변수가 생성 되었는지 불분명하고 일반 변수는 인스턴스의 수만큼 존재할 것이기에 특정 할 수가 없다.
        // 그 반대의 경우 멤버 함수는 static 함수와 변수를 호출 할 수 있다.

        // 중첩 클래스
        // -> 클래스 안에 클래스를 만드는 것

        // 중첩 클래스를 쓰는 경우
        // 1. 외부에 공개하고 싶지 않은 클래스가 있을 때
        // 2. 클래스 내부에서만 사용되는 클래스일 경우


        // Main 함수 또한 Program 클래스 안의 멤버 함수이다.
        // 일반 함수 제작에 static을 붙이는 것도 그 연장선

        int number = 10; // private
        // 외부에서 접근이 불가능한 것이지 Program 내부의 함수는 접근 가능하다.
        public partial class Box // public 접근 지정자 후 외부 호출 방법은 Program.Box로 호출해야한다.
        {
            Box()
            {
                Program p = new Program();
                p.number = 10;
                // 클래스 Box는 Program 클래스 내부에 있다. 때문에 접근이 가능하다.
            }
        }

        // 분할 클래스
        // 떨어져있지만 붙어 있는 것과 같게 만들어주는 키워드. 분할 개수의 제한은 없다.
        // 별개의 파일에서 선언해도 partial은 정상적으로 작동한다. (C#은 클래스 기반이기에 물리성은 큰 의미가 없다. 모든 곳이 전역)
        // 대신 클래스명은 같아야한다.
        // 클래스가 속해 있는 namespace가 같아야한다. 다르다면 using namespace명을 코드 최상단에 선언한 후 namespace.클래스명으로 사용

        // 접근지정자와 상속 관계 또한 partial로 묶여 있다면 2번 쓸 필요는 없다. 다만 partial은 다 붙여주어야한다.
        


        partial class Box
        {
            ~Box()
            {

            }
        }

        class Inventory
        {
            // 상수는 선언 시에 반드시 값을 초기화 해야한다. 불변성이 그 이유이다.
            const int MAX_SLOT = 21;
            // 상수는 모두 대문자로 표기하기 때문에 띄워쓰기는 _로 표현한다.

            // const는 한번 값이 대입되면 변경이 불가능하다.
            // readonly는 const와 상동하지만 생성자에 한해 값의 대입이 가능하다.
            readonly int MIN_SLOT;

            public int count;
            
            // static 변수, 함수는 클래스 그 자체에 귀속된다.
            // 클래스 객체가 인스턴스 될 때 생성되는 것이 아니다.
            // 그래서 오직 1개만 존재하게 된다.

            public static int gold;
            
            public Inventory(int MIN_SLOT)
            {
                this.MIN_SLOT = MIN_SLOT;
            }

            public void Show()
            {

            }

            public static void Func()
            {

            }


        }

        class Person
        {
            static int count;       // 사람의 수
            int money;
            public Person(int money)
            {
                count += 1;
                this.money = money;
            }

            void Simple()
            {
            }
            public static void Showcount()
            {
                Console.WriteLine("현재 인원 수 : " +count);
                // Simple();    함수 또한 호출 할 수 없다.
                // money += 1;  static 함수 내부에서 일반 변수를 부르지 못하는 모습을 보여준다.
            }

            public void GetPucture()
            {
                // 선행처리기 예시
#if DEBUG
                Console.WriteLine("윈도우의 파일 읽기");
#else
                Console.WriteLine("IOS의 파일을 읽어오는 명령어");
#endif
            }

            // 내포된 함수도 오버라이딩 가능
            public override string ToString()
            {
                return "웅앵";
            }

        }
        static void Main(string[] args)
        {
            // const (상수 선언) = 선언 시에만 값이 대입 가능하다. 그 이후는 대입 불가능.

            const int MAX= 10; // MAX 변수의 상수화
                               // 상수이기 때문에 값을 대입 할 수 없다.

            Inventory inven = new Inventory(20);
            inven.Show();

            inven.count = 0;
            // inven.gold = 0; 수정 되지 않음
            

            // static이 붙은 요소들은 인스턴스에게 옮겨지지 않는다.

            Person p1 = new Person(1000);
            Person p2 = new Person(20000);

            Person.Showcount();
            // p1.Showcount(); 내포하고 있는 함수이지만 호출 자체가 되지 않음.


            // 수학 관련 함수를 담고 있는 Math 클래스
            // 절댓값을 구하는 Math
            Console.WriteLine("-100의 절댓값은 : " + Math.Abs(-100));
            // Math의 올림, 내림, 반올림
            float score = 103.5f;
            Console.WriteLine($"올림 : {Math.Ceiling(score)}");
            Console.WriteLine($"내림 : {Math.Floor(score)}");
            Console.WriteLine($"반올림 : {Math.Round(score)}");
            Console.WriteLine();

            // 최소 최대값 제한
            Console.WriteLine("절대값 " + Math.Clamp(score, 0, 100));
            // 삼각함수
            Console.WriteLine("Sin " + Math.Sin(60));
            Console.WriteLine("Cos " + Math.Cos(60));
            Console.WriteLine("Tan " + Math.Tan(60));
            Console.WriteLine();

            // 그 외는 microsoft docs 참조 



/*
            int length = 0;
            length = Console.Read();
            const int MAX_ = 20;    상수화는 엄밀히 말하면 상수가 아니다. set 함수를 축출 당한 변수이다.
            int array[MAX_];        array는 상수만을 크기로 가지므로 불가능하다.
*/


        }
    }
    // exe 파일이 만들어지는 과정
    // 선행 처리 -> 컴파일 -> 링킹 -> exe파일 생성

    // 선행처리 : 선행처리기가 선행처리문을 처리하는 과정 (#if 등..)
    // 컴파일 : 컴파일러가 프로그램 언어를 기계가 이해하는 기계어로 번역하는 과정이다.
    // 링킹 : 링커가 번역된 파일을 하나의 실행 파일로 묶는 과정이다.
    // 런타임 : 프로그램이 실행된 상태

    // 32비트 운영체제는 주소 값을 4byte(=32bit)로 표현한다. 주소 값을 2^32까지 표현 가능하다.
    // 64비트 운영체제는 주소 값을 8byte(=64bit)로 표현한다. 주소 값을 2^64까지 표현 가능하다.

    // 메모리 구조
    // 코드 영역 : 텍스트파일, 제어문, 상수, 함수
    // 데이터 영역 : static 변수&함수, 클래스
    // 힙 영역 : 참조형 변수의 값 (class, object)
    // 스택 영역 : 값 형 변수의 값 (struct)

    // 힙과 스택의 상호 관계
    // 힙 영역의 메모리 크기가 모자랄 경우 스택 영역으로 확장 할 수 있다.
    // 이때 충돌하지 않기 위해 힙은 위부터 스택은 아래에서부터 메모리를 쌓는다.
    // 충돌시 메모리 오버플로우로 인해 강제 종료된다.

    // 재귀 함수
    // 함수가 자기 자신을 다시 호출하는 함수
    // 무한 루프에 빠질 시 아웃 메모리가 발생한다.

    // C#은 사용자가 메모리 주소에 접근하지 못한다.
    // 가비지 컬렉터가 메모리 파편화를 막기 위해 주소를 최적화 시킨다. 때문에 포인터 사용시 변경 전의 주소를 가르킬 가능성이 있어 막는다.
    // 때문에 C#에서는 메모리 파편화가 생길 수 없다.

    // 가비지 컬렉터의 생명주기
    // 메모리 순환 후에 잔류하는 메모리의 세대를 올린다. 세대가 높은 메모리는 프로그램에서 중요도가 높다고 판단하고
    // 콜렉팅 항목에서 후순위로 미뤄진다. (삭제 안됨) 자세한건 '가비지 컬렉터의 생명주기' 검색 ㄱ


}
