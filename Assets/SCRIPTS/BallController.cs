using System.Collections;
using System.Collections.Generic;
using System.Runtime.CompilerServices;
using UnityEngine;

public class BallController : MonoBehaviour

{
    public float ballVelocity = 10f;
    public float velocityMulty = 1f;
    public Game_Manager gameManager;
    AudioClip _audioClip;
    AudioSource _audioSource;
    Rigidbody2D _rb;
    float _lastHorizontalDirection = 1f;
    public float timeAlive = 0f;

    void Start()
    {
        _rb = GetComponent<Rigidbody2D>();
        _audioSource = GetComponent<AudioSource>();
        LaunchBall(0);
    }
    private void Update()
    {
        if (timeAlive > 2f && velocityMulty < 2.5f)
        {
            velocityMulty += 0.25f;
            ballVelocity *= velocityMulty;
            timeAlive = 0f;
        }
        else
        {
            timeAlive += Time.deltaTime;
        }

    }
    void FixedUpdate()
    {
        if (_rb.velocity.magnitude > ballVelocity)
        {
            _rb.velocity = _rb.velocity.normalized * ballVelocity;
        }

        if (Mathf.Abs(_rb.velocity.x) >= ballVelocity * 0.3f)
        {
            _lastHorizontalDirection = Mathf.Sign(_rb.velocity.x);
        }
        else
        {
            float yDirection = Mathf.Sign(_rb.velocity.y);

            if (yDirection == 0f)
            {
                yDirection = 1f;
            }

            float minX = 0.3f;
            float y = Mathf.Sqrt(1f - minX * minX);

            _rb.velocity = new Vector2(
                _lastHorizontalDirection * minX,
                yDirection * y
            ) * ballVelocity;
        }
    }

    void LaunchBall(int dir)
    {
        velocityMulty = 1f;
        timeAlive = 0f;
        ballVelocity = 10f;
        this.transform.position = Vector2.zero;
        if (dir == 0)
        {
            _lastHorizontalDirection = Random.value > 0.5f ? 1f : -1f;
        }
        else
        {
            _lastHorizontalDirection = dir;
        }

        float yVelocity = Random.Range(-0.7f, 0.7f);

        _rb.velocity = new Vector2(
            _lastHorizontalDirection,
            yVelocity
        ).normalized * ballVelocity;
    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.CompareTag("wall_R"))
        {
            gameManager.p1++;
            _audioSource.Play();
            LaunchBall(-1);
        }
        if (collision.gameObject.CompareTag("wall_L"))
        {
            gameManager.p2++;
            _audioSource.Play();
            LaunchBall(1);
        }
        if (collision.gameObject.CompareTag("wall_R") || collision.gameObject.CompareTag("wall_L"))
        {
            _rb.transform.position = new Vector3(0, 0, 0);
        }
        _audioSource.Play();
        _audioSource.pitch = Random.Range(0.8f, 1.2f);

        gameManager.UpdatePointsText();

    }
}