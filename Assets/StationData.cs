using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class StationData : MonoBehaviour
{
    [SerializeField] int coalInStation;
    [SerializeField] GameObject[] gearsToSpawn;

    [SerializeField] Transform stationRewardPosition;
    [SerializeField] float rewardRatio;
    [SerializeField] float maxCoordinate;

    // Start is called before the first frame update
    public int RewardAmount()
    {
        return (int)(coalInStation * rewardRatio);
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
        }
    }

    public void AddCoalInStation(int coalToAdd)
    {
        coalInStation += coalToAdd;
    }
}
