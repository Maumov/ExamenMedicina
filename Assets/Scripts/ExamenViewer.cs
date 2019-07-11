﻿using System.Collections;
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

    int currentPregunta = 0;

    public List<InputField> inputs;

    private void OnEnable() {
        ShowExamen();
    }

    public void ShowExamen() {
        examen = studentControl.examen;
        currentPregunta = 0;
        ShowQuestion();
    }

    public void ShowQuestion() {
        inputs = new List<InputField>();
        if(currentPregunta < examen.preguntas.Count) {
            CreatePreguntaPack(examen.preguntas[currentPregunta]);
        } else {
            //EnviarExamen
            studentControl.SendRespuestas();
            //-----------

        }
        
    }

    public void NextQuestion() {
        for(int i = 0; i < inputs.Count; i++  ) {
            studentControl.SetAnswerToQuestion(currentPregunta, i, inputs[i].text);
        }
        DeleteContent();
        currentPregunta++;
        ShowQuestion();
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
        inputs.Add(go.GetComponent<InputField>()); 
    }

    public void DeleteContent() {
        RectTransform[] gos = origin.GetComponentsInChildren<RectTransform>();
        foreach(RectTransform rt in gos) {
            if(rt != origin.GetComponent<RectTransform>()) {
                Destroy(rt.gameObject);
            }
        }
    }
}