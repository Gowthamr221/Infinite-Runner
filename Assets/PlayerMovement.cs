using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityStandardAssets.CrossPlatformInput;
using UnityEngine.SceneManagement;
public class PlayerMovement : MonoBehaviour
{
    [SerializeField] private Transform CameraPosition;
    [SerializeField] private Rigidbody2D PlayerRb;
    [SerializeField] private float PlayerSpeed;
    private Animator anim;
    private BoxCollider2D coll;
    [SerializeField] private float jumpVelocity;
    private SpriteRenderer playerSprite;
    [SerializeField] private LayerMask jumpableGround;
    private int state;
    private enum MovementState { idle,running,jumping,falling};
    private float dirX=0f;
    // Start is called before the first frame update
    void Start()
    {

        coll = GetComponent<BoxCollider2D>();
        playerSprite = GetComponent<SpriteRenderer>();
        anim =GetComponent<Animator>();
    }

    // Update is called once per frame
    void Update()
    {
        dirX = CrossPlatformInputManager.GetAxis("Horizontal");

        UpdateAnimationState();
        PlayerRb.velocity = new Vector2(dirX * PlayerSpeed, PlayerRb.velocity.y);

        if (CrossPlatformInputManager.GetButtonDown("Jump") && isGrounded() )
        {
            PlayerRb.AddForce(Vector2.up * jumpVelocity);
        }

        if(this.PlayerRb.position.y < -5f)
        {
             
            if (PlayerPrefs.GetInt("SCORE")  > PlayerPrefs.GetInt("HIGH_SCORE"))
            {
                PlayerPrefs.SetInt("HIGH_SCORE", PlayerPrefs.GetInt("SCORE"));
            }
            PlayerPrefs.SetInt("SCORE", 0);
            SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex + 1);
        }

    


    }
    private void UpdateAnimationState()
    {
        MovementState state;
        if (dirX > 0f)
        {
            state = MovementState.running;
            playerSprite.flipX = false;
        }
        else if (dirX < 0f)
        {
            state = MovementState.running;
            playerSprite.flipX = true;
        }
        else
        {
            state = MovementState.idle;
        }

        if (PlayerRb.velocity.y > .1f)
        {
            state = MovementState.jumping;
        }
        else if (PlayerRb.velocity.y < -.1f)
        {
            state = MovementState.falling;
        }


        anim.SetInteger("state", (int)state);
    }
    private bool isGrounded()
    {

        return Physics2D.BoxCast(coll.bounds.center, coll.bounds.size, 0f, Vector2.down, .1f, jumpableGround);
    }
}
