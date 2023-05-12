using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public enum Team {
    Enemy,
    Player,
    Neutral,
    Possessable,
}
public interface IDamageable
{
    Team team {get;}
    void isHit(float value,Vector2 hitDir);
}
