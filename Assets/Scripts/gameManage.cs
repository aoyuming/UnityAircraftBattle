using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

[System.Serializable]
public struct Border
{
    public float xMin;
    public float xMax;
    public float zMin;
    public float zMax;
}

public class gameManage : MonoBehaviour
{
    public GameObject[] objectPrefabs;//游戏对象数组
    public float createSpeed;//生成时间
    public Border border;//边界
    public Text scoreText;//分数文本
    private int score;
    float lastTime;//上次生成的时间
    public bool isGameOver;
    public GameObject uiParent;

    private void Awake()
    {
        isGameOver = false;
        instance = this;
        scoreText.text = "Score:" + score;
    }

    public void addScore(int s)
    {
        score += s;
        scoreText.text = "Score:" + score;
    }

    public void gameOver()
    {
        isGameOver = true;
        if (uiParent)
            uiParent.SetActive(true);
    }

    //继续游戏
    public void continueGame()
    {
        SceneManager.LoadScene("start");
    }

    void Start()
    {
        lastTime = Time.time;
    }

    void Update()
    {
        if (Time.time - lastTime > createSpeed && !isGameOver)
        {
            int index = Random.Range(0, objectPrefabs.Length);
            var obj = GameObject.Instantiate(objectPrefabs[index]);
            obj.transform.position = new Vector3(Random.Range(border.xMin, border.xMax), 1.5f, 10);
            lastTime = Time.time;
        }
    }

    #region

    gameManage() { }
    private static gameManage instance;//私有对象
    public static gameManage Instance{ get{ return instance; }}


    #endregion
}
