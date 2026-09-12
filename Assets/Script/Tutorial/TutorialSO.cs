
using System.Collections.Generic;
using UnityEngine;

[System.Serializable]
public class Tutorial
{
    public Sprite tutorialImage;
    public string tutorialName;
    [TextArea(3, 5)] public string tutorialDescription;
}

[CreateAssetMenu(fileName = "TutorialSO", menuName = "Scriptable Objects/TutorialSO")]
public class TutorialSO : ScriptableObject
{
    public List<Tutorial> tutorials;
}
