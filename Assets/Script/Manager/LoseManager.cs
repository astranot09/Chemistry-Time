using UnityEngine;

public class LoseManager : MonoBehaviour
{
    public static LoseManager instance;

    private void Awake()
    {
        if(instance == null)
            instance = this;
        else
            Destroy(gameObject);
    }

    public void PlayerLose()
    {
        UIManager.instance.DeadPanelOpen();
    }
}
