using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ShootRandom : IEntityState {
    public EntityContext context { get; }
    private float shootInterval;
    private int shotAmmount;
    private float timer = 0;
    private int shots;
    private GameObject bulletPrefab;

    public ShootRandom(EntityContext context, GameObject bulletPrefab, float shootInterval, int shotAmmount) {
        this.context = context;
        this.shootInterval = shootInterval;
        this.shotAmmount = shotAmmount;
        this.bulletPrefab = bulletPrefab;
    }

    public void Enter() {
        timer = 0;
        shots = shotAmmount;
    }

    public void Exit() {
        timer = 0;
    }

    // Update is called once per frame
    public void Update() {

        if (timer > 0) {
            timer -= Time.deltaTime;
        } else {
            if (shots > 0) {
                //   Debug.Log("Shot once!");
                timer = shootInterval;
                var bullet = GameObject.Instantiate(bulletPrefab, context.transform.position, Quaternion.identity).GetComponent<Bullet>();
                Vector3 rng = Random.insideUnitCircle;
                bullet.setDirection(context.transform.position + rng);
                shots--;
            }
        }
        if (shots <= 0 && timer < 0) {
            Exit();
            context.setDefault();
            return;
        }
    }
}
