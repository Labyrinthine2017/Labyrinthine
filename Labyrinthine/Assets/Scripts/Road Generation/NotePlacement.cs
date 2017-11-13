using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEditor;
using System.Text;
using System;
using System.Globalization;
using System.IO;
using System.Xml;
using System.Xml.Serialization;


public class NotePlacement : MonoBehaviour
{
    //beatPlacement / 1000.0f * playerSpeed
    [SerializeField] GameObject Player;
    private float playerSpeed;
    private float leftrightDistance;
    [SerializeField] Type type;

    private List<ObjectLoc> redList = new List<ObjectLoc>();

    public enum Type
    {
        Drones,
        Notes,
        HazardCar
    }
    [Serializable()]
    public class ObjectLoc
    {
        public ObjectLoc() { }
        public ObjectLoc(string n, float x, float y, float z)
        {
            name = n;
            xPos = x;
            yPos = y;
            zPos = z;
        }
        public string name;
        public float xPos;
        public float yPos;
        public float zPos;
    }
    // Use this for initialization
    void Start ()
    {
        playerSpeed = Player.GetComponent<PlayerMovement>().ForwardMovementSpeed;
        leftrightDistance = Player.GetComponent<PlayerMovement>().DifferenceInXBetweenPlatforms;
    }

    private void Update()
    {
        if(Input.GetKeyDown(KeyCode.Z))
        {
            ObjectLoc temp = new ObjectLoc(type.ToString(), 0.0f - leftrightDistance, 0.0f, Player.transform.position.z);
            redList.Add(temp);
        }
        if (Input.GetKeyDown(KeyCode.X))
        {
            ObjectLoc temp = new ObjectLoc(type.ToString(), 0.0f, 0.0f, Player.transform.position.z);
            redList.Add(temp);
        }
        if (Input.GetKeyDown(KeyCode.C))
        {
            ObjectLoc temp = new ObjectLoc(type.ToString(), 0.0f + leftrightDistance, 0.0f, Player.transform.position.z);
            redList.Add(temp);
        }
    }

    //void LoadNotesAndBadZone()
    //{
        
    //    //Load text file
    //    List<long> m_lBeatTimes = new List<long>();
    //    string[] stringList = new string[300];
    //    char[] removeVariables = new char[] { '\r', '\n' };

    //    string line = textFile.text;
    //    stringList = line.Split(removeVariables, StringSplitOptions.RemoveEmptyEntries);
    //    for (int i = 0; i < stringList.Length; i++)
    //    {
    //        m_lBeatTimes.Add(long.Parse(stringList[i]));
    //    }

    //    for (int i = 0; i < m_lBeatTimes.Count; i++)
    //    {
    //        int lane = UnityEngine.Random.Range(1, 4);
    //        GameObject tempNote = Instantiate(m_oCoolant, transform, true) as GameObject;
    //        GameObject tempDamage1 = Instantiate(damageZoneObject, transform, true) as GameObject;
    //        GameObject tempDamage2 = Instantiate(damageZoneObject, transform, true) as GameObject;
    //        if (lane == 1)
    //        {
    //            tempNote.transform.position = new Vector3(0.0f - leftrightDistance, 0.9f, m_lBeatTimes[i] / 1000.0f * playerSpeed);
    //            tempDamage1.transform.position = new Vector3(0.0f, 0.0f, m_lBeatTimes[i] / 1000.0f * playerSpeed + 15.77f);
    //            tempDamage2.transform.position = new Vector3(0.0f + leftrightDistance, 0.0f, m_lBeatTimes[i] / 1000.0f * playerSpeed + 15.77f);
    //        }
    //        if (lane == 2)
    //        {
    //            tempDamage1.transform.position = new Vector3(0.0f - leftrightDistance, 0.0f, m_lBeatTimes[i] / 1000.0f * playerSpeed + 15.77f);
    //            tempNote.transform.position = new Vector3(0.0f, 0.9f, m_lBeatTimes[i] / 1000.0f * playerSpeed);
    //            tempDamage2.transform.position = new Vector3(0.0f + leftrightDistance, 0.0f, m_lBeatTimes[i] / 1000.0f * playerSpeed + 15.77f);
    //        }
    //        if (lane == 3)
    //        {
    //            tempDamage1.transform.position = new Vector3(0.0f - leftrightDistance, 0.0f, m_lBeatTimes[i] / 1000.0f * playerSpeed + 15.77f);
    //            tempDamage2.transform.position = new Vector3(0.0f, 0.0f, m_lBeatTimes[i] / 1000.0f * playerSpeed + 15.77f);
    //            tempNote.transform.position = new Vector3(0.0f + leftrightDistance, 0.9f, m_lBeatTimes[i] / 1000.0f * playerSpeed);
    //        }
    //    }
    //}

    private void OnApplicationQuit()
    {
        UnityXMLSerializer.SerializeToXMLFile<List<ObjectLoc>>("ObjectLoc.xml", redList, true);     
    }
}
