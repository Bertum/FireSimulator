using UnityEngine;
using UnityEngine.UI;

public class UIController : MonoBehaviour
{
    private GameController gameController;
    private WindController windController;

    private void Awake()
    {
        gameController = GameObject.Find("GameController").GetComponent<GameController>();
        windController = GameObject.Find("WindController").GetComponent<WindController>();
    }



    public void Clear()
    {
        gameController.Clear();
    }

    public void Generate()
    {
        gameController.GeneratePlants();
    }

    public void PlayStop()
    {
        gameController.PlayStop();
    }

    public void Fire()
    {
        gameController.Fire();
    }

    public void ExitGame()
    {
        Application.Quit();
    }

    public void ModeChanged(Dropdown dropdown)
    {
        gameController.SetMode(dropdown.value);
    }

    public void WindSpeedChanged(Slider slider)
    {
        windController.SetSpeed(slider.value);
    }

    public void WindDirectionChanged(Slider slider)
    {
        windController.SetDirection(slider.value);
    }
}
