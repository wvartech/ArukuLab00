using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;
using System.Linq;

public class GameManager : MonoBehaviour
{
    [SerializeField]
    private Transform player;
    public static GameManager instance;
    public List<Transform> possesables = new List<Transform>();

    private void Awake() {
        if (instance == null) {
            instance = this;
        } else {
            Destroy(this);
        }
        var iDamageable = FindObjectsOfType<MonoBehaviour>().OfType<IPossesable>();
        if (iDamageable == null) { Debug.Log("Its null"); return; }
        foreach (MonoBehaviour t in iDamageable) {
            possesables.Add(t.transform);
            Debug.Log(t.transform.position);
            Debug.Log(t.gameObject.name);
        }

    }
    
    public Transform closestPossesable(Transform requester) {
        Transform target = null;
        foreach (Transform t in possesables) {
            if (target == null) { target = t; continue; }
            if (Vector3.Distance(requester.position, t.position) < Vector3.Distance(requester.position, target.position)) {
                target = t;
            }
        }
        return target;
    }

    public Transform getPlayer() { return player; }

}
