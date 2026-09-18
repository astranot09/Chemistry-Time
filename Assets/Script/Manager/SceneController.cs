using System.Collections;
using UnityEngine;
using UnityEngine.SceneManagement;
public class SceneController : MonoBehaviour
{
    public static SceneController instance;

    private void Awake()
    {
        if (instance == null)
            instance = this;
        else
            Destroy(gameObject);
       // DontDestroyOnLoad(gameObject);
    }

    [SerializeField] private Animator animator;

    public void MainMenuScene()
    {
        StartCoroutine(LoadScene(0));
    }
    public void GameScene()
    {
        StartCoroutine(LoadScene(1));
    }

    public void ExitGame()
    {
        Application.Quit();
    }

    IEnumerator LoadScene(int idx)
    {
        animator.SetTrigger("Start");
        yield return new WaitForSeconds(1);
        SceneManager.LoadScene(idx);
    }
}
