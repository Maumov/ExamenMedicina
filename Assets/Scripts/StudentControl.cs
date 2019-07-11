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

}
