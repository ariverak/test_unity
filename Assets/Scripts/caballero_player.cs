using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class caballero_player : MonoBehaviour {

	private Rigidbody2D _rb2d;
	public float maxVelocidad; 
	bool voltear = true;
	SpriteRenderer _caballeroRender;

	Animator _caballeroAnim;

	bool puedeMover = true;

	float checkedRadioSuelo = 0.2f;
	public LayerMask capaSuelo;

	public Transform checkearSuelo;
	bool enSuelo = false;

	public float poderSalto;

	void Start () {
		_rb2d = GetComponent<Rigidbody2D>();
		_caballeroRender = GetComponent<SpriteRenderer>();
		_caballeroAnim = GetComponent<Animator>();
	}
	
	// Update is called once per frame
	void Update () {
		float mover = Input.GetAxis("Horizontal");

		if(puedeMover && enSuelo && Input.GetAxis("Jump") > 0){
			_caballeroAnim.SetBool("estaEnSuelo",false);
			_rb2d.velocity = new Vector2(_rb2d.velocity.x, 0f );
			_rb2d.AddForce(new Vector2(0,poderSalto),ForceMode2D.Impulse);
			enSuelo = false;
		}

		enSuelo = Physics2D.OverlapCircle(checkearSuelo.position,checkedRadioSuelo,capaSuelo);
		_caballeroAnim.SetBool("estaEnSuelo",enSuelo);

		if(puedeMover){
			if(mover > 0 && !voltear){
				VoltearCaballero();
			}else if(mover < 0 && voltear){
				VoltearCaballero();
			}
	     	_rb2d.velocity = new Vector2(mover * maxVelocidad,_rb2d.velocity.y);
			 _caballeroAnim.SetFloat("VelMovimiento",Mathf.Abs(mover));
		}else{
			_rb2d.velocity = new Vector2(0,_rb2d.velocity.y);
			_caballeroAnim.SetFloat("VelMovimiento",0);
		}
		
	}

	private void VoltearCaballero(){
		voltear = !voltear;
		_caballeroRender.flipX = !_caballeroRender.flipX;
	}
		public void TogglePuedeMover(){
			puedeMover = !puedeMover;
	}
}
