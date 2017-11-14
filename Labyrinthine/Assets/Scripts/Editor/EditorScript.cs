using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEditor;
using System.Text;
using System.IO;
using System.Globalization;
using System.Xml;
using System.Xml.Serialization;

public class EditorScript : MonoBehaviour
{
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

    public float beatPlacement = 90.0f; 
    [MenuItem("Coolant Nodes/Load Coolant Nodes")]
    private static void LoadCoolant()
    {
        //Creating a list of longs that will contain  
        List<long> m_lBeatTimes = new List<long>();

        string file = EditorUtility.OpenFilePanel("Select file", "", "txt");
        
        //Load text file
        string line;
        StreamReader streamreader = new StreamReader(file, Encoding.Default);

        using (streamreader)
        {
            do
            {
                line = streamreader.ReadLine();

                if (line != null)
                {
                    long time = long.Parse(line, CultureInfo.InvariantCulture.NumberFormat);
                    m_lBeatTimes.Add(time);
                }
            }
            while (line != null);

            streamreader.Close();
        }

		Object m_oCoolant = AssetDatabase.LoadAssetAtPath("Assets/Prefabs/Pickup_CoolantNode_Unwrapped.prefab", typeof(GameObject));
       
        //needs to load all beats played into an array that will covert time to distance 
        //adding a list of long to unity 

        for (int i = 0; i < m_lBeatTimes.Count; ++i)
        {
            GameObject m_goCollantClone = Instantiate(m_oCoolant, Vector3.zero, Quaternion.identity) as GameObject;

            //has to contain all milleseconds that are already converted to distance
			m_goCollantClone.transform.position = new Vector3(0, 0.9f, m_lBeatTimes[i] / 1000.0f * 90.0f);
            Undo.RegisterCreatedObjectUndo(m_goCollantClone, "Created Coolant Nodes");
        }        
    }
    [MenuItem("Coolant Nodes/Load From XML")]
    private static void LoadFromXML()
    {
        List<ObjectLoc> temp = new List<ObjectLoc>();
        GameObject Hazards = GameObject.FindGameObjectWithTag("Hazards");
        GameObject Beats = GameObject.FindGameObjectWithTag("Notes");
        Object drone = AssetDatabase.LoadAssetAtPath("Assets/Prefabs/SmelterDrone.prefab", typeof(GameObject));
        Object node = AssetDatabase.LoadAssetAtPath("Assets/Prefabs/NodeObject.prefab", typeof(GameObject));
        Object car = AssetDatabase.LoadAssetAtPath("Assets/Prefabs/HazardCar.prefab", typeof(GameObject));
        TextReader reader = null;
        try
        {
            var serializer = new XmlSerializer(typeof(List<ObjectLoc>));
            reader = new StreamReader("ObjectLoc.xml");
            temp = (List<ObjectLoc>)serializer.Deserialize(reader);
        }
        finally
        {
            if (reader != null)
                reader.Close();
        }

        for(int i = 0; i < temp.Count; i ++)
        {
            if(temp[i].name == "Drones")
            {
                GameObject tempObject = Instantiate(drone, GameObject.FindGameObjectWithTag("Hazards").transform) as GameObject;
                tempObject.transform.position = new Vector3(temp[i].xPos, 5.0f, temp[i].zPos);
                tempObject.transform.SetParent(Hazards.transform);
            }
            if(temp[i].name == "Notes")
            {
                GameObject tempObject = Instantiate(node, GameObject.FindGameObjectWithTag("Notes").transform) as GameObject;
                tempObject.transform.position = new Vector3(temp[i].xPos, 0.9f, temp[i].zPos);
                tempObject.transform.SetParent(Beats.transform);
            }
            if(temp[i].name == "HazardCar")
            {
                GameObject tempObject = Instantiate(car, GameObject.FindGameObjectWithTag("Hazards").transform) as GameObject;
                tempObject.transform.position = new Vector3(temp[i].xPos, 0.5f, temp[i].zPos);
                tempObject.transform.rotation = Quaternion.Euler(0.0f, Random.Range(0.0f, 360.0f), 0.0f);
                tempObject.transform.SetParent(Hazards.transform);
            }
        }

    }
    [MenuItem("Coolant Nodes/Load Road")]
    private static void LoadRoad()
    {
        Object road = AssetDatabase.LoadAssetAtPath("Assets/Prefabs/Full_Road.prefab", typeof(GameObject));
        float zLoc = 33.88f;
        while (zLoc < 11000.0f)
        {
            Instantiate(road, new Vector3(3.84f, 0.0f, zLoc), Quaternion.identity, GameObject.FindGameObjectWithTag("Road").transform);
            zLoc += 78.79f;
        }

    }
    [MenuItem("Coolant Nodes/Reload Current Objects")]
    private static void Reload()
    {
        List<ObjectLoc> objects = new List<ObjectLoc>();
        Object drone = AssetDatabase.LoadAssetAtPath("Assets/Prefabs/SmelterDrone.prefab", typeof(GameObject));
        Object node = AssetDatabase.LoadAssetAtPath("Assets/Prefabs/NodeObject.prefab", typeof(GameObject));
        Object car = AssetDatabase.LoadAssetAtPath("Assets/Prefabs/HazardCar.prefab", typeof(GameObject));

        GameObject beats = GameObject.FindGameObjectWithTag("Notes");
        GameObject hazards = GameObject.FindGameObjectWithTag("Hazards");

        for(int i = 0; i < beats.transform.childCount; i ++)
        {
            objects.Add(new ObjectLoc("Notes", beats.transform.GetChild(i).position.x, beats.transform.GetChild(i).position.y, beats.transform.GetChild(i).position.z));
        }
        for(int i = beats.transform.childCount - 1; i > -1; i --)
        {
            DestroyImmediate(beats.transform.GetChild(i).gameObject);
        }
        for (int i = 0; i < hazards.transform.childCount; i++)
        {
            objects.Add(new ObjectLoc("HazardCar", hazards.transform.GetChild(i).position.x, hazards.transform.GetChild(i).position.y, hazards.transform.GetChild(i).position.z));
        }
        for (int i = hazards.transform.childCount - 1; i > -1; i--)
        {
            DestroyImmediate(hazards.transform.GetChild(i).gameObject);
        }

        for(int i = 0; i < objects.Count; i ++)
        {
            if(objects[i].name == "Notes")
            {
                Instantiate(node, new Vector3(objects[i].xPos, objects[i].yPos, objects[i].zPos), Quaternion.identity, beats.transform);
            }
            if(objects[i].name == "HazardCar")
            {
                Instantiate(node, new Vector3(objects[i].xPos, objects[i].yPos, objects[i].zPos), Quaternion.identity, hazards.transform);
            }
        }

        LoadFromXML();
    }

}
