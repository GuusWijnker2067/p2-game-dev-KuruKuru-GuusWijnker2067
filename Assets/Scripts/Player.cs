using TMPro;
using UnityEngine;

public class Player : MonoBehaviour
{
    private Rigidbody2D m_Rigidbody;

    private Vector2 input;

    [SerializeField] private float speed;
    [SerializeField] private float rotationSpeed;

    [SerializeField] private int LifeCount;

    TextMeshProUGUI lifeCounter;

    void Start()
    {
        m_Rigidbody = GetComponent<Rigidbody2D>();
        lifeCounter = GameObject.Find("lifeCounter").GetComponent<TextMeshProUGUI>();
        UpdateLifeCounter();
    }

    private void Update()
    {
        input = new Vector2(Input.GetAxis("Horizontal") * speed, Input.GetAxis("Vertical") * speed);

        if (input == Vector2.zero)
        {
            m_Rigidbody.linearDamping = 1000f;
        }
        else
        {
            m_Rigidbody.linearDamping = 1f;
        }
    }

    private void FixedUpdate()
    {
        m_Rigidbody.rotation += rotationSpeed;

        m_Rigidbody.linearVelocity = input;
    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        LifeCount -= 1;
        m_Rigidbody.rotation -= rotationSpeed * 20;
        Vector3 point = collision.contacts[0].point;

        transform.position = (transform.position - point) + transform.position;
        
        //transform.position -= new Vector3(input.x * 0.1f, input.y * 0.1f, 0);

        if (LifeCount < 1)
        {
            Debug.Log("Game Over");
            transform.position = Vector3.zero;
            LifeCount = 3;
        }
        UpdateLifeCounter();
    }

    private void UpdateLifeCounter()
    {
        lifeCounter.text = "Lives: " + LifeCount;
    }
}
