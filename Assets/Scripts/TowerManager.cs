using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TowerManager : MonoBehaviour
{

    public static TowerManager instance;

    public void Awake()
    {
        instance = this;
    }

    public Tower activeTower;
    public Transform indicator;
    public bool isPlacing;
    public LayerMask whatIsPlacement, whatIsObstacle;

    void Update()
    {
        if(isPlacing)
        {
            indicator.position = GetGridPosition();

            RaycastHit hit;
            if(Physics.Raycast(indicator.position + new Vector3(0,-3.0f,0), Vector3.up, out hit, 10f, whatIsObstacle))
            {
                indicator.gameObject.SetActive(true);
            }
            else
            {
                indicator.gameObject.SetActive(true);
                if(Input.GetMouseButtonDown(0))
                {
                    isPlacing = false;

                    Instantiate(activeTower, indicator.position, activeTower.transform.rotation);
                    indicator.gameObject.SetActive(false);
                }
            }
        }
    }

    public void StartTowerPlacement(Tower towerToPlace)
    {
        activeTower = towerToPlace;
        isPlacing = true;

        //indicator.gameObject.SetActive(true);
        //Debug.Log("Ну началось");
        Destroy(indicator.gameObject);
        Tower placeTower = Instantiate(activeTower);
        placeTower.enabled = false;
        placeTower.GetComponent<Collider>().enabled = false;
        indicator = placeTower.transform;
    }

    public Vector3 GetGridPosition()
    {
        Vector3 location = Vector3.zero;
        
        Ray ray = Camera.main.ScreenPointToRay(Input.mousePosition);
        Debug.DrawRay(ray.origin, ray.direction * 100f, Color.blue);

        RaycastHit hit;
        if(Physics.Raycast(ray, out hit, 100f, whatIsPlacement))
        {
            location = hit.point;
        }

        return location;
    }

}
