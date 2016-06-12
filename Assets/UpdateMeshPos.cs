using UnityEngine;
using System.Collections;
using System.Collections.Generic;
using ProceduralToolkit;

public class UpdateMeshPos : MonoBehaviour {

    private MeshFilter myMeshFilter;

    private MeshDraft draft;
    private MeshDraft draftOrig;

	// Use this for initialization
	void Start () {
        myMeshFilter = GetComponent<MeshFilter>();

        draftOrig = new MeshDraft(myMeshFilter.sharedMesh);
        draft = draftOrig;
	}
	
	// Update is called once per frame
	void Update () {

        MoveVerts(transform.position);
	}

    void MoveVerts(Vector3 position)
    {
        draft = new MeshDraft(draft.ToMesh());

        //draft.Move(new Vector3(0, 0, val));

       

        int vertexCount = draft.vertices.Count;

        //Vector3[] verts = new Vector3[vertexCount];

        List<Vector3> verts = new List<Vector3>();

        for (int i = 0; i < vertexCount; i++)
        {
            Vector3 vertex = draftOrig.vertices[i];
            vertex += position;
            verts.Add(vertex);
        }

        draft.vertices = verts;
        myMeshFilter.sharedMesh = draft.ToMesh();

        //myMeshFilter.sharedMesh.SetVertices(verts);
        //myMeshFilter.sharedMesh.UploadMeshData(false);
    }

}