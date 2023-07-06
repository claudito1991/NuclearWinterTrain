using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GenerateCoalLoot : MonoBehaviour
{
    [SerializeField] Collider collider;
    [SerializeField] GameObject coalStack;
    [SerializeField] float coalGenerationCooldown;
    [SerializeField] Renderer thisRenderer;
    float currentTime;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {

        GenerateStackOverTime();
        thisRenderer = GetComponentInChildren<Renderer>();
        if(thisRenderer.isVisible)
        {
            //Debug.Log("visible " + gameObject.name);
        }
    }

    private void GenerateStackOverTime()
    {
        currentTime += Time.deltaTime;
        if(currentTime>coalGenerationCooldown)
        {
            GenerateCoal();
            currentTime=0f;
        }
    }

    public void GenerateCoal()
    {
        GameObject instantiatedObject = Instantiate(coalStack, GetRandomPositionInsideCollider(collider), Quaternion.identity);
        instantiatedObject.transform.SetParent(transform);
    }

    private Vector3 GetRandomPositionInsideCollider(Collider collider)
    {
        Bounds bounds = collider.bounds;
        Vector3 randomPoint = new Vector3(
            Random.Range(bounds.min.x, bounds.max.x),
            Random.Range(bounds.min.y, bounds.max.y),
            Random.Range(bounds.min.z, bounds.max.z)
        );

        // Check if the generated point is inside the collider
        while (!collider.bounds.Contains(randomPoint))
        {
            randomPoint = new Vector3(
                Random.Range(bounds.min.x, bounds.max.x),
                Random.Range(bounds.min.y, bounds.max.y),
                Random.Range(bounds.min.z, bounds.max.z)
            );
        }

        return randomPoint;
    }
}

