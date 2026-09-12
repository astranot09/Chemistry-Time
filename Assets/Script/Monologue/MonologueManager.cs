using UnityEngine;
using TMPro;
public class MonologueManager : MonoBehaviour
{

    public static MonologueManager instance;

    private void Awake()
    {
        if(instance == null)
            instance = this;
        else
            Destroy(gameObject);
    }


    [Header("Data")]
    [SerializeField] private MonologueSO monologueData;
    [Header("UI")]
    [SerializeField] private TMP_Text monologueText;

    public void PlayMonologue(MonologueSO monologue)
    {
        monologueData = monologue;
        monologueText.text = monologueData.monologueText.ToString();
    }
    

}
