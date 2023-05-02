using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HelloWorld : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {
        Debug.Log("Start");
    }

    // Update is called once per frame
    void Update()
    {
        Debug.Log("Update");
    }

    private void FixedUpdate() {
        Debug.Log("Fixed Update ------------------");
    }

    private void Awake() {
        Debug.Log("Awake");
    }
}
