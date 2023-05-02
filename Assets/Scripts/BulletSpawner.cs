using UnityEngine;

public class BulletSpawner : MonoBehaviour
{
    //public
    public GameObject bulletPrefab;
    public Transform bulletSpawnPoint;
    public float timeBetweenSpawn = 1.0f;
    public Transform launcherModel;
    public GameObject shootEffect;

    //private
    private float shotCounter;
    private Tower theTower;
    private Transform target;
    

    void Start()
    {
        theTower = GetComponent<Tower>();
    }

    void Update()
    {
        shotCounter -= Time.deltaTime;

        if(target != null)
        {
            //launcherModel.LookAt(target);
            launcherModel.rotation = 
            Quaternion.Slerp(launcherModel.rotation, Quaternion.LookRotation(target.position - transform.position), 4.0f * Time.deltaTime);
            launcherModel.rotation = Quaternion.Euler(0f, launcherModel.rotation.eulerAngles.y ,0f);
        }

        if (shotCounter <= 0 && target != null)
        {
            shotCounter = timeBetweenSpawn;
            bulletSpawnPoint.LookAt(target);
            
            Instantiate(bulletPrefab, bulletSpawnPoint.position, bulletSpawnPoint.rotation);
            Instantiate(shootEffect, bulletSpawnPoint.position, bulletSpawnPoint.rotation);
        }


        if(theTower.enemiesInRange.Count> 0)
        {
            float minDistance = theTower.range + 1f;
            foreach(EnemyController enemy in theTower.enemiesInRange)
            {
                if (enemy != null)
                {
                    float distance = Vector3.Distance(transform.position, enemy.transform.position);
                    if(distance < minDistance)
                    {
                        minDistance = distance;
                        target = enemy.transform;
                    }
                }
            }
        }
        else
        {
            target = null;
        }
    }
}