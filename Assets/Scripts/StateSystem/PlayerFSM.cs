using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerFSM : EntityContext
{    
    private bool running;
    // Start is called before the first frame update
    void Start()
    {
        defaultState = new HandlePlayerMovementInputs(this);
        currentState = defaultState;
    }

    // Update is called once per frame
    new void Update()
    {
        base.Update();
    }


    
}
