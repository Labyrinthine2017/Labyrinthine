using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GridGenerator : MonoBehaviour
{
    int xSize;
    private Vector3[] vertices;
    private Mesh mesh;
    private Mesh[] meshes;
    int meshesCount = 0;
    int[] triangles;
    Grid[] childern;
	// Use this for initialization
	void Start ()
    {
        childern = gameObject.GetComponentsInChildren<Grid>();
        meshes = new Mesh[childern.Length-1];

        for(int i = 0; i < childern.Length - 1; i ++)
        {
            MergeTwoLines(childern[i], childern[i + 1]);
        }
        
        CombineMeshes();
    }

    void CombineMeshes()
    {
        //MeshFilter[] childMeshFilters = GetComponentsInChildren<MeshFilter>();
        CombineInstance[] meshesToCombine = new CombineInstance[meshes.Length];
        int meshCounter = 0;
        //While the counter is less than the amount of child mesh filters
        while (meshCounter < meshes.Length)
        {
            if (meshes[meshCounter] != GetComponent<MeshFilter>().mesh)
            {
                //Adds the childs meshes to the combine list of meshes
                meshesToCombine[meshCounter].mesh = meshes[meshCounter];
                //Sets that meshes transform to the child's meshes position in the world
                meshesToCombine[meshCounter].transform = Matrix4x4.identity;// meshes[meshCounter].transform.localToWorldMatrix;
                //Deactivates the child game object
                //Destroy(meshes[meshCounter].gameObject);
            }
            meshCounter++;
        }

        transform.GetComponent<MeshFilter>().mesh = new Mesh();
        transform.GetComponent<MeshFilter>().name = "MapMesh";
        transform.GetComponent<MeshFilter>().mesh.CombineMeshes(meshesToCombine);
        transform.gameObject.SetActive(true);
    }
    void MergeTwoLines(Grid child1, Grid child2)
    {

       
        Mesh tempMesh = new Mesh();
    
     
        
        //Adds the two points associated with the children lines to form a rectangle corner points
        Vector3[] tempVertices = new Vector3[4];
        tempVertices[0] = child1.LPos;
        tempVertices[1] = child1.RPos;
        tempVertices[2] = child2.LPos;
        tempVertices[3] = child2.RPos;

        tempMesh.vertices = tempVertices;

        int[] tempTriangles = new int[6];
        tempTriangles[0] = 0;
        tempTriangles[1] = 1;
        tempTriangles[2] = 2;
        tempTriangles[3] = 2;
        tempTriangles[4] = 1;
        tempTriangles[5] = 3;

        tempMesh.triangles = tempTriangles;
        meshes[meshesCount] = tempMesh;
        meshesCount++;
    }
}
