using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class deleteSelf : MonoBehaviour
{
    public float delayedTime;//�ӳ�ɾ���Լ���ʱ��
    void Start()
    {
        GameObject.Destroy(this.gameObject, delayedTime);
    }

}
