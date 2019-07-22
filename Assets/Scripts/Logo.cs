using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Logo : MonoBehaviour
{
    public GameObject Inicio;
    // Start is called before the first frame update
    void Start()
    {
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void StartInicioCoroutine()
    {
        StartCoroutine(GoToInicio());
    }

    IEnumerator GoToInicio() {


        Inicio.SetActive(true);

        yield return null;
        gameObject.SetActive(false);


    }
}
