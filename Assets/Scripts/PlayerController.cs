using UnityEngine;

public class PlayerController : MonoBehaviour
{

    public Rigidbody2D rb;
    public float torque = 10f;
    public float forward = 5f;
    private bool onGround = false;
    private CapsuleCollider2D cd;
    public bool isGameOver = false;

    private AudioSource audioS;
    [SerializeField] private AudioClip clip;
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        rb = gameObject.GetComponent<Rigidbody2D>();
        cd = gameObject.GetComponent<CapsuleCollider2D>();
        audioS = gameObject.GetComponent<AudioSource>();
    }

    // Update is called once per frame
    void FixedUpdate()
    {

        if (isGameOver)
        {
            rb.linearVelocity = Vector2.zero;
            rb.angularVelocity = 0f;
        }
        else
        {
            if (Input.GetKey(KeyCode.A) || Input.GetKey(KeyCode.LeftArrow))
            {
                rb.AddTorque(torque * Time.deltaTime);
            }

            if (Input.GetKey(KeyCode.D) || Input.GetKey(KeyCode.RightArrow))
            {
                rb.AddTorque(-torque * Time.deltaTime);
            }


            if ((Input.GetKey(KeyCode.W) || Input.GetKey(KeyCode.UpArrow)) && onGround)
            {
                rb.AddForce(transform.right * forward * Time.deltaTime, ForceMode2D.Force);

                if (!audioS.isPlaying)
                {
                    audioS.PlayOneShot(clip, 0.7f);
                    Debug.Log("ŞADİ ANANI SİKEYİM");
                }
            }
        }
        
    }


    void OnCollisionEnter2D(Collision2D collision)
    {

        if (collision.otherCollider == cd)
        {
            Debug.Log("Game Over");
            isGameOver = true;
            GameManager.instance.GameOver();
        }
        else
        {
            onGround = true;
            
        }
    }

    void OnCollisionExit2D(Collision2D collision)
    {
        onGround = false;
        //audioS.Stop();
    }
}
