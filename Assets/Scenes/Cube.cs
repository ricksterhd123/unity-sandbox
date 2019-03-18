using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Cube : MonoBehaviour
{
    public GameObject obj;
    
    // Start is called before the first frame update
    void Start()
    {
        Debug.Log("Hello world");
    }

    // Update is called once per frame
    void Update()
    {
        // Rotate the cube around all axis
        obj.transform.Rotate(new Vector3(1f * Time.deltaTime, Mathf.Sin(obj.transform.rotation.x % Mathf.PI * 2), Mathf.Cos(obj.transform.rotation.y % Mathf.PI * 2)));
    }
}
