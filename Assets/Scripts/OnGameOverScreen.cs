using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class OnGameOverScreen : MonoBehaviour
{
    [SerializeField] List<GameObject> listaInventarios;
    [SerializeField] TextMeshProUGUI whyYouLose;

    void Start()
    {
        gameObject.SetActive(false);
    }
    // Start is called before the first frame update

    void OnEnable()
    {
        foreach( GameObject obj in listaInventarios)
        {
            obj.SetActive(false);
            Debug.Log("called enable");
        }
    }

        void OnDisable()
    {
        foreach( GameObject obj in listaInventarios)
        {
            obj.SetActive(true);
            Debug.Log("called disable");
        }
        WhyYouWillLose("");
    }

    public void WhyYouWillLose(string loseCondition)
    {
        Debug.Log("on game over called");
        whyYouLose.text = loseCondition;
    }

}
