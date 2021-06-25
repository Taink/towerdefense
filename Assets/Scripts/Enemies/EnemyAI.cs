using UnityEngine;
using UnityEngine.SceneManagement;
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
    private float movSpeed; //vitesse de d�placement
    [SerializeField]
    private int _killReward; //quantit� d'or donn�e � la mort
    [SerializeField]
    private int _damage; //d�gats lorsqu'il sort de la carte

    private readonly Transform _target = Enemies.Target;
    private AIDestinationSetter _destinationSetter;
    private AIPath _aiPath;

    private float slowTime;
    private float baseSpeed;

    private void Awake()
    {
        Enemies.AddEnemy(transform);
    }

    private void Start()
    {
        _destinationSetter = GetComponent<AIDestinationSetter>();
        _destinationSetter.target = _target;
        _aiPath = GetComponent<AIPath>();
        _aiPath.maxSpeed = movSpeed;
        baseSpeed = movSpeed;
        generateEnemy();
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
        Enemies.enemyKilled(transform, _killReward);
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
        if(_aiPath != null)
        {
            if (_aiPath.maxSpeed == baseSpeed)
            {
                _aiPath.maxSpeed = (float)(_aiPath.maxSpeed * 0.65);
            }
        
            slowTime = Time.time;
        }
 

    }
    public void Update()
    {
        if (Mathf.Abs(this.transform.position.x - _target.position.x) < 0.1 && Mathf.Abs(this.transform.position.y - _target.position.y) < 0.1 && Mathf.Abs(this.transform.position.z - _target.position.z) < 0.1)
        {
            LivesCounter.remainingLives -= _damage;
            Destroy(gameObject);
            Enemies.RemoveEnemy(transform);
            if (LivesCounter.remainingLives <= 0)
            {
                SceneManager.LoadScene("DefeatScene");
            }
        }
    }

    /* Update is called once per frame
     * v�rifie la position
     * d�place l'objet
     * */
    private void FixedUpdate()
    {
        // checkPos();
        // moveEnemy();
        if (Time.time - slowTime >= 2)
        {
            _aiPath.maxSpeed = baseSpeed;
        }
    }
}
