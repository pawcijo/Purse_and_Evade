using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Agent : MonoBehaviour {



    public float maxSpeed;
    public float maxAccel;
    public float orientation;
    public float rotation;
    public Vector3 velocity;
    protected Steering steering;
    void Start()
    {
        velocity = Vector3.zero;
        steering = new Steering();
    }

    public void SetSteetring(Steering steering)
    {
        this.steering = steering;

    }

    public virtual void Update()
    {
        Vector3 displacemanet = velocity * Time.deltaTime;
        orientation += rotation * Time.deltaTime;
        //Limit na wartosci  orientacji
        if(orientation<0.0f)
        {
            orientation += 360.0f;
        }
        else if(orientation >360.0f)
        {
            orientation -= 360.0f;
        }
        transform.Translate(displacemanet, Space.World);
        transform.rotation = new Quaternion();
        transform.Rotate(Vector3.up, orientation);
   

    }

    public virtual void LateUpdate()
    {
        velocity += steering.linerar * Time.deltaTime;
        rotation += steering.angular * Time.deltaTime;

        if(velocity.magnitude>maxSpeed)
        {
            velocity.Normalize();
            velocity = velocity * maxSpeed;
        }
        if (steering.angular==0.0f)
        {
            rotation = 0.0f;
        }
        if (steering.linerar.sqrMagnitude==0.0f)
        {
            velocity = Vector3.zero;
        }

        steering = new Steering();





    }

}
