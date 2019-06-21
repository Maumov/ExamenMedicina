using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class EstudianteCodigoLoginViewer : MonoBehaviour
{
    public InputField codigo;

    public StudentControl studentControl;

    public void ButtonPressed() {
        studentControl.EntrarExamen(codigo.text);
    }
}
