using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DataMaker : MonoBehaviour {

    public Question questionTest;
    public Estudiante estudianteTest;
    public Profesor profesorTest;
    public Examen examenTest;
    public Codigo codigoTest;

    [ContextMenu("Question creation Test")]
    public void CreateQuestion() {
        StartCoroutine(GenerateQuestion(questionTest));
    }

    IEnumerator GenerateQuestion(Question question) {
        string url = "https://docs.google.com/forms/d/1bZwJLDpG5UL1-oy7Fb0KPBvm6DJKxBlVhoAfIUm0AuU/formResponse?embedded=true";
        WWWForm form = new WWWForm();
        form.AddField("entry.957284751", question.id);
        form.AddField("entry.757561497",  question.parrafo);
        form.AddField("entry.1228001765",  question.video);
        form.AddField("entry.1168160256",  GeneratePreguntasJSON(question));
        
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

        form.AddField("entry.1624511214",  profesor.id);
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
        form.AddField("entry.1984751887",  estudiante.nombre);
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
        form.AddField("entry.2083147523", examen.nombre);
        form.AddField("entry.1971879306",  examen.profesor.id);
        form.AddField("entry.1477725636",  GenerateExamenPreguntasIdsJSON(examen.preguntas));
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
    [ContextMenu("Codigo creation Test")]
    public void CreateCodigo() {
        StartCoroutine(GenerateCodigo(codigoTest));
    }

    IEnumerator GenerateCodigo(Codigo codigo) {
        string url = "https://docs.google.com/forms/d/1PcQKN2KPseHKN17JsMTru80Uuj_AuW35S1qDrfZeuRU/formResponse?embedded=true";
        WWWForm form = new WWWForm();

        form.AddField("entry.904679377", codigo.id);
        form.AddField("entry.761260333", codigo.examen);
        form.AddField("entry.596794584", codigo.fechaInicio);
        form.AddField("entry.305779192", codigo.fechaFin);
        WWW www = new WWW(url, form);
        yield return www;
        Debug.Log(www.text);
        yield return null;
        Debug.Log("Sent");
    }
}

[System.Serializable]
public class Estudiante {
    //public string timeStamp;
    public string id;
    public string nombre;
    public string apellido;
}

[System.Serializable]
public class Profesor {
    //public string timeStamp;
    public string id;
    public string nombre;
    public string apellido;
}

[System.Serializable]
public class Examen {
    //public string timeStamp;
    public string id;
    public string nombre;
    public Profesor profesor;
    public List<string> preguntas;
}

[System.Serializable]
public class Question {
    //public string timeStamp;
    public string id;
    public string parrafo;
    public string video;
    public List<string> preguntas;
    public List<string> respuestas;
}
[System.Serializable]
public class Codigo {
    public string id;
    public string examen;
    public string fechaInicio;
    public string fechaFin;
}
