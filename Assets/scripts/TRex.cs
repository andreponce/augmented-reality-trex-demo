using UnityEngine;
using System.Collections;

public class TRex : MonoBehaviour {

	public Camera camera;

	private Animation anim;
	private AudioSource[] audios;
	private AudioSource current_audio;

	private string anim_name = "stand";
	private float audio_delay = 0;

	// Use this for initialization
	void Start () {
		anim = GetComponent<Animation> ();
		audios = GetComponents<AudioSource>();
	}
	
	// Update is called once per frame
	void Update () {
		if (Input.GetMouseButtonDown (0)) {
			if(Input.mousePosition.x>190) executar();			
		}
		if (Input.GetKey (KeyCode.Q))
			andar ();
		if (Input.GetKey (KeyCode.W))
			correr ();
		if (Input.GetKey (KeyCode.E))
			descansar ();
		if (Input.GetKey (KeyCode.R))
			farejar ();
		if (Input.GetKey (KeyCode.T))
			rugir ();
		if (Input.GetKey (KeyCode.Y))
			ataque1 ();
		if (Input.GetKey (KeyCode.U))
			ataque2 ();
		if (Input.GetKey (KeyCode.I))
			ataque3 ();
		if (Input.GetKey (KeyCode.O))
			ataque4 ();
		if (Input.GetKey (KeyCode.P))
			hit1 ();
		if (Input.GetKey (KeyCode.A))
			hit2 ();
		if (Input.GetKey (KeyCode.S))
			morrer ();
	}

	public void executar()
	{
		CancelInvoke ("fim");
		anim.Stop ();
		anim.Play (anim_name);
		if (current_audio)
			current_audio.Stop ();

		if(anim_name!="walk" && anim_name!="run" && anim_name!="stand" && anim_name!="death") Invoke("fim", anim[anim_name].length);

		if(current_audio) current_audio.PlayDelayed (audio_delay);
	}

	private void fim()
	{
		//descansar ();
		string gambi = anim_name;
		AudioSource audio_gambi = current_audio;
		anim_name = "stand";
		current_audio = null;
		executar ();
		anim_name = gambi;
		current_audio = audio_gambi;
	}

	public void andar()
	{
		anim_name = "walk";
		current_audio = null;
		executar ();
	}

	public void correr()
	{
		anim_name = "run";
		current_audio = null;
		executar ();
	}

	public void descansar()
	{
		anim_name = "stand";
		current_audio = null;
		executar ();
	}

	public void farejar()
	{
		anim_name = "idle";
		current_audio = audios [3];
		audio_delay = .4f;
		executar ();
	}

	public void rugir()
	{
		Debug.Log ("ROARRRRRRRR");
		anim_name = "roar";
		current_audio = audios [2];
		audio_delay = .5f;
		executar ();
	}

	public void ataque1()
	{
		anim_name = "attack1";
		current_audio = audios [4];
		audio_delay = .3f;
		executar ();
	}

	public void ataque2()
	{
		anim_name = "attack2";
		current_audio = audios [4];
		audio_delay = .3f;
		executar ();
	}

	public void ataque3()
	{
		anim_name = "attack3";
		current_audio = null;
		executar ();
	}

	public void ataque4()
	{
		anim_name = "whip tail";
		current_audio = null;
		executar ();
	}

	public void hit1()
	{
		anim_name = "hit1";
		current_audio = null;
		executar ();
	}

	public void hit2()
	{
		anim_name = "hit2";
		current_audio = null;
		executar ();
	}

	public void morrer()
	{
		anim_name = "death";
		current_audio = null;
		executar ();
	}

	void OnGUI()
	{
		GUI.Box (new Rect (5, 5, 190, 570), "Comandos:");
		if (GUI.Button (new Rect (20, 30, 160, 40), "Descansar"))
			descansar ();
		if (GUI.Button (new Rect (20, 75, 160, 40), "Andar"))
			andar ();
		if (GUI.Button (new Rect (20, 120, 160, 40), "Correr"))
			correr ();
		if (GUI.Button (new Rect (20, 165, 160, 40), "Farejar"))
			farejar ();
		if (GUI.Button (new Rect (20, 210, 160, 40), "Rugir"))
			rugir ();
		if (GUI.Button (new Rect (20, 255, 160, 40), "Ataque 1"))
			ataque1 ();
		if (GUI.Button (new Rect (20, 300, 160, 40), "Ataque 2"))
			ataque2 ();
		if (GUI.Button (new Rect (20, 345, 160, 40), "Ataque 3"))
			ataque3 ();
		if (GUI.Button (new Rect (20, 390, 160, 40), "Ataque 4"))
			ataque4 ();
		if (GUI.Button (new Rect (20, 435, 160, 40), "Hit 1"))
			hit1 ();
		if (GUI.Button (new Rect (20, 480, 160, 40), "Hit 2"))
			hit2 ();
		if (GUI.Button (new Rect (20, 525, 160, 40), "Morrer"))
			morrer ();
	}
}
