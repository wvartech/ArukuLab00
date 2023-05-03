using System.Collections;
using System.Collections.Generic;
using System.Linq.Expressions;
using UnityEngine;

public class GoodSpirit : EntityContext
{
//    private EntityContext context;
//    private IEntityState defaultState;    
    
    private void Start() {
        target = GameManager.instance.getPlayer();
        defaultState = new LerpTo(this,target, 1f);
     //   defaultState = new MoveToTarget(this, player);
        currentState = defaultState;
        
    }

    // Update is called once per frame
    new void Update()
    {
        base.Update();
    }



}
