using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Dongle : MonoBehaviour
{
    public int level;
    public bool isDrag;
    Rigidbody2D rigid;
    Animator anim;
    
    void Awake()
    {
        rigid = GetComponent<Rigidbody2D>();
        anim = GetComponent<Animator>();
    }
    void OnEnable()
    {
        anim.SetInteger("Level", level);
    }
    // Update is called once per frame
    void Update()
    {
        if (isDrag)
        {
            Vector3 mousPos = Camera.main.ScreenToWorldPoint(Input.mousePosition);
            float leftBorder = -4.2f + transform.localScale.x / 2f;
            float rightBorder = 4.2f - transform.localScale.x / 2f;
            if (mousPos.x < leftBorder)
                mousPos.x = leftBorder;
            if (mousPos.x > rightBorder)
                mousPos.x = rightBorder;
            mousPos.y = 7.5f;
            mousPos.z = 0;
            transform.position = Vector3.Lerp(transform.position, mousPos, 0.2f);

        }
    }
    public void Drag()
    {
        isDrag = true;
        rigid.simulated = false;
    }
    public void Drop()
    {
        isDrag = false;
        rigid.simulated = true;
    }
}
