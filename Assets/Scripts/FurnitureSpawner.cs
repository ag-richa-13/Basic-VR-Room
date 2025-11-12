using UnityEngine;

public class FurnitureSpawner : MonoBehaviour
{
    [Header("Prefabs")]
    public GameObject chairPrefab;
    public GameObject tablePrefab;

    [Header("Parent Room")]
    public Transform roomRoot; // Assign your Room_Root in Inspector

    [Header("Placement Settings")]
    public Vector3 chairPosition = new Vector3(1.0f, 0.0f, 1.0f);
    public Vector3 tablePosition = new Vector3(1.0f, 0.0f, 0.0f);

    public Vector3 chairRotation = new Vector3(0f, 180f, 0f);
    public Vector3 tableRotation = new Vector3(0f, 90f, 0f);

    void Start()
    {
        SpawnFurniture();
    }

    private void SpawnFurniture()
    {
        if (roomRoot == null)
        {
            Debug.LogError("Room root not assigned in FurnitureSpawner!");
            return;
        }

        // Instantiate Table
        if (tablePrefab != null)
        {
            GameObject table = Instantiate(tablePrefab, 
                roomRoot.TransformPoint(tablePosition), 
                Quaternion.Euler(tableRotation), 
                roomRoot);
            table.name = "Table";
        }

        // Instantiate Chair
        if (chairPrefab != null)
        {
            GameObject chair = Instantiate(chairPrefab, 
                roomRoot.TransformPoint(chairPosition), 
                Quaternion.Euler(chairRotation), 
                roomRoot);
            chair.name = "Chair";
        }
    }
}
