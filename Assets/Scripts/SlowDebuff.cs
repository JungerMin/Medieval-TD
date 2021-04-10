using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SlowDebuff : TimedEffect
{
    public float slowPct = 30f;

    protected override void Start()
    {
        base.Start();
        slowPct = slowPct / 100;
    }

    protected override void ApplyEffect()
    {
        target.Slow(slowPct);
    }

    protected override void EndEffect()
    {
        target.Slow(0);
        base.EndEffect();
    }
}
