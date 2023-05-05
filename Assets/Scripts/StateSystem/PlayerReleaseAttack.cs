using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerReleaseAttack : IEntityState
{
    public EntityContext context {get;}
    private float cooldown = 0.25f;
    private float timer;

    public PlayerReleaseAttack(EntityContext context ){
        this.context = context;        
        timer = cooldown;
    }

    public void Enter(){
        timer = cooldown;
    }

    public void Exit(){

    }


    // Update is called once per frame
    public void Update()
    {
        timer -= Time.deltaTime;
        if (timer <= 0){
            context.setDefault();
        }
    }

    private void Attack(){

    }

}
