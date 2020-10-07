using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BrownBird : Bird
{
    public float radius = 5.0f;
    public float power = 1.0f;
    public float torque = 3.0f;

    

    public override void OnTap()
    {
        explotion();
    }

    void explotion()
    {
        //Mengambil titik saat ledakan
        Vector3 explotionPos = transform.position;
        //Mengambil colider diarea titik ledakan dengan radius tertentu dalam bentu array
        Collider2D[] colliders = Physics2D.OverlapCircleAll(explotionPos, radius);

        //Pengambilan 1 per satu colider yg didpt
        foreach(Collider2D hit in colliders)
        {
            //Mengambil Rigidbody yang terdapat pada objek colider
            Rigidbody2D rb = hit.GetComponent<Rigidbody2D>();

            if(rb != null)
            {
                //Memberikan dorongan dari titik ledakan dengan kekuatan yg ditentukan
                rb.AddRelativeForce(explotionPos * power, ForceMode2D.Impulse);
                //Memberikan putaran pada objek
                rb.AddTorque(torque, ForceMode2D.Impulse);
            }

        }
    }
}
