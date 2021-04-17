// Greg Talotta
const int servoPin = 3;

void start()
{
  
  return;
}

void end()
{
  
  return;
}

void move()
{
  return;
}

void handleCommand(String command)
{
  char *ptr1;
  if (command == "start")
  {
    start();
  }
  if (command == "end")
  {
    end();
  }
  else if (command[0] == 'a')
  {
    move();
  }
  return;
}

void setup()
{
  pinMode(servoPin, OUTPUT);
  Serial.begin(9600);
}

String buffer;
void loop()
{
  while (Serial.available() > 0)
  {
    int c = Serial.read();
    if (c < 0)
      break;
    if (c == '\n')
    { // newline, check for a valid command
      handleCommand(buffer);
      buffer = "";
    }
    else if (c != '\r')
    { // normal non-control char, just add it to the string
      buffer += (char)c;
    }
  }
  // … do normal work here: blink LEDs, etc
}