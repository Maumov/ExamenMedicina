using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DataLoader : MonoBehaviour
{
    public List<Profesor> profesores;
    public List<Estudiante> estudiantes;
    public List<Examen> examenes;
    public List<Question> preguntas;

    [ContextMenu("GetAllData")]
    public void GetAllData() {
        StartCoroutine(GetProfesores());
        StartCoroutine(GetEstudiantes());
        StartCoroutine(GetExamen());
        StartCoroutine(GetPreguntas());
    }

    IEnumerator GetProfesores() {
        string docId = "1zRt_ugcGqIB6Kn7hfJHQW0f-fjx-fEmBNfxhfHX4-z0";
        string sheetId = "1354977118";
        string url = "https://docs.google.com/spreadsheets/d/" + docId + "/export?format=csv";
        if(!string.IsNullOrEmpty(sheetId)) {
            url += "&gid=" + sheetId;
        }
        WWWForm form = new WWWForm();
        WWW download = new WWW(url, form);
        yield return download;
        Debug.Log(download.text);
    }

    IEnumerator GetEstudiantes() {
        string docId = "1zRt_ugcGqIB6Kn7hfJHQW0f-fjx-fEmBNfxhfHX4-z0";
        string sheetId = "1948744068";
        string url = "https://docs.google.com/spreadsheets/d/" + docId + "/export?format=csv";
        if(!string.IsNullOrEmpty(sheetId)) {
            url += "&gid=" + sheetId;
        }
        WWWForm form = new WWWForm();
        WWW download = new WWW(url, form);
        yield return download;
        Debug.Log(download.text);
    }
    
     IEnumerator GetExamen() {
        string docId = "1zRt_ugcGqIB6Kn7hfJHQW0f-fjx-fEmBNfxhfHX4-z0";
        string sheetId = "1895458670";
        string url = "https://docs.google.com/spreadsheets/d/" + docId + "/export?format=csv";
        if(!string.IsNullOrEmpty(sheetId)) {
            url += "&gid=" + sheetId;
        }
        WWWForm form = new WWWForm();
        WWW download = new WWW(url, form);
        yield return download;
        Debug.Log(download.text);
    }
    IEnumerator GetPreguntas() {
        string docId = "1zRt_ugcGqIB6Kn7hfJHQW0f-fjx-fEmBNfxhfHX4-z0";
        string sheetId = "1589617286";
        string url = "https://docs.google.com/spreadsheets/d/" + docId + "/export?format=csv";
        if(!string.IsNullOrEmpty(sheetId)) {
            url += "&gid=" + sheetId;
        }
        WWWForm form = new WWWForm();
        WWW download = new WWW(url, form);
        yield return download;
        Debug.Log(download.text);
    }
}
