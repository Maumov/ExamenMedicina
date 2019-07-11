using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Logo : MonoBehaviour
{
    public GameObject Inicio;
    // Start is called before the first frame update
    void Start()
    {
        StartCoroutine(GoToInicio());
    }

    // Update is called once per frame
    void Update()
    {
        
    }


    IEnumerator GoToInicio() {


        Inicio.SetActive(true);

        yield return null;
        gameObject.SetActive(false);


    }
}
