using System.Collections;
using System.Collections.Generic;
using System.Runtime.CompilerServices;
using UnityEngine;

public class EffectManager : MonoBehaviour
{
    public static EffectManager instance;

    [SerializeField] ParticleSystem jumpEffect;
    [SerializeField] ParticleSystem YellowConsumer;
    [SerializeField] ParticleSystem doubleJumpEffect;

    private void Awake()
    {
        instance = this;
    }


    public void JumpEffect(Vector3 position)
    {
        jumpEffect.transform.position = position;
        jumpEffect.Emit(10);
    }


    public void YellowEffect(Vector3 position)
    {
        YellowConsumer.transform.position = position;
        YellowConsumer.Emit(10);
    }

    public void DoubleJumpEffect(Vector3 position)
    {
        doubleJumpEffect.transform.position = position;
        doubleJumpEffect.Emit(10);
    }
}