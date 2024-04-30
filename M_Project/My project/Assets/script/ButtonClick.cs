using System.Collections;
using System.Collections.Generic;
using UnityEngine.UI;
using UnityEngine;

public class ButtonClick : MonoBehaviour
{
    public GameObject Myself; // Myself GameObject를 가리키는 변수
    public GameObject Next;   // next GameObject를 가리키는 변수

    // Start is called before the first frame update
    void Start()
    {
        // 버튼에 클릭 이벤트 리스너 추가
        Button button = GetComponent<Button>();
        if (button != null)
        {
            button.onClick.AddListener(OnClick);
        }
    }

    void aaa()
    {

    }
    void OnClick()
    {
        // Lobby GameObject를 비활성화
        if (Myself != null)
        {
            Myself.SetActive(false);
        }

        // Mod GameObject를 활성화
        if (Next != null)
        {
            Next.SetActive(true);
        }
    }
}
