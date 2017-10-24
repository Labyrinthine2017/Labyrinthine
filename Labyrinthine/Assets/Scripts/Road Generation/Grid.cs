using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Grid : MonoBehaviour
{
    public int xSize;
    public int xRotation, yRotation, zRotation;
    public int meshNumber;

    public GameObject LeftSphere;
    public GameObject RightSphere;

    public Vector3 LPos { get; set; }
    public Vector3 RPos { get; set; }

    private Vector3[] vertices;
    private Mesh mesh;

    //[SerializeField] GameObject sphere;

	// Use this for initialization
	void Awake ()
    {
        Generate();
	}
	
	// Update is called once per frame
	void Update ()
    {

	}

    private void Generate()
    {
        //Initializes the vertices array to size of xSize by ySize
        vertices = new Vector3[2];
        GetComponent<MeshFilter>().mesh = mesh = new Mesh();
        mesh.name = "Procedural Grid" + meshNumber;

        transform.Rotate(new Vector3(xRotation, yRotation, zRotation));

        vertices[0] = new Vector3(-xSize / 2, 0.0f, 0.0f);
        vertices[1] = new Vector3(xSize / 2, 0.0f, 0.0f);

        mesh.vertices = vertices;

        Bounds bounds = mesh.bounds;
        LPos = transform.TransformPoint(bounds.min);//Bottom left corner
        RPos = transform.TransformPoint(new Vector3(bounds.max.x, 0.0f, bounds.min.z));//Bottom right corner

        Instantiate(LeftSphere, LPos, Quaternion.identity);
        Instantiate(RightSphere, RPos, Quaternion.identity);

    }
    //private void OnDrawGizmos()
    //{
    //    Gizmos.color = Color.black;
    //    Gizmos.DrawSphere(bLPos, 0.5f);
    //    Gizmos.DrawSphere(tLPos, 0.5f);
    //    Gizmos.DrawSphere(bRPos, 0.5f);
    //    Gizmos.DrawSphere(tRPos, 0.5f);
    //}


    public Vector3[] GetVerticies()
    {
        return vertices;
    }
    public Vector3 GetVerticies(int a_index)
    {
        return vertices[a_index];
    }
}
