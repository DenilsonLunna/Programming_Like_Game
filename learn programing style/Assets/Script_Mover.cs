using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Script_Mover : MonoBehaviour
{
    
    //Indicates if the script is running or not
    public bool running;
    // object to execute the action
    public Transform obj;
    // how much should the object move on the X and Y axis
    public float xAxis, yAxis;
    public float posX, posY;
    // Tells the script when to start move
    public bool startMove, startMoveSingle;
    // which direction the 'mova' or 'girar' should act on
    public bool left, right, up, down;
    // number of repetitions // variable to control the distance 
    public int numRepeticoes, varControle;
    // holds the position where the obj started to move
    public Vector3 posOriginal;
    // reference to its possible father
    public Script_Repita repita;
    public Script_Testar arasta;
    public Vector3 vet;
    public bool setup;
    
    // Start is called before the first frame update
    void Start()
    {
        //obj = transform;
        startMove = false;
    }

    // Update is called once per frame
    void Update()
    {

    	if (!running) return;
        if (startMoveSingle) Move();
        if (setup) SetupParameters();
        
    }

    public bool Move()
    {

        // if shoudn`t move, return
        if (!startMove && !startMoveSingle) return true;
        // if the object in this script is null, set it to its father`s object
        if(obj == null) obj = repita.obj;
        // checks which direction should move
        if (left && obj.position.x > posOriginal.x - numRepeticoes) obj.Translate(-xAxis, 0.0f, 0.0f, Space.World);
        else if (right && obj.position.x < posOriginal.x + numRepeticoes) obj.Translate(xAxis, 0.0f, 0.0f, Space.World);
        else if (up && obj.position.y < posOriginal.y + numRepeticoes) obj.Translate(0.0f, yAxis, 0.0f, Space.World);
        else if (down && obj.position.y > posOriginal.y - numRepeticoes) obj.Translate(0.0f, -yAxis, 0.0f, Space.World);
        else {
            // if the object is the wanted position, reset all the control variables
        	repita.isExecuting = false;
        	repita.startMove = false;
        	Debug.Log("Move");
        	startMove = false;
        	return false;
        }

        // calculates the current traveled distance on the X axis
        if (left || right)
        {
            posX = System.Math.Abs(System.Math.Abs(posOriginal.x) - System.Math.Abs(obj.position.x));
            if ((posX - varControle) >= 1) { Debug.Log("Instanciar +1"); varControle++; }
        }
        // calculates the current traveled distance on the Y axis
        if (up || down)
        {
            posY = System.Math.Abs(System.Math.Abs(posOriginal.y) - System.Math.Abs(obj.position.y));
            if (posY - varControle >= 1) { Debug.Log("Instanciar +1"); varControle++; }
        }
        startMoveSingle = varControle != numRepeticoes ? true : false;
        running = startMoveSingle;
        arasta.running = running == true ? false : true;
        // if varControle different than number of repetitions return true, else, return false
        return varControle != numRepeticoes ? true : false;
        

        //Debug.Log((posX - varControle)+" "+((posY - varControle) >= varControle)+" :::: "+(posY - varControle)+" "+((posX - varControle) >= varControle));
    }

    // gets the parameters of block repita and passes it to this script
    public void AdjustParameters(bool startMove, bool left, bool right, bool up, bool down, int numRepeticoes, int varControle, Vector3 posOriginal, Transform obj) {
        this.startMove = startMove;
        this.left = left;
        this.right = right;
        this.up = up;
        this.down = down;
        this.numRepeticoes = numRepeticoes;
        this.varControle = varControle;
        this.posOriginal = posOriginal;
        this.obj = obj;
        if (right) this.vet = new Vector3(posOriginal.x + numRepeticoes, posOriginal.y,0);
        if (left) this.vet = new Vector3(posOriginal.x - numRepeticoes, posOriginal.y, 0);
        if (up )    this.vet = new Vector3(posOriginal.x, posOriginal.y + numRepeticoes,0);
        if (down) this.vet = new Vector3(posOriginal.x, posOriginal.y - numRepeticoes, 0);
    }

    public void SetupParameters(){
        posOriginal = obj.position;
        AdjustParameters(false, left, right, up, down, 1, 0, posOriginal, obj);
    }
}
