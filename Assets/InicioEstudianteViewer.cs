using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class InicioEstudianteViewer : MonoBehaviour {

    public InputField estudiante;
    
    public StudentControl studentControl;

    public void ButtonPressed() {
        studentControl.Login(estudiante.text);
    }
}
