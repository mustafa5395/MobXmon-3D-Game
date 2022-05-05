using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class KarakterKontrol : MonoBehaviour
{

   

    GameKontrol Kontrol;
    private float BaslangicTime;
    GameObject GreenButon;
    Animator Control;
    MenuControl MenuCont;
    CoinNo PlayerCoin;

    Image LeftButton;
    Image RightButton;
    Image ForwardButton;
    Image BackButton;

    //---------Coin-----------//
    int Coin;
    public int CoinNumber;
    public Text CoinText;
    public Text CoinCompleteText;
    public AudioSource CoinSound;
    public AudioSource GreenButSound;

    [Header("Floor")]
    public GameObject Isin;

    public bool FlooIsActive;
    public float FloorMass;
    public float FloorTime;


    [Header("Hareket")]
    public AudioSource StepSound;
    public float Speed;
    public List<GameObject> Buttons;
    bool Oldumu;
    bool Forward;
    bool Back;
    bool Left;
    bool Right;
    bool IsMove;

    [Header("Teleport")]
    public AudioSource TeleportSound;
    public int IsinSayi;
    public  bool IsinlanDegdimi;
    List<GameObject> IsinlanGir;
    List<GameObject> IsinlanCik;
    public ParticleSystem Teleport;
    public float TeleportTime;
    public float TeleportFinishTime;
    public ParticleSystem TeleportFinish; 
    int IsinlanSiraNo;
    bool IsinlanDurum;

   [Header("BlueButton")]
    bool IsActive = true;

    [Header("Sounds")]
    public AudioSource DikenSes;
    public AudioSource CompleteSound;
    public AudioSource WaterSound;
    public AudioSource DeathSound;
    bool WaterSnd;

    void Start()
    {
        LeftButton = GameObject.FindWithTag("left").GetComponent<Image>();
        RightButton= GameObject.FindWithTag("right").GetComponent<Image>();
        ForwardButton = GameObject.FindWithTag("forward").GetComponent<Image>();
        BackButton = GameObject.FindWithTag("back").GetComponent<Image>();

        PlayerCoin = GameObject.FindWithTag("Coin").GetComponent<CoinNo>();
        IsinlanGir = GameObject.FindWithTag("GameKontrol").GetComponent<GameKontrol>().TeleportIn;
        IsinlanCik = GameObject.FindWithTag("GameKontrol").GetComponent<GameKontrol>().TeleportEx;

        WaterSnd = true;
      
      
        BaslangicTime=Time.time;
        IsinlanDegdimi = true;
        Oldumu = true;
        Control = GetComponent<Animator>();
        Kontrol = GameObject.FindWithTag("GameKontrol").GetComponent<GameKontrol>();
       

        Forward = false;
        Back = false;
        Right = false;
        Left = false;
        IsMove = true;
     
    }


   

    private void OnTriggerEnter(Collider other)
    {
    
        GameObject Diken = other.gameObject;

        if (other.transform.CompareTag("BlueButton"))
        {

            List<GameObject> BlueHedef = other.GetComponent<BlueButton>().HedefOjeler;
            List<GameObject> BlueObje = other.GetComponent<BlueButton>().Objeler;
            other.gameObject.GetComponent<BlueButton>().Color.GetComponent<MeshRenderer>().material.color = new Color32(255, 4, 191, 255);
            if (other.GetComponent<BlueButton>().NegPoz == true)
            {

                foreach (var item in BlueHedef)
                {
                    int no = item.GetComponent<Bridge>().No - 1;
                    foreach (var obje in BlueObje)
                    {

                        StartCoroutine(SoundPlay("Blue"));
                        // BlueObje[no].transform.position = Vector3.Lerp(BlueObje[no].transform.position, BlueHedef[no].transform.position, (Time.time - BaslangicTime) * other.GetComponent<BlueButton>().Mesafe);
                        StartCoroutine(BlueButon(BlueObje[no], BlueHedef[no], other.GetComponent<BlueButton>().Mesafe));

                    }
                }

            }


        }

        if (other.transform.CompareTag("BlueButton"))
        {
            other.gameObject.GetComponent<BoxCollider>().isTrigger = false;

            List<GameObject> BlueHedef = other.GetComponent<BlueButton>().HedefOjeler;
            List<GameObject> BlueObje = other.GetComponent<BlueButton>().Objeler;
            other.gameObject.GetComponent<BlueButton>().Color.GetComponent<MeshRenderer>().material.color = new Color32(255, 4, 191, 255);
            if (other.GetComponent<BlueButton>().NegPoz == true)
            {
                
                foreach (var item in BlueHedef)
                {
                    int no = item.GetComponent<Bridge>().No - 1;
                    foreach (var obje in BlueObje)
                    {

                        StartCoroutine(SoundPlay("Blue"));
                        // BlueObje[no].transform.position = Vector3.Lerp(BlueObje[no].transform.position, BlueHedef[no].transform.position, (Time.time - BaslangicTime) * other.GetComponent<BlueButton>().Mesafe);
                        StartCoroutine(BlueButon(BlueObje[no], BlueHedef[no], other.GetComponent<BlueButton>().Mesafe));

                    }
                }

            }


        }
      
        if (other.transform.CompareTag("RedButton") && Diken.GetComponent<RedDestroy>().DikenBas)
        {

            GameObject button;
            List<GameObject> Thorn = Diken.GetComponent<RedDestroy>().Dikenler;
            Diken.GetComponent<RedDestroy>().DikenBas = false;
            button = Diken.GetComponent<RedDestroy>().Buttonum;
            button.GetComponent<MeshRenderer>().material.color = Color.white;
            StartCoroutine(Thorns(Thorn,true));
           
            
        }
        if (other.transform.CompareTag("Redbutton2") && Diken.GetComponent<RedDestroy>().DikenBas)
        {

            GameObject button;
            List<GameObject> Thorn = Diken.GetComponent<RedDestroy>().Dikenler;
            Diken.GetComponent<RedDestroy>().DikenBas = false;
            button = Diken.GetComponent<RedDestroy>().Buttonum;
            button.GetComponent<MeshRenderer>().material.color = Color.white;
            StartCoroutine(Thorns(Thorn,false));


        }
        if (other.transform.CompareTag("Diken"))
        {
            Control.SetTrigger("Die");
         
            Oldumu = false;
            StartCoroutine(Death());
            DeathSound.Play();
        }
        if (other.transform.CompareTag("Isinlanma"))
        {
            IsinlanSiraNo = other.GetComponent<Isinlan>().SiraNo;
            IsinlanDurum= other.GetComponent<Isinlan>().Durum;

          
            if (IsinlanDurum==true)
            {
                Instantiate(Teleport, IsinlanGir[IsinlanSiraNo - 1].transform.position, Quaternion.Euler(-90, 0, 0));
                Teleport.Play();
                StartCoroutine(Port("Gir", IsinlanCik[IsinlanSiraNo - 1].transform.gameObject, TeleportTime));
                //gameObject.transform.position = IsinlanCik[IsinlanSiraNo - 1].transform.position;
                IsinlanCik[IsinlanSiraNo - 1].GetComponent<BoxCollider>().isTrigger = false;
                other.GetComponent<Isinlan>().GelenDurum = true;
                
                
            }
            else
            {

                 Instantiate(Teleport,IsinlanCik[IsinlanSiraNo - 1].transform.position, Quaternion.Euler(-90, 0, 0));
                Teleport.Play();
                StartCoroutine(Port("Cik", IsinlanGir[IsinlanSiraNo - 1].transform.gameObject, TeleportTime));
                //gameObject.transform.position = IsinlanGir[IsinlanSiraNo - 1].transform.position;
                IsinlanGir[IsinlanSiraNo - 1].GetComponent<BoxCollider>().isTrigger = false;
                other.GetComponent<Isinlan>().GelenDurum = true;

            }

        }
        if (other.transform.CompareTag("Water"))
        {
            if (WaterSnd==true)
            {
                WaterSound.Play();
                WaterSnd = false;
            }
           
            Control.SetTrigger("Die");
            StartCoroutine(Death());
        }
        if (other.transform.CompareTag("GreenButton"))
        {
            GreenButon = other.gameObject;
            List<GameObject> Cubes= GreenButon.GetComponent<GreenButton>().GreenButon;
            StartCoroutine(GreenButton(Cubes,0));
          
        }

        if (other.transform.CompareTag("GreenButton2"))
        {
            GreenButon = other.gameObject;
            List<GameObject> Cubes = GreenButon.GetComponent<GreenButton>().GreenButon;
         
            foreach (var item in Cubes)
            {
                item.SetActive(false);
                other.gameObject.SetActive(false);
               
            }
            GreenButon.GetComponent<GreenButton>().AddColor.GetComponent<MeshRenderer>().material.color = new Color32(42, 46, 12, 255);
            GreenButSound.Play();
        }

      
        if (other.transform.CompareTag("Again"))
        {
            StartCoroutine(Death());

        }
        if (other.transform.CompareTag("Coin"))
        {
            
            PlayerCoin.ListNo.Add(other.gameObject.GetComponent<CoinNo>().No);
            CoinSound.Play();
            Coin++;
            CoinText.text = (":"+Coin.ToString()) ;
            CoinCompleteText.text = (":" + Coin.ToString());
            Destroy(other.gameObject);
            PlayerPrefs.SetInt("Coin", Coin);
          //  CoinNumber = other.transform.gameObject.GetComponent<CoinNo>().CoinNumber;

        }
        if (other.transform.CompareTag("Complete"))
        {
            for (int i = 0; i < PlayerCoin.ListNo.Count; i++)
            {
                PlayerPrefs.SetInt("Coin" + PlayerCoin.ListNo[i], PlayerCoin.ListNo[i]);
            }

            if (!PlayerPrefs.HasKey("GameStart"))
            {
                Debug.Log("Girdi");
                PlayerPrefs.SetInt("TotalCoin", Coin);
                PlayerPrefs.SetInt("GameStart",1);
            }
            else
            {
                Debug.Log("Girmedi");
                PlayerPrefs.SetInt("TotalCoin", PlayerPrefs.GetInt("TotalCoin") + Coin);
            }
          
            Debug.Log(PlayerPrefs.GetInt("TotalCoin"));
            Instantiate(TeleportFinish, new Vector3(other.transform.position.x, other.transform.position.y+0.2f, other.transform.position.z), Quaternion.Euler(-90,0,0));
            TeleportFinish.Play();
            StartCoroutine(SoundPlay("Complete"));
            StartCoroutine(Complete());
            if ( other.gameObject.GetComponent<Comlete>().Level >= PlayerPrefs.GetInt("Level") )
            {
                PlayerPrefs.SetInt("Level", other.gameObject.GetComponent<Comlete>().Level);
            }
               
            
           

            

        }
        if (other.transform.CompareTag("move"))
        {

            StepSound.Stop();
            Control.SetBool("Run Forward", false);


        }
    }
    
    private void FixedUpdate()
    {
        RaycastHit hit;
        if (Physics.Raycast(Isin.transform.position, Isin.transform.TransformDirection(Vector3.forward), out hit, 2) && FlooIsActive)
        {
            if (hit.transform.CompareTag("Zemin"))
            {
                StartCoroutine(Floor(hit.transform.gameObject));
            }

        }

        //if (Physics.Raycast(Isin.transform.position, Isin.transform.TransformDirection(Vector3.forward), out hit, 2))
        //{
        //    if (hit.transform.CompareTag("BlueButton"))
        //    {

        //        List<GameObject> BlueHedef = hit.transform.GetComponent<BlueButton>().HedefOjeler;
        //        List<GameObject> BlueObje = hit.transform.GetComponent<BlueButton>().Objeler;
        //        hit.transform.GetComponent<BlueButton>().Color.GetComponent<MeshRenderer>().material.color = new Color32(255, 4, 191, 255);
        //        if (hit.transform.GetComponent<BlueButton>().NegPoz == true)
        //        {

        //            foreach (var item in BlueHedef)
        //            {
        //                int no = item.GetComponent<Bridge>().No - 1;
        //                foreach (var obje in BlueObje)
        //                {


        //                    // BlueObje[no].transform.position = Vector3.Lerp(BlueObje[no].transform.position, BlueHedef[no].transform.position, (Time.time - BaslangicTime) * other.GetComponent<BlueButton>().Mesafe);
        //                    StartCoroutine(BlueButon(BlueObje[no], BlueHedef[no], hit.transform.gameObject.GetComponent<BlueButton>().Mesafe));

        //                }
        //            }

        //        }


        //    }

        //}
        Move();
        if (Oldumu==true)
        {
            if (Forward || Back || Right || Left)
            {
                Control.SetBool("Run Forward", true);

            }
        }
       
        else
        {
            StepSound.Stop();
        }
    }

    void Move()
    {
        if (Forward&&Oldumu==true&&IsMove)
        {
         
            transform.rotation = Quaternion.Euler(0F, 0F, 0F);
            transform.Translate(new Vector3(0, 0, 1f) * Speed * Time.deltaTime);
           
        }
        else
        {
           
            Control.SetBool("Run Forward", false);
        }
        if (Back && Oldumu==true && IsMove)
        {
           
            transform.rotation = Quaternion.Euler(0F, 180F, 0F);
            transform.Translate(Vector3.forward * Speed * Time.deltaTime);
        }
        else
        {
           
            Control.SetBool("Run Forward", false);
        }
        if (Left && Oldumu == true && IsMove)
        {
           
            transform.rotation = Quaternion.Euler(0f, -90f, 0f);
            transform.Translate(Vector3.forward * Speed * Time.deltaTime);
        }
        else
        {
          
            Control.SetBool("Run Forward", false);
          
        }
        if (Right && Oldumu == true && IsMove)
        {
           
            transform.Translate(Vector3.forward * Speed * Time.deltaTime);
            transform.rotation = Quaternion.Euler(0f, 90f, 0f);
        }
        else
        {
          
            Control.SetBool("Run Forward", false);
        }
    }
    IEnumerator SoundPlay(string Value)
    {
        //if (Value=="Blue")
        //{
        //    if (IsActive == true)
        //    {
        //        yield return new WaitForSeconds(0.2f);
               
        //        IsActive = false;
        //    }
        //}
        if (Value=="Complete")
        {
            yield return new WaitForSeconds(0f);
            CompleteSound.Play();
        }

        if (Value == "Die")
        {
            yield return new WaitForSeconds(.3f);
            DeathSound.Play();
        }


    }
    IEnumerator BlueButon(GameObject First, GameObject Second, float Mesafe)
    {
     
        while (First.transform.position != Second.transform.position)
        {
           
            yield return new WaitForSeconds(.1f);
            First.transform.position = Vector3.Lerp(First.transform.position, Second.transform.position, Mesafe);
            
        }
       

    }
    IEnumerator Floor(GameObject AddRb)
    {

            yield return new WaitForSeconds(FloorTime);
        if (!AddRb.transform.gameObject.GetComponent<Rigidbody>())
        {
            AddRb.transform.gameObject.AddComponent<Rigidbody>();
            AddRb.transform.gameObject.GetComponent<Rigidbody>().mass = FloorMass;
        }

        yield return new WaitForSeconds(1F);
        AddRb.SetActive(false);

    }
    IEnumerator GreenButton(List<GameObject> Buttons,int Value)
    {
        //  int soundNo = 0;

        if (Value==0)
        {
            if (GreenButon.GetComponent<GreenButton>().IsActive == true)
            {
                GreenButon.GetComponent<GreenButton>().AddColor.GetComponent<MeshRenderer>().material.color = new Color32(42, 46, 12, 255);
                for (int i = 0; i < Buttons.Count; i++)
                {
                    yield return new WaitForSeconds(.5f);
                    Buttons[i].SetActive(false);
                    GreenButSound.Play();
                }
                GreenButon.GetComponent<GreenButton>().IsActive = false;

            }
            else
            {
                GreenButon.GetComponent<GreenButton>().AddColor.GetComponent<MeshRenderer>().material.color = new Color32(42, 46, 12, 255);
                foreach (var item in GreenButon.GetComponent<GreenButton>().GreenButon)
                {
                    yield return new WaitForSeconds(.5f);
                    item.SetActive(true);

                    if (GreenButon.GetComponent<GreenButton>().IsActive == false)
                    {

                        GreenButSound.Play();


                    }
                }

                GreenButon.GetComponent<GreenButton>().IsActive = true;
            }

        }
  





    }
    IEnumerator Death()
    {
        yield return new WaitForSeconds(.3f);
        Oldumu = false;
        yield return new WaitForSeconds(1.5f);
        
      
        Kontrol.GameOver();

    }
    IEnumerator Thorns(List<GameObject> Thorns,bool IsActive)
    {
        if (IsActive==true)
        {
            for (int i = 0; i < Thorns.Count; i++)
            {
                yield return new WaitForSeconds(.5f);
                DikenSes.Play();
                Thorns[i].SetActive(false);
            }
        }
        else
        {
            for (int i = 0; i < Thorns.Count; i++)
            {
                yield return new WaitForSeconds(.5f);
                DikenSes.Play();
                Thorns[i].SetActive(true);
            }
        }
       
    }
    IEnumerator Port(string Tur,GameObject Obje,float Time)
    {
        yield return new WaitForSeconds(Time);
        if (Tur=="Gir")
        {
            transform.position = Obje.transform.position;
            TeleportSound.Play();
        }
        if (Tur == "Cik")
        {
            transform.position = Obje.transform.position;
            TeleportSound.Play();
        }
    }
    IEnumerator Complete()
    {
        yield return new WaitForSeconds(.3f);
        IsMove = false;
      
        yield return new WaitForSeconds(TeleportFinishTime);
        
        gameObject.SetActive(false);
       
        Kontrol.Win();


       
    }

   



    public void ForwardDown()
    {
        Forward = true;
        LeftButton.raycastTarget = false;
        RightButton.raycastTarget = false;
        BackButton.raycastTarget = false;

        //Buttons[1].GetComponent<Image>().raycastTarget = false;
        //Buttons[2].GetComponent<Image>().raycastTarget = false;
        //Buttons[3].GetComponent<Image>().raycastTarget = false;
      
        if (Kontrol.MiddleNo==0)
        {
            StepSound.Play();
        }
        

    }
    public void ForwardUp()
    {
        Forward = false;
        LeftButton.raycastTarget = true;
        RightButton.raycastTarget = true;
        BackButton.raycastTarget = true;
        //Buttons[1].GetComponent<Image>().raycastTarget = true;
        //Buttons[2].GetComponent<Image>().raycastTarget = true;
        //Buttons[3].GetComponent<Image>().raycastTarget = true;
        StepSound.Stop();
    }
    public void BackDown()
    {
        LeftButton.raycastTarget = false;
        RightButton.raycastTarget = false;
        ForwardButton.raycastTarget = false;
        Back = true;
        //Buttons[0].GetComponent<Image>().raycastTarget = false;
        //Buttons[2].GetComponent<Image>().raycastTarget = false;
        //Buttons[3].GetComponent<Image>().raycastTarget = false;
        if (Kontrol.MiddleNo == 0)
        {
            StepSound.Play();
        }
    }
    public void BackUp()
    {
        LeftButton.raycastTarget = true;
        RightButton.raycastTarget = true;
        ForwardButton.raycastTarget = true; 
        Back = false;
        //Buttons[0].GetComponent<Image>().raycastTarget = true;
        //Buttons[2].GetComponent<Image>().raycastTarget = true;
        //Buttons[3].GetComponent<Image>().raycastTarget = true;
        StepSound.Stop();
    }
    public void LeftDown()
    {
        BackButton.raycastTarget = false;
        RightButton.raycastTarget = false;
        ForwardButton.raycastTarget = false;

        Left = true;
        //Buttons[0].GetComponent<Image>().raycastTarget = false;
        //Buttons[1].GetComponent<Image>().raycastTarget = false;
        //Buttons[3].GetComponent<Image>().raycastTarget = false;
        if (Kontrol.MiddleNo == 0)
        {
            StepSound.Play();
        }
    }
    public void LeftUp()
    {
        BackButton.raycastTarget = true;
        RightButton.raycastTarget = true;
        ForwardButton.raycastTarget = true; 

        Left = false;
        //Buttons[0].GetComponent<Image>().raycastTarget = true;
        //Buttons[1].GetComponent<Image>().raycastTarget = true;
        //Buttons[3].GetComponent<Image>().raycastTarget = true;
        StepSound.Stop();
    }
    public void RightDown()
    {
        BackButton.raycastTarget = false;
        LeftButton.raycastTarget = false;
        ForwardButton.raycastTarget = false;

        Right = true;
        //Buttons[0].GetComponent<Image>().raycastTarget = false;
        //Buttons[1].GetComponent<Image>().raycastTarget = false;
        //Buttons[2].GetComponent<Image>().raycastTarget = false;
        if (Kontrol.MiddleNo == 0)
        {
            StepSound.Play();
        }
    }
    public void RightUp()
    {
        BackButton.raycastTarget = true;
        LeftButton.raycastTarget = true;
        ForwardButton.raycastTarget = true;

        Right = false;
        //Buttons[0].GetComponent<Image>().raycastTarget = true;
        //Buttons[1].GetComponent<Image>().raycastTarget = true;
        //Buttons[2].GetComponent<Image>().raycastTarget = true;
        StepSound.Stop();
    }

}
