using UnityEngine;

public class PlayerController : MonoBehaviour {

	public ScoreManager scoreManager; //Through it we will change the player's score
	private Rigidbody2D rb; //From this parameter we can get the player velocity

	private bool canJump = false; //Is at this point in time a player allowed to jump

	//Parameters that will help us determine whether the player is on the ground or not
	public Transform groundCheck;
	private bool isGrounded;
	[SerializeField] float groundCheckRadius;
	public LayerMask whatIsGround;

	//Modifiable parameters
	[SerializeField] float moveForce = 365f;
	[SerializeField] float maxSpeed = 5f;
	[SerializeField] float jumpForce = 1000f;
	[SerializeField] float bounceFactor = 1.25f;
	[SerializeField] float HorizontalJumpFactor = 100f;
	[SerializeField] KeyCode jump;

	/**Initialize variables Rigidbody2D**/
	private void Start()
	{
		rb = GetComponent<Rigidbody2D>();
	}

	/**Called every frame,Used for regular updates such as: Moving non-physics objects,Simple Timers, Receiving Input **/
	private void Update()
	{
		isGrounded = Physics2D.OverlapCircle(groundCheck.position, groundCheckRadius, whatIsGround);
		if (Input.GetKeyDown(jump) && isGrounded)
			canJump = true;
	}

	/**Called every physics step,FixedUpdate intervals are consistent, Used for regular updates such as: Adjusting physicd objects **/
	private void FixedUpdate()
	{
		float horizontal = Input.GetAxis("Horizontal");
		//The player does not have enough speed 
		if (Mathf.Abs(horizontal * rb.velocity.x) < maxSpeed)
		{
			rb.AddForce(horizontal * moveForce * Vector2.right);
		}
	
		if (canJump)
		{
			//Add a momentary jumping force to the player
			float totalJumpForce = jumpForce + Mathf.Abs(rb.velocity.x) * HorizontalJumpFactor;
			rb.AddForce(Vector2.up * totalJumpForce);
			canJump = false;
		}
	}

	/**The function gives the player power when he collides with the walls as well as the function also updates the score according to the 
	 * number of steps the player has passed**/
	private void OnCollisionEnter2D(Collision2D col)
	{
		if(col.gameObject.tag == "Wall")
		{
			Vector2 rev = new Vector2(rb.velocity.x * bounceFactor, 0);
			rb.AddForce(rev, ForceMode2D.Impulse);
		}
		if(col.gameObject.tag == "Platform")
		{
			scoreManager.UpdateScore((int)transform.position.y);
		}
	}
}
