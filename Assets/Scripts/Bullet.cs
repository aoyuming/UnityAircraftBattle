using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public enum BulletType
{
    player,
    enemy
}

public class Bullet : MonoBehaviour
{
    public float moveSpeed;
    public BulletType bulletType;

    private void Awake()
    {
        switch (bulletType)
        {
            case BulletType.player:
                GetComponent<Rigidbody>().velocity = Vector3.forward * moveSpeed;
                break;
            case BulletType.enemy:
                GetComponent<Rigidbody>().velocity = -Vector3.forward * moveSpeed;
                break;
            default:
                break;
        }
    }

    // 第一帧调用
    void Start()
    {
    }

    // 没帧调用
    void Update()
    {
        
    }

    //子弹的碰撞检查
    private void OnTriggerEnter(Collider other)
    {
        if (bulletType == BulletType.player)
        {
            switch (other.tag)
            {
                case "background":
                case "Player":
                    return;
                case "aerolite":
                    other.GetComponent<aerolite>().ExplosionPlay();
                    break;
                case "enemy_1":
                    gameManage.Instance.addScore(20);
                    other.GetComponent<enemy>().destroy();
                    break;
                case "enemy_2":
                    gameManage.Instance.addScore(50);
                    other.GetComponent<enemy>().destroy();
                    break;
            }
            GameObject.Destroy(other.gameObject);
            GameObject.Destroy(this.gameObject);
        }
    }
}
