using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Grid : MonoBehaviour
{
    public int xSize, zSize;
    public int zRotation;
    public int meshNumber;

    public Vector3 LPos { get; set; }
    public Vector3 RPos { get; set; }

    private Vector3[] vertices;
    private Mesh mesh;
    int[] triangles;
    Vector2[] uv;
    [SerializeField] GameObject sphere;

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
        uv = new Vector2[vertices.Length];
        GetComponent<MeshFilter>().mesh = mesh = new Mesh();
        mesh.name = "Procedural Grid" + meshNumber;

        vertices[0] = new Vector3(0.0f, 0.0f, 0.0f);
        vertices[1] = new Vector3(xSize, 0.0f, 0.0f);

        mesh.vertices = vertices;

        Bounds bounds = mesh.bounds;
        LPos = transform.TransformPoint(bounds.min);//Bottom left corner
        RPos = transform.TransformPoint(new Vector3(bounds.max.x, 0.0f, bounds.min.z));//Bottom right corner

        Instantiate(sphere, LPos, Quaternion.identity);
        Instantiate(sphere, RPos, Quaternion.identity);

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
    public Vector2[] GetUV()
    {
        return uv;
    }
    public Vector2 GetUV( int a_index)
    {
        return uv[a_index];
    }
    public int[] GetTriangles()
    {
        return triangles;
    }
    public int GetTriangles(int a_index)
    {
        return triangles[a_index];
    }
}
