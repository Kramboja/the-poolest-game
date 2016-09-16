using UnityEngine;
using System.Collections;

public class BallPhysics : MonoBehaviour {

    private Vector3 lastpos;
    [SerializeField] private Rigidbody body;

    void Reset()
    {
        body = GetComponent<Rigidbody>();
    }

	void FixedUpdate()
    {
        if (transform.position != lastpos)
        {
            Vector3 velocity = new Vector3(0,0,0);
            //Debug.Log(body.velocity);
            if (body.angularVelocity.x > 0.01f)
            {
                //Debug.Log("x > 0.1f");
                Debug.Log("Start plusus : " + velocity);
                velocity.x = body.angularVelocity.x - 0.01f;
                Debug.Log("End Plusus : " + velocity);
            }
            else if (body.angularVelocity.x < -0.01f)
            {
                // Debug.Log("x < 0.1f");
                Debug.Log("Start minus : " + velocity);
                velocity.x = body.angularVelocity.x + 0.01f;
                Debug.Log("End minus : " + velocity);
            }
            else
            {
                //Debug.Log("else");
                Debug.Log("Start elsus : " + velocity);
                velocity.x = 0;
                
                Debug.Log("End elsus : " + velocity);
            }
            if (body.velocity.y != 0)
            {
                body.velocity = new Vector3(0, body.velocity.y - 1f, 0);
            }
            if (body.angularVelocity.z > 0.1f)
            {
                velocity.x = body.angularVelocity.z - 0.1f;
            }
            else if (body.angularVelocity.z < -0.1f)
            {
                velocity.x = body.angularVelocity.z + 0.1f;
            }
            else
            {
                velocity.z = 0;
            }
            /*body.useGravity = false;
            body.useGravity = true;*/
            body.isKinematic = true;
            body.isKinematic = false;
            body.angularVelocity = velocity;
            //Debug.Log(body.angularVelocity);

            lastpos = transform.position;
        }
    }
    /*void OnCollisionEnter(Collision collision)
    {
        if(collision.gameObject.tag == "Side")
        {
            foreach (ContactPoint contact in collision.contacts)
            {
                Debug.DrawRay(contact.point, contact.normal, Color.white);
                body.freezeRotation = true;
                body.freezeRotation = false;
                body.AddForceAtPosition(transform.position - lastpos, contact.point);
            }
        }
    }*/
}
