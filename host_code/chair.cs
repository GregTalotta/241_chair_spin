using System;
using System.IO.Ports;


public class chair
{
    SerialPort port = new SerialPort("COM7", 9600); //Set the board COM
    // Start is called before the first update
    void Start()
    {
        port.Open();
        if (port !=null &&port.IsOpen)
        {
            portWrite("start");
        }
    }

    // move is called once per update
    void Move(double angle)
    {
        if (port !=null &&port.IsOpen)
        {
            int true_angle = (int) angle + 90;
            if((true_angle < 10)||(true_angle > 170)){
                portWrite("a90"); // reset to midpoint
            }
            portWrite("a" + true_angle);
        }
    }

    void End()
    {
        if (port !=null &&port.IsOpen)
        {
            portWrite("end");
        }
        port.Close();
    }
}