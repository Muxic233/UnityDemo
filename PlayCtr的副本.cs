using UnityEngine;
using System.Collections;

public class PlayCtr : MonoBehaviour {
	[SerializeField]
	private ETCJoystick joyStick;
	private StateMachine m_StateMachine;
	public Animation ani;
	// Use this for initialization
	void Start () {
		ani = GetComponent<Animation> ();
		m_StateMachine = new StateMachine (new IdleState (0, this));
		InitState ();
	}

	void InitState(){
		m_StateMachine.RegisterState (new RunState (1, this));
	}
	
	// Update is called once per frame
	void Update () {
		float x = joyStick.axisX.axisValue;
		float z = joyStick.axisY.axisValue;
		if (x!=0||z!=0) {
			transform.LookAt (new Vector3 (x, 0, z) + transform.position);
			m_StateMachine.TranslateToTstate (1);
		}
	}

	void LateUpdate(){
		m_StateMachine.FSMUpdate ();
	}
}
