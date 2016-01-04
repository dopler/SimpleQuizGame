using UnityEngine;
using System.Collections;
using System.Collections.Generic;
using UnityEngine.UI;

public class GameController : MonoBehaviour 
{
	[System.Serializable]
	public class TriviaQuestion
	{
		public string question;
		public bool answer;

		public TriviaQuestion(string questionContent, bool trueFalse)
		{
			question = questionContent;
			answer = trueFalse;
		}
	}


	public List<TriviaQuestion> questions = new List<TriviaQuestion>();
	public int currentQuestion;
	public int count;
	public Text questionText;
	public Text questionNumber;
	public int score = 0;
	public int totalQuestions;
	public Button yes;
	public Button no;
	public Animator yesAnimator;
	public Animator noAnimator;






	// Use this for initialization
	void Start () 
	{
		count = 1;
		if(questions.Count > 0)
		{
			totalQuestions = questions.Count;
			currentQuestion = Random.Range(0,questions.Count);
			questionText.text = questions[currentQuestion].question;
		}
	
	}
	
	// Update is called once per frame
	void Update () 
	{
			
	}

	public void CheckTrue()
	{
		if(questions.Count>0)
		{
			if(questions[currentQuestion].answer == true)
			{
				score ++;
				yesAnimator.SetTrigger("correct");
			}
			else
			{
				noAnimator.SetTrigger("wrong");
			}
			StartCoroutine(TrueDelay());
			/*
			questions.RemoveAt (currentQuestion);
			if(questions.Count>0)
			{
				currentQuestion = Random.Range (0, questions.Count);
				questionText.text = questions[currentQuestion].question;
			}*/
		}
	}

	IEnumerator TrueDelay()
	{
		if(questions.Count>0)
		{	
			count++;
			questions.RemoveAt (currentQuestion);
			yes.interactable = false;
			no.interactable = false;
			yield return new WaitForSeconds(1);
			yes.interactable = true;
			no.interactable = true;

			if(questions.Count>0)
			{
				currentQuestion = Random.Range (0, questions.Count);
				questionText.text = questions[currentQuestion].question;
				questionNumber.text = "Question " + count.ToString() + ".)";
			}
			else
			{
				EndGame();
			}
		}

	}

	public void CheckFalse()
	{
		if(questions.Count>0)
		{
			if(questions[currentQuestion].answer == false)
			{
				score ++;
				yesAnimator.SetTrigger("correct");
			}
			else
			{
				noAnimator.SetTrigger("wrong");
			}
			StartCoroutine(FalseDelay());
			/*questions.RemoveAt (currentQuestion);
			if(questions.Count>0)
			{
				currentQuestion = Random.Range (0, questions.Count);
				questionText.text = questions[currentQuestion].question;
			}*/
		}
	}

	IEnumerator FalseDelay()
	{
		if(questions.Count>0)
		{
			count++;
			questions.RemoveAt (currentQuestion);
			yes.interactable = false;
			no.interactable = false;
			yield return new WaitForSeconds(1);
			yes.interactable = true;
			no.interactable = true;

			if(questions.Count>0)
			{
				currentQuestion = Random.Range (0, questions.Count);
				questionText.text = questions[currentQuestion].question;
				questionNumber.text = "Question " + count.ToString() + ".)";
			}
			else
			{
				EndGame();
			}
		}

	}

	public void EndGame()
	{
		Debug.Log ("GAME OVER: " + score);
		PlayerPrefs.SetInt ("totalQuestions", totalQuestions);
		PlayerPrefs.SetInt ("score", score);
	}
}
