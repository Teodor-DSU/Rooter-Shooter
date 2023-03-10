using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

public class PlayerController : MonoBehaviour
{
    [SerializeField] private UnityEvent LoadEndScene;
    [SerializeField] private IntVariableSO enemiesKilled;
    [SerializeField] private VoidEventChannelSO PlayerJumped;
    [SerializeField] private VoidEventChannelSO GotNewHost;
    [SerializeField] private VoidEventChannelSO StartedDying;
    [SerializeField] private FloatEventChannelSO LostBlood;
    [SerializeField] private float speed = 5f;
    [SerializeField] private bool explodesOnDeath = false;
    [SerializeField] private GameObject explosion;
    [SerializeField] private GameObject bloodSplatter;
    public float maxBloodTank = 100;
    [HideInInspector] public float currentBlood;
    [SerializeField] private float reverseBloodLossRate = 0.5f;
    [SerializeField] private float fadeAwayTime = 3f;
    [SerializeField] private float outOfBloodLastChanceTime = 5f;
    [SerializeField] private Color lastChanceColor = Color.red;

    private SpriteRenderer sr;
    private ShootSource ss;
    public static Transform ActivePlayer = null;
    private bool isQuitting = false;

    private void Awake()
    {
        if (!ActivePlayer)
            ActivePlayer = transform;
    }

    private void Start()
    {
        sr = GetComponent<SpriteRenderer>();
        ss = GetComponentInChildren<ShootSource>();
        currentBlood = maxBloodTank;
        StartCoroutine(BleedOut());
        GotNewHost.RaiseEvent();
    }

    private void OnEnable()
    {
        PlayerJumped.OnEventRaised += TurnOff;
        LostBlood.OnEventRaised += LoseBlood;
    }

    private void OnDisable()
    {
        PlayerJumped.OnEventRaised -= TurnOff;
        LostBlood.OnEventRaised -= LoseBlood;
    }

    private void OnApplicationQuit()
    {
        isQuitting = true;
    }

    private void OnDestroy()
    {
        if (!isQuitting)
        {
            Instantiate(bloodSplatter, transform.position, transform.rotation);
            if (explodesOnDeath)
            {
                Instantiate(explosion, transform.position, transform.rotation);
            }
        }
    }

    private void TurnOff()
    {
        gameObject.tag = "Untagged";
        StartCoroutine(FadeAway());
        enabled = false;
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
        enemiesKilled.Value++;
        Destroy(gameObject);
    }

    private void LoseBlood(float value)
    {
        currentBlood -= value;
    }
    
    private IEnumerator BleedOut()
    {
        while (currentBlood > 0f)
        {
            yield return new WaitForSeconds(reverseBloodLossRate);
            currentBlood--;
        }

        StartCoroutine(SlowlyDying());
    }

    private IEnumerator SlowlyDying()
    {
        StartedDying.RaiseEvent();
        ss.enabled = false;
        sr.color = lastChanceColor;
        yield return new WaitForSeconds(outOfBloodLastChanceTime);
        Debug.Log("You loose");
        LoadEndScene.Invoke();
    }
}
