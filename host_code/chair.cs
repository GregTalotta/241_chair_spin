using System.Collections;
using System.Collections.Generic;
using System;
using System.IO.Ports;
using UnityEngine;

public class Chair
{
    SerialPort port = new SerialPort("COM3", 9600); //Set the board COM
    // Start is called before the first update
    public void Start()
    {
        port.Open();
        if (port !=null &&port.IsOpen)
        {
            port.Write("start");
        }
    }

    // move is called once per update
    public void Move(double angle)
    {
        if (port !=null &&port.IsOpen)
        {
            int true_angle = (int) angle + 90;
            if((true_angle < 10)||(true_angle > 170)){
                port.Write("a90"); // reset to midpoint
            }
            port.Write("a" + true_angle);
        }
    }

    public void End()
    {
        if (port !=null &&port.IsOpen)
        {
            port.Write("end");
        }
        port.Close();
    }
}