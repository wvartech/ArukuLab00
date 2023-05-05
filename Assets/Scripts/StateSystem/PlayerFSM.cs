using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerFSM : EntityContext , IDamageable
{    
    private bool running;
    public Team team { get; private set; }    
    
    void Start()
    {
        team = Team.Player;
        defaultState = new HandlePlayerMovementInputs(this);
        currentState = defaultState;
    }

    // Update is called once per frame
    new void Update()
    {
        base.Update();
    }

    public void isHit(float stunDuration) {
        setState(new Flinch(this, stunDuration));
    }

}
