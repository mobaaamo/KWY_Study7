using System;
using UnityEngine;


[RequireComponent(typeof(Collider))]
public class ButtonSubject : MonoBehaviour
{

    public event Action Clicked;
    private Collider m_Collider;
    void Start()
    {
        m_Collider = GetComponent<Collider>();
    }

    void Update()
    {
        CheckCollider();
    }
    private void CheckCollider()
    {
        if(Input.GetMouseButtonDown(0))
        {
            Ray ray = Camera.main.ScreenPointToRay(Input.mousePosition);

            RaycastHit hitInfo;

            if(Physics.Raycast(ray, out hitInfo, 100.0f))
            {
                if(hitInfo.collider==m_Collider)
                {
                    ClickButton();
                }
            }
        }
    }
    public void ClickButton()
    {
        Clicked?.Invoke();
    }
}
