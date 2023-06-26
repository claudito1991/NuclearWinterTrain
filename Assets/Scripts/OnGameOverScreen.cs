using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class OnGameOverScreen : MonoBehaviour
{
    [SerializeField] List<GameObject> listaInventarios;

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
    }

}
