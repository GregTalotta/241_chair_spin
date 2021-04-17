using System;
using System.IO.Ports;


public class chair
{
    SerialPort port = new SerialPort("COM7", 9600); //Set the board COM
    
    // Start is called before the first update
    void Start()
    {
        port.Open();
    }

    // move is called once per update
    void move(double angle)
    {
        if (port !=null &&port.IsOpen)
        {
            portWrite((int) angle);
        }
    }
}