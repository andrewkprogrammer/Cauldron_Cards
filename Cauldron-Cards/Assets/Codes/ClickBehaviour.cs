using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;


public class ClickBehaviour : MonoBehaviour, IPointerClickHandler
 {
    GameObject parent;

    bool Front_Showing = false;
    float timer = 0.0f;

    Animator animator;
     public void OnPointerClick(PointerEventData eventData)
     {
        if (!Front_Showing)
        {
            animator.SetTrigger("Display");
            Front_Showing = true;
        }
        //else
        //{
        //    animator.SetTrigger("Reset");
        //    Front_Showing = false;
        //}
     }

     // Use this for initialization
     void Start()
     {
        parent = GameObject.Find("Card_Grid");
        animator = GetComponent<Animator>();
     }

     // Update is called once per frame
     void Update()
     {
        if(Front_Showing)
        {
            timer += Time.deltaTime;
            
            if(timer > 3.0f)
            {
                animator.SetTrigger("Reset");
                Front_Showing = false;
                timer = 0.0f;
            }
        }
     }
 }
