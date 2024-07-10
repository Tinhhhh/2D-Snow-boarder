using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting.Antlr3.Runtime;
using UnityEngine;
using UnityEngine.InputSystem;

public class PlayerController : MonoBehaviour
{
    [SerializeField] private float torqueValue = 5f;
    [SerializeField] private Rigidbody2D rb;
    [SerializeField] private Transform groundCheck;
    [SerializeField] private LayerMask groundLayer;
    [SerializeField] private TrailRenderer tr;
    [SerializeField] private CapsuleCollider2D cc;



    private bool canDash = true;
    private bool isDashing;
    private float dashingPower = 30f;
    private float dashingTime = 0.2f;
    private float dashingCooldown = 4f;

    private float horizontal;
    private float speed =  10f;
    private float jumpingPower = 16f;

    // Update is called once per frame
    void Awake(){
        cc = GetComponent<CapsuleCollider2D>();
        rb = GetComponent<Rigidbody2D>();
    }
    void Update()
    {
        if (isDashing){
            return;
        }
        if (Input.GetKey(KeyCode.LeftArrow) || Input.GetKey(KeyCode.A))
        {
            rb.AddTorque(torqueValue);
        }

         if (Input.GetKey(KeyCode.RightArrow) || Input.GetKey(KeyCode.D))
        {
            rb.AddTorque(-torqueValue);
        }

        if (Input.GetKeyDown(KeyCode.Space) && IsGround())
        {
            rb.velocity = new Vector2(rb.velocity.x, jumpingPower);
        }

        if (Input.GetKeyDown(KeyCode.LeftShift) && canDash && IsGround())
        {
            StartCoroutine(Dash());
        }
        
    }

    private IEnumerator Dash(){
        canDash = false;
        isDashing = true;
        float originalGravity = rb.gravityScale;
        rb.gravityScale = 0f;
        rb.velocity = new Vector2(transform.localScale.x * dashingPower, 0f);
        tr.emitting = true;
        yield return new WaitForSeconds(dashingTime);
        tr.emitting = false;
        rb.gravityScale = originalGravity;
        isDashing = false;
        yield return new WaitForSeconds(dashingCooldown);
        canDash = true;
        }

    private bool IsGround(){
        if (Physics2D.OverlapBox(cc.bounds.center, cc.bounds.size, 0f, groundLayer))
        {
            Debug.Log("Grounded");
            return true;
        }
        return false;
    }

    void OnTriggerEnter2D(Collider2D other)
    {
        if (other.tag == "Ground")
        {
            Debug.Log("Game Over");
            PlayerManager.instance.SetAlive(false);
            StartCoroutine(SecondAfterDead());
            HighestScoreManager.instance.HighestScoreUpdate();
        }
        
    }

    private IEnumerator SecondAfterDead(){
        yield return new WaitForSeconds(0.5f);
            rb.simulated = false;
    }

    private void OnDrawGizmos()
    {
        // Lấy kích thước của Collider2D
        Vector2 size = cc.bounds.size;

        // Lấy vị trí của Collider2D
        Vector3 position = cc.bounds.center;

        Gizmos.color = Color.yellow;
        // Gizmos.DrawWireSphere(groundCheck.position, 0.2f);

        // Vẽ hình vuông chỉ với các đường viền tại vị trí của Collider2D và có kích thước bằng với kích thước của Collider2D
        Gizmos.DrawWireCube(position, size);

    }
}
