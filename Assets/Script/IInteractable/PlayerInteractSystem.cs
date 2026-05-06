using UnityEngine;
using UnityEngine.InputSystem;

public class PlayerInteractSystem : MonoBehaviour
{
    [Header("Interact Settings")]
    [SerializeField] private float interactDistance = 2f;
    [SerializeField] private LayerMask interactLayer;

    private Vector2 lastDirection = Vector2.right;

    [SerializeField] private RaycastHit2D hit;

    // Dipanggil dari script movement kamu
    public void SetDirection(Vector2 dir)
    {
        if (dir != Vector2.zero)
        {
            lastDirection = dir.normalized;
        }
    }

    public void Interact(InputAction.CallbackContext ctx)
    {
        if (ctx.started) return;

        Debug.Log("Interact ditekan");

        hit = Physics2D.Raycast(
            transform.position,
            lastDirection,
            interactDistance,
            interactLayer
        );

        if (hit.collider != null)
        {
            Debug.Log("Kena: " + hit.collider.name);

            IInteractable interactable = hit.collider.GetComponent<IInteractable>();

            if (interactable != null)
            {
                interactable.Interact();
            }
            else
            {
                Debug.Log("Tidak ada IInteractable");
            }
        }
        else
        {
            Debug.Log("Tidak kena apa-apa");
        }
    }

    // Debug garis di Scene
    private void OnDrawGizmos()
    {
        Gizmos.color = Color.yellow;
        Gizmos.DrawLine(
            transform.position,
            transform.position + (Vector3)lastDirection * interactDistance
        );
    }
}