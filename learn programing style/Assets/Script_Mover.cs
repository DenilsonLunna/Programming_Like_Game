using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Script_Mover : MonoBehaviour
{
    //public Vector3 posOriginal;
    public float timer, xAxis, yAxis;
    public float posX, posY;
    public bool startMove;
    public bool left, right, up, down;
    public int numRepeticoes, varControle;
    public Vector3 posOriginal;
    public Script_Repita repita;
    public Vector3 vet;
    public Transform obj;
    // Start is called before the first frame update
    void Start()
    {
        //obj = transform;
        startMove = false;
    }

    // Update is called once per frame
    void Update()
    {
        //if( obj != null)startMove = repita.startMove;
        //startMove = repita.startMove;
        //Debug.Log(d);
        //if (startMove) Move();
    }

    public bool Move()
    {
        if (!startMove) return true;
        if(obj == null) obj = repita.platform;
        if (left && obj.position.x > posOriginal.x - numRepeticoes) obj.Translate(-xAxis, 0.0f, 0.0f);
        else if (right && obj.position.x < posOriginal.x + numRepeticoes) obj.Translate(xAxis, 0.0f, 0.0f);
        else if (up && obj.position.y < posOriginal.y + numRepeticoes) obj.Translate(0.0f, yAxis, 0.0f);
        else if (down && obj.position.y > posOriginal.y - numRepeticoes) obj.Translate(0.0f, -yAxis, 0.0f);
        else {
        	repita.isExecuting = false;
        	repita.startMove = false;
        	Debug.Log("Move");
        	startMove = false;
        	return false;
        }

        if (left || right)
        {
            posX = System.Math.Abs(System.Math.Abs(posOriginal.x) - System.Math.Abs(obj.position.x));
            if ((posX - varControle) >= 1) { Debug.Log("Instanciar +1"); varControle++; }
        }
        if (up || down)
        {
            posY = System.Math.Abs(System.Math.Abs(posOriginal.y) - System.Math.Abs(obj.position.y));
            if (posY - varControle >= 1) { Debug.Log("Instanciar +1"); varControle++; }
        }
        startMove = varControle != numRepeticoes ? true : false;
        return varControle != numRepeticoes ? true : false;
        

        //Debug.Log((posX - varControle)+" "+((posY - varControle) >= varControle)+" :::: "+(posY - varControle)+" "+((posX - varControle) >= varControle));
    }

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
}
