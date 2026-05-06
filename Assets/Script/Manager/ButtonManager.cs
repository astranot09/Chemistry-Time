using UnityEngine;

public class ButtonManager : MonoBehaviour
{
    public void StartGame()
    {
        SceneController.instance.GameScene();
    }
    public void ExitGame()
    {
        SceneController.instance.ExitGame();
    }
    public void MainMenu()
    {
        SceneController.instance.MainMenuScene();
    }
}
