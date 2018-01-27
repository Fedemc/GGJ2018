using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TableManager : MonoBehaviour {
    public int TableID;
    public float X_Offset = 1f;

    private GameObject playerAssigned;
    private GameObject[] tablePositions;

	// Use this for initialization
	void Start ()
    {
        //Obtengo los hijos de la mesa (sus posiciones) y agrego cada pos a un array
        tablePositions = new GameObject[transform.childCount];
        for (int i=0;i<transform.childCount;i++)
        {
            tablePositions[i] = transform.GetChild(i).gameObject;
            //Debug.Log(tablePositions[i].name);
        }
        
        //Averiguo que player soy dependiendo que ID de mesa tengo (TableID=1 -> Player1, TableID=2 -> Player2)
        playerAssigned = GameObject.Find(string.Format("Player{0}", TableID));

        //Posiciono al player en la 1er pos de su mesa correspondiente, aplicando el offset para acomodarlo a un costado
        if(TableID==1)
        {
            playerAssigned.transform.position = tablePositions[0].transform.position - new Vector3(X_Offset, 0, 0);
        }
        else
        {
            playerAssigned.transform.position = tablePositions[0].transform.position + new Vector3(X_Offset, 0, 0);
        }
    }

    public GameObject[] GetTablePositions()    //Devuelve un array con las posiciones de la mesa
    {
        return tablePositions;
    }
	
    // Update is called once per frame
    void Update ()
    {
		
	}
    

}
