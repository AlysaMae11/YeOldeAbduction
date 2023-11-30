
using UnityEngine;

public class Node : MonoBehaviour
{

    public GameObject turret;
    public Vector3 positionOffset;
   // public GameObject problemTurret;

    public Color hoverColor;
    private Renderer rend;
    private Color startColor;

    public Color notEnoughMoneyColor;

    BuildManager buildManager;

    //[SerializeField] private AudioSource buildSound;

    private void Start()
    {
        rend = GetComponent<Renderer>();
        startColor = rend.material.color;

        buildManager = BuildManager.Instance;
    }

    public TurretBlueprint Name;
    public Vector3 GetBuildPosition()
    {
        
        if(Name.name == "Cannon")
        {
            return transform.position + positionOffset;
        }
        else
        {
            return transform.position;
        }
    }

    private void OnMouseDown()
    {
        if (!buildManager.CanBuild) { 
        //buildSound.Play();
        return;
        }

        if(turret != null)
        {
            Debug.Log("Can't build here");
            return;
        }

        buildManager.BuildTurretOn(this);

    }
    void OnMouseEnter()
    {
        if (!buildManager.CanBuild)
            return;

        if (buildManager.HasMoney)
        {
            rend.material.color = hoverColor;
        }
        else
        {
            rend.material.color = notEnoughMoneyColor;
        }
        

    }

    private void OnMouseExit()
    {
        rend.material.color = startColor;
    }
}
