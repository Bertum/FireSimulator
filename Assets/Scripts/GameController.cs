using UnityEngine;

public class GameController : MonoBehaviour
{
    public GameObject plantPrefab;
    private float terrainX, terrainZ;
    private int plantCounter;
    private InteractionMode interactionMode;

    private void Awake()
    {
        interactionMode = InteractionMode.Add;
        terrainX = Terrain.activeTerrain.terrainData.bounds.size.x;
        terrainZ = Terrain.activeTerrain.terrainData.bounds.size.z;
    }

    private void Update()
    {
        MouseClicked();
    }

    public void GeneratePlants()
    {
        plantCounter = Random.Range(0, 100);
        for (int i = 0; i < plantCounter; i++)
        {
            var x = Random.Range(0, terrainX);
            var y = Random.Range(0, terrainZ);
            Instantiate(plantPrefab, new Vector3(x, Terrain.activeTerrain.SampleHeight(new Vector3(x, 0, y)), y), Quaternion.identity);
        }
    }

    public void Clear()
    {
        var plants = GameObject.FindGameObjectsWithTag("Plant");
        for (int i = 0; i < plants.Length; i++)
        {
            Destroy(plants[i]);
        }
    }

    public void Fire()
    {
        var plants = GameObject.FindGameObjectsWithTag("Plant");
        //Set fire to the half of the plants
        for (int i = 0; i < plantCounter / 2; i++)
        {
            var rnd = Random.Range(0, plantCounter);
            plants[rnd].GetComponent<PlantController>().SetFire();
        }
    }

    public void PlayStop()
    {
        Time.timeScale = Time.timeScale == 1 ? 0 : 1;
    }

    public void SetMode(int mode)
    {
        interactionMode = (InteractionMode)mode;
    }

    private void MouseClicked()
    {
        if (Input.GetMouseButtonDown(0))
        {
            if (interactionMode == InteractionMode.Add)
            {
                RaycastHit hit;
                Ray ray = Camera.main.ScreenPointToRay(Input.mousePosition);
                if (Terrain.activeTerrain.gameObject.GetComponent<Collider>().Raycast(ray, out hit, Mathf.Infinity))
                {
                    Instantiate(plantPrefab, new Vector3(hit.point.x, Terrain.activeTerrain.SampleHeight(new Vector3(hit.point.x, 0, hit.point.z)), hit.point.z), Quaternion.identity);
                }
            }
            else
            {
                RaycastHit hit;
                Ray ray = Camera.main.ScreenPointToRay(Input.mousePosition);
                if (Physics.Raycast(ray, out hit, 500))
                {
                    if (hit.transform.gameObject.tag == "Plant")
                    {
                        if (interactionMode == InteractionMode.Remove)
                        {
                            Destroy(hit.transform.gameObject);
                        }
                        else if (interactionMode == InteractionMode.ToogleFire)
                        {
                            hit.transform.gameObject.GetComponent<PlantController>().SetFire();
                        }
                    }
                }
            }
        }
    }
}
