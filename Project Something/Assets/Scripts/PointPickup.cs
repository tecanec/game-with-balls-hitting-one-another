using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PointPickup : MonoBehaviour {
    public SpriteRenderer sprite;
    public Rigidbody2D body;
    public CircleCollider2D collider;

    public float normalChance;

    public Sprite normalSprite;
    public Sprite detractorSprite;
    public Sprite attractorSprite;
    public Sprite speedySprite;

    public enum Type { normal, detract, attract, speedy };
    Type currentType;

    private void Start()
    {
        RandomLocation();

        if (body == null)
            body = GetComponent<Rigidbody2D>();
    }

    private void Update()
    {
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

        body.velocity *= 1 - Time.deltaTime;
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        Player target = collision.gameObject.GetComponent<Player>();
        if (target)
        {
            target.GivePoint(1, currentType);
            RandomLocation();
        }
    }

    void RandomLocation()
    {
        Rect spawnZone = GameMasta.TheMasta.gameZone;
        transform.position = spawnZone.position + new Vector2(Random.value * spawnZone.width, Random.value * spawnZone.height);
        body.velocity = Vector2.zero;

        currentType = (Random.value <= normalChance) ? Type.normal : (Type)Random.Range(1, 4);
        sprite.sprite =
            (currentType == Type.normal) ? normalSprite :
            (currentType == Type.detract) ? detractorSprite :
            (currentType == Type.attract) ? attractorSprite :
            speedySprite;
        collider.radius = (currentType == Type.normal) ? 0.1f : 0.2f;
    }
}
