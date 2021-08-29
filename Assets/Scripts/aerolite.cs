using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class aerolite : MonoBehaviour
{
    public float moveSpeed;//移动速度
    public float rotateSpeed;//旋转速度
    public GameObject destaoryPrefab;//销毁特效预制体

    void Start()
    {
        GetComponent<Rigidbody>().velocity = Vector3.back * moveSpeed;
        Vector2 randAngular = Random.insideUnitCircle;
        GetComponent<Rigidbody>().angularVelocity = new Vector3(randAngular.x, 0, randAngular.y).normalized * rotateSpeed;
    }

    public void ExplosionPlay()//播放陨石爆炸效果
    {
        GameObject.Instantiate(destaoryPrefab, this.transform.position, Quaternion.identity);
    }

    private void OnTriggerEnter(Collider other)
    {
        switch (other.tag)
        {
            case "Player":
                ExplosionPlay();
                GameObject.Destroy(this.gameObject);
                GameObject.Destroy(other.gameObject);
                break;
            default:
                break;
        }
    }

    private void OnDestroy()
    {
        
    }
}
