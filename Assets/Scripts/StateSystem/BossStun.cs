using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BossStun : IEntityState
{
    private float timer;
    private bool teleport;
    public EntityContext context {get; private set;}

    public BossStun(EntityContext context, float duration, bool teleport) {
        this.context = context;
        this.timer = duration;
        this.teleport = teleport;
    }

    public void Enter() {
        context.playerAnimator.Play("BossStun");
    }

    public void Exit() {
    }

    public void Update()
    {
        if (timer > 0) { timer -= Time.deltaTime; } else {
            if (teleport) {
                Vector3 rng = Random.insideUnitCircle.normalized * 2;
                Teleport(context.target.position + rng);
            }
            context.setDefault();
        }
    }

    private void Teleport(Vector2 location) {
        context.transform.position = location;
    }

}
