using UnityEngine;

public class PlantController : MonoBehaviour
{
    private PlantStatus plantStatus;
    private float fireTimer;
    private float timeToBurnt = 10;

    private void Awake()
    {
        fireTimer = 0;
        plantStatus = PlantStatus.Base;
        SwitchColor();
    }

    void Update()
    {
        CountTimer();
        CheckIfBurnt();
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
}
