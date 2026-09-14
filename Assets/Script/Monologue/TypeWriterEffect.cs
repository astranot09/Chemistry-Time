using System.Collections;
using TMPro;
using UnityEngine;

public class TypeWriterEffect : MonoBehaviour
{
    //public static TypeWriterEffect instance;

    //private void Awake()
    //{
    //    if (instance == null)
    //        instance = this;
    //    else
    //        Destroy(gameObject);
    //}

    [SerializeField] private float delayBeforeStart = 0.1f;
    [SerializeField] private float typeWriterSpeed = 50f;
    [SerializeField] private float delayBeforeClose = 1f;

    private Coroutine monologueCoroutine;
    public void Run(string textToType, TMP_Text textLabel)
    {
        if (monologueCoroutine != null)
        {
            StopCoroutine(monologueCoroutine);
        }

        monologueCoroutine = StartCoroutine(TypeText(textToType, textLabel));
    }

    private IEnumerator TypeText(string textToType, TMP_Text textLabel)
    {

        textLabel.text = string.Empty;

        yield return new WaitForSeconds(delayBeforeStart);

        float t = 0;
        int charIndex = 0;
        while(charIndex < textToType.Length)
        {
            t += Time.deltaTime * typeWriterSpeed;
            charIndex = Mathf.FloorToInt(t);
            charIndex = Mathf.Clamp(charIndex, 0, textToType.Length);

            textLabel.text = textToType.Substring(0, charIndex);

            yield return null;
        }

        textLabel.text = textToType;
        StartCoroutine(FinishText());
    }

    private IEnumerator FinishText()
    {
        yield return new WaitForSeconds(delayBeforeClose);
        monologueCoroutine = null;
        MonologueManager.instance.CloseMonologue();
    }

}
