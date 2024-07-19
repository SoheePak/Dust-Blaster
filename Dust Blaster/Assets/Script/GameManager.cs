using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;
using UnityEngine.UIElements;

public class GameManager : MonoBehaviour
{
    public static GameManager instance;
    public Text scoreText;
    private int score = 0;
    public bool isEnd;
    public Text recordText;
    public GameObject gameoverText;
    int b;
    public void AddScore(int newScore)
    {
        score += newScore;
        scoreText.text = "Score : " + score;
        b = PlayerPrefs.GetInt("Bestscore");
        if (score >= b)
        {
            b = score;
            PlayerPrefs.SetInt("Bestscore", b);
        }
    }
    void Awake()
    {
        isEnd = false;
        gameoverText.SetActive(false);
        if (instance == null)
        {   // instance가 비어있다면(null) 그곳에 자기 자신을 할당
            instance = this;
        }
        else
        {
            // instance에 이미 다른 GameManager 오브젝트가 할당되어 있는 경우
            // 씬에 두개 이상의 GameManager 오브젝트가 존재한다는 의미.
            // 싱글톤 오브젝트는 하나만 존재해야 하므로 자신의 게임 오브젝트를 파괴
            Debug.LogWarning("씬에 두개 이상의 게임 매니저가 존재합니다!");
            Destroy(gameObject);
        }
    }
    public void End()
    {
        isEnd = true;
        gameoverText.SetActive(true);

      
        recordText.text = "Best Score : "+ b ;
    }

    public void Intro()
    {
        SceneManager.LoadScene("Intro2");
    }
    public void Retry()
    {
        SceneManager.LoadScene("SampleScene");
    }
    public void Exit()
    {
        Application.Quit();
    }
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
