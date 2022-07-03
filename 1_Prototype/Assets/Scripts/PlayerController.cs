using System.Collections;
using System.Collections.Generic;
using UnityEngine;



public class PlayerController : MonoBehaviour
{
    [SerializeField] Rigidbody rb;
    [SerializeField] GameObject boy;
    public float maxDegreesDelta = 0.2f;
    public float jump = 1.0f;
    public float speed = 0.2f;
    public float xSpeed = 0.2f;
    public int targetIndex;
    public PathObject pathObject;
    public Animator animator;
    public Animator skateAnimator;
    public Vector3 target;
    public Vector3 offset;
    bool left;
    bool right;


    void Start()
    {
        target = pathObject.points[targetIndex]; //pathobject scriptindeki noktalar hedeflendi 
    }

    void Update()
    {

        //Vector3 goRight = Vector3.forward * 0.8f + Vector3.up * 1.1f; //sa�a git  //oldu
        //Vector3 goLeft = Vector3.forward*-1 * 0.8f + Vector3.up * 1.1f;   //sola git //oldu




        if (Input.touchCount > 0) //ekranda birden fazla dokunma varsa
        {
            Touch finger = Input.GetTouch(0); //dokundu�umuz parma��n konumu,0 burada 1 parmak dokunu�unu ifade ediyor

            Vector3 boyPos = boy.transform.localPosition + finger.deltaPosition.x * Vector3.right*Time.deltaTime*xSpeed;  //new
            boyPos.x = Mathf.Clamp(boyPos.x, -0.8f, 0.8f);
            boy.transform.localPosition = boyPos;



            if (finger.deltaPosition.y > 50.0f) //yukar� do�ru 50 piksellik dokunma olursa, &&isOnGround
            {
                rb.velocity = Vector3.zero;    //eskiden kalan g��ler eklenmesin diye g�c�m�z� s�f�rlad�k 
                rb.velocity = Vector3.up * jump;   //yukar� do�ru g�� uygula
                animator.SetTrigger("JumpAnimation");
                skateAnimator.SetTrigger("jump");



            }



            //if (right) //sa� true ise,true yazmaya gerek yok true olarak alg�lar, sa�a git
            //{
            //    offset = goRight;
            //}

            //if (left) //sol true ise sola git
            //{
            //   offset = goLeft;
            // }

        }

        if (Vector3.Distance(transform.position, target + offset) > 0.01f)
        {
            //hedefe yak�n de�ilken 
            transform.position = Vector3.MoveTowards(transform.position, target + offset, speed);

        }
        else if (targetIndex < pathObject.points.Count - 1)
        {
            //hedefe yak�nken
            targetIndex++;
            target = pathObject.points[targetIndex];

        }

        //LookRotation(target+offset);
        Vector3 lookTarget = (target - transform.position + offset);
        //lookTarget.y = transform.position.y;
        transform.forward = Vector3.MoveTowards(transform.forward, lookTarget, maxDegreesDelta);
        transform.rotation = Quaternion.Euler(0, transform.eulerAngles.y, 0);

    }

    void LookRotation(Vector3 lookTarget)
    {
        var lookRotation = Quaternion.LookRotation(new Vector3(lookTarget.x, transform.position.y, lookTarget.z) - transform.position);
        transform.rotation = Quaternion.RotateTowards(transform.rotation, lookRotation, maxDegreesDelta);

    }













}

