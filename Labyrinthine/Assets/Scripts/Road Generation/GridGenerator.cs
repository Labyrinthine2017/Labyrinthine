using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GridGenerator : MonoBehaviour
{
    int xSize;
    private Vector3[] vertices;
    private Mesh mesh;
    private List<Mesh> meshes;
    int meshesCount = 0;
    int[] triangles;
    public Grid[] childern;

    public GameObject sphere;
	// Use this for initialization
	void Start ()
    {
        childern = gameObject.GetComponentsInChildren<Grid>();
        meshes = new List<Mesh>();

        for(int i = 0; i < childern.Length - 1; i ++)
        {
            MergeCorner(childern[i], childern[i + 1]);  
        }        
        CombineMeshes();
    }

    void CombineMeshes()
    {
        //MeshFilter[] childMeshFilters = GetComponentsInChildren<MeshFilter>();
        CombineInstance[] meshesToCombine = new CombineInstance[meshes.Count];
        int meshCounter = 0;
        //While the counter is less than the amount of child mesh filters
        while (meshCounter < meshes.Count)
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
        transform.gameObject.AddComponent<MeshCollider>();
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
        meshes.Add(tempMesh);
        meshesCount++;
    }
    void MergeCorner(Grid child1, Grid child2)
    {
        if(child1.LPos == child2.LPos && child1.LPos.y == child2.LPos.y)
        {
            //Gets the 2 vectors required to get the angle between the 2 lines
            Vector3 vecChild1 = child1.RPos - child1.LPos;
            Vector3 vecChild2 = child2.RPos - child2.LPos;
            //Get the angle between the 2 vectors for the amount of triangles that will be required
            float angleBetween = Vector3.Angle(vecChild1, vecChild2);
            int amountOfTriangles = (int)(angleBetween / 1.0f) + 1;

            Vector3 rotationCenterPoint = vecChild1;

            while (rotationCenterPoint != vecChild2)
            {
                rotationCenterPoint = Vector3.RotateTowards(rotationCenterPoint, vecChild2, 1.0f, 0.0f);
                Instantiate(sphere, rotationCenterPoint, Quaternion.identity);
            }
        }
        if (child1.RPos.x == child2.RPos.x && child1.RPos.y == child2.RPos.y)
        {
            //Gets the 2 vectors required to get the angle between the 2 lines
            Vector3 vecChild1 = child1.LPos - child1.RPos;
            Vector3 vecChild2 = child2.LPos - child2.RPos;
            //Get the angle between the 2 vectors for the amount of triangles that will be required
            float angleBetween = Vector3.Angle(vecChild1, vecChild2);
            int amountOfTriangles = (int)(angleBetween / 1.0f) + 1;

            Vector3 rotationCenterPoint = vecChild1;

            while (rotationCenterPoint != vecChild2)
            {
                rotationCenterPoint = Vector3.RotateTowards(rotationCenterPoint, vecChild2, 1.0f, 0.0f);
                Instantiate(sphere, rotationCenterPoint, Quaternion.identity);
            }
        }
        //////Gets the number of triangles that will be required for the mesh
        ////int triangles = (int)(90.0f / 1.0f) + 1;
        //////Sets the number of vertices for the curve
        //////one for each triangle of circle, + 1 for the corner, + 1 for the last point on rotation.
        ////Vector3[] tempVertices = new Vector3[1 * triangles + 1 + 1];
        ////Vector3 previousPoint = new Vector3();
        //////Each triangle has 3 points
        ////int[] tempTriangles = new int[triangles*3];
        ////bool firstCorner = true;
        ////if ((child1.LPos.x / child2.LPos.x >= 0.95f && child1.LPos.x / child2.LPos.x <= 1.05f) || (child1.LPos.x / child2.LPos.x <= -0.95f && child1.LPos.x / child2.LPos.x >= -1.05f))
        ////{
        ////    if(firstCorner)
        ////    {
        ////        previousPoint = child1.LPos;
        ////        firstCorner = false;
        ////    }
        ////    Vector3 vecCenterForRotation = child1.LPos;
        ////    Vector3 vecBetween = child1.RPos - vecCenterForRotation;

        ////    Mesh tempMesh = new Mesh();
        ////    int triangleIndex = 0;
        ////    int vertexIndex = 0;

        ////    int pointOnCircleIndex = 0;

        ////    //set first vert as 
        ////    tempVertices[vertexIndex++] = vecCenterForRotation;

        ////    //set's up vertices
        ////    float xRotation = 0.0f;
        ////    while (xRotation <= 90.0f)
        ////    {
        ////        //Pushes the line for rotation up the curve
        ////        Quaternion rotation = Quaternion.Euler(new Vector3(0.0f, xRotation, 0.0f));
        ////        Vector3 newVec = rotation * vecBetween;
        ////        //Pushes the point out to the edge of the curve
        ////        newVec += vecCenterForRotation;

        ////        tempVertices[vertexIndex++] = newVec;      

        ////        previousPoint = newVec;
        ////        xRotation += 1.0f;
        ////    }
        ////    tempMesh.vertices = tempVertices;

        ////    //loops and creates triangles
        ////    while (triangleIndex <= triangles * 3 - 2)
        ////    {
        ////        tempTriangles[triangleIndex++] = 0;
        ////        tempTriangles[triangleIndex++] = pointOnCircleIndex;
        ////        tempTriangles[triangleIndex++] = pointOnCircleIndex + 1;

        ////        pointOnCircleIndex++;
        ////    }

        ////    tempMesh.triangles = tempTriangles;

        ////    meshes.Add(tempMesh);
        ////    meshesCount++;
        ////}
    }
}
