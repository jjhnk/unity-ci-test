using System.Collections;
using System.Collections.Generic;
using UnityEngine;
 
[CreateAssetMenu(fileName = "DeveloperInformation", menuName= "DeveloperInformation",order =0)]
public class DeveloperInformation : ScriptableObject
{
    [SerializeField]
    private string developer_name;
 
    public string Name
    {
        get
        {
            return developer_name;
        }
    }
}
