using UnityEngine;
using System.Collections;
using UnityEngine.UI;

public class FinalScreenScript : MonoBehaviour 
{
	public Text correct;
	public Text total;

	// Use this for initialization
	void Start () 
	{
		total.text = PlayerPrefs.GetInt ("totalQuestions").ToString();
		correct.text = PlayerPrefs.GetInt ("score").ToString();
	}
	
	// Update is called once per frame
	void Update () 
	{
	
	}
}
