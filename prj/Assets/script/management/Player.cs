using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public abstract class Player : MonoBehaviour
{
    

    [Header("State")]
    protected float speed;
    protected float jumpForce;
    public bool isSit;
    public bool isRun;
    public bool isUp;
    public bool isDown;
    public bool isGrounded;

    [Header("Landing Effect")]
    public ObjectPool objectPool;
    public Transform footPos;

    [Header("Die Effect")]
    public GameObject dieEffect;
    protected SpriteRenderer dieEffectSR;
    protected Animator dieEffectAnim;
    protected Dictionary<string, Color> colorDic;


    protected Rigidbody2D rigid2d;
    protected SpriteRenderer spriteRenderer;
    protected Animator animator;
    protected CapsuleCollider2D collider;
    protected CapsuleCollider2D childCollider;

    //���̺�����Ʈ
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


        //state �ʱ�ȭ
        speed = 8;
        jumpForce = 17;

        isSit = false;
        isRun = false;
        isUp = false;
        isDown = false;
        isGrounded = true;

        //���̺�����Ʈ
        currentSavePoint = GameObject.Find("savePoint" + GameManager.Instance.savePointNow.ToString());
        currentSavePointPos = currentSavePoint.transform.position;

        //�÷� ��ųʸ� �ʱ�ȭ �� �߰�
        colorDic = new Dictionary<string, Color>();
        colorDic.Add("purple", new Color32(150, 93, 198, 255));
        colorDic.Add("yellow", new Color32(255, 192, 99, 255));



    }

    

    protected void StateUpDown()
    {
        if (rigid2d.velocity.y > 1.5) { isUp = true; isDown = false; }
        else if (rigid2d.velocity.y < -1.5) { isUp = false; isDown = true; }
        else { isUp = false; isDown = false; }
    }

    protected void MoveAnim()
    {
         animator.SetBool("isSit", isSit);
         if (!isUp && !isDown) animator.SetBool("isRun", isRun); //�����߿��� �޸��� �ִϸ��̼�X
         else animator.SetBool("isRun", false);
         animator.SetBool("isUp", isUp);
         animator.SetBool("isDown", isDown);    
    }


    protected abstract void DieEffectColorSetting();
    protected abstract void LandingSoundAudioSetting();

    
    protected void Move(float moveX)
    {
        //�̵�
        rigid2d.velocity = new Vector2(moveX * speed, rigid2d.velocity.y);
        //x�� �̵��� x*speed�� y�� �̵��� ������ �ӷ°�(����� �߷�)

        //�̲����� ����
        if (moveX == 0) rigid2d.constraints = RigidbodyConstraints2D.FreezePositionX | RigidbodyConstraints2D.FreezeRotation;
        else rigid2d.constraints = RigidbodyConstraints2D.FreezeRotation;

        //anim �¿���⼳��
        if (moveX < 0) spriteRenderer.flipX = false;
        else if (moveX > 0) spriteRenderer.flipX = true;


        //���� ����
        if (moveX != 0) isRun = true;
        else isRun = false;
    }
    protected void MoveSound(int audioSource)
    {
         if (isRun && !AudioManager.Instance.audioSources[audioSource].isPlaying
          && !isSit)
         {
             if (SceneManager.GetActiveScene().name == "stage1")
                 AudioManager.Instance.PlaySE("s1Footstep", audioSource);
             else if (SceneManager.GetActiveScene().name == "stage2")
                 AudioManager.Instance.PlaySE("s2Footstep", audioSource);

         }
    }


    protected void DieEffect()
    {

        var dieEffect_=Instantiate(dieEffect, transform.position, transform.rotation);
        dieEffect_.SetActive(true);
        dieEffectSR = dieEffect_.GetComponent<SpriteRenderer>();
        DieEffectColorSetting();
        gameObject.SetActive(false);
        
    }

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
