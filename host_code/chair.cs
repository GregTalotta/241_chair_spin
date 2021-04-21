using System.Collections;
using System.Collections.Generic;
// using System;
using UnityEngine;
using System.IO.Ports;
using System.Threading;

public class Chair : MonoBehaviour
{
    public static SerialPort port = new SerialPort("COM3", 9600); //Set the board COM
    // Start is called before the first update
    void Start()
    {
        OpenCom();
    }

    public void OpenCom(){
        if(port != null){
            port.DtrEnable = true;
            port.RtsEnable = true;
            if(port.IsOpen){
                port.Close();
                print("Closing port, because it's already open");
            }
            else
            {
                port.Open();
                port.ReadTimeout = 100;
                port.Write("a90\n");
            }
        }
        else{
            if(port.IsOpen)
            {
                print("port is already open");
            }
            else{
                print("port == null");
            }
        }
    }
    // move is called once per update
    public static void Move(int angle)
    {
        if(port.IsOpen){
            int true_angle = (int) angle;
            string sendstr = "a" + true_angle +"\n";
            // if((true_angle < 10)||(true_angle > 170)){
            //     sendstr = "a90\n"; // reset to midpoint
            // }
            print("moved: " +sendstr);
            port.Write(sendstr);
        }
        else{
            if(port != null){
                port.Open();
                port.ReadTimeout = 100;
                port.Write("a90\n");
            }
        }
        // if (port !=null &&port.IsOpen)
        // {
        //     int true_angle = (int) angle + 90;
        //     if((true_angle < 10)||(true_angle > 170)){
        //         port.Write("a90"); // reset to midpoint
        //     }
        //     port.Write("a" + true_angle);
        // }
    }

    void OnApplicationQuit(){
        port.Close();
    }
}