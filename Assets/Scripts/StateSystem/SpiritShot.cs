using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpiritShot : IEntityState
{
    private float baseSpeed = 3;
    private float speed;
    private float duration = 1.25f;
    private Vector2 direction;
    private float multiplier;
    public EntityContext context { get; }

    public SpiritShot(EntityContext context, float hitPower, Vector2 direction) {
        this.context = context;
        multiplier = hitPower < 0.5f ? 0.5f : 1+hitPower;
        speed = multiplier * baseSpeed;
        this.direction = direction;
        Debug.Log("Launching wish speed of " + speed);
    }
    public void Enter() {
    }

    public void Exit() {
    }


    // Update is called once per frame
    public void Update()
    {        
        context.transform.position += (Vector3)direction*speed*Time.deltaTime;
        duration -= Time.deltaTime;
        if (duration < 0) {
            context.setState(new WaitFor(context, (1 + multiplier)/2));
        }
    }

}
