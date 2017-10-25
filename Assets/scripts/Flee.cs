using System.Collections;
using System.Collections.Generic;
using UnityEngine;


public class Flee : AgentBehavior {


    public override Steering GetSteering()
    {
        Steering steering = new Steering();
        steering.linerar = transform.position - target.transform.position;
        steering.linerar.Normalize();
        steering.linerar = steering.linerar * agent.maxAccel;
        return steering;

    }


}
