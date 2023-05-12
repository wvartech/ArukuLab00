using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Summon : IEntityState
{
    public EntityContext context {get; private set;}
    private GameObject prefab;
    private Vector2 location;

    public Summon(EntityContext context, GameObject prefab, Vector2 position) {
        this.context = context;
        this.prefab = prefab;
        this.location = position;

    }

    public void Enter() {
        spawnMob();
        context.setDefault();
    }

    public void Exit() {
    }


    // Update is called once per frame
    public void Update()
    {
        
    }

    private void spawnMob() {
        if (prefab == null) {
            Vector2 rng = Random.insideUnitCircle.normalized*0.5f;
            var a = GameManager.instance.spawnEnemy(location + rng, 2);
            var b = GameManager.instance.spawnEnemy(location - rng, 2);
            //var b = a.GetComponent<EntityContext>().setState(new MoveToTarget);
        }
    }

}
