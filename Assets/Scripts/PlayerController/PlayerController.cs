
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController : MonoBehaviour
{
    [SerializeField] private LayerMask whatToDetect;
    [SerializeField] private Camera mainCamera;

    void Start()
    {
        mainCamera = Camera.main;
    }

    void Update()
    {
        if(Input.GetMouseButtonDown(0))
        {
            //Debug.Log("Detect click");
            RaycastHit hit;
            Ray ray = mainCamera.ScreenPointToRay(Input.mousePosition);

            Debug.DrawRay(ray.origin, ray.direction* 20f, Color.cyan,1f);
            if(Physics.Raycast(ray, out hit, 100f,whatToDetect))
            {
                hit.transform.GetComponent<AddItemToInventory>().AddThisItemToTrain();
                hit.transform.gameObject.GetComponent<MeshRenderer>().enabled=false;
                Destroy (hit.transform.gameObject,0.2f);
                
            }
        }
    }
    
}
