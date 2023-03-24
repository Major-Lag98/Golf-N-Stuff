using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MoveTrack : MonoBehaviour
{
    public float maxDistUnit = 10; 
    public float minDistUnit = -10 ;
    public float intenstity  = 2f; 
    private bool switched  = true; 
    private float currDist = 0 ;
    public enum Way
    {
        HORZ,
        VERT,
        
    }
    public enum Type
    {
        MOVE,
        ROTATE
    }
   [SerializeField] private Way arrow = Way.VERT ;
   [SerializeField] public  Type path = Type.ROTATE ; 
    public float perUnit = 1f  ; 
    private float rotate ; 
    void Start()
    {
        perUnit = perUnit * intenstity ;


    }
    // Update is called once per frame
    void Update()
    {
        if( path != Type.ROTATE)
        {

            moveObject(arrow);
        }
        else
        {
            rotateObject(arrow);

                 

        }
    }
    public void moveObject(Way path )
    {
            //test if we have reached the upper boudns or not
            bool test = true;
             arrow = path;
            float posX = this.transform.position.x  ;  
            float posY = this.transform.position.y ;
            
            //check if vertial movment or horizontal
                switch (arrow)
                {
                   
                    //if vertical
                    case(Way.VERT):
                         posX = this.transform.position.x  ;
                        posY = LeftOrRightMove(switched,  posY) ; 
                    break;
                    //if horizontal
                    case(Way.HORZ):
                        posY =  this.transform.position.y ;
                        posX = LeftOrRightMove(switched,  posX) ; 
                    
                    break;                
                }
            this.transform.position = new Vector3 (posX,posY,this.transform.position.z);
            test = currDist < maxDistUnit && currDist > minDistUnit;
            //check if in range
            if( !test)
            {
                //go towards new postion
                 switched = !switched ; 
           
            }
         

    }
    private float LeftOrRightMove(bool switched, float pos)
    {
        if( switched )
        {
            //decirment
            currDist+=perUnit * Time.deltaTime;  
            pos =pos+   perUnit * Time.deltaTime;
        }
        else
        {
            currDist-=perUnit* Time.deltaTime; ;
            //incriment
            pos=pos- perUnit * Time.deltaTime;
        }     
    
        return pos ; 

    }
    public void rotateObject(Way path)
    {
        arrow = path ;
        Vector3 rotationToAdd  = Vector3.zero;
        switch(arrow)
        {
            case(Way.VERT):
            rotationToAdd = new Vector3(0, 0, perUnit* Time.deltaTime);
                 
               

            break;
            case(Way.HORZ):
                    rotationToAdd = new Vector3(0, perUnit* Time.deltaTime, 0);


            break;

        }


         this.transform.Rotate(rotationToAdd);

    }

}
