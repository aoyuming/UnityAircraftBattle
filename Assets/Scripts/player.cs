using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[System.Serializable]
public struct Border
{
    public float left;
    public float top;
    public float right;
    public float buttom;
}

public class player : MonoBehaviour
{
    public float moveSpeed;
    public Border border;//边界范围
    Rigidbody rig;

    //发射子弹
    public GameObject bullet;
    public float shootTime;//发射间隔时间
    float lastTime;

    // 第一帧调用
    void Start()
    {
        rig = GetComponent<Rigidbody>();
        lastTime = Time.time;
    }

    // 没帧调用
    void Update()
    {
        if (rig)
        {
            var hor = Input.GetAxis("Horizontal");
            var ver = Input.GetAxis("Vertical");
            rig.velocity = new Vector3(hor, 0, ver) * moveSpeed;
        }

        //限制飞机不出边界
        var posX = Mathf.Clamp(transform.position.x, border.left, border.right);
        var posZ = Mathf.Clamp(transform.position.z, border.buttom, border.top);
        transform.position = new Vector3(posX, 0, posZ);

        if (Time.time - lastTime > shootTime)
        {
            var obj = GameObject.Instantiate(bullet);
            obj.transform.position = GameObject.Find("firePos").transform.position;
            lastTime = Time.time;
        }
    }
}
