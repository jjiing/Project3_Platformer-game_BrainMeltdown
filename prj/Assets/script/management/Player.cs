using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public abstract class Player : MonoBehaviour
{

    [Header("State")]
    [SerializeField] private float speed;
    [SerializeField] private float jumpForce;
    protected bool isSit;
    protected bool isRun;
    protected bool isUp;
    protected bool isDown;
    protected bool isGrounded;
    private float stateUpDownNum;


    [Header("Landing Effect")]
    [SerializeField] ObjectPool objectPool;
    [SerializeField] Transform footPos;

    [Header("Die Effect")]
    [SerializeField] GameObject dieEffect;
    protected SpriteRenderer dieEffectSR;
    protected Animator dieEffectAnim;
    protected Dictionary<string, Color> colorDic;


    protected Rigidbody2D rigid2d;
    protected SpriteRenderer spriteRenderer;
    protected Animator animator;
    protected CapsuleCollider2D collider;
    protected CapsuleCollider2D childCollider;


    //세이브포인트
    protected GameObject currentSavePoint;
    protected Vector3 currentSavePointPos;

   
    protected int audioNum;


    

    public void Start()
    {
 
        rigid2d = GetComponent<Rigidbody2D>();
        spriteRenderer = GetComponent<SpriteRenderer>();
        animator = GetComponent<Animator>();
        collider = GetComponent<CapsuleCollider2D>();
        childCollider = transform.GetChild(0).gameObject.GetComponent<CapsuleCollider2D>();
        dieEffectAnim = dieEffect.GetComponent<Animator>();


        //state 초기화
        speed = 8;
        jumpForce = 17;
        stateUpDownNum = 1.5f;

        isSit = false;
        isRun = false;
        isUp = false;
        isDown = false;
        isGrounded = true;

        //세이브포인트
        currentSavePoint = GameObject.Find("savePoint" + GameManager.Instance.savePointNow.ToString());
        currentSavePointPos = currentSavePoint.transform.position;

        //컬러 딕셔너리 초기화 및 추가
        colorDic = new Dictionary<string, Color>();
        colorDic.Add("purple", new Color32(150, 93, 198, 255));
        colorDic.Add("yellow", new Color32(255, 192, 99, 255));



    }

    

    protected void StateUpDown()
    {
        if (rigid2d.velocity.y > stateUpDownNum) { isUp = true; isDown = false; }
        else if (rigid2d.velocity.y < -stateUpDownNum) { isUp = false; isDown = true; }
        else { isUp = false; isDown = false; }
    }

    protected void MoveAnim()
    {
         animator.SetBool("isSit", isSit);
         if (!isUp && !isDown) animator.SetBool("isRun", isRun); //점프중에는 달리는 애니메이션X
         else animator.SetBool("isRun", false);
         animator.SetBool("isUp", isUp);
         animator.SetBool("isDown", isDown);    
    }


   
    protected abstract void LandingSoundAudioSetting();

    
    protected void Move(float moveX)
    {
        //이동
        rigid2d.velocity = new Vector2(moveX * speed, rigid2d.velocity.y);
        //x축 이동은 x*speed로 y축 이동은 기존의 속력값(현재는 중력)

        //미끄러짐 방지
        if (moveX == 0) rigid2d.constraints = RigidbodyConstraints2D.FreezePositionX | RigidbodyConstraints2D.FreezeRotation;
        else rigid2d.constraints = RigidbodyConstraints2D.FreezeRotation;

        //anim 좌우방향설정
        if (moveX < 0) spriteRenderer.flipX = false;
        else if (moveX > 0) spriteRenderer.flipX = true;


        //상태 설정
        if (moveX != 0) isRun = true;
        else isRun = false;
    }
    protected void MoveSound(int audioSource)
    {
         if (isRun && !AudioManager.Instance.audioSources[audioSource].isPlaying
          && !isSit && isGrounded)
         {
             if (SceneManager.GetActiveScene().name == "stage1")
                 AudioManager.Instance.PlaySE("s1Footstep", audioSource);
             else if (SceneManager.GetActiveScene().name == "stage2")
                 AudioManager.Instance.PlaySE("s2Footstep", audioSource);

         }
    }


    protected void DieEffect()
    {

        GameObject dieEffect_=Instantiate(dieEffect, transform.position, transform.rotation);
        dieEffect_.SetActive(true);
        dieEffectSR = dieEffect_.GetComponent<SpriteRenderer>();

        DieEffectColorSetting(); //하위클래스별로 차이가 나는 부분

        gameObject.SetActive(false);
        
    }
    protected abstract void DieEffectColorSetting();

    protected void Jump(bool key)
    {
         if (key && isGrounded)
         {
             isGrounded = false;
             rigid2d.velocity = Vector2.up * jumpForce;

         }
    }
    protected void Sit(bool key)
    {
        if (key)
        {
            isSit = true;
            collider.enabled = false;
            childCollider.enabled = true;
        }
        else
        {
            isSit = false;
            collider.enabled = true;
            childCollider.enabled = false;
        }
    }



    protected void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.tag == "Obstacle")
        {
            GameManager.Instance.isDead = true;
            GameManager.Instance.GameOver();
            DieEffect();

        }
        else if (collision.gameObject.tag == "Ground")
        {
            isGrounded = true;
            LandingEffect();
        }
    }
    private void LandingEffect()
    {
        GameObject landingEffect = objectPool.UsePrefab();
        landingEffect.transform.position = footPos.position;
        StartCoroutine(GetBackPrefabCo(landingEffect));
        LandingSoundAudioSetting();
        PlayLandingSound(audioNum);
    }





    private void PlayLandingSound(int audioSource)
    {
        if (SceneManager.GetActiveScene().name == "stage1")
            AudioManager.Instance.PlaySE("s1Landing", audioSource);
        else if (SceneManager.GetActiveScene().name == "stage2")
            AudioManager.Instance.PlaySE("s2Landing", audioSource);
    }



    private void OnCollisionExit2D(Collision2D collision)
    {
        if (collision.gameObject.tag == "Ground")
        {
            isGrounded = false;
        }
    }
    IEnumerator GetBackPrefabCo(GameObject gameObject)
    {
        yield return new WaitForSeconds(0.6f);
        objectPool.GetBackPrefab(gameObject);
    }
   




}
