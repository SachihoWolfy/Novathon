using UnityEngine;

public class PlayerCollision : MonoBehaviour {
	public Rigidbody rb;
	public PlayerMovement movement;

	void OnCollisionEnter (Collision collisionInfo)
	{
		if (collisionInfo.collider.tag == "Obstacle")
		{
			rb.AddExplosionForce(400f, rb.position, 5);
			rb.AddTorque(1000, 400, 200);
			movement.enabled = false;
			FindObjectOfType<GameManager>().EndGame();
		}
		if (collisionInfo.collider.name == "Sphere")
        {
			rb.AddExplosionForce(700f, collisionInfo.rigidbody.position, 100f);
			rb.AddTorque(2000, 800, 400);
        }
	}

}
