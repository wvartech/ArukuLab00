using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Boss00 : EntityContext, IDamageable {
    public Team team { get; private set; }
    private float actionInterval = 2f;
    private float timer = 2;
    private int tempo = 0;
    [SerializeField]
    private GameObject bulletPrefab;

    private float maxHealth = 100;
    private float health;
    [SerializeField]
    private Image healthbarA,healthbarB;



    void Start() {
        health = maxHealth;
        team = Team.Enemy;
        target = GameManager.instance.getPlayer();
        defaultState = new WaitFor(this, 2);
        currentState = defaultState;
        healthbarA.fillAmount = health / maxHealth;
        healthbarB.fillAmount = health / maxHealth;
    }

    // Update is called once per frame
    new void Update() {
        if (currentState == defaultState) { timer -= Time.deltaTime; }
        if (timer < 0) {
            timer = actionInterval;
            TempoAction(tempo);
        }

        if (currentState.GetType() != typeof(BossStun)) {
            playerAnimator.Play("BossIdle");
        }

        base.Update();
    }
    public void isHit(float value, Vector2 hitDir) {
        if (value  >= 1f) {
            health -= 10;
            if (currentState.GetType() != typeof(BossStun)) {
                setState(new BossStun(this, 2.5f, true));
            }
            
        } else {
            health -= 5;
        }

        healthbarA.fillAmount = health / maxHealth;
        healthbarB.fillAmount = health / maxHealth;

        if (health <= 0) {
            Destroy(gameObject);
            GameManager.instance.GameOver("Victory!");
        }
        
    }

    private void TempoAction(int t) {
        switch (t) {
            case 0:
                tempo++;
                setState(new Reposition(this,target.position, 2.5f, 1));
                break;
            case 1:
                tempo++;
                setState(new Reposition(this, target.position, 0.5f, 1));
                timer = 0.25f;
                break;
            case 2:
                tempo++;
                setState(new Shoot(this, bulletPrefab, 0.05f, 12));
                timer = 0.75f;
                break;
            case 3:
                tempo++;
                setState(new Reposition(this, target.position, 0f, 0.45f));
                break;
            case 4:
                tempo++;
                setState(new Summon(this, null, transform.position));
                break;
            default:
                tempo = 0;
                break;
        }

    }

    private void OnCollisionEnter2D(Collision2D collision) {
        var other = collision.gameObject.GetComponent<IDamageable>();
        if (other == null) { return; }
        if (other.team == Team.Player) {
            Debug.Log("Bumped into player!");
            other.isHit(0.25f, transform.position);

        }

    }

}
