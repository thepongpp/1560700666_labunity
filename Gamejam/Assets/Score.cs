using UnityEngine;
using System.Collections;
using UnityEngine.UI;

public class Score : MonoBehaviour
{
	private int _Score = 0;
	
	public Text _TxtScore;
	
	public void OnTriggerEnter2D(Collider2D collider)
	{
		if (collider.gameObject.tag == "Score")
		{
			_Score++;
			_TxtScore.text = _Score.ToString();
		}
	}
}