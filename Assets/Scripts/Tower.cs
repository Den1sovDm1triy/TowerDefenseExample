using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Tower : MonoBehaviour
{

    public float range = 3.0f;

    public Collider[] collidersInTange;
    public List<EnemyController> enemiesInRange = new List<EnemyController>();

    private float checkCounter;
    public float checkTime = 0.2f;

    public GameObject rangeMode;

    void Start()
    {
        checkCounter = checkTime;
    }


    void Update()
    {
        checkCounter -= Time.deltaTime;
        if (checkCounter <= 0){

            checkCounter = checkTime;
            collidersInTange = Physics.OverlapSphere(transform.position, range);

            enemiesInRange.Clear();
            foreach (Collider col in collidersInTange){
                enemiesInRange.Add(col.GetComponent<EnemyController>());
            }
        }
        
    }
}
