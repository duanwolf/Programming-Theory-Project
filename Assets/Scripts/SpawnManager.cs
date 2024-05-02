using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpawnManager : MonoBehaviour
{
    // Start is called before the first frame update
    [SerializeField]
    private GameObject[] animalPrefabs;

    [SerializeField]
    private GameObject[] foodPrefabs;
    [SerializeField]
    private Vector3 animalLeftTop;
    [SerializeField]
    private Vector3 animalRightBottom;
    [SerializeField]
    private Vector3 foodLeftTop;
    [SerializeField]
    private Vector3 foodRightBottom;
    private List<List<Vector3>> animalAreas;
    private List<List<Vector3>> foodAreas;

    public float startTime = 5;
    public float foodInterval = 2f;
    public float animalInterval = 5f;
    void Start()
    {
        animalAreas = new List<List<Vector3>>();
        List<Vector3> animalArea = new List<Vector3>();
        animalArea.Add(animalLeftTop);
        animalArea.Add(animalRightBottom);
        animalAreas.Add(animalArea);

        foodAreas = new List<List<Vector3>>();
        List<Vector3> foodArea = new List<Vector3>();
        foodArea.Add(foodLeftTop);
        foodArea.Add(foodRightBottom);
        foodAreas.Add(foodArea);

        InvokeRepeating("RandomSpawnFood", startTime, foodInterval);
        InvokeRepeating("RandomSpawnAnimal", startTime, animalInterval);
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    void RandomSpawnGameObject(GameObject[] gameObjects, List<List<Vector3>> areas)
    {
        int firstIndex = Random.Range(0, gameObjects.Length);
        int secondIndex = Random.Range(0, areas.Count);
        List<Vector3> area = areas[secondIndex];
        Instantiate(gameObjects[firstIndex], RandomSpawnPositionFromArea(area), gameObjects[firstIndex].transform.rotation);
    }
    Vector3 RandomSpawnPositionFromArea(List<Vector3> area)
    {
        float x = Random.Range(area[0].x, area[1].x);
        float z = Random.Range(area[0].z, area[1].z);
        return new Vector3(x, area[0].y, z);
    }

    void RandomSpawnFood()
    {
        RandomSpawnGameObject(foodPrefabs, foodAreas);
    }

    void RandomSpawnAnimal()
    {
        RandomSpawnGameObject(animalPrefabs, animalAreas);
    }

    public bool ValideAnimalPosition(Vector3 pos)
    {
        bool result = true;
        foreach (var area in animalAreas)
        {
            float x = pos.x;
            float z = pos.z;
            Vector3 first = area[0];
            Vector3 second = area[1];
            if (x < first.x || z > first.z || x > second.x || z < second.z)
            {
                result = false;
                break;
            }
        }
        return result;
    }
}
