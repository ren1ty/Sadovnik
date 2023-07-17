using UnityEngine;

public class FW_ParticleSpawner : MonoBehaviour
{
    [SerializeField] private Material[] ParticlesVariants;

    private ParticleSystem _particleSystem;


    private void Start()
    {
        _particleSystem = GetComponent<ParticleSystem>();
    }

    
    public void ThrowParticlesEmoji(int ParticleID)
    {
        _particleSystem.GetComponent<Renderer>().material = ParticlesVariants[ParticleID];
        _particleSystem.Play();
    }

}
