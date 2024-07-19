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
        {   // instance�� ����ִٸ�(null) �װ��� �ڱ� �ڽ��� �Ҵ�
            instance = this;
        }
        else
        {
            // instance�� �̹� �ٸ� GameManager ������Ʈ�� �Ҵ�Ǿ� �ִ� ���
            // ���� �ΰ� �̻��� GameManager ������Ʈ�� �����Ѵٴ� �ǹ�.
            // �̱��� ������Ʈ�� �ϳ��� �����ؾ� �ϹǷ� �ڽ��� ���� ������Ʈ�� �ı�
            Debug.LogWarning("���� �ΰ� �̻��� ���� �Ŵ����� �����մϴ�!");
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
