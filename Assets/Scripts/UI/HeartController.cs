using UnityEngine;
using UnityEngine.UI;

public class HeartController : MonoBehaviour
{
    //public Image heartPrefab; // Prefab of the heart image
    //public Transform heartContainer; // Container for the heart images
    //public Sprite fullHeart; // Full heart sprite
    //public Sprite emptyHeart; // Empty heart sprite

    public PlayerHealth playerHealth;
    [SerializeField] SceneController _sceneController;
    [SerializeField] PlayerMove _playerMove;
    float countDown;
    
  
   

    public static HeartController Instance { get; private set; }

  
    private void Awake()
    {
        if (Instance == null)
        {
            Instance = this;
            DontDestroyOnLoad(gameObject);
        }
        else
        {
            Destroy(gameObject);
        }
    }

    private void Start()
    {
      

        UIManager.Instance.CreateHearts(playerHealth.maxHearts,playerHealth.currentHearts);
    }


    private void Update()
    {
 

    }



    //public void CreateHearts(int maxhearts, int fullhearts)
    //{

    //    int emptyhearts = (maxhearts - fullhearts);

    //    // Instantiate heart images
    //    for (int i = 0; i < fullhearts; i++)
    //    {
    //        Image heartImage = Instantiate(heartPrefab, heartContainer);
    //        heartImage.sprite = fullHeart;
    //    }


    //    for (int i = 0; i < emptyhearts; i++)
    //    {
    //        Image heartImage = Instantiate(heartPrefab, heartContainer);
    //        heartImage.sprite = emptyHeart;
    //    }

    //}








    //public void AddHeart()
    //{
    //    if (playerHealth.currentHearts < playerHealth.maxHearts)
    //    {
    //        heartContainer.GetChild(playerHealth.currentHearts).GetComponent<Image>().sprite = fullHeart;
    //        playerHealth.currentHearts++;
    //    }

    //}

    //public void FillHearts()
    //{
    //    foreach (Transform child in heartContainer)
    //    {
    //        child.GetComponent<Image>().sprite = fullHeart;
    //    }

    //}

 
}



