using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AimingMode : IEntityState
{
    
    public EntityContext context {get; private set;}
    private EntityContext helper;

    public void Enter(){

    }

    public void Exit(){

    }


    public AimingMode(EntityContext player, EntityContext helper){
        this.context = player;
        this.helper = helper;
    }

    // Update is called once per frame
    public void Update()
    {
        float inputX = Input.GetAxis("Horizontal");
        float inputY = Input.GetAxis("Vertical");
        //Debug.Log(inputX + "," + inputY);



        Vector2 dir = new Vector2(inputX,inputY);
        helper.transform.position = context.transform.position + (Vector3)dir.normalized*0.3f;
    }
}
