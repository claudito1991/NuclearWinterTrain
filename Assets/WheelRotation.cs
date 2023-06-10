using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WheelRotation : MonoBehaviour
{
    TrainSpeedController trainSpeedController;
    [SerializeField] float modSpeed;

    // Start is called before the first frame update
    void Start()
    {
        trainSpeedController = GetComponentInParent<TrainSpeedController>();
    }

    // Update is called once per frame
    void Update()
    {
        if(trainSpeedController.TrainSpeed>0)
        {
            transform.Rotate(new Vector3(0f,0f,1f) * -Time.deltaTime * trainSpeedController.TrainSpeed * modSpeed, Space.Self);
        }
        
    }
}
