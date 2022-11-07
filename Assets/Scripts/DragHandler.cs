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
    public Transform NewParent;
    public Transform OldParent;
    public Transform Child;
    public Text tr;
    public Item ITM;
    public int Itemamount;
    public DragHandler OtherHandler;
    public GameObject Col;

    public void OnBeginDrag(PointerEventData eventData)
    {
        NewParent = transform.parent;
        OldParent = transform.parent;
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
                OldParent.GetComponent<SlotHolder>().Checkslot(0);
                Child = null;
                Destroy(gameObject);
            }
            else
            {
                Child.SetParent(OldParent);
                Child.position = OldPose;
                OldParent.GetComponent<SlotHolder>().Checkslot(OtherHandler.ITM.ID);
            }
        }
        else
        {
            OldParent.GetComponent<SlotHolder>().Checkslot(0);
        }
        
        transform.position = startposition;
        transform.SetParent(NewParent);
        if (Col != null)
        {
            Col.GetComponent<SlotHolder>().Checkslot(ITM.ID);

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
            NewParent = collision.transform;
        }
    }
    private void OnTriggerExit2D(Collider2D collision)
    {
        Col = null;
        Child = null;
        OtherHandler = null;
        startposition = OldPose;
        NewParent = OldParent;
    }

    public void Getsome()
    {
        tr.text = "" + Itemamount;
    }
}
