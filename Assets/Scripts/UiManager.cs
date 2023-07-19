using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI; 
public class UiManager : MonoBehaviour
{
    public int score;
    private static UiManager instance;
    public Text scoreText;
    private UiManager() { }
    private void Awake()
    {
        if (instance == null)
        {
            instance = this;
            DontDestroyOnLoad(this.gameObject);
        }
        else if(instance != this)
        {
            Destroy(this.gameObject);
        }
        
    }
    private void Update()
    {
        IncreaseScore();
    }
    private void Start()
    {
        NewGame();
        scoreText.text = "Score: " + score.ToString();
    }
    public static UiManager Instance
    {
        get
        {
            if(instance == null)
            {
                instance = new UiManager();
            }
            return instance;
        }        
    }
  public void IncreaseScore()
    {
        scoreText.text = "Score: " + score.ToString();
    }
    void NewGame()
    {
        score = 0;
    }
}
