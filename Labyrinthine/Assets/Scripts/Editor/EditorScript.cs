using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEditor;
using System.Text;
using System.IO;
using System.Globalization;

public class EditorScript : MonoBehaviour
{

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

		Object m_oCoolant = AssetDatabase.LoadAssetAtPath("Assets/Prefabs/Pickup_CoolantNode.prefab", typeof(GameObject));
       
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
     


}
