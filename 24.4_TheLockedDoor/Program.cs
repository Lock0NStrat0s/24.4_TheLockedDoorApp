namespace _24._4_TheLockedDoor;

class Program
{
    static void Main(string[] args)
    {
        bool gameRunning = true;

        string doorCode = Passcode("Create Passcode: ");
        Door door = new Door(doorCode);

        do
        {
            Console.Clear();
            Console.WriteLine($"Door is {door.DoorState}.\n\nChoose from:");
            Console.WriteLine("1 - open\n2 - close\n3 - lock\n4 - unlock\n5 - change passcode\nAny other key to exit");
            Console.Write("\nSelect your action: ");
            string action = Console.ReadLine();

            switch (action)
            {
                case "1":
                    door.Open();
                    break;
                case "2":
                    door.Close();
                    break;
                case "3":
                    door.Lock();
                    break;
                case "4":
                    string checkPasscode = Passcode("Enter passcode to unlock: ");
                    door.Unlock(checkPasscode);
                    break;
                case "5":
                    string oldPasscode = Passcode("Enter old passcode: ");
                    string newPasscode = Passcode("Enter new passcode: ");
                    door.ChangePasscode(oldPasscode, newPasscode);
                    break;
                default:
                    gameRunning = false;
                    break;
            }


        } while (gameRunning);



        Console.ReadLine();
    }

    public static string Passcode(string text)
    {
        Console.Write(text);
        return Console.ReadLine();
    }
}

public class Door
{
    public State DoorState { get; private set; }
    private string Passcode { get; set; }

    public Door(string passcode)
    {
        Passcode = passcode;
        DoorState = State.Closed;
    }

    public void Open()
    {
        if (DoorState == State.Closed) { DoorState = State.Opened; }
    }

    public void Close()
    {
        if (DoorState == State.Opened) { DoorState = State.Closed; }
    }

    public void Lock()
    {
        if (DoorState == State.Closed) { DoorState = State.Locked; }
    }

    public void Unlock(string passcode)
    {
        if (DoorState == State.Locked && Passcode == passcode) { DoorState = State.Closed; }
    }

    public void ChangePasscode(string oldPasscode, string newPasscode)
    {
        if (Passcode == oldPasscode) { Passcode = newPasscode; }
    }

}

public enum State
{
    Locked,
    Opened,
    Closed
}