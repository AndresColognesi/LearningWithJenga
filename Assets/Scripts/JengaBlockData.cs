using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[System.Serializable]
public class JengaBlockData
{
    /***
     * A class that stores all data of a given Jenga
     * block, to serve as a dictionary.
     ***/


    public int id; //{ get; set; }
    public string subject; //{ get; set; }
    public string grade; //{ get; set; }
    public int mastery; //{ get; set; }
    public string domainid; //{ get; set; }
    public string domain; //{ get; set; }
    public string cluster; //{ get; set; }
    public string standardid; //{ get; set; }
    public string standarddescription; //{ get; set; }

}

[System.Serializable]
public class JengaBlockDataListObject
{
    /***
     * A class that stores a list of JengaBlockData
     * objects.
     ***/

    public List<JengaBlockData> jengaBlockDataList; //{ get; set; }
}
