using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class StudentControl : MonoBehaviour
{
    public Estudiante estudiante;

    public DataLoader dataLoader;

    public Examen examen;


    public delegate void StudentDelegate();
    public event StudentDelegate OnLoginSuccesful, OnInvalidCode, OnInvalidTest, OnEstudianteNoEncontrado, OnEnteredCode;

    public void Login(string estudiante) {

        Estudiante e = dataLoader.GetEstudiante(estudiante);
        if(e != null) {
            if(OnLoginSuccesful != null) {
                OnLoginSuccesful();
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
}
