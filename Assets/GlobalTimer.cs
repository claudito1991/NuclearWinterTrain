using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
using System;

public class GlobalTimer : MonoBehaviour
{
    [SerializeField] TextMeshProUGUI timerTMPRO;
    [SerializeField] GameObject gameOverScreen;
    [SerializeField] float maxTime;
    [SerializeField] float currentTime;
    [SerializeField] int difficultyRatio;
    [SerializeField] int maxDiffModifier;
    public int DifficultyRatio{get{return difficultyRatio;}}

    [SerializeField] bool isGameOver;
    public bool IsGameOver{get{return isGameOver;}}

    // Start is called before the first frame update
    void Start()
    {
        currentTime = maxTime;
        isGameOver = false;
    }

    // Update is called once per frame
    void Update()
    {

        ConsumeGlobalTime();

    }

    private void ConsumeGlobalTime()
    {
        if(currentTime>0f)
        {
            currentTime -= Time.deltaTime;
            
        }
        else
        {
            if(!isGameOver)
            {
                WinGame();
            }
        }

        timerTMPRO.text = currentTime.ToString("0");
        difficultyRatio = (int)(maxDiffModifier * (1f - (currentTime / maxTime)));
        //Debug.Log("Diff" + difficultyRatio.ToString());
    }

    public void SetGameState(bool gameState)
    {
        isGameOver = gameState;
    }

    public void WinGame()
    {
        gameOverScreen.SetActive(true);
        gameOverScreen.GetComponent<OnGameOverScreen>().WhyYouWillLose("ALL CITIES SAVED !");
        Debug.Log("triggered win cond.");
        StartCoroutine(winning());
    }

    IEnumerator winning()
    {
        yield return new WaitForSeconds(5f);
        isGameOver=true;
    }
}
