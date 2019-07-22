using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ActividadInicioViewer : MonoBehaviour
{
    public GameObject inicioTallerCanvas;
    public GameObject inicioPracticaCanvas;
    public GameObject inicioExamenCanvas;

    public void BotonTaller()
    {
        gameObject.SetActive(false);
        inicioTallerCanvas.SetActive(true);
    }

    public void BotonPractica()
    {
        gameObject.SetActive(false);
        inicioPracticaCanvas.SetActive(true);
    }

    public void BotonExamen()
    {
        gameObject.SetActive(false);
        inicioExamenCanvas.SetActive(true);
    }
}
