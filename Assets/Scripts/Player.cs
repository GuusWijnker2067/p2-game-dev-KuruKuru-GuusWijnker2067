using UnityEngine;

public class Player : MonoBehaviour
{
    private Rigidbody2D m_Rigidbody;

    void Start()
    {
        m_Rigidbody = GetComponent<Rigidbody2D>();
    }

    private void FixedUpdate()
    {
        if (Input.GetAxis("Horizontal") > 0)
        {
            m_Rigidbody.AddForce(new Vector2(10, 0));
        }
        else if (Input.GetAxis("Horizontal") < 0)
        {
            m_Rigidbody.AddForce(new Vector2(-10, 0));
        }
        //else
        //{
        //    m_Rigidbody.AddForce(new Vector2(0, 0));
        //}

        if (Input.GetAxis("Vertical") > 0)
        {
            m_Rigidbody.AddForce(new Vector2(0, 10));
        }
        else if (Input.GetAxis("Vertical") < 0)
        {
            m_Rigidbody.AddForce(new Vector2(0, -10));
        }
        //else
        //{
        //    m_Rigidbody.AddForce(new Vector2(0, 0));
        //}

        m_Rigidbody.rotation += 5f;
    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        transform.position = Vector3.zero;
        Debug.Log("We hebben iets geraakt");
    }
}
