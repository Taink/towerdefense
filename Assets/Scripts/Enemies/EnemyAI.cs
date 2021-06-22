using UnityEngine;
using Pathfinding;

public class EnemyAI : MonoBehaviour
{
    [SerializeField]
    private float health; //vie de l'ennemi
    public HealthBar healthbar; // barre de vie de l'ennemi

    [SerializeField]
    private float armor; //resistance physique
    [SerializeField]
    private float magicRes;//resistance magique
    //resistances : 0 = 0% | 1 = 15% | 2 = 35% | 3 = 60%
    // -> pourquoi ne pas le stocker sous une forme de pourcentage au lieu de passer via des nombres?
    //    qqch comme 0.6 pour 60% de r�sistance magique
    [SerializeField]  
    private float movSpeed = 200f; //vitesse de d�placement
    private int _killReward; //quantit� d'or donn�e � la mort
    private int _damage; //d�gats lorsqu'il sort de la carte

    private readonly Transform _target = Enemies.target;
    private Path _path;
    private int _currentWayPoint = 0;
    private float _nextWaypointDistance;
    private bool _reachedEndOfPath = false;
    private Seeker _seeker;
    private Rigidbody2D _rb;

    private float slowTime;
    private float baseSpeed;

    private void Awake()
    {
        Enemies.AddEnemy(transform);
    }

    private void Start()
    {
        _seeker = GetComponent<Seeker>();
        _rb = GetComponent<Rigidbody2D>();

        _seeker.StartPath(_rb.position, _target.position, OnPathComplete);
        generateEnemy();
        baseSpeed = movSpeed;
    }

    private void OnPathComplete(Path p)
    {
        if (!p.error)
        {
            _path = p;
            _currentWayPoint = 0;
        }
    }

    //M�thode de g�n�ration : d�fini la premi�re case comme la StartTile, d�finie dans MapGenerator
    private void generateEnemy()
    {
        healthbar.SetMaxHealth((int)health);
    }

    public void takeDamage(float dmg, int dmgType)
    {
        if (dmgType == 0)
        {
            dmg = armor switch
            {
                1 => (float) (dmg * 0.85),
                2 => (float) (dmg * 0.65),
                3 => (float) (dmg * 0.4),
                _ => dmg
            };
        }
        else if (dmgType == 1)
        {
            dmg = magicRes switch
            {
                1 => (float) (dmg * 0.85),
                2 => (float) (dmg * 0.65),
                3 => (float) (dmg * 0.4),
                _ => dmg
            };
        }
        health -= dmg;
        healthbar.SetHealth((int) health);

        if(health <= 0)
        {
            die();
        }
    }

    private void die()
    {
        Enemies.RemoveEnemy(transform);
        Destroy(gameObject);
    }

    //D�place l'objet vers la case d�finie comme "objectif" (target)
    private void moveEnemy()
    {
        if (_target)
        {
            this.transform.position = Vector3.MoveTowards(transform.position, _target.position, movSpeed * Time.deltaTime);
            if (this.transform.position.Equals(MapGenerator.getEndCoords()))
            {
                LivesCounter.remainingLives -= _damage;
                die();
            }
        }
    }

    public void slow()
    {
        if (movSpeed == baseSpeed)
        {
            movSpeed = (float)(movSpeed * 0.6);
        }
        
        slowTime = Time.time;

    }

    /* Update is called once per frame
     * v�rifie la position
     * d�place l'objet
     * */
    private void FixedUpdate()
    {
        if (_path == null) return;

        _reachedEndOfPath = _currentWayPoint >= _path.vectorPath.Count;
        if (_reachedEndOfPath) return;

        Vector2 direction = ((Vector2) _path.vectorPath[_currentWayPoint] - _rb.position).normalized;
        Vector2 force = direction * baseSpeed * Time.deltaTime;

        float distance = Vector2.Distance(_rb.position, _path.vectorPath[_currentWayPoint]);
        if (distance < _nextWaypointDistance)
        
        // checkPos();
        moveEnemy();
        if (Time.time - slowTime >= 3)
        {
            movSpeed = baseSpeed;
        }
    }
}
