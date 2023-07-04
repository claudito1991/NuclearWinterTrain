using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class GlobalTimer : MonoBehaviour
{
    [SerializeField] TextMeshProUGUI timerTMPRO;
    [SerializeField] float maxTime;
    [SerializeField] float currentTime;
    [SerializeField] float difficultyRatio;
    public float DifficultyRatio{get{return difficultyRatio;}}

    // Start is called before the first frame update
    void Start()
    {
        currentTime = maxTime;
    }

    // Update is called once per frame
    void Update()
    {
        currentTime -= Time.deltaTime;
        timerTMPRO.text = currentTime.ToString("0");
        difficultyRatio = 1f-(currentTime/maxTime);
        Debug.Log("Diff" + difficultyRatio.ToString());
    }
}
