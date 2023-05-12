using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class PlayerFSM : EntityContext , IDamageable
{    
    private bool running;
    private float maxHealth = 100f;
    private float currentHealth;
    [SerializeField]
    private Image hpBar;

    [SerializeField]
    private EntityContext helper;

    public Team team { get; private set; }    
    
    void Start()
    {
        team = Team.Player;
        currentHealth = maxHealth;
        defaultState = new HandlePlayerMovementInputs(this, helper);
        currentState = defaultState;
        hpBar.fillAmount = currentHealth/maxHealth;
    }

    // Update is called once per frame
    new void Update()
    {
        base.Update();
    }

    public void isHit(float stunDuration, Vector2 hitDir) {
        setState(new Flinch(this, stunDuration,hitDir));
        currentHealth -= 10;
        hpBar.fillAmount = currentHealth / maxHealth;
        if (currentHealth <= 0) {
            //Destroy(gameObject);            
            Destroy(this);
            GameManager.instance.GameOver("Game Over!");
            //LoadManager.instance.StartGame();
        }
    }

    public EntityContext getHelper(){
        return helper;
    }


}
