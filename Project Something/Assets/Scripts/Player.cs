using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player : MonoBehaviour {
    public Rigidbody2D body;
    public AudioSource audioSource;
    public PointEffector2D pointEffector;
    public SpriteRenderer roleMarker;

    public AudioClip Blop;
    public AudioClip BaDing;
    public AudioClip KraDing;

    public Sprite HappyRoleMarker;
    public Sprite SadRoleMarker;

    public float HappyAcceleration;
    public float SadAcceleration;
    public float MaxSpeed;

    public KeyCode Up;
    public KeyCode Down;
    public KeyCode Left;
    public KeyCode Right;

    public int points;

    public static Player HappyRole;
    static bool RoleSwiched;

    float pointEffectorTimer;
    float speedyTimer;

    // Use this for initialization
    void Start () {
	}
	
	// Update is called once per frame
	void Update () {
        RoleSwiched = false;

        Vector2 movement = Vector2.zero;

        if (Input.GetKey(Up))
            movement.y += 1;
        if (Input.GetKey(Down))
            movement.y -= 1;
        if (Input.GetKey(Right))
            movement.x += 1;
        if (Input.GetKey(Left))
            movement.x -= 1;

        float acceleration = ((HappyRole == this) ? HappyAcceleration : SadAcceleration) * ((speedyTimer > 0) ? 5 : 1);
        body.velocity = Vector2.MoveTowards(body.velocity, movement.normalized * MaxSpeed, Time.deltaTime * acceleration);
        if (body.velocity.magnitude > 3 * MaxSpeed)
            body.velocity = body.velocity.normalized * MaxSpeed * 3;

        transform.rotation = Quaternion.Euler(body.velocity.y, -body.velocity.x, 0) * transform.rotation;

        Rect gameZone = GameMasta.TheMasta.gameZone;
        if (!gameZone.Contains(transform.position))
        {
            transform.position -= (Vector3)gameZone.position - new Vector3(.5f, .5f);
            transform.position = new Vector3(
                Mathf.Repeat(transform.position.x, gameZone.width + 1), 
                Mathf.Repeat(transform.position.y, gameZone.height + 1)
            );
            transform.position += (Vector3)gameZone.position - new Vector3(.5f, .5f);
        }

        pointEffectorTimer -= Time.deltaTime;
        if (pointEffectorTimer < 0)
        {
            pointEffector.enabled = false;
        }

        speedyTimer -= Time.deltaTime;

        roleMarker.sprite = (HappyRole == this) ? HappyRoleMarker : SadRoleMarker;
        roleMarker.transform.position = transform.position + new Vector3(0, 0, -3);
        roleMarker.transform.rotation = Quaternion.identity;
    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        Player other = collision.gameObject.GetComponent<Player>();
        if (other && HappyRole == other && !RoleSwiched)
        {
            HappyRole = this;
            RoleSwiched = true;
            audioSource.PlayOneShot(Blop);
        }
    }

    public void GivePoint(int amount, PointPickup.Type type)
    {
        points += (HappyRole == this) ? amount : -amount;

        if (HappyRole == this)
        {
            audioSource.PlayOneShot(BaDing);
        }
        else
        {
            audioSource.PlayOneShot(KraDing);
        }

        switch (type)
        {
            case PointPickup.Type.normal:
                break;
            case PointPickup.Type.detract:
                pointEffector.enabled = true;
                pointEffector.forceMagnitude = 5;
                pointEffectorTimer = 10;
                break;
            case PointPickup.Type.attract:
                pointEffector.enabled = true;
                pointEffector.forceMagnitude = -10;
                pointEffectorTimer = 10;
                break;
            case PointPickup.Type.speedy:
                speedyTimer = 5;
                break;
            default:
                break;
        }
    }
}
