using UnityEngine;

public class PlayerCollision : Subject {
	public Rigidbody rb;
	public PlayerMovement movement;
	private MusicManager mm;
	public bool dying = false;
	public bool grazing = false;
	public bool isSlease = false;
	private void Start()
	{
		mm = FindObjectOfType<MusicManager>();
	}
	private void OnEnable()
	{
		if (!mm) mm = FindObjectOfType<MusicManager>();
		if (mm) Attach(mm);
		NotifyObservers();

	}
	private void OnDisable()
	{
		if (!mm) mm = FindObjectOfType<MusicManager>();
		if (mm) Detach(mm);
	}
	void OnCollisionEnter (Collision collisionInfo)
	{
		if (collisionInfo.collider.tag == "Obstacle")
		{
			dying = true;
			NotifyObservers();
			rb.AddExplosionForce(400f, rb.position, 5);
			rb.AddTorque(1000, 400, 200);
			movement.enabled = false;
			FindObjectOfType<GameManager>().EndGame();
		}
		if (collisionInfo.collider.name.Contains("Sphere", System.StringComparison.CurrentCultureIgnoreCase))
        {
			rb.AddExplosionForce(700f, collisionInfo.rigidbody.position, 100f);
			rb.AddTorque(2000, 800, 400);
        }
	}
    private void FixedUpdate()
    {
		if (rb.position.y < -1f)
		{
			dying = true;
			NotifyObservers();
			rb.AddTorque(100, 0, 100);
			FindObjectOfType<GameManager>().EndGame();
		}
	}
}
