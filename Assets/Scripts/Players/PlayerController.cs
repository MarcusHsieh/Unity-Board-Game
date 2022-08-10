// lets get coding mook!! ٩(●˙▿˙●)۶…⋆ฺ

using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;
using MookCode._FallTile;
using MookCode.GlobalData;

namespace MookCode.NPlayers
{
    
    public class PlayerController : MonoBehaviour {

		[SerializeField] private float m_JumpForce = 400f;                          // Amount of force added when the player jumps
		[SerializeField] private float m_DashForce = 1000f;							// Amount of force added when the player dashes
		[Range(0, 1)][SerializeField] private float m_CrouchSpeed = .36f;           // Amount of maxSpeed applied to crouching movement  1 = 100%
		[Range(0, .3f)][SerializeField] private float m_MovementSmoothing = .05f;   // How much to smooth out the movement
		[SerializeField] private float m_TimeBetweenDash = 1.2f;                    // Amount of time between each slap
		[SerializeField] private float m_TimeBeforeNextDash = 0f;                   // m_TimeBeforeNextDash = m_TimeBetweenDash + Time.time
		[SerializeField] private float m_Direction = 1f;                            // +1 (right) or -1 (left) for dash direction
		[SerializeField] private bool m_AirControl = true;                         // Whether or not a player can steer while jumping;
		[SerializeField] private LayerMask m_WhatIsGround;                          // A mask determining what is ground to the character
		[SerializeField] private Transform m_GroundCheck;                           // A position marking where to check if the player is grounded
		[SerializeField] private Transform m_CeilingCheck;                          // A position marking where to check for ceilings
		[SerializeField] private Collider2D m_CrouchDisableCollider;                // A collider that will be disabled when crouching
		public ParticleSystem DashPS;

		const float k_GroundedRadius = .2f; // Radius of the overlap circle to determine if grounded
		private bool m_Grounded;            // Whether or not the player is grounded.
		const float k_CeilingRadius = .2f; // Radius of the overlap circle to determine if the player can stand up
		private Rigidbody2D m_Rigidbody2D;
		private bool m_FacingRight = true;  // For determining which way the player is currently facing.
		private Vector3 m_Velocity = Vector3.zero;

		[Header("Events")]
		[Space]

		public UnityEvent OnLandEvent;

		public UnityEvent OnDashEvent;

		[System.Serializable]
		public class BoolEvent : UnityEvent<bool> {
		}

		public BoolEvent OnCrouchEvent;
		private bool m_wasCrouching = false;

		private void Awake() {
			m_Rigidbody2D = GetComponent<Rigidbody2D>();

			if (OnLandEvent == null)
				OnLandEvent = new UnityEvent();

			if (OnDashEvent == null) {
				OnDashEvent = new UnityEvent();
			}

			if (OnCrouchEvent == null)
				OnCrouchEvent = new BoolEvent();
		}

		private void FixedUpdate() {
			bool wasGrounded = m_Grounded;
			m_Grounded = false;

			// check for jump on block layer
			Collider2D[] colliders = Physics2D.OverlapCircleAll(m_GroundCheck.position, k_GroundedRadius, m_WhatIsGround);
			for (int i = 0; i < colliders.Length; i++) {
				if (colliders[i].gameObject != gameObject) {
					m_Grounded = true;
					if (!wasGrounded)
						OnLandEvent.Invoke();
				}
			}
			// check for jump on players layer
			Collider2D[] pColliders = Physics2D.OverlapCircleAll(m_GroundCheck.position, k_GroundedRadius);
			for (int i = 0; i < pColliders.Length; i++) {
				if (pColliders[i].gameObject != gameObject) {
					m_Grounded = true;
					if (!wasGrounded)
						OnLandEvent.Invoke();
				}
			}
		}
        private void OnCollisionEnter2D(Collision2D col) {
			Debug.Log(col);
			Debug.Log(col.gameObject.layer);
			if (col.gameObject.layer == 11 && !Data.hasGameEnded) { // 11 == FallBlock layer
				//Debug.Log("Die");

				FindObjectOfType<StressReceiver>().InduceStress(.5f);
				gameObject.GetComponent<PlayerMovement>().pDeath();
				Destroy(gameObject);
				Destroy(col.gameObject);
			}
			if (col.gameObject.layer == 13) { // 13 == Players layer
				m_Grounded = true;
			}
        }

		public void enableDashPS() {
			DashPS.GetComponent<Transform>().localScale = new Vector2(m_Direction, 1);
			DashPS.Play();
		}

		public void Move(float move, bool crouch, bool jump, bool dash) {
			// If crouching, check to see if the character can stand up
			if (!crouch) {
				// If the character has a ceiling preventing them from standing up, keep them crouching
				if (Physics2D.OverlapCircle(m_CeilingCheck.position, k_CeilingRadius, m_WhatIsGround)) {
					crouch = true;
				}
			}

			//only control the player if grounded or airControl is turned on
			if (m_Grounded || m_AirControl) {

				// If crouching
				if (crouch) {
					if (!m_wasCrouching) {
						m_wasCrouching = true;
						OnCrouchEvent.Invoke(true);
					}

					// Reduce the speed by the crouchSpeed multiplier
					move *= m_CrouchSpeed;

					// Disable one of the colliders when crouching
					if (m_CrouchDisableCollider != null)
						m_CrouchDisableCollider.enabled = false;
				}
				else {
					// Enable the collider when not crouching
					if (m_CrouchDisableCollider != null)
						m_CrouchDisableCollider.enabled = true;

					if (m_wasCrouching) {
						m_wasCrouching = false;
						OnCrouchEvent.Invoke(false);
					}
				}

				// Move the character by finding the target velocity
				Vector3 targetVelocity = new Vector2(move * 10f, m_Rigidbody2D.velocity.y);
				// And then smoothing it out and applying it to the character
				m_Rigidbody2D.velocity = Vector3.SmoothDamp(m_Rigidbody2D.velocity, targetVelocity, ref m_Velocity, m_MovementSmoothing);

				// If the input is moving the player right and the player is facing left...
				if (move > 0 && !m_FacingRight) {
					// ... flip the player.
					Flip();
				}
				// Otherwise if the input is moving the player left and the player is facing right...
				else if (move < 0 && m_FacingRight) {
					// ... flip the player.
					Flip();
				}
			}
			// If the player should jump...
			if (m_Grounded && jump) {
				// Add a vertical force to the player
				m_Grounded = false;
				m_Rigidbody2D.AddForce(new Vector2(0f, m_JumpForce));
			}
			if (Time.time > m_TimeBeforeNextDash && dash) {
				// Add horizontal force to the player
				m_TimeBeforeNextDash = m_TimeBetweenDash + Time.time;
				m_Rigidbody2D.AddForce(new Vector2(m_DashForce * m_Direction, 0f));
				OnDashEvent.Invoke();
			}
		}


		private void Flip() {
			// Switch the way the player is labelled as facing.
			m_FacingRight = !m_FacingRight;
			m_Direction *= -1;
			// Multiply the player's x local scale by -1.
			Vector3 theScale = transform.localScale;
			theScale.x *= -1;
			transform.localScale = theScale;
		}
	}
}
