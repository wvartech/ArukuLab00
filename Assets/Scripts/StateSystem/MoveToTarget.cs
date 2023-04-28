using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MoveToTarget : IEntityState
{
    
    private Transform target;
    public EntityContext context { get; }

    public MoveToTarget(EntityContext context,Transform target) {
        this.context = context;
        this.target = target;
    }    

    public void Enter() {
        
    }

    public void Exit() {
        
    }

    public void Update() {
        if (Vector3.Distance(context.transform.position, target.transform.position) < 0.5f) {
            Exit();
            context.setState(new WaitFor(context,2f));
        }
        context.transform.position += GetDirection(target.position) * Time.deltaTime;
    }

    private Vector3 GetDirection(Vector3 target) {
        var a  = target - context.transform.position;
        
        return a.normalized;
    }

}
