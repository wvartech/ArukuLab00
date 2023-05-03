using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LerpTo : IEntityState
{
    private Vector3 target;
    private Transform transformTarget;
    public EntityContext context { get; }
    float lerpDuration;
    [Range(0f, 1f)]
    private float lerper = 0;
    private Vector3 startPosition;

    public LerpTo(EntityContext context, Transform target, float lerpDuration) {
        transformTarget = target;
        this.context = context;
        this.target = target.position;
        this.lerpDuration = lerpDuration;
        startPosition = context.transform.position;
    }

    public void Enter() {
        lerper = 0;
        target = transformTarget.position;

        if (Vector3.Distance(context.transform.position, target) < 0.5f) {
            target = context.transform.position;
        } 
        startPosition = context.transform.position;
        
    }

    public void Exit() {
        lerper = 0;
        target = transformTarget.position;
        startPosition = context.transform.position;
//        context.setState(new WaitFor(context, 1f));
    }


    // Update is called once per frame
    public void Update()
    {
        getLerping();
    }

    private void getLerping() {
        lerper += Time.deltaTime;        
        if (lerper > lerpDuration) {
            Exit();
            return;
        }
        context.transform.position = Vector3.Lerp(startPosition, target, lerper - 0.15f);
    }

}
