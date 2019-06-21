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

    public DataLoader dataLoader;
    public void ShowExamen() {
        examen = studentControl.examen;

        //
        //
        //
        //Generar pregunta 1;

    }
    [ContextMenu("TEST CREACION DE PREGUNTA")]
    public void TestCreacionDePregunta() {
        CreatePreguntaPack("1");
    }


    public void CreatePreguntaPack(string id) {
        Question q = dataLoader.GetQuestion(id);
        CreateParrafo(q.parrafo);
        CreateVideoButton(q.video);
        for(int i = 0; i< q.preguntas.Count; i++) {
            CreatePregunta(q.preguntas[i]);
            CreateRespuesta();
        }
    }
   
    public void CreateParrafo(string parrafo) {
        GameObject go = Instantiate(Parrafo, origin);
        Text text = go.GetComponentInChildren<Text>();
        text.text = parrafo;
    }
    public void CreatePregunta(string pregunta) {
        GameObject go = Instantiate(Pregunta, origin);
        Text text = go.GetComponentInChildren<Text>();
        text.text = pregunta;
    }
    public void CreateVideoButton(string video) {
        GameObject go = Instantiate(Video, origin);   
    }
    public void CreateRespuesta() {
        GameObject go = Instantiate(Respuesta, origin);
    }
}