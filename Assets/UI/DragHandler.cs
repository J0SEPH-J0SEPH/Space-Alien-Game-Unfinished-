using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;
using UnityEngine.UI;
public class DragHandler : MonoBehaviour,IBeginDragHandler,IDragHandler,IEndDragHandler{

    public Transform Selecter;
    public GameObject ItembeingDraged;
    public Vector3 startposition;
    public Vector3 OldPose;
    public Transform Parnt;
    public Transform OldParnt;
    public Transform Child;
    public Text tr;
    public Item ITM;
    public int Itemamount;
    public DragHandler OtherHandler;
    public GameObject Col;

    public void OnBeginDrag(PointerEventData eventData)
    {
        Parnt = transform.parent;
        OldParnt = transform.parent;
        OldPose = transform.position;
        startposition = transform.position;

        Getsome();
    }

    public void OnDrag(PointerEventData eventData)
    {
        transform.position = Input.mousePosition;
        transform.SetParent(Selecter);
    }

    public void OnEndDrag(PointerEventData eventData)
    {
        if (Child != null)
        {
            if (OtherHandler.ITM.ID == ITM.ID)
            {
                Debug.Log("Dead");
                OtherHandler.Itemamount += Itemamount;
                OtherHandler.Getsome();
                OldParnt.GetComponent<slotholder>().Checkslot(0);
                Child = null;
                Destroy(gameObject);
            }
            else
            {
                Child.SetParent(OldParnt);
                Child.position = OldPose;
                OldParnt.GetComponent<slotholder>().Checkslot(OtherHandler.ITM.ID);
            }
        }
        else
        {
            OldParnt.GetComponent<slotholder>().Checkslot(0);
        }
        
        transform.position = startposition;
        transform.SetParent(Parnt);
        if (Col != null)
        {
            Col.GetComponent<slotholder>().Checkslot(ITM.ID);

        }
    }


    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (!collision.CompareTag("Slot") && collision.transform != transform.parent)
        {
            Col = collision.gameObject;

            if (collision.transform.childCount != 0)
            {
                Child = collision.transform.GetChild(0);
                OtherHandler = Child.gameObject.GetComponent<DragHandler>();
            }
            startposition = collision.transform.position;
            Parnt = collision.transform;
        }
    }
    private void OnTriggerExit2D(Collider2D collision)
    {
        Col = null;
        Child = null;
        OtherHandler = null;
        startposition = OldPose;
        Parnt = OldParnt;
    }

    public void Getsome()
    {
        tr.text = "" + Itemamount;
    }
}
