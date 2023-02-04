using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController : MonoBehaviour
{
    [SerializeField] private VoidEventChannelSO PlayerJumped;
    [SerializeField] private bool explodesOnDeath = false;
    [SerializeField] private GameObject explosion;

    [SerializeField] private float speed = 5f;
    [SerializeField] private float fadeAwayTime = 3f;

    public static Transform ActivePlayer = null;

    private void Awake()
    {
        if (!ActivePlayer)
            ActivePlayer = transform;
    }

    // Start is called before the first frame update
    void Start()
    {
        
    }

    private void OnEnable()
    {
        PlayerJumped.OnEventRaised += TurnOff;
    }

    private void OnDisable()
    {
        PlayerJumped.OnEventRaised -= TurnOff;
    }

    private void OnDestroy()
    {
        if (explodesOnDeath)
        {
            Instantiate(explosion, transform.position, transform.rotation);
        }
    }

    private void TurnOff()
    {
        this.enabled = false;
        StartCoroutine(FadeAway());
    }

    // Update is called once per frame
    void FixedUpdate()
    {
        float inputX = Input.GetAxis("Horizontal");
        float inputY = Input.GetAxis("Vertical");
        
        transform.Translate(new Vector3(inputX, inputY, 0) * (speed * Time.fixedDeltaTime), Space.World);
        //Rigidbody2D rigidbody2D = transform.GetComponent<Rigidbody2D>();
        //rigidbody2D.position += new Vector2(inputX, inputY) * (speed )
    }

    private IEnumerator FadeAway()
    {
        yield return new WaitForSeconds(fadeAwayTime);
        Destroy(gameObject);
    }
}
