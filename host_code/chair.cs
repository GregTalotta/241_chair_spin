using System.Collections;
using System.Collections.Generic;
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
            print("moved: " +sendstr);
            // port.Write(sendstr); // debug print
        }
        else{
            if(port != null){
                port.Open();
                port.ReadTimeout = 100;
                port.Write("a90\n");
            }
        }
    }

    void OnApplicationQuit(){
        port.Close();
    }
}