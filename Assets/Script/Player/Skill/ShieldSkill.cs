using UnityEngine;
using UnityEngine.InputSystem;

public class ShieldSkill : MonoBehaviour
{

    [SerializeField] private GameObject shield;
    [SerializeField] private float currCooldown;
    [SerializeField] private float cooldown;
    [SerializeField] private bool OnActived;

    private void Start()
    {
        OnReset();
    }
    private void Update()
    {
        if(currCooldown > 0)
        {
            currCooldown -= Time.deltaTime;
        }
    }
    public void OnSkill(InputAction.CallbackContext ctx)
    {
        if (ctx.performed)
        {
            if(currCooldown > 0 || OnActived)
                return;
            SkillActivated();
        }
            
    }


    public void OnReset()
    {
        currCooldown = cooldown;
        OnActived = false;
    }

    private void SkillActivated()
    {
        OnActived = true;
        var x = Instantiate(shield, transform.position, Quaternion.identity,transform);
        x.GetComponent<ShieldScript>().shield = this;
    }
}
