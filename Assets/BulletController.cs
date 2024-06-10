using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BulletController : MonoBehaviour
{
    float speed = 5f;
    public Vector3 mousePosition;

    float lifetime = 3f;

    public void Initialise()
    {
        // Get the mouse position in the world space
        mousePosition.z = 0f;

        // Calculate the direction from the current position to the mouse position
        Vector3 direction = (mousePosition - transform.position).normalized;

        // Move the object towards the mouse position
        //GetComponent<Rigidbody>().velocity = direction * speed;
        GetComponent<Rigidbody>().velocity = Vector3.right * speed;

        // Rotate the object to face the mouse pointer (optional)
        float angle = Mathf.Atan2(direction.y, direction.x) * Mathf.Rad2Deg;
        transform.rotation = Quaternion.Euler(new Vector3(0, 0, angle));

        lifetime = 3f;
    }

    private void Update()
    {
        lifetime -= Time.deltaTime;

        if(lifetime < 0f)
        {
            ObjectPooler.EnqueueObject(this, "Bullet");
        }
    }
}
