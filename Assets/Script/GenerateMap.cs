using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GenerateMap : MonoBehaviour
{
    [SerializeField] private Transform tfmFloorParent;
    [SerializeField] private GameObject prefabCuboid;

    public int FloorSize = 10;
    public float OffSet = 5f;
    public Vector3 StartPos = Vector3.zero;

    [ContextMenu("Generate Floor")]
    public void GenerateFloor()
    {
        for (int i = 0; i < FloorSize; i++)
        {
            for (int j = 0; j < FloorSize; j++)
            {
                var cuboid = Instantiate(prefabCuboid, tfmFloorParent);
                cuboid.transform.localRotation = Quaternion.Euler(Vector3.zero);
                cuboid.transform.position = new Vector3(StartPos.x + (j * OffSet), StartPos.y, StartPos.z + (i * OffSet));
            }
        }
    }

    [ContextMenu("Delete All Childs")]
    public void DeleteChildFloor()
    {
        var allChild = tfmFloorParent.GetComponentsInChildren<Transform>();

        for (int i = 0; i < allChild.Length; i++)
        {
            DestroyImmediate(allChild[i].gameObject);
        }
    }
}
