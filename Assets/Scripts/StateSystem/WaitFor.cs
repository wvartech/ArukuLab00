using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WaitFor : IEntityState {
    public EntityContext context { get; }
    private float waitTarget;

    public WaitFor(EntityContext context,float delay) {
        this.context = context;
        waitTarget = Time.time + delay;
    }
    public void Enter() {
        
    }

    public void Exit() {
        context.setDefault();
    }

    public void Update() {
        if (waitTarget > Time.time) { return; } else {
            Exit();         
        }
    }
}
