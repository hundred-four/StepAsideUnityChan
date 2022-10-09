using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class UnityChanController : MonoBehaviour
{
    private Animator myAnimator;
    private Rigidbody myRigidbody;
    private GameObject gameOverText;
    private GameObject gameClearText;
    private GameObject scoreText;
    public GameObject retry;
    private float velocityZ = 16f;
    private float velocityX = 10f;
    private float velocityY = 10f;
    private float movableRange = 3.4f;
    private float coefficent = 0.95f;
    private bool isEnd = false;
    private int score = 0;
    private bool isLButtonDown = false;
    private bool isRButtonDown = false;
    private bool isJButtonDown = false;

    // Start is called before the first frame update
    void Start()
    {
        this.myAnimator = GetComponent<Animator>();
        this.myAnimator.SetFloat("Speed", 1);
        this.myRigidbody = GetComponent<Rigidbody>();
        this.gameOverText = GameObject.Find("GameOverText");
        this.gameClearText = GameObject.Find("GameClearText");
        this.scoreText = GameObject.Find("ScoreText");

    }

    // Update is called once per frame
    void Update()
    {
        if (this.isEnd)
        {
            this.myAnimator.SetBool("Goal", true);
            this.velocityX *= this.coefficent;
            this.velocityY *= this.coefficent;
            this.velocityZ *= this.coefficent;
            retry.SetActive(true);

        }

        float inputVelocityX = 0;
        float inputVelocityY = 0;

        if ((Input.GetKey(KeyCode.LeftArrow)||this.isLButtonDown) && -movableRange < this.transform.position.x)
        {
            inputVelocityX = -this.velocityX;
        }
        else if ((Input.GetKey(KeyCode.RightArrow)||this.isRButtonDown) && movableRange > this.transform.position.x)
        {
            inputVelocityX = this.velocityX;
        }

        if ((Input.GetKeyDown(KeyCode.Space)||this.isJButtonDown) && this.transform.position.y <= 0.5f)
        {
            inputVelocityY = this.velocityY;
            this.myAnimator.SetBool("Jump", true);
        }
        else
        {
            inputVelocityY = this.myRigidbody.velocity.y;
        }

        if (this.myAnimator.GetCurrentAnimatorStateInfo(0).IsName("Jump"))
        {
            this.myAnimator.SetBool("Jump", false);
        }
        this.myRigidbody.velocity = new Vector3(inputVelocityX, inputVelocityY, velocityZ);
    }

    private void OnTriggerEnter(Collider other)
    {
        if(other.gameObject.tag=="TrafficCornTag"|| other.gameObject.tag == "CarTag")
        {
            Vector3 futtobi = new Vector3(0, 7, -100);
            this.myAnimator.SetBool("Hidan", true);
            this.velocityX = 0;
            this.velocityY = 0;
            this.velocityZ = 0;
            this.myRigidbody.AddForce(futtobi, ForceMode.Impulse);
            this.gameOverText.GetComponent<Text>().text="GAME OVER!";
            retry.SetActive(true);
        }

        if (other.gameObject.tag == "CoinTag")
        {
            GetComponent<ParticleSystem>().Play();
            this.score += 10;
            this.scoreText.GetComponent<Text>().text="SCORE:"+this.score.ToString("D4")+"pt";
            Destroy(other.gameObject);
        }

        if (other.gameObject.tag == "GoalTag")
        {
            this.gameClearText.GetComponent<Text>().text = "CLEAR!!";
            isEnd = true;
        }
    }

    public void GetMyLeftButtonDown()
    {
        this.isLButtonDown = true;
    }
    public void GetMyLeftButtonUp()
    {
        this.isLButtonDown = false;
    }

    public void GetMyRightButtonDown()
    {
        this.isRButtonDown = true;
    }
    public void GetMyRightButtonUp()
    {
        this.isRButtonDown = false;
    }

    public void GetMyJumpButtonDown()
    {
        this.isJButtonDown = true;
    }
    public void GetMyJumpButtonUp()
    {
        this.isJButtonDown = false;
    }

    public void Retry()
    {
        SceneManager.LoadScene("SampleScene");
    }
}
