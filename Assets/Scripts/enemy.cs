using System.Collections;
using System.Collections.Generic;
using UnityEngine;

//敌机类
public class enemy : MonoBehaviour
{
    public float fireSpeed;//开火速度
    public float moveSpeed;//移动速度
    public GameObject bulletPrefab;//子弹预制体
    public GameObject explodePrefab;//爆炸预制体
    float fireTime;//开火时间

    private void Awake()
    {
        GetComponent<Rigidbody>().velocity = -Vector3.forward * moveSpeed;
        fireTime = Time.time;
    }

    void Update()
    {
        if (Time.time - fireTime > fireSpeed)
        {
            var obj = GameObject.Instantiate(bulletPrefab);
            obj.transform.position = GameObject.Find("enemyFirePos").transform.position;
            fireTime = Time.time;
        }
    }

    public void destroy()
    {
        GameObject.Instantiate(explodePrefab, transform.position, Quaternion.identity);
    }

    private void OnDestroy()
    {
        
    }
}
