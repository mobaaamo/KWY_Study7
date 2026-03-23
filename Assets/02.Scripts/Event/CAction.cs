using System;
using UnityEngine;
/**************************************
 [Action]
 - 반환값이 없는 메서드를 참조하는 델리게이트
 - 매개변수는 없을수 있고 있다면 최대 16개의 인자를 받을수 있음
 
 **************************************/
public class CAction : MonoBehaviour
{
    // public delegate void MyDelegate(string msg);

    Action Hello;               //매개변수 없는
    Action<string> Hello2;      //string 1개
    Action<int, int> numbers;   //int 형 2개

    void HelloPrint()
    {
        Debug.Log("안녕");
    }
    void HelloPrint2(string msg)
    {
        Debug.Log($"말하기 : {msg}");
    }
    void Add(int a, int b)
    {
        Debug.Log($"합계 {a + b}");
    }

    private Action startActions;
    private void ShowMessge() => Debug.Log("게임시작");
    private void InitPlayer() => Debug.Log("플레이어 초기화 완료");
    private void LoadData() => Debug.Log("데이터 로드 완료");

    private void Awake()
    {
        startActions += ShowMessge;
        startActions += InitPlayer;
        startActions += LoadData;
    }
    void Start()
    {
        //Hello = HelloPrint;
        //Hello2 = HelloPrint2;
        //numbers = Add;

        //등록된 모든 Action 순서대로 실행
        startActions?.Invoke(); 
    }
    private void OnDestroy()
    {
        startActions -= ShowMessge;
        startActions -= InitPlayer;
        startActions -= LoadData;
    }

}

//public class UIManager : MonoBehaviour 
//{
//    private void OnEnable()
//    {
//        GameManager.OnGameOver += ShowGameoverUI;
//    }
//    private void OnDisable()
//    {
//        GameManager.OnGameOnver -= ShowGameoverUI;
//    }
//    public void ShowGameoverUI()
//    {

//    }
//}
