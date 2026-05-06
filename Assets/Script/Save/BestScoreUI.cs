using UnityEngine;
using TMPro;
public class BestScoreUI : MonoBehaviour
{
    [SerializeField] private TMP_Text scoreText;
    private void Start()
    {
        int i = BestScoreManager.instance.GetBestScore();
        scoreText.text = i.ToString();
    }
}
