using UnityEngine;
using System.Collections;
using ProceduralToolkit;

public class ApplyVertColors : MonoBehaviour {

    private Mesh myMesh;
	// Use this for initialization
	void Start () {

        myMesh = GetComponent<MeshFilter>().sharedMesh;
        
       
        Color[] colors = new Color[myMesh.vertexCount];
        //Debug.Log(colors.Length);
      

        for (int i = 0; i < myMesh.vertexCount; i++)
        {
            colors[i] = RandomE.colorHSV;
        }

        myMesh.colors = colors;
    }

    // Update is called once per frame
    void Update () {
	    

	}



}
