using UnityEngine;

public class PlayerController : MonoBehaviour
{

    [SerializeField] float torqueAmount = 4f;
    [SerializeField] private float boostSpeed = 30f;
    [SerializeField] private float defaultSpeed = 20f;
    
    Rigidbody2D barryRigidbody2D;
    private SurfaceEffector2D surfaceEffector2D;
    private bool canMove = true;
    
    // Start is called before the first frame update
    void Start()
    {
        barryRigidbody2D = GetComponent<Rigidbody2D>();
        surfaceEffector2D = FindObjectOfType<SurfaceEffector2D>();
    }

    // Update is called once per frame
    void Update()
    {
        if (canMove)
        {
            RotatePlayer();
            BoostPlayer();    
        }
    }

    public void DisableControls()
    {
        canMove = false;
    }
    
    public void EnableControls()
    {
        canMove = true;
    }

    private void BoostPlayer()
    {
        if (Input.GetKey(KeyCode.Space))
        {
            surfaceEffector2D.speed = boostSpeed;
        }
        else
        {
            surfaceEffector2D.speed = defaultSpeed;
        }
    }

    void RotatePlayer()
    {
        if (Input.GetKey(KeyCode.LeftArrow))
        {
            barryRigidbody2D.AddTorque(torqueAmount);
        } else if (Input.GetKey(KeyCode.RightArrow))
        {
            barryRigidbody2D.AddTorque(-torqueAmount);
        }
    }
}
