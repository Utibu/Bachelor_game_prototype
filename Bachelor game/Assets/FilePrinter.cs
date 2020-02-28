using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System.IO;
using System.Xml;
using System.Xml.Serialization;

public class FilePrinter : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void SaveFile(string identifier)
    {
        BachelorFileData fileData = new BachelorFileData();
        fileData.version = GameManager.Instance.Version.ToString();
        fileData.identifier = identifier;

        for (int i = 0; i < GameManager.Instance.taskManager.taskTimes.Count; i++)
        {
            TimeData temp = new TimeData("Task " + (i + 1), GameManager.Instance.taskManager.taskTimes[i]);
            fileData.timeData.Add(temp);
        }

        fileData.Save(identifier + ".xml");
    }
}

[XmlRoot("BachelorTimeData")]
public class BachelorFileData
{
    [XmlArray("TimeData")]
    [XmlArrayItem("DataEntry")]
    public List<TimeData> timeData = new List<TimeData>();
    public string version;
    public string identifier;

    public void Save(string path)
    {
        var serializer = new XmlSerializer(typeof(BachelorFileData));
        using (var stream = new FileStream(path, FileMode.Create))
        {
            serializer.Serialize(stream, this);
        }
    }
}

public class TimeData
{
    public string title;
    public float time;

    public TimeData(string title, float time)
    {
        this.title = title;
        this.time = time;
    }

    public TimeData()
    {

    }
}