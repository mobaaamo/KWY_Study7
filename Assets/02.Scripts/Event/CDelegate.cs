using UnityEngine;
/*****************************
 [대리자(delegate)]
  - C#에서 메서드 참조를 객체로 다룰수 있게 해주는 타입
  - 델리게이트는 메서드를 가리키는 참조형 변수로 실행할 메서드를 동적으로 설정하고 호출
  - 주로 이벤트처리나, 콜백 메서드에서 사용

[기본 문법]
public delegate 반환형 델리게이트 이름(매개변수)
 *****************************/

/********************************
 델리게이트 체인
 - 여러 델리게이트 메서드를 연결해서 하나의 델리게이트 호출로 순차적으로 실행되게 하는 방식
 - 여러 메서드를 한번에 호출할수 잇어 이벤트처리나 특정 작업을 여러 메서드가 동시에 수행할때 유용
 - +=,-=연산자를 통해 할당을 추가하고 제거할수 있음
-  = 연산자를 통해 할당할 경우 이전에 다른 메서드들을 할당한 상황이 사라짐
 
 
 ********************************/

public class CDelegate : MonoBehaviour
{
    #region DelegateBasic
    ////델리게이트 선언
    //public delegate float Calc(float x, float y);
    //public delegate void Printer(string msg);

    //private Calc calc;
    //private Printer printer;
    //public static float Plus(float left, float right)
    //{
    //    return left + right;    
    //}
    //public static float Minus(float left, float right)
    //{
    //    return left - right;
    //}
    //public static float Multi(float left, float right)
    //{
    //    return left * right;
    //}
    //public static float Divide(float left, float right)
    //{
    //    return right != 0 ? left / right : 0f;
    //}

    //public static void Message(string msg)
    //{
    //    Debug.Log(msg);
    //}
    #endregion

    public delegate void MyDelegate(string message);
    public static void Method1(string message) { Debug.Log($"메서드 1 : {message}"); }
    public static void Method2(string message) { Debug.Log($"메서드 2 : {message}"); }
    public static void Method3(string message) { Debug.Log($"메서드 3 : {message}"); }

    private MyDelegate delChain;
    void Start()
    {
        //calc = Plus;
        //printer = Message;

        //printer("계산시작");
        //Debug.Log(calc(20.0f, 10.0f));

        //델리게이트 체인생성
        delChain = Method1;
        delChain += Method2;
        delChain += Method3;

        delChain("호출");
        Debug.Log("----------");
        delChain -= Method2;

        delChain("두번째호출");
        Debug.Log("----------");
        delChain = Method1;
        delChain("세번째호출");
    }

  
}
