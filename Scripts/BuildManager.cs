using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BuildManager : MonoBehaviour
{

    [SerializeField] private AudioSource buildSound;

    public static BuildManager Instance;

    private void Awake()
    {
        if (Instance != null)
        {
            Debug.LogError("More than one BuildManager in scene.");
                return;
        }
        Instance = this;
    }

    public GameObject CatpultTurretPrefab;
    public GameObject ArrowTurretPrefab;
    public GameObject CannonTurretPrefab;

    public GameObject BuildEffect;
    
    private TurretBlueprint turretToBuild;
    private TurretBlueprint Name;

    public bool CanBuild { get { return turretToBuild != null; } }
    public bool HasMoney { get { return PlayerStats.Money >= turretToBuild.cost; } }

    public void BuildTurretOn (Node node)
    {
        buildSound.Play();

        if (PlayerStats.Money < turretToBuild.cost)
        {
            Debug.Log("Not enough Gold");
            return;

        }
        
        PlayerStats.Money -= turretToBuild.cost;

       //Debug.Log(node.GetBuildPosition());

        GameObject turret = Instantiate(turretToBuild.prefab, node.GetBuildPosition(), Quaternion.identity);
        node.turret = turret;

        GameObject effect = (GameObject)Instantiate(BuildEffect, node.GetBuildPosition(), Quaternion.identity);
        Destroy(effect, 5f);

        Debug.Log("Turret build! Money Left:" + PlayerStats.Money);
    }

    public void SelectTurretToBuild(TurretBlueprint turret)
    {
        
        turretToBuild = turret;  
    }
}
