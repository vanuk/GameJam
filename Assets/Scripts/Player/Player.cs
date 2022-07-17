using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player : MonoBehaviour
{
    public float hp, initialHp = 40;
    public float damage, initialDamage;
    public float movingSpeed, initialMovingSpeed;
    public float reloadSpeed, initialReloadSpeed;
    public float jumpPower, initialJumpPower;
    public Buff CurrentBuff;

    public void Awake()
    {
        ResetVariables();
    }

    public void ResetVariables()
    {
        hp = initialHp;
        damage = initialDamage;
        movingSpeed = initialMovingSpeed;
        reloadSpeed = initialReloadSpeed;
        jumpPower = initialJumpPower;
    }
    public void ApplyBuff()
    {
        
        switch (CurrentBuff.buff)
        {
            case BuffType.MovementSpeedBoost:
                movingSpeed *= CurrentBuff.buffPower;
                break;
            case BuffType.JumpPowerBoost:
                jumpPower *= CurrentBuff.buffPower;
                break;
            case BuffType.ReloadSpeedBoost:
                reloadSpeed *= CurrentBuff.buffPower;
                break;
        }
    }
    
}

public struct Buff
{
    public BuffType buff;
    public float buffPower;

}

public enum BuffType
{
    MovementSpeedBoost,
    ReloadSpeedBoost,
    JumpPowerBoost
} 
