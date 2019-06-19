using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DataMaker : MonoBehaviour {

    public Question questionTest;
    public Estudiante estudianteTest;
    public Profesor profesorTest;
    public Examen examenTest;

    [ContextMenu("Question creation Test")]
    public void CreateQuestion() {
        StartCoroutine(GenerateQuestion(questionTest));
    }

    IEnumerator GenerateQuestion(Question question) {
        string url = "https://docs.google.com/forms/d/1bZwJLDpG5UL1-oy7Fb0KPBvm6DJKxBlVhoAfIUm0AuU/formResponse?embedded=true";
        WWWForm form = new WWWForm();

        form.AddField("entry.757561497", question.parrafo);
        form.AddField("entry.1228001765", question.video);
        form.AddField("entry.1168160256", GeneratePreguntasJSON(question));
        
        WWW www = new WWW(url, form);
        yield return www;
        Debug.Log(www.text);
        yield return null;
        Debug.Log("Sent");
    }

    [ContextMenu("Profesor creation Test")]
    public void CreateProfesor() {
        StartCoroutine(GenerateProfesor(profesorTest));
    }

    IEnumerator GenerateProfesor(Profesor profesor) {
        string url = "https://docs.google.com/forms/d/1EzaPJtJlmz2C-b1gj3sSh5ufEFUj5L4nVwjqC987BD0/formResponse?embedded=true";
        WWWForm form = new WWWForm();

        form.AddField("entry.1624511214", profesor.id);
        form.AddField("entry.1757591822", profesor.nombre);
        form.AddField("entry.1222460419", profesor.apellido);

        WWW www = new WWW(url, form);
        yield return www;
        Debug.Log(www.text);
        yield return null;
        Debug.Log("Sent");
    }

    [ContextMenu("Student creation Test")]
    public void CreateStudent() {
        StartCoroutine(GenerateStudent(estudianteTest));
    }

    IEnumerator GenerateStudent(Estudiante estudiante) {
        string url = "https://docs.google.com/forms/d/19Z_M9Ewr24FDI7EpP68mUXZRGdEIN8O4Tt08xp4Iw3A/formResponse?embedded=true";
        WWWForm form = new WWWForm();

        form.AddField("entry.660551555", estudiante.id);
        form.AddField("entry.1984751887", estudiante.nombre);
        form.AddField("entry.617746056", estudiante.apellido);

        WWW www = new WWW(url, form);
        yield return www;
        Debug.Log(www.text);
        yield return null;
        Debug.Log("Sent");
    }

    [ContextMenu("Test creation Test")]
    public void CreateTest() {
        StartCoroutine(GenerateTest(examenTest));
    }

    IEnumerator GenerateTest(Examen examen) {
        string url = "https://docs.google.com/forms/d/1ZyVDCr6WMBiQk9uku0TpmctyIUgxnPVKD0LUjsLxIjo/formResponse?embedded=true";
        WWWForm form = new WWWForm();

        form.AddField("entry.393321971", examen.id);
        form.AddField("entry.1971879306", examen.profesor.id);
        form.AddField("entry.1477725636", GenerateExamenPreguntasIdsJSON(examen.preguntas));

        WWW www = new WWW(url, form);
        yield return www;
        Debug.Log(www.text);
        yield return null;
        Debug.Log("Sent");
    }

    string GenerateExamenPreguntasIdsJSON(List<string> question) {
        string preguntas = "{";
        for(int i = 0; i < question.Count - 1; i++) {
            preguntas += question[i] + ",";
        }
        preguntas += question[question.Count - 1] + "}";
        return preguntas;
    }

    string GeneratePreguntasJSON(Question question) {
        string preguntas = "{";
        for(int i = 0; i < question.preguntas.Count-1; i++) {
            preguntas += question.preguntas[i]+",";
        }
        preguntas += question.preguntas[question.preguntas.Count-1] + "}";
        return preguntas;
    }

}
[System.Serializable]
public class Estudiante {
    public string id;
    public string nombre;
    public string apellido;
}
[System.Serializable]
public class Profesor {
    public string id;
    public string nombre;
    public string apellido;
}
[System.Serializable]
public class Examen {
    public string id;
    public Profesor profesor;
    public List<string> preguntas;
}
[System.Serializable]
public class Question {
    public string parrafo;
    public string video;
    public List<string> preguntas;
    public List<string> respuestas;
}
