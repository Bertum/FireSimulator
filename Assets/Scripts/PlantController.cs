using UnityEngine;

public class PlantController : MonoBehaviour
{
    private PlantStatus plantStatus;
    private float fireTimer;
    private float timeToBurnt = 10;
    private GameController gameController;
    public Vector3 windDirection;
    public float windSpeed;

    private void Awake()
    {
        gameController = GameObject.Find("GameController").GetComponent<GameController>();
        fireTimer = 0;
        plantStatus = PlantStatus.Base;
        SwitchColor();
    }

    void Update()
    {
        CountTimer();
        CheckIfBurnt();
        SetFireNearPlants();
    }

    private void CountTimer()
    {
        if (plantStatus == PlantStatus.Burning)
        {
            fireTimer += Time.deltaTime;
        }
    }

    private void CheckIfBurnt()
    {
        if (fireTimer >= timeToBurnt)
        {
            plantStatus = PlantStatus.Burnt;
            SwitchColor();
        }
    }

    public void SetFire()
    {
        if (plantStatus != PlantStatus.Burnt)
        {
            plantStatus = PlantStatus.Burning;
            SwitchColor();
        }
    }

    private void SwitchColor()
    {
        switch (plantStatus)
        {
            case PlantStatus.Base:
                this.GetComponent<Renderer>().material.color = Color.green;
                break;
            case PlantStatus.Burning:
                this.GetComponent<Renderer>().material.color = Color.red;
                break;
            case PlantStatus.Burnt:
                this.GetComponent<Renderer>().material.color = Color.black;
                break;
            default:
                break;
        }
    }

    private void SetFireNearPlants()
    {
        if (plantStatus == PlantStatus.Burning)
        {
            RaycastHit hit;
            Ray ray = new Ray(this.transform.position, new Vector3(windDirection.x, this.transform.position.y, windDirection.z));
            if (Physics.Raycast(ray, out hit, 100))
            {
                if (hit.collider.gameObject.tag == "Plant")
                {
                    CheckIfBurn(hit.collider.gameObject);
                }
            }
        }
    }

    /// <summary>
    /// More wind more posibilities
    /// </summary>
    private void CheckIfBurn(GameObject plant)
    {
        var rnd = Random.Range(0, 100);
        // if the number is less than the wind speed then burn
        // higher speed more posibilities
        if (rnd <= windSpeed)
        {
            plant.GetComponent<PlantController>().SetFire();
        }
    }
}
