using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
public class AIBuyer : MonoBehaviour {

    public bool BuyNot;
    public bool Served, QuitForStockEmpty;
    public int random;
    public int menu;
    public bool BuyDone;
    public float LimitTimeBuy;
    public float LimitTimeBuyCurr;

    public bool BuyMove;
    public int MoveIndex;
    public int MoveIndexChild;
    public Transform targetMove;
    public int NumberinArray;
    public int MoveIndexOut;

    public Image BuyIcon;
    public Image LimitTimeBuyImage;

    BuyerIdentity manager2;
    UIMainManager manager;
    BahanManager manager3;

    MenuIdentity manager4;

    AISpawnBuyer manager6;
    public float DirectionIdentity;

    public bool NotAction;

    private void Awake()
    {
        manager6 = FindObjectOfType<AISpawnBuyer>();
    }
    // Use this for initialization
    void Start () {
        manager = FindObjectOfType<UIMainManager>();
        manager2 = FindObjectOfType<BuyerIdentity>();
        manager3 = FindObjectOfType<BahanManager>();
        manager4 = GetComponent<MenuIdentity>();
        DirectionIdentity = manager6.IdentitityLocation;

        LimitTimeBuy = manager2.identityBuyer.MaxService;
        LimitTimeBuyCurr = manager2.identityBuyer.MaxService;

        LimitTimeBuyImage.enabled = false;
        BuyIcon.enabled = false;

        targetMove = manager6.aipaths[MoveIndex].path[0];
    }
	
	// Update is called once per frame
	void Update () {
        ControlAI();  
	}

    void ControlAI()
    {
        if (!BuyNot)
        {
            // transform.Translate(0, 0, -25f * DirectionIdentity * Time.fixedDeltaTime);
            transform.Translate(0, 0, 25f  * Time.fixedDeltaTime);
        }
        
        else if (BuyNot )
        {
           
            if (BuyMove)
            {
                Vector3 dir = targetMove.position - this.transform.position;
                dir.y = 0;
                
              
                    this.transform.rotation = Quaternion.Slerp(this.transform.rotation, Quaternion.LookRotation(dir), 0.1f);
                    
                
                

                transform.Translate(dir.normalized * 25f * Time.deltaTime);

                if (Vector3.Distance(transform.position, targetMove.position) <= 0.2f)
                {
                    if (MoveIndexChild == 1 )
                    {
                        //  manager.StackBuyer.Add(this);

                        //this.transform.rotation = Quaternion.Slerp(this.transform.rotation, Quaternion.LookRotation(targetMove.position - manager6.TokoGameObject.position), 0.1f);
                       // this.transform.rotation = Quaternion.Slerp(this.transform.rotation, Quaternion.LookRotation(dir2), 0.1f);
                        BuyMove = false;
                        return;
                    }
                    else if (MoveIndex == NumberinArray + 2 )
                    {
                        // MoveIndex += 1;
                        MoveIndexChild += 1;
                        targetMove = manager6.aipaths[MoveIndex].path[MoveIndexChild];
                       // this.transform.rotation = Quaternion.Slerp(this.transform.rotation, Quaternion.LookRotation(targetMove.position - manager6.TokoGameObject.position), 0.1f);
                        //  Vector3 dir2 = manager6.TokoGameObject.position - this.transform.position;
                        // this.transform.rotation = Quaternion.LookRotation(manager6.TokoGameObject.position);
                        return;
                    }
                    if (MoveIndex != manager6.aipaths.Length -1) {
                        MoveIndex += 1;
                        targetMove = manager6.aipaths[MoveIndex].path[MoveIndexChild];
                    }
                   
                }
            }
            else {

                if (!NotAction) {
                    Vector3 dir2 = new Vector3(0, -90, 0);
                    //  dir2.y = 0;
                    this.transform.rotation = Quaternion.Slerp(this.transform.rotation, Quaternion.EulerAngles(dir2), 0.1f);
                }

                if (QuitForStockEmpty)
                {
                    //manager.StackBuyer.Remove(this);
                    //  manager.StackBuyer.Remove(this);
                    BuyDone = true;
                    NotAction = true;
                    targetMove = manager6.stackout[MoveIndexOut];

                        Vector3 dir = targetMove.position - this.transform.position;
                        dir.y = 0;

                    // this.transform.rotation = Quaternion.Slerp(this.transform.rotation, Quaternion.LookRotation(dir), 0.1f);
                    //  transform.Translate(dir.normalized * 25f * Time.deltaTime);
                    this.transform.rotation = Quaternion.Slerp(this.transform.rotation, Quaternion.LookRotation(dir), 0.5f);
                    // transform.Translate(dir.normalized * 25f * Time.deltaTime);
                    transform.Translate(0, 0, 15 * Time.deltaTime);

                    if (Vector3.Distance(transform.position, targetMove.position) <= 0.2f)
                        {
                           
                            if (MoveIndexOut == 1)
                            {

                                BuyStuff();
                              }
                             else {
                                MoveIndexOut += 1;
                                targetMove = manager6.stackout[MoveIndexOut];
                             }
                        }
                    
                     
                    
                    return;
                }
                if (Served)
                {
                    //  manager.StackBuyer.Remove(this);
                    BuyDone = true;
                    NotAction = true;
                    targetMove = manager6.stackout[MoveIndexOut];

                    Vector3 dir = targetMove.position - this.transform.position;
                    dir.y = 0;

                    // this.transform.rotation = Quaternion.Slerp(this.transform.rotation, Quaternion.LookRotation(dir), 0.1f);
                    //  transform.Translate(dir.normalized * 25f * Time.deltaTime);
                    this.transform.rotation = Quaternion.Slerp(this.transform.rotation, Quaternion.LookRotation(dir), 0.5f);
                    // transform.Translate(dir.normalized * 25f * Time.deltaTime);
                    transform.Translate(0, 0, 15 * Time.deltaTime);
                    manager.audioCollection[0].Play();
                    if (Vector3.Distance(transform.position, targetMove.position) <= 0.2f)
                    {

                        if (MoveIndexOut == 1)
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
                            Debug.Log("Masuk sini Index");
                        }
                        else {
                            MoveIndexOut += 1;
                            targetMove = manager6.stackout[MoveIndexOut];
                        }
                       
                    }
                    
                }
                else
                {
                    
                    StartCoroutine(CountCancelBuy());
                    
                }
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

            BuyDone = true;
            NotAction = true;
            targetMove = manager6.stackout[MoveIndexOut];

            Vector3 dir = targetMove.position - this.transform.position;
            dir.y = 0;

             this.transform.rotation = Quaternion.Slerp(this.transform.rotation, Quaternion.LookRotation(dir), 0.5f);
            // transform.Translate(dir.normalized * 25f * Time.deltaTime);
            transform.Translate(0,0,15*Time.deltaTime);
            if (Vector3.Distance(transform.position, targetMove.position) <= 0.2f)
            {

                if (MoveIndexOut == 1)
                {

                    BuyStuff();
                }
                else
                {
                    MoveIndexOut += 1;
                    targetMove = manager6.stackout[MoveIndexOut];
                }
            }
            //  manager.TotalIncome += manager.MoneyCurr;
            manager.TotalPeopleCancelBuy += 1;
           
        }
        yield return 0;
    }

  

    void BuyStuff() {
        // yield return new WaitForSeconds(2f);
        
        manager.StackBuyer.Remove(this);
       // this.transform.position = manager.StackPositionOut.position;
        
       
        LimitTimeBuyImage.enabled = false;
        BuyIcon.enabled = false;

        BuyNot = false;
        for (int i = NumberinArray; i < manager.StackBuyer.Count; i++)
            {
            // manager.StackBuyer[i].transform.position = manager.StackPosition[i].position;
            if ( manager.StackBuyer[i].MoveIndex <= 2)
            {
                manager.StackBuyer[i].NumberinArray -= 1;
                return;
            }
            else {
                manager.StackBuyer[i].BuyMove = true;
                manager.StackBuyer[i].MoveIndex -= 1;
                manager.StackBuyer[i].targetMove = manager6.aipaths[manager.StackBuyer[i].MoveIndex].path[1];
                manager.StackBuyer[i].NumberinArray -= 1;
            }
        }
            
       

    }

    private void OnCollisionEnter(Collision collision)
    {
        
        
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.tag == "Toko")
        {
           
            if (manager.StackBuyer.Count >4 || BuyDone || BuyNot)
            {
                return;
            }
             random = Random.Range(0,100);
            if (random > AllGameManager.instance.ProbabilityBuy + manager2.identityBuyer.ProbabilityBuy) {
                return;
            }
            manager3.StackOn = true;
             menu = Random.Range(0, AllGameManager.instance.ListMenu.Count);
            manager4.identityBuyer = AllGameManager.instance.ListMenu[menu];
            BuyIcon.sprite = manager4.identityBuyer.Icon;

            manager.TotalPeopleCometoBooth += 1;

            BuyNot = true;

            //  this.transform.position =  manager.StackPosition[manager.StackBuyer.Count].position;
            
            BuyMove = true;
            NumberinArray = manager.StackBuyer.Count;
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
