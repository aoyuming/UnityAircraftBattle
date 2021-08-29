using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class player : MonoBehaviour
{
    public float moveSpeed;
    Rigidbody rig;

    //发射子弹
    public GameObject bullet;
    public float shootTime;//发射间隔时间
    public GameObject destoryPrefab;//销毁自己的特效预制体
    float lastTime;

    // 第一帧调用
    void Start()
    {
        rig = GetComponent<Rigidbody>();
        lastTime = Time.time;
    }

    //播放死亡动画
    public void diePlay()
    {
        GameObject.Instantiate(destoryPrefab, this.transform.position, Quaternion.identity);
        //GameObject.Destroy(this.gameObject);
    }

    // 没帧调用
    void Update()
    {
        var hor = Input.GetAxis("Horizontal");
        var ver = Input.GetAxis("Vertical");
        rig.velocity = new Vector3(hor, 0, ver) * moveSpeed;

        //限制飞机不出边界
        var posX = Mathf.Clamp(transform.position.x, gameManage.Instance.border.xMin, gameManage.Instance.border.xMax);
        var posZ = Mathf.Clamp(transform.position.z, gameManage.Instance.border.zMin, gameManage.Instance.border.zMax);
        transform.position = new Vector3(posX, 1.5f, posZ);

        if (Time.time - lastTime > shootTime)
        {
            var obj = GameObject.Instantiate(bullet);
            obj.transform.position = GameObject.Find("firePos").transform.position;
            lastTime = Time.time;
        }
    }

    void OnTriggerEnter(Collider other)
    {
        switch (other.tag)
        {
            case "playerBullet":
            case "background":
                return;
            case "enemy_1":
            case "enemy_2":
                other.GetComponent<enemy>().destroy();
                break;
        }
        GameObject.Destroy(gameObject);
        GameObject.Destroy(other.gameObject);
    }

    private void OnDestroy()
    {
        diePlay();
        gameManage.Instance.gameOver();
    }
}
