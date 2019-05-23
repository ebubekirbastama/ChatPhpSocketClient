using System.Net;
using System.Net.Sockets;
using System.Text;


public class Client
{
    private static byte[] result = new byte[1024];
    public string serverIp;
    string hacked;
    public int severPort;
    public Client(string serverIp, int serverPort)
    {
        this.serverIp = serverIp;
        this.severPort = serverPort;
    }
    public string  start(string mesaj)
    {
           IPAddress ip = IPAddress.Parse(serverIp);
        Socket clientSocket = new Socket(AddressFamily.InterNetwork, SocketType.Stream, ProtocolType.Tcp);
        try
        {
            clientSocket.Connect(new IPEndPoint(ip, severPort));
        }
        catch
        {

        }

        while (clientSocket.Connected)
        {
             hacked = clientSocket.Send(Encoding.ASCII.GetBytes(mesaj)).ToString();
             clientSocket.Close();
        }
        return hacked;
    }
}


