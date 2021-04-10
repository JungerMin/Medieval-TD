using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SlowDebuff : TimedEffect
{
    public float slowPct = 30f;

    protected override void Start()
    {
        base.Start();
        slowPct /= 100;
    }

    protected override void ApplyEffect()
    {
        if(target != null)
        {
            target.Slow(slowPct);
        }
        else
        {
            Destroy(gameObject);
        }
            
    }

    protected override void EndEffect()
    {
        if(target != null)
        {
            target.Slow(0);
        }
        base.EndEffect();
    }
}
