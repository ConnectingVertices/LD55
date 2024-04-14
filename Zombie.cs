using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Zombie : MonoBehaviour
{
    public float moveSpeed = 3f;
    private Rigidbody rb;
    private Collider lastCollision;
    private bool isColliding = false;
    private float collisionCheckDelay = 0.5f;
    private Vector3 lastPosition;
    private float timer;
    public AudioSource deathSound;
    private SkinnedMeshRenderer zombieRenderer;
    private Collider zombieCollider;

    [SerializeField] SpaenManager spaenManager;

    void Start()
    {
        rb = GetComponent<Rigidbody>();
        timer = 3f;
        lastPosition = transform.position;
        zombieRenderer = GetComponentInChildren<SkinnedMeshRenderer>();
        zombieCollider = GetComponent<Collider>();
        TurnRandomDirection();
    }

    void Update()
    {
        timer -= Time.deltaTime;

        if (timer <= 0f)
        {
            float distanceMoved = Vector3.Distance(transform.position, lastPosition);

            if (distanceMoved <= 1f)
            {
                RespawnMe();
            }

            timer = 3f;
            lastPosition = transform.position;
        }

        rb.velocity = transform.forward * moveSpeed;
        if (isColliding && Time.time >= collisionCheckDelay)
        {
            TurnRandomDirection();
        }
    }

    void OnCollisionEnter(Collision collision)
    {
        if (collision.collider != lastCollision)
        {
            lastCollision = collision.collider;

            if (collision.gameObject.CompareTag("Player"))
            {
                if (deathSound != null)
                {
                    deathSound.Play();
                }

                RespawnMe();
            }
            else
            {
                isColliding = true;
                collisionCheckDelay = Time.time + 0.5f;
            }
        }
    }

    public void RespawnMe()
    {
        StartCoroutine(HideAndReappear());
    }

    private IEnumerator HideAndReappear()
    {
        zombieRenderer.enabled = false;
        zombieCollider.enabled = false;

        yield return new WaitForSeconds(2f);

        transform.position = spaenManager.GetRandomPosition();
        TurnRandomDirection();

        zombieRenderer.enabled = true;
        zombieCollider.enabled = true;

    }


    void OnCollisionExit(Collision collision)
    {
        isColliding = false;
    }

    void TurnRandomDirection()
    {
        float randomAngle = Random.Range(0f, 360f);
        transform.Rotate(0f, randomAngle, 0f);
    }
}
