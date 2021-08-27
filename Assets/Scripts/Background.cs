using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Background : MonoBehaviour
{
    MeshRenderer meshRD;
    public float moveSpeed;

    private void Start()
    {
        meshRD = GetComponent<MeshRenderer>();
    }

    private void Update()
    {
        //通过修改材质y偏移量 实现背景滚动
        meshRD.material.mainTextureOffset += new Vector2(0, moveSpeed * Time.deltaTime);
    }

    private void OnTriggerExit(Collider other)
    {
        GameObject.Destroy(other.gameObject);
    }
}
