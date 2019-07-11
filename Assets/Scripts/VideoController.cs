using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class VideoController : MonoBehaviour
{
    //public string propertyName;
    public float offSetSpeed1;
    public float offSetSpeed2;
    public float offSetSpeed3;
    public float offSetSpeed4;
    public Material mat1;
    public Material mat2;
    public Material mat3;
    public Material mat4;

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
        UpdateMaterial(mat1, offSetSpeed1);
        UpdateMaterial(mat2, offSetSpeed2);
        UpdateMaterial(mat3, offSetSpeed3);
        UpdateMaterial(mat4, offSetSpeed4);
    }

    public void Restart() {
        mat1.mainTextureOffset = new Vector2(0f, mat1.mainTextureOffset.y);
        mat2.mainTextureOffset = new Vector2(0f, mat2.mainTextureOffset.y);
        mat3.mainTextureOffset = new Vector2(0f, mat3.mainTextureOffset.y);
        mat4.mainTextureOffset = new Vector2(0f, mat4.mainTextureOffset.y);
    }

    void UpdateMaterial(Material mat, float speed) {
        mat.mainTextureOffset = new Vector2(mat.mainTextureOffset.x + (speed * Time.deltaTime), mat.mainTextureOffset.y);
    }


}
