﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class StudentControl : MonoBehaviour
{
    public Estudiante estudiante;
    public DataLoader dataLoader;
    public Examen examen;

    public List<Question> preguntas;
    
    public delegate void StudentDelegate();
    public event StudentDelegate OnLoginSuccesful, OnInvalidCode, OnInvalidTest, OnEstudianteNoEncontrado, OnEnteredCode, OnCodigoNotReady;

    public void Login(string codigoEstudiante) {

        Estudiante e = dataLoader.GetEstudiante(codigoEstudiante);
        if(e != null) {
            if(OnLoginSuccesful != null) {
                OnLoginSuccesful();
                estudiante = e;
            }
            
        } else {
            if(OnEstudianteNoEncontrado != null) {
                OnEstudianteNoEncontrado();
            }
        }
    }

    public void EntrarExamen(string codigo) {
        Codigo cod = dataLoader.GetCodigo(codigo);
        if(cod != null) {
            if(!CodigoIsAvailable(cod)) {
                if(OnCodigoNotReady != null) {
                    OnCodigoNotReady();
                }
            } else {
                Examen e = dataLoader.GetExamen(cod.examen);
                if(e != null) {
                    examen = e;
                    LlenarPreguntas();
                    if(OnEnteredCode != null) {
                        OnEnteredCode();
                    }
                } else {
                    if(OnInvalidTest != null) {
                        OnInvalidTest();
                    }
                }
            }
        } else {
            if(OnInvalidCode != null) {
                OnInvalidCode();
            }
        }
    }

    bool CodigoIsAvailable(Codigo cod) {
        System.DateTime dateNow = System.DateTime.Now;
        string[] fechaInicio = cod.fechaInicio.Split('-');
        string[] fechaFin = cod.fechaFin.Split('-');
        System.DateTime trialDateStart = new System.DateTime(int.Parse(fechaInicio[2]), int.Parse(fechaInicio[1]), int.Parse(fechaInicio[0]), int.Parse(fechaInicio[3]), int.Parse(fechaInicio[4]), 0);
        System.DateTime trialDateEnd = new System.DateTime(int.Parse(fechaFin[2]), int.Parse(fechaFin[1]), int.Parse(fechaFin[0]),int.Parse(fechaFin[3]), int.Parse(fechaFin[4]), 0);
        if(dateNow <= trialDateStart || dateNow >= trialDateEnd) {
            //to disable this trial code, just comment the line below.
            return false;
        } else {
            return true;
        }
        
    }

    void LlenarPreguntas() {
        preguntas = new List<Question>();
        preguntas.AddRange(dataLoader.preguntas);
    }


    public void SetAnswerToQuestion(int question,int pregunta, string value) {
        preguntas[question].respuestas[pregunta] = value;
    }

    public void SendRespuestas() {
        StartCoroutine(SendRespuestas2());
    }

    IEnumerator SendRespuestas2() {
        string url = "https://docs.google.com/forms/d/1ZrGX524BP69VbLBdsQMhoOaS9zQFQdIbfly4WWlQs8E/formResponse?embedded=true";
        WWWForm form = new WWWForm();

        form.AddField("entry.83696122", estudiante.id);
        form.AddField("entry.2073131150", estudiante.nombre);
        form.AddField("entry.2121727155", estudiante.apellido);
        form.AddField("entry.335580683", examen.nombre);
        //-----
        
        string preguntasYrespuestas = "";
        for(int i = 0; i< preguntas.Count; i++) {
            preguntasYrespuestas += preguntas[i].ToString();
        }
        form.AddField("entry.1465623747", preguntasYrespuestas);
        WWW www = new WWW(url, form);
        yield return www;
        Debug.Log(www.text);
        yield return null;
        Debug.Log("Sent");
    }
}
