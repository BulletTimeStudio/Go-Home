using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class PlayerController : MonoBehaviour
{

    public CharacterController Player;
    //Movimiento Player
    public float horizontalMove;
    public float playerSpeed;
    private Vector3 movePlayer;
    //Gravedad
    public float gravity = 9.8f;
    public float fallVelocity;
    public float jumpForce;
    public float jumpCont = 0;
    
    private Vector3 playerInput;
    
     //Start is called before the first frame update
    void Start()
    {
        Player = GetComponent<CharacterController>();
    }

    // Update is called once per frame
    void Update()
    {
        horizontalMove = Input.GetAxis("Horizontal");
        playerInput = new Vector3(horizontalMove, 0, 0);
        playerInput = Vector3.ClampMagnitude(playerInput, 1);

        movePlayer = playerInput * playerSpeed;
        
        Player.transform.LookAt(Player.transform.position + movePlayer);
        //inicia la funcion de la gravedad
        SetGravity();
        
        playerSkills();
        //Movimiento ya calculado
        Player.Move(movePlayer * Time.deltaTime);
        
        if (Input.GetKey(KeyCode.Z) && Player.isGrounded)
        {
            playerSpeed = 10;
        }
        
        if (Input.GetKeyUp(KeyCode.Z))
        {
            playerSpeed = 5;
        }

        if (Player.transform.position.x <= -4.307246 && Player.transform.position.y >= 20)
        {
            SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex + 2);
        }
        
        if (Player.isGrounded)
        {
            jumpCont = 0;
        }
    }
    
    //Habilidades del player
    public void playerSkills()
    {
        if (Player.isGrounded && Input.GetButtonDown("Jump") && jumpCont == 0)
        {
            fallVelocity = jumpForce;
            movePlayer.y = fallVelocity;
            jumpCont = jumpCont + 1;
        }
        
        if (Player.isGrounded == false && Input.GetButtonDown("Jump") && jumpCont == 1)
        {
            fallVelocity = jumpForce;
            movePlayer.y = fallVelocity;
            jumpCont = 0;
        }
    }
    
    
    //Funcion que controla la gravedad
    void SetGravity()
    {
        
        if (Player.isGrounded)
        {
            fallVelocity = -gravity * Time.deltaTime;
            movePlayer.y = fallVelocity;
        }
        else
        {
            fallVelocity -= gravity * Time.deltaTime;
            movePlayer.y = fallVelocity;
        }
    }
}
