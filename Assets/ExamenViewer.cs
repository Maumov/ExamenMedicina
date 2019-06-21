using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ExamenViewer : MonoBehaviour {

    public StudentControl studentControl;
    public Examen examen;

    public RectTransform origin;

    public GameObject Parrafo;
    public GameObject Pregunta;
    public GameObject Video;
    public GameObject Respuesta;

    public void ShowExamen() {
        examen = studentControl.examen;

        //
        //
        //
        //Generar pregunta 1;

    }

    public void CreatePreguntaPack(string id) {

    }
   
    public void CreateParrafo(string parrafo) {
        GameObject go = Instantiate(Parrafo, origin);
        Text text = go.GetComponent<Text>();
        text.text = parrafo;
    }
    public void CreatePregunta(string pregunta) {
        GameObject go = Instantiate(Pregunta, origin);
        Text text = go.GetComponent<Text>();
        text.text = pregunta;
    }
    public void CreateVideoButton() {
        GameObject go = Instantiate(Video, origin);   
    }
    public void CreateRespuesta() {
        GameObject go = Instantiate(Respuesta, origin);
    }
}