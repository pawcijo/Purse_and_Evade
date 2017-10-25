using System.Collections;
using UnityEngine;

public class Leave : AgentBehavior
{
    public float escapeRadius;
    public float dangerRadius;
    public float timetoTarget = 0.1f;

    //Steering steering = new Steering();
    //Vector3 direction = transform.p


    public override Steering GetSteering()
    {

        Steering steering = new Steering();
        Vector3 direction = transform.position - target.transform.position;
        float distance = direction.magnitude;

        if(distance>dangerRadius)
        {
            return steering;
        }
        float reduce;
        if(distance <escapeRadius)
        {
            reduce = 0.0f;
        }
        else
        {
            reduce = distance / dangerRadius * agent.maxSpeed;
        }
        float targetSpeed = agent.maxSpeed - reduce;

        //---------------

        Vector3 desiredVelocity = direction;
        desiredVelocity.Normalize();
        desiredVelocity *= targetSpeed;
        steering.linerar = desiredVelocity - agent.velocity;
        steering.linerar /= timetoTarget;

        if (steering.linerar.magnitude > agent.maxSpeed)
        {
            steering.linerar.Normalize();
            steering.linerar *= agent.maxSpeed;
        }

        return steering;

    }
}
