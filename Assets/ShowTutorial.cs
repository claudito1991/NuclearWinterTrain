using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ShowTutorial : MonoBehaviour
{
    [SerializeField] GameObject[] mainMenuUI;
    [SerializeField] GameObject tutorialScreen;


    [SerializeField] GameObject[] tutorialCards;
    private int currentCardIndex;
    // Start is called before the first frame update
    void Start()
    {
        tutorialScreen.SetActive(false);
        currentCardIndex=0;
    }



    private void ResetTutorialCards()
    {
        currentCardIndex=0;
        for(int i = 0; i<tutorialCards.Length;i++)
        {
            if(i==0)
            {
                tutorialCards[i].SetActive(true);
            }
            else
            {
                tutorialCards[i].SetActive(false);
            }
        }

    }

    public void ShowTutorialScreen(bool tutorialScreenShowing)
    {
        tutorialScreen.SetActive(tutorialScreenShowing);
        ResetTutorialCards();
        foreach(GameObject ui in mainMenuUI)
        {
            ui.SetActive(!tutorialScreenShowing);
        }
    }

    public void ShowNextCard()
    {
        if(currentCardIndex < tutorialCards.Length-1)
        {
            tutorialCards[currentCardIndex].SetActive(false);
            tutorialCards[currentCardIndex+1].SetActive(true);
            currentCardIndex++;
            Debug.Log(currentCardIndex);
        }
        else
        {
            tutorialCards[currentCardIndex].SetActive(false);
            currentCardIndex=0;
            tutorialCards[currentCardIndex].SetActive(true);
        }
    }
    public void ShowPreviousCard()
    {
        if(currentCardIndex > 0)
        {
            tutorialCards[currentCardIndex].SetActive(false);
            tutorialCards[currentCardIndex-1].SetActive(true);
            currentCardIndex--;
        }
        else
        {
            currentCardIndex = 0;
            tutorialCards[currentCardIndex].SetActive(true);
        }
    }


}
