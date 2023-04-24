using UnityEngine;

public class Weapon : MonoBehaviour
{
    [SerializeField] private float damage;
    [SerializeField] private float cooldown;

    public float Damage 
    { 
        get => damage; 
        private set => _ = damage; 
    }
    public float Cooldown 
    {
        get => cooldown;
        private set => _ = cooldown;
    }

    [SerializeField] private ParticleSystem flashEffect;
    // можно звук ещё

    public void MakeShootEffect()
    {
        flashEffect.Play();
    }
}
