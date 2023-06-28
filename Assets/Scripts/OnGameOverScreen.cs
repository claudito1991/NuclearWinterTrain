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
        }
    }

        void OnDisable()
    {
        foreach( GameObject obj in listaInventarios)
        {
            obj.SetActive(true);
        }
        WhyYouWillLose("");
    }

    public void WhyYouWillLose(string loseCondition)
    {
        whyYouLose.text = loseCondition;
    }

}
