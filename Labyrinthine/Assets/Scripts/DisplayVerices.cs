using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DisplayVerices : MonoBehaviour
{
    Mesh mesh;
	// Use this for initialization
	void Start ()
    {
        mesh = GetComponent<MeshFilter>().mesh;
	}

    private void OnDrawGizmos()
    {
        Gizmos.DrawSphere(mesh.vertices[8], 0.1f);
        Gizmos.DrawSphere(mesh.vertices[9], 0.1f);
        Gizmos.DrawSphere(mesh.vertices[10], 0.1f);
        Gizmos.DrawSphere(mesh.vertices[11], 0.1f);
        Gizmos.DrawSphere(mesh.vertices[12], 0.1f);
        Gizmos.DrawSphere(mesh.vertices[13], 0.1f);
        Gizmos.DrawSphere(mesh.vertices[14], 0.1f);
        Gizmos.DrawSphere(mesh.vertices[15], 0.1f);
    }

    // Update is called once per frame
    void Update ()
    {
		
	}
}
