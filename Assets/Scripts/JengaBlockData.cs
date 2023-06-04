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

    #region Attributes

    public int id; //{ get; set; }
    public string subject; //{ get; set; }
    public string grade; //{ get; set; }
    public int mastery; //{ get; set; }
    public string domainid; //{ get; set; }
    public string domain; //{ get; set; }
    public string cluster; //{ get; set; }
    public string standardid; //{ get; set; }
    public string standarddescription; //{ get; set; }

    #endregion
}

[System.Serializable]
public class AllData
{
    /***
     * A class that stores a list of JengaBlockData
     * objects.
     ***/

    #region Attributes

    public List<JengaBlockData> listOfdata; //{ get; set; }

    #endregion
}
