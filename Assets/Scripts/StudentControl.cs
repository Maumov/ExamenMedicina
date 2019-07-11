using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class StudentControl : MonoBehaviour
{
    public Estudiante estudiante;
    public DataLoader dataLoader;
    public Examen examen;

    public List<Question> preguntas;
    
    public delegate void StudentDelegate();
    public event StudentDelegate OnLoginSuccesful, OnInvalidCode, OnInvalidTest, OnEstudianteNoEncontrado, OnEnteredCode;

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
        } else {
            if(OnInvalidCode != null) {
                OnInvalidCode();
            }
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
