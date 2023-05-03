using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MoveToTarget : IEntityState
{
    
    public EntityContext context { get; }

    public MoveToTarget(EntityContext context) {
        this.context = context;        
    }    

    public void Enter() {
        
    }

    public void Exit() {
        
    }

    public void Update() {
        
        if (Vector3.Distance(context.transform.position, context.target.position) < 0.5f) {
            Exit();
            return;
        }
        context.transform.position += GetDirection(context.target.position) * Time.deltaTime * context.speed;
    }

    private Vector3 GetDirection(Vector3 target) {
        var a  = target - context.transform.position;
        
        return a.normalized;
    }

}
