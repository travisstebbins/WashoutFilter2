using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System.IO;

public class FileWriter : MonoBehaviour
{
	StreamWriter writer;

	void Start()
	{
		string path = "Assets/Resources/" + GameManager.instance.participantID + "_" + GameManager.instance.sessionID + ".csv";

		writer = new StreamWriter(path, false);
		writer.WriteLine ("time,x,y,z");
	}

	void Update ()
	{
		string line = Time.time.ToString();
		float adjustedYRotation = Camera.main.transform.rotation.eulerAngles.y > 180 ? Camera.main.transform.rotation.eulerAngles.y - 360 : Camera.main.transform.rotation.eulerAngles.y;
		line += ("," + Camera.main.transform.rotation.eulerAngles.x + "," + adjustedYRotation + "," + Camera.main.transform.rotation.eulerAngles.z);
		writer.WriteLine (line);
	}

	void OnDisable()
	{
		Debug.Log ("about to close writer");
		writer.Close ();
		Debug.Log ("closed writer");
	}
}
