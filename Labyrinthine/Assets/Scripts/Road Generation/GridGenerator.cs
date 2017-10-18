using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GridGenerator : MonoBehaviour
{
    [SerializeField] GameObject roadPoint;
    Grid[] childern;
    bool draw = false;
	// Use this for initialization
	void Start ()
    {
        childern = this.GetComponentsInChildren<Grid>();

        for(int i = 0; i < childern.Length - 1; i ++)
        {
            if(childern[i].tRPos != childern[i + 1].bRPos)
            {
                draw = true;
            }
        }
        //CombineMeshes();
    }

    void CombineMeshes()
    {
        MeshFilter[] childMeshFilters = GetComponentsInChildren<MeshFilter>();
        CombineInstance[] meshesToCombine = new CombineInstance[childMeshFilters.Length];
        int meshCounter = 0;
        //While the counter is less than the amount of child mesh filters
        while (meshCounter < childMeshFilters.Length)
        {
            if (childMeshFilters[meshCounter] != GetComponent<MeshFilter>())
            {
                //Adds the childs meshes to the combine list of meshes
                meshesToCombine[meshCounter].mesh = childMeshFilters[meshCounter].sharedMesh;
                //Sets that meshes transform to the child's meshes position in the world
                meshesToCombine[meshCounter].transform = childMeshFilters[meshCounter].transform.localToWorldMatrix;
                //Deactivates the child game object
                Destroy(childMeshFilters[meshCounter].gameObject);
            }
            meshCounter++;
        }

        transform.GetComponent<MeshFilter>().mesh = new Mesh();
        transform.GetComponent<MeshFilter>().name = "MapMesh";
        transform.GetComponent<MeshFilter>().mesh.CombineMeshes(meshesToCombine);
        transform.gameObject.SetActive(true);
    }
}
