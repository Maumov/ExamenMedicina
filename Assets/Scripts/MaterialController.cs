using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MaterialController : MonoBehaviour
{
    //public string propertyName;
    public float offSetSpeed;
    public Material mat;
    // Start is called before the first frame update
    void Start()
    {
        //mat.SetTextureOffset(propertyName, new Vector2(mat.mainTextureOffset.x, mat.mainTextureOffset.y));
        //mat.mainTextureOffset = new Vector2(mat.mainTextureOffset.x + (offSetSpeed * Time.deltaTime), mat.mainTextureOffset.y));
        Restart();
    }

    // Update is called once per frame
    void Update()
    {
        mat.mainTextureOffset = new Vector2(mat.mainTextureOffset.x + (offSetSpeed * Time.deltaTime), mat.mainTextureOffset.y);
    }

    void Restart() {
        mat.mainTextureOffset = new Vector2(0f, mat.mainTextureOffset.y);
    }
}
