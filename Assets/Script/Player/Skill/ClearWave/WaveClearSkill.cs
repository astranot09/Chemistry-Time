using UnityEngine;

public class WaveClearSkill : MonoBehaviour
{
    public ParticleSystem particleSystem;

    public void SkillCast()
    {
        particleSystem.Play();
    }
}
