using System.IO.Ports;


public class chair
{
    SerialPort sp = new SerialPort(path, 9600);
    
    // Start is called before the first frame update
    void Start()
    {
        sp.Open();
        sp.ReadTimeout = 100;
    }

    // move is called once per frame
    void move()
    {
        if (sp.IsOpen){
            try{
            }
            catch (System.Exception){
               
            }

        }
    }
}