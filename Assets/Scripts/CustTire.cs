using System.Collections;
using System.Collections.Generic;
using UnityEditor;
using UnityEngine;

public class CustTire : MonoBehaviour
{
 
    [SerializeField] MeshFilter[] tireMeshFilters; // Array of mesh filters for all wheels
    [SerializeField] MeshRenderer[] tireMeshRenderers;// An array of mesh renderers to display the wheels

    [SerializeField] Material tireMaterial;// Material for wheels
    [SerializeField] Mesh[] tireMeshes;// Array of different meshes for the wheels

    int curTireMesh;// Variable to keep track of the current wheel mesh

    // Method to change wheel mesh
    public void ChangeTire(Mesh meshToChange)
    {
        foreach (var meshFilter in tireMeshFilters)
        {
            meshFilter.mesh = meshToChange;// Change the wheel mesh to the given one
        }
    }

    // Method to move to the next wheel mesh
    public void NextTireMeshButton()
    {
        foreach (var renderer in tireMeshRenderers)
        {
            renderer.material = tireMaterial;
        }

        curTireMesh++;

        if (curTireMesh >= tireMeshes.Length)
        {
            curTireMesh = 0;// If the index goes beyond the array, we return it to the beginning
        }

        Mesh selectedMesh = tireMeshes[curTireMesh];// Select a new mesh for the wheels

        foreach (var meshFilter in tireMeshFilters)
        {
            meshFilter.mesh = selectedMesh;// Change the meshes of all wheels to the selected mesh
        }
    }

    // Method to go to previous wheel mesh
    public void PriviousTireMeshButton()
    {
        foreach (var renderer in tireMeshRenderers)
        {
            renderer.material = tireMaterial;
        }

        if (curTireMesh == 0)
        {
            curTireMesh = tireMeshes.Length - 1; // If the index is already zero, set it to the last mesh
        }
        else
        {
            curTireMesh--;
        }
        Mesh selectedMesh = tireMeshes[curTireMesh];
        foreach (var meshFilter in tireMeshFilters)
        {
            meshFilter.mesh = selectedMesh;// Change the meshes of all wheels to the selected mesh
        }
    }
    
}
