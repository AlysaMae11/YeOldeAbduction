
using UnityEngine;

public class Shop : MonoBehaviour
{
    public TurretBlueprint CatpultTurret;
    public TurretBlueprint ArrowTurret;
    public TurretBlueprint CannonTurret;
    BuildManager buildManager;

    private void Start()
    {
        buildManager = BuildManager.Instance;
    }

    public void SelectCatpultTurret()
    {
        Debug.Log("Catpult Selected");
        buildManager.SelectTurretToBuild(CatpultTurret);
    }

    public void SelectArrowTurret()
    {
        Debug.Log("Arrow Selected");
        buildManager.SelectTurretToBuild(ArrowTurret);
    }

    public void SelectCannonTurret()
    {
        Debug.Log("Cannon Selected");
        buildManager.SelectTurretToBuild(CannonTurret);
    }
}
