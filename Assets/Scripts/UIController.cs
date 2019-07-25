using UnityEngine;
using UnityEngine.UI;

public class UIController : MonoBehaviour
{
    private GameController gameController;

    private void Awake()
    {
        gameController = GameObject.Find("GameController").GetComponent<GameController>();
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
}
