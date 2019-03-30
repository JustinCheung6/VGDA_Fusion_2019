using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ExplosionHandler : MonoBehaviour
{
    [SerializeField] 
    private ParticleSystem explosion;

    public AudioSource explosionSound;

    private void OnEnable()
    {
        Ticker.OnDeathEvent += TriggerExplosion;
    }

    private void OnDisable()
    {
        Ticker.OnDeathEvent -= TriggerExplosion;
    }

    private void TriggerExplosion()
    {
        explosion.Play();
        explosionSound.Play();
        Ticker.OnDeathEvent -= TriggerExplosion;
    }
    
}
