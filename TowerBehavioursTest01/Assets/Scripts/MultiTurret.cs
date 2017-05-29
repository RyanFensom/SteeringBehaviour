using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MultiTurret : MonoBehaviour
{

    public Transform[] shootPoint;
    public GameObject bullet;

	// Use this for initialization
	void Start ()
    {
		
	}
	
	// Update is called once per frame
	void Update () {

        Shoot();
    }

    void Shoot()
    {
        for (int i = 0; i < shootPoint.Length; i++)
        {
            Instantiate(bullet, shootPoint[i]);
        }

    }

}
