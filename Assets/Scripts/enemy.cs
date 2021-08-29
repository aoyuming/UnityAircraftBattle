using System.Collections;
using System.Collections.Generic;
using UnityEngine;

//�л���
public class enemy : MonoBehaviour
{
    public float fireSpeed;//�����ٶ�
    public float moveSpeed;//�ƶ��ٶ�
    public GameObject bulletPrefab;//�ӵ�Ԥ����
    public GameObject explodePrefab;//��ըԤ����
    float fireTime;//����ʱ��

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
