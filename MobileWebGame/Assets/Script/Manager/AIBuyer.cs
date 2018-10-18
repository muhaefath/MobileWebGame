using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
public class AIBuyer : MonoBehaviour {

    public bool BuyNot;
    public bool Served;
    public int random;
    public int menu;
    public bool BuyDone;
    public float LimitTimeBuy;
    public float LimitTimeBuyCurr;

    public Image BuyIcon;
    public Image LimitTimeBuyImage;

    BuyerIdentity manager2;
    UIMainManager manager;
    BahanManager manager3;

    MenuIdentity manager4;

	// Use this for initialization
	void Start () {
        manager = FindObjectOfType<UIMainManager>();
        manager2 = FindObjectOfType<BuyerIdentity>();
        manager3 = FindObjectOfType<BahanManager>();
        manager4 = GetComponent<MenuIdentity>();

        LimitTimeBuy = manager2.identityBuyer.MaxService;
        LimitTimeBuyCurr = manager2.identityBuyer.MaxService;

        LimitTimeBuyImage.enabled = false;
        BuyIcon.enabled = false;

    }
	
	// Update is called once per frame
	void Update () {
        ControlAI();  
	}

    void ControlAI()
    {
        if (!BuyNot)
        {
            transform.Translate(-25f * Time.fixedDeltaTime, 0, 0);
        }
        
        else if (BuyNot )
        {
            if (Served)
            {
                BuyStuff();
                manager.TotalIncome += manager.MoneyCurr;
                manager.TotalPeopleBuy += 1;
                AllGameManager.instance.MoneyCurr += AllGameManager.instance.PriceStuff;
                AllGameManager.instance.MoneyText.text = "" + AllGameManager.instance.MoneyCurr;

                AllGameManager.instance.StockMenu[menu] -= 1;
                manager3.MenuQuantityText[menu].text = "" + AllGameManager.instance.StockMenu[menu];

                if (AllGameManager.instance.StockMenu[menu] == 0)
                {
                    manager3.MenuStockButton[menu].interactable = false;
                }
            }
            else {
                StartCoroutine(CountCancelBuy());
                
            }
           
        }
    }

     IEnumerator CountCancelBuy() {
        if (LimitTimeBuy >= 0)
        {
            LimitTimeBuy -= Time.deltaTime;
            LimitTimeBuyImage.fillAmount = LimitTimeBuy / LimitTimeBuyCurr;
        }
        else {
            BuyStuff();
           //  manager.TotalIncome += manager.MoneyCurr;
            manager.TotalPeopleCancelBuy += 1;
           
        }
        yield return 0;
    }

  

    void BuyStuff() {
        // yield return new WaitForSeconds(2f);
        this.transform.position = manager.StackPositionOut.position;
        BuyDone = true;
        manager.StackBuyer.Remove(this);
        LimitTimeBuyImage.enabled = false;
        BuyIcon.enabled = false;

       
        for (int i = 0; i < manager.StackBuyer.Count; i++)
            {
                manager.StackBuyer[i].transform.position = manager.StackPosition[i].position;
            }
            
        BuyNot = false;

    }

    private void OnCollisionEnter(Collision collision)
    {
        
        
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.tag == "Toko")
        {
            if (manager.StackBuyer.Count >4 || BuyDone )
            {
                return;
            }
             random = Random.Range(0,100);
            if (random > AllGameManager.instance.ProbabilityBuy + manager2.identityBuyer.ProbabilityBuy) {
                return;
            }
            manager3.StackOn = true;
             menu = Random.Range(0,3);
            manager4.identityBuyer = AllGameManager.instance.ListMenu[menu];
            BuyIcon.sprite = manager4.identityBuyer.Icon;

            manager.TotalPeopleCometoBooth += 1;

            BuyNot = true;
            
            this.transform.position =  manager.StackPosition[manager.StackBuyer.Count].position;
            manager.StackBuyer.Add(this);

            LimitTimeBuyImage.enabled = true;
            BuyIcon.enabled = true;
        }

        if (other.gameObject.tag == "LimitDoor")
        {
            Destroy(gameObject);
        }
    }
}
