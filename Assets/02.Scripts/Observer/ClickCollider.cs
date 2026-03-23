using UnityEngine;


[RequireComponent(typeof(Collider),typeof(ButtonSubject))]
public class ClickCollider : MonoBehaviour
{

    private ButtonSubject m_ButtonSubject;
    private Collider m_Collider;
    // Start is called before the first frame update
    void Start()
    {
        m_Collider = GetComponent<Collider>();
        m_ButtonSubject = GetComponent<ButtonSubject>();
    }

    // Update is called once per frame
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
                    m_ButtonSubject.ClickButton();
                }
            }
        }
    }
}
