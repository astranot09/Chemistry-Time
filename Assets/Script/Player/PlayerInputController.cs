using UnityEngine;
using UnityEngine.InputSystem;

public class PlayerInputController : MonoBehaviour
{
    public static PlayerInputController instance;

    private void Awake()
    {
        if(instance == null)
            instance = this;
        else
            Destroy(gameObject);
    }

    [Header("Direction")]
    private Vector2 dir;
    public Vector2 lastDir;


    [Header("Reference")]
    [SerializeField] private Player player;
    [SerializeField] private ChemistryWeapon chemistryWeapon;
    [SerializeField] private WaveClearSkill clearSkill;
    [SerializeField] private ShieldSkill shieldSkill;
    [SerializeField] private PlayerInteractSystem interactSystem;

    public void OnMove(InputAction.CallbackContext ctx)
    {
        dir = ctx.ReadValue<Vector2>();
        if (ctx.performed)
        {
            lastDir = dir;
            interactSystem.SetDirection(lastDir);
        }
        player.SetDirectionPlayer(dir,lastDir);
    }

    public void OnSkillWaveClear(InputAction.CallbackContext ctx)
    {
        if (ctx.canceled)
        {
            clearSkill.SkillCast();
        }
    }
    public void OnSkillShield(InputAction.CallbackContext ctx)
    {
        if (ctx.canceled)
        {
            shieldSkill.SkillActivated();
        }
    }
    public void OnShoot(InputAction.CallbackContext ctx)
    {
        if (ctx.started)
        {
            chemistryWeapon.OnHoldCharge();
        }

        if (ctx.canceled)
        {
            chemistryWeapon.OnChargeOff();
        }
    }

    public void OnInteract(InputAction.CallbackContext ctx)
    {
        if (ctx.started) return;

        interactSystem.Interact();
    }
}
