using UnityEngine;
using System.Collections;

public class junkai : MonoBehaviour
{
    public GameObject smoke;
    public GameObject bon;
    int HP;
    public float speed = 10f;
    private float rotationsmooth = 1f;
    private Vector3 targetposition;
    private float changetargetsqrdistance = 40f;
    GameObject sensya;
    public Transform turret;
    public Transform muzzle;
    public GameObject bulletPrefab;
    public GameObject exprolen;
    private Transform player;
    private float attackInterval = 5f;
    private float turretRotationSmooth = 1;
    public float lastAttackTime;
    public Transform sensyaobject; // 追いかける対象
    public float rotMax; // 回転速度
    public float speedf = 1;
    AudioSource audiosource;
    // Use this for initialization
    private void Start()
    {
        HP = 4;
        targetposition = GetRandomPositionOnLevel();
        sensya = GameObject.FindWithTag("Player");
        player = GameObject.FindWithTag("Player").transform;
        audiosource = gameObject.GetComponent<AudioSource>();
    }

    // Update is called once per frame
    private void Update()
    {
        lastAttackTime += Time.deltaTime;
        float sqrdistancetotarget = Vector3.SqrMagnitude(transform.position - targetposition);
        if (sqrdistancetotarget < changetargetsqrdistance)
        {
            targetposition = GetRandomPositionOnLevel();
        }
       /* Quaternion targetRotation = Quaternion.LookRotation(targetposition - transform.position);
        transform.rotation = Quaternion.Slerp(transform.rotation, targetRotation, Time.deltaTime * rotationsmooth);*/
        transform.Translate(Vector3.forward * speed * Time.deltaTime);
        Quaternion playerRotation = Quaternion.LookRotation(player.position - turret.position);
        turret.rotation = Quaternion.Slerp(turret.rotation, playerRotation, Time.deltaTime * turretRotationSmooth);

        if (Vector3.Distance(sensya.transform.position, transform.position) <= 150 && Vector3.Distance(sensya.transform.position, transform.position) >= 11)
        {


            Vector3 vec = sensyaobject.position - transform.position;
            transform.rotation = Quaternion.Slerp(transform.rotation, Quaternion.LookRotation(new Vector3(vec.x, 0, vec.z)), rotMax);
            transform.Translate(Vector3.forward * speedf);
            if (Time.time > lastAttackTime + attackInterval)
            {
                Debug.Log("bullet of enemy");
                audiosource.PlayOneShot(audiosource.clip);
                Instantiate(bulletPrefab, muzzle.position, muzzle.rotation);
                Instantiate(exprolen, transform.position, transform.rotation);
                lastAttackTime = Time.time;
            }
            // 一定間隔で弾丸を発射する
        }else if (Vector3.Distance(sensya.transform.position, transform.position) >= 151 || Vector3.Distance(sensya.transform.position, transform.position) <= 10)
            {
                speedf = 0f;
            }
        
        if (HP <= 2 && HP >= 1)
        {
            Instantiate(smoke,transform.position,transform.rotation);
        }
    }

    public Vector3 GetRandomPositionOnLevel()
    {
        float levelsize = 55f;
        return new Vector3(Random.Range(-levelsize, levelsize), 0, Random.Range(-levelsize, levelsize));
    }
   
    
    void OnCollisionEnter(Collision collider)
    {
        if (collider.gameObject.tag == "shot")
        {
            Debug.Log(HP);
            HP = HP - 1;
            if (HP <= 0)
            {
                Debug.Log(HP);
                Destroy(gameObject);
                Instantiate(bon, transform.position, transform.rotation);
                stage.enemy++;
            }
        }
    }
}
