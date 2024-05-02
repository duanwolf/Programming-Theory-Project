using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class UIController : MonoBehaviour
{
    public static UIController Instance { get; private set; }
    private Dictionary<string, int> foodMap;
    private Dictionary<string, TextMeshProUGUI> textMap;
    [SerializeField]
    private TextMeshProUGUI appleText;
    [SerializeField]
    private TextMeshProUGUI bananaText;
    [SerializeField]
    private TextMeshProUGUI cakeText;
    [SerializeField]
    private TextMeshProUGUI carrotText;
    [SerializeField]
    private TextMeshProUGUI fishText;
    [SerializeField]
    private TextMeshProUGUI steakText;
    private void Awake()
    {
        if (Instance != null)
        {
            Destroy(gameObject);
            return;
        }
        Instance = this;
        initFoodMap();
    }
    private void initFoodMap()
    {
        foodMap = new Dictionary<string, int>();
        foodMap[Constant.TAG_APPLE] = 0;
        foodMap[Constant.TAG_BANANA] = 0;
        foodMap[Constant.TAG_FISH] = 0;
        foodMap[Constant.TAG_STEAK] = 0;
        foodMap[Constant.TAG_CARROT] = 0;
        foodMap[Constant.TAG_CAKE] = 0;
        textMap = new Dictionary<string, TextMeshProUGUI>();
        textMap[Constant.TAG_APPLE] = appleText;
        textMap[Constant.TAG_BANANA] = bananaText;
        textMap[Constant.TAG_CAKE] = cakeText;
        textMap[Constant.TAG_CARROT] = carrotText;
        textMap[Constant.TAG_FISH] = fishText;
        textMap[Constant.TAG_STEAK] = steakText;
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void IncreaseTagNum(string tag, int count)
    {
        foodMap[tag] += count;
        textMap[tag].text = "x" + foodMap[tag];
    } 

    public bool ValidPositiveCount(string tag)
    {
        return foodMap.ContainsKey(tag) && foodMap[tag] > 0;
    }
}
