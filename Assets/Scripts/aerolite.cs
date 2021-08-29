using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class aerolite : MonoBehaviour
{
    public float moveSpeed;//�ƶ��ٶ�
    public float rotateSpeed;//��ת�ٶ�
    public GameObject destaoryPrefab;//������ЧԤ����

    void Start()
    {
        GetComponent<Rigidbody>().velocity = Vector3.back * moveSpeed;
        Vector2 randAngular = Random.insideUnitCircle;
        GetComponent<Rigidbody>().angularVelocity = new Vector3(randAngular.x, 0, randAngular.y).normalized * rotateSpeed;
    }

    public void ExplosionPlay()//������ʯ��ըЧ��
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
