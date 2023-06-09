using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class StationData : MonoBehaviour
{
    [SerializeField] float coalInStation;
    [SerializeField] GameObject[] gearsToSpawn;
    [SerializeField] TextMeshProUGUI stationCoalUI;
    [SerializeField] TextMeshProUGUI stationNameUI;
    [SerializeField] TextMeshProUGUI thisStationNameUI;
    [SerializeField] GameObject gameOverScreen;
    [SerializeField] Transform stationRewardPosition;
    [SerializeField] string thisStationName;
    [SerializeField] float maxCoordinate;
    [SerializeField] int stationCoalConsumptionRate;
    [SerializeField] float coalConsumptionRateChangeCooldown;
    [SerializeField] float auxTime;
    private GlobalTimer globalTimer;

    // Start is called before the first frame update
    public int RewardAmount()
    {
        //+ (int)(coalInStation * rewardRatio)
        int reward = Random.Range(0,2);
        return reward;
    }

    void Start()
    {
        stationNameUI.text = thisStationName + " St.";
        thisStationNameUI.text = thisStationName;
        globalTimer = FindObjectOfType<GlobalTimer>();

    }

    void OnEnable()
    {
        
    }

    void Update()
    {
        if(!globalTimer.IsGameOver)
        {
            ConsumeCoalOverTime();
            ChangeCoalConsumptionRate();
        }

    }

    private void ChangeCoalConsumptionRate()
    {
        auxTime += Time.deltaTime;
        if(auxTime>coalConsumptionRateChangeCooldown)
        {
            stationCoalConsumptionRate = Random.Range(1,5) + globalTimer.DifficultyRatio;
        }
    }

    private void ConsumeCoalOverTime()
    {
                stationCoalUI.text = coalInStation.ToString("0");
                if(coalInStation>0)
                {
                    coalInStation -= stationCoalConsumptionRate * Time.deltaTime;
                }
                else
                {
                    coalInStation = 0;
                    if(!gameOverScreen.activeInHierarchy)
                    {
                        gameOverScreen.SetActive(true);
                        gameOverScreen.GetComponent<OnGameOverScreen>().WhyYouWillLose("CITY FROZEN");
                        //
                        StartCoroutine(losing());
                        Debug.Log("triggered Lose cond.");
                    }

                }
        
    }

    IEnumerator losing()
    {
        yield return new WaitForSeconds(5f);
        globalTimer.SetGameState(true);

    }

    public Vector3 GenerateCoordinate()
    {
        return new Vector3 (stationRewardPosition.transform.position.x + Random.Range(-maxCoordinate,maxCoordinate), transform.position.y, stationRewardPosition.transform.position.z + Random.Range(-maxCoordinate, maxCoordinate));
    }

    public void SpawnReward(GameObject rewardObject, Vector3 positionToPlace)
    {
        Instantiate(rewardObject,positionToPlace, Quaternion.identity);
    }

    public void GenerateRewardAmount()
    {
        int amount = RewardAmount();

        for(int i = 0; i<amount;i++)
        {
            SpawnReward(gearsToSpawn[0],GenerateCoordinate());
            Debug.Log("reward generated");
        }
    }

    public void AddCoalInStation(int coalToAdd)
    {
        coalInStation += coalToAdd;
    }
}
