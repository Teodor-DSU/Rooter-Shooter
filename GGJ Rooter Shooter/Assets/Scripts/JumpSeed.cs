using Cinemachine;
using UnityEngine;
using UnityEngine.Events;

public class JumpSeed : MonoBehaviour
{
    [SerializeField] private UnityEvent loseGame;
    private static int EnemiesLayer = 7;
    
    public Transform PlayerPrefab;
    
    [SerializeField]
    private Vector2 Limits = new Vector2(5.0f, 10.0f);
    private Vector3 direction;
    private float power;

    private bool hasSpawned = false;

    private void Start()
    {

    }

    // Update is called once per frame
    void FixedUpdate()
    {
        transform.position += power * Time.fixedDeltaTime * direction;
    }

    private void Update()
    {
        if (power > 0)
        {
            power -= Time.deltaTime;
        }
        else
        {
            loseGame.Invoke();
        }
    }

    public void SetDirection(Vector3 dir, float pow)
    {
        direction = dir;
        power = Mathf.Clamp(pow, Limits.x, Limits.y);
    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.TryGetComponent(out Enemy enemyScript))
        {
            if (enemyScript.controllable && !hasSpawned)
            {
                Destroy(gameObject);
                PlayerPrefab = enemyScript.playerToSpawn;
                Destroy(collision.gameObject);
        
                Transform player = Instantiate(PlayerPrefab, transform.position, Quaternion.Euler(0.0f, 0.0f, 0.0f));
                PlayerController.ActivePlayer = player;
                hasSpawned = true;
                
                CinemachineVirtualCamera cinemachine = Camera.main.GetComponentInChildren<CinemachineVirtualCamera>();
                cinemachine.Follow = player;
                
                //TODO(Vasilis): Start rooting animation
                
                foreach (Transform enemy in MoveTowardsPlayer.Enemies)
                {
                    MoveTowardsPlayer chase = enemy.GetComponent<MoveTowardsPlayer>();
                    chase.ChangeChaseTarget(player);
                }
            }
        }
    }
}
