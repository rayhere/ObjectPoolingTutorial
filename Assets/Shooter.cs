using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Shooter : MonoBehaviour
{
    public BulletController bullet;

    void Update() 
    {
        //if (Input.GetKeyDown(KeyCode.Mouse0))  
        if (Input.GetKey(KeyCode.Space))  
        {
            BulletController instance = ObjectPooler.DequeueObject<BulletController>("Bullet");
            instance.Initialise();
            instance.gameObject.SetActive(true);
            instance.mousePosition = Camera.main.ScreenToWorldPoint(Input.mousePosition);
        } 
    }
}
