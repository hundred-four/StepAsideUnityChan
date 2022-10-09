using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Destroy : MonoBehaviour
{
    private GameObject unityChanPos;

    // Start is called before the first frame update
    void Start()
    {
        this.unityChanPos = GameObject.Find("unitychan");
    }

    // Update is called once per frame
    void Update()
    {
        if (unityChanPos.transform.position.z - this.transform.position.z > 10)
        {
            Destroy(this.gameObject);
        }
    }
}
