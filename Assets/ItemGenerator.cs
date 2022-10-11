using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ItemGenerator : MonoBehaviour
{
    public GameObject carPrefab;
    public GameObject coinPrefab;
    public GameObject cornPrefab;
    private int startPos = 80;
    private int goalPos = 360;
    private bool generate = false;
    private float posRange = 3.4f;
    private GameObject unitychanPos;


    // Start is called before the first frame update
    void Start()
    {
        unitychanPos = GameObject.Find("UnityChan");
        
        
        /*for(int i = startPos; i < goalPos; i += 15)
        {
            int num = Random.Range(1, 11);
            if (num <= 2)
            {
                for(float j = -1; j <= 1; j += 0.4f)
                {
                    GameObject corn=Instantiate(cornPrefab);
                    corn.transform.position = new Vector3(4 * j, corn.transform.position.y, i);
                }
            }
            else
            {
                for (int j = -1; j <= 1; j++)
                {
                    int item = Random.Range(1, 11);
                    int offsetZ = Random.Range(-5, 6);
                    if (1 <= item && item <= 6)
                    {
                        GameObject coin = Instantiate(coinPrefab);
                        coin.transform.position = new Vector3(posRange*j, coin.transform.position.y, i + offsetZ);
                    }
                    else if (7 <= item && item <= 9)
                    {
                        GameObject car = Instantiate(carPrefab);
                        car.transform.position = new Vector3(posRange*j, car.transform.position.y, i + offsetZ);
                    }
                }
            }

        }*/
    }

    // Update is called once per frame
    void Update()
    {
        if (this.transform.position.z > startPos && this.transform.position.z<goalPos && generate==false)
        {
            generate = true;
            int num = Random.Range(1, 11);
            if (num <= 2)
            {
                for (float j = -1; j <= 1; j += 0.4f)
                {
                    GameObject corn = Instantiate(cornPrefab);
                    corn.transform.position = new Vector3(4 * j, corn.transform.position.y, this.transform.position.z);
                }
            }
            else
            {
                for (int j = -1; j <= 1; j++)
                {
                    int item = Random.Range(1, 11);
                    int offsetZ = Random.Range(-5, 6);
                    if (1 <= item && item <= 6)
                    {
                        GameObject coin = Instantiate(coinPrefab);
                        coin.transform.position = new Vector3(posRange * j, coin.transform.position.y, this.transform.position.z + offsetZ);
                    }
                    else if (7 <= item && item <= 9)
                    {
                        GameObject car = Instantiate(carPrefab);
                        car.transform.position = new Vector3(posRange * j, car.transform.position.y, this.transform.position.z + offsetZ);
                    }
                }
            }

        }

        if (this.transform.position.z > startPos + 15) 
        {
            generate = false;
            startPos += 15;
        }


    }
}
