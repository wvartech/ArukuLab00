using System.Collections;
using System.Collections.Generic;
using System.Linq.Expressions;
using UnityEngine;

public class GoodSpirit : EntityContext, IDamageable
{
    public Team team { get;private set; }

    private void Start() {
        team = Team.Neutral;
        target = GameManager.instance.getPlayer();
        defaultState = new LerpTo(this,target, 1f);     
        currentState = defaultState;        
    }

    // Update is called once per frame
    new void Update()
    {
        base.Update();
    }

    public void isHit(float value, Vector2 hitDir) {
        setState(new SpiritShot(this,value,hitDir));
    }

    private void OnCollisionEnter2D(Collision2D collision) {

        if (currentState.GetType() == typeof(SpiritShot)) {
            Debug.Log("Collided something while shooting!");

            var enemy = collision.gameObject.GetComponent<IDamageable>();
            if (enemy != null) { if (enemy.team == Team.Enemy || enemy.team == Team.Possessable) { enemy.isHit(2, transform.position); } }

        }


    }

}
