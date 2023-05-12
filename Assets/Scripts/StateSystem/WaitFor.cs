using System.Collections;
using System.Collections.Generic;
using System.Runtime.CompilerServices;
using UnityEngine;

public class WaitFor : IEntityState {
    public EntityContext context { get; }
    private float waitTarget;
    private float delay;

    public WaitFor(EntityContext context,float delay) {
        this.context = context;
        this.delay = delay;
        waitTarget = Time.time + delay;
    }
    public void Enter() {
        waitTarget = Time.time + delay;
    }

    public void Exit() {
     //   Debug.Log("Waited. . .");
    }

    public void Update() {
        if (waitTarget > Time.time) { return; } else {
            context.setDefault();
        }
    }
}
