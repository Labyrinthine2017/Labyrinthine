using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Grid : MonoBehaviour
{
    public int xSize, zSize;
    public int zRotation;
    public int meshNumber;

    public Vector3 bLPos { get; set; }
    public Vector3 tLPos { get; set; }
    public Vector3 bRPos { get; set; }
    public Vector3 tRPos { get; set; }

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
        vertices = new Vector3[4];
        uv = new Vector2[vertices.Length];
        GetComponent<MeshFilter>().mesh = mesh = new Mesh();
        mesh.name = "Procedural Grid" + meshNumber;

        vertices[0] = new Vector3(0.0f, 0.0f, 0.0f);
        vertices[1] = new Vector3(xSize, 0.0f, 0.0f);
        vertices[2] = new Vector3(0.0f, 0.0f, zSize);
        vertices[3] = new Vector3(xSize, 0.0f, zSize);

        transform.Rotate(0.0f, 0.0f, zRotation);

        

        mesh.vertices = vertices;

        triangles = new int[6];
        //Assigns the triangular verticies of the mesh 
        triangles[0] = 2;
        triangles[1] = 3;
        triangles[2] = 0;
        triangles[3] = 3;
        triangles[4] = 1;
        triangles[5] = 0;

        mesh.triangles = triangles;
        mesh.RecalculateNormals();

        Bounds bounds = mesh.bounds;
        bLPos = transform.TransformPoint(bounds.min);//Bottom left corner
        tLPos = transform.TransformPoint(new Vector3(bounds.min.x, 0.0f, bounds.max.z));//Top left corner
        bRPos = transform.TransformPoint(new Vector3(bounds.max.x, 0.0f, bounds.min.z));//Bottom right corner
        tRPos = transform.TransformPoint(bounds.max);//Top right corner

        Instantiate(sphere, bLPos, Quaternion.identity);
        Instantiate(sphere, bRPos, Quaternion.identity);
        Instantiate(sphere, tLPos, Quaternion.identity);
        Instantiate(sphere, tRPos, Quaternion.identity);

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
