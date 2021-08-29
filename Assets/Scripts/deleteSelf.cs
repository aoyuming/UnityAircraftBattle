using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class deleteSelf : MonoBehaviour
{
    public float delayedTime;//延迟删除自己的时间
    void Start()
    {
        GameObject.Destroy(this.gameObject, delayedTime);
    }

}
