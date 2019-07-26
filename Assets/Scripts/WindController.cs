using UnityEngine;

public class WindController : MonoBehaviour
{
    public GameObject windPointer;
    private float windSpeed;
    public GameObject windDirection;

    private void Awake()
    {
        SetDirection(0);
    }

    public void SetDirection(float direction)
    {
        windPointer.transform.rotation = Quaternion.Euler(90, 0, direction);
        UpdatePlants();
    }

    public void SetSpeed(float speed)
    {
        windSpeed = speed;
        UpdatePlants();
    }

    private void UpdatePlants()
    {
        var plants = GameObject.FindGameObjectsWithTag("Plant");
        foreach (var plant in plants)
        {
            var plantController = plant.GetComponent<PlantController>();
            plantController.windSpeed = windSpeed;
            plantController.windDirection = windDirection.transform.position;
        }
    }
}
