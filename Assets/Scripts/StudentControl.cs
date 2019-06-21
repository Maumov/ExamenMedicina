using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class StudentControl : MonoBehaviour
{
    public Estudiante estudiante;

    public DataLoader dataLoader;

    public Examen examen;

    public void Login(string nombre, string apellido, string codigoExamen) {

        Codigo cod = dataLoader.GetCodigo(codigoExamen);
        if(cod != null) {

            Examen e = dataLoader.GetExamen(cod.examen);
            if(e != null) {
                examen = e;

            } else {
                //examen no existe
            }
        } else {
            //Codigo no existe
        }
    }

    public void ShowExamen() {

    }



}
