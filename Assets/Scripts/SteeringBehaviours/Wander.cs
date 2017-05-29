using System.Collections;
using System.Collections.Generic;
using UnityEngine;

using GGL;

public class Wander : SteeringBehaviour
{
    public float offset = 1.0f;
    public float radius = 1.0f;
    public float jitter = 0.2f;

    private Vector3 targetDir;
    private Vector3 randomDir;

    public override Vector3 GetForce()
    {
        // SET force to zero
        Vector3 force = Vector3.zero;
        // Generate random numbers between a certain range

        // 0x7fff = 32767
        float randX = Random.Range(0, 0x7fff) - (0x7fff * 0.5f);
        float randZ = Random.Range(0, 0x7fff) - (0x7fff * 0.5f);

        #region Calculate randomDir
        // SET randomDir to new Vector3 x = randX & z = randZ
        randomDir = new Vector3 (randX, 0, randZ);
        // SET randomDir to normalized randomDir
        randomDir = randomDir.normalized;
        // SET randomDir to randomDir * jitter (amplify randomDir by jitter)
        randomDir *= jitter;
        #endregion

        #region Calculate TargetDir
        // SET targetDir to targetDir + randomDir
        targetDir += randomDir;
        // SET targetDir to normalized targetDir
        targetDir = targetDir.normalized;
        // SET targetDir to targetDir * radius
        targetDir *= radius;
        #endregion


        #region Calculate force
        // SET seekPos to owner's position + targetDir
        Vector3 seekPos = owner.transform.position + targetDir;
        // SET seekPos to seekPos + owner's forward * offset
        seekPos += owner.transform.forward * offset;

        #region GIZMOS
        // SET offsetPos to position + forward * offset
        Vector3 offsetPos = transform.position + transform.forward.normalized * offset;
        // ADD circle with offsetPos + up * amount, rotate circle with lookRotation (down)
        GizmosGL.AddCircle(offsetPos + Vector3.up * 0.1f, radius, Quaternion.LookRotation(Vector3.down), 16, Color.red);
        GizmosGL.AddCircle(seekPos + Vector3.up * 0.15f, radius * 0.6f, Quaternion.LookRotation(Vector3.down), 16, Color.blue);
        #endregion
        // Set desiredForce to seekPos
        Vector3 desiredForce = seekPos - transform.position;
        // IF desiredForce is not zero
        if (desiredForce != Vector3.zero)
        {
            // SET desiredForce to desiredForce normalized * weighting
            desiredForce = desiredForce.normalized * weighting;
            // SET force to desiredForce - owner's velocity
            force = desiredForce - owner.velocity;
        }

        #endregion

        // RETURN force
        return force;
    }
}
