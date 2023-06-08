using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PieceDataStorage : MonoBehaviour
{
    #region Attributes

    // Data container for current Jenga Piece:
    private JengaBlockData pieceData;

    #endregion


    #region Custom Methods

    public void SetPieceData(JengaBlockData data)
    {
        /***
         * Set pieceData attribute of this object based
         * on the received JengaBlockData.
         ***/

        pieceData = data;
    }

    public string[] GetDisplayInfo()
    {
        /***
         * Return the strings of this block to be displayed
         * when selecting the piece.
         ***/

        return new string[] { pieceData.grade, pieceData.domain, pieceData.cluster, pieceData.standardid, pieceData.standarddescription };
    }

    public int GetMasteryValue()
    {
        /***
         * Return the mastery level stored on this current piece
         * object.
         ***/

        return pieceData.mastery;
    }

    #endregion


    #region Built-in Methods

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    #endregion
}
