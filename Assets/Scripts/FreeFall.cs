using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FreeFall : MonoBehaviour
{
    private const float g = 9.81f;
    private Vector3 vel;
    private Vector3 pos;
    private const float m = 1f;
    public float lambda = 2.5f;

    public int e = 1;
    public bool isOnFloor = false;

    void Start()
    {
        vel = Vector3.zero;
        pos = transform.position;
    }


    void checkCollision()
    {

        isOnFloor = transform.position.y < 0;

    }

    void Update()
    {
        float deltaT = Time.fixedDeltaTime;

        checkCollision();
        if (isOnFloor)
        {
            Debug.Log("On the Floor , y=0");
            vel *= -e;
        }
        Debug.Log(vel);



        // Utilisation de la méthode de Runge-Kutta d'ordre 4
        Vector3 k1 = CalculateAcceleration(pos, vel);
        Vector3 k2 = CalculateAcceleration(pos + 0.5f * vel * deltaT, vel + 0.5f * k1 * deltaT);
        Vector3 k3 = CalculateAcceleration(pos + 0.5f * vel * deltaT, vel + 0.5f * k2 * deltaT);
        Vector3 k4 = CalculateAcceleration(pos + vel * deltaT, vel + k3 * deltaT);

        vel += (k1 + 2f * k2 + 2f * k3 + k4) * (deltaT / 6f);
        pos += vel * deltaT;

        transform.position = pos;
    }

    Vector3 CalculateAcceleration(Vector3 position, Vector3 velocity)
    {
        // Calcule l'accélération avec frottements visqueux
        Vector3 dragForce = -lambda * velocity;
        Vector3 gravityForce = new Vector3(0, -m * g, 0);
        Vector3 acceleration = (gravityForce + dragForce) / m;
        return acceleration;
    }

}
