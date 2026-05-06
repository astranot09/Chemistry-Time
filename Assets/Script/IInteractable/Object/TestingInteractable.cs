using UnityEngine;

public class TestingInteractable : MonoBehaviour, IInteractable
{
    public void Interact()
    {
        Debug.Log("Interact");
    }
}
