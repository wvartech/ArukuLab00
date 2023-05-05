using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public enum Team {
    Enemy,
    Player,
    Neutral,
}
public interface IDamageable
{
    Team team {get;}
    void isHit(float value);
}
