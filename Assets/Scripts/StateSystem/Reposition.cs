using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Reposition : IEntityState
{
    private Vector3 target;
    private Vector3 start;
    private float relocationTime;
    [Range(0f, 1f)]
    private float lerper;
    private float offset;
    public EntityContext context { get; private set; }

    public Reposition(EntityContext context, Vector3 target,float offset ,float relocationTime) {
        this.context = context;
        this.target = target;
        this.relocationTime = relocationTime;
        this.offset = offset;
        start = context.transform.position;
        this.target += (Vector3)Random.insideUnitCircle.normalized * offset;
        lerper = 0f;
        context.setFacing(target);
    }

    public void Enter() {
        context.setFacing(target);
    }

    public void Exit() {
    }


    // Update is called once per frame
    public void Update()
    {
        lerper += Time.deltaTime / relocationTime;
        if (lerper >= 1f) {
            context.setDefault();
        }
        getLerping();
        
    }

    private void getLerping() {
        context.transform.position = Vector3.Lerp(start, target, lerper);
    }

}
