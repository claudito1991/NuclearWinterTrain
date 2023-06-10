using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class ShowTrainSpeedUI : MonoBehaviour
{
    [SerializeField] TextMeshProUGUI text;
    [SerializeField] TrainSpeedController trainSpeed;
    // Start is called before the first frame update
    void Start()
    {
        trainSpeed = FindObjectOfType<TrainSpeedController>();
    }

    // Update is called once per frame
    void Update()
    {
        text.text = trainSpeed.TrainSpeed.ToString();
    }
}
