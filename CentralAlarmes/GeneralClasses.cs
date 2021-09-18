using System;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Net;
using System.Net.Sockets;

namespace PanelManagement
{
    public class AlarmPanel
    {
        private string header;
        private string code;
        private string endCommand;
        private string ipAdr;
        private int tcpPort;

        public string Header { get => header; set => header = value; }
        public string Code { get => code; set => code = value; }
        public string EndCommand { get => endCommand; set => endCommand = value; }
        public string IpAdr { get => ipAdr; set => ipAdr = value; }
        public int TcpPort { get => tcpPort; set => tcpPort = value; }

        public void StartPanel(string connectHex, string eventHex, string disconnectHex)
        {
            GeneralFunctions gf = new GeneralFunctions();
            try
            {
                // Fixo para testes.
                ipAdr = "127.0.0.1";
                tcpPort = 9000;
                
                IPHostEntry ipHostInfo = Dns.GetHostEntry(Dns.GetHostName());                
                IPAddress ipAddress = IPAddress.Parse(ipAdr);
                IPEndPoint remoteEP = new IPEndPoint(ipAddress, tcpPort);
                
                // Cria o socket TCP/IP. 
                Socket sender = new Socket(ipAddress.AddressFamily, SocketType.Stream, ProtocolType.Tcp);

                try
                {
                    sender.Connect(remoteEP);

                    Console.WriteLine("Socket connected to {0}", sender.RemoteEndPoint.ToString());

                    // Codifica a string Hex de conexão num array de bytes.
                    byte[] bufferConn = gf.HexStringToByteArray(connectHex);
                    // Envia comando de conexão.
                    int bytesSentConn = sender.Send(bufferConn);

                    // Envia eventos até ser desconectado.
                    Task.Run(() => SendEvent(sender, gf.HexStringToByteArray(eventHex)));

                    
                    byte[] bytes = new byte[4];
                    // Aguarda comando de desconexão.
                    while (!gf.ByteArrayToHexString(bytes).Equals(disconnectHex))
                    {
                        // Aguarda comando de desconexão.
                        int bytesRec = sender.Receive(bytes);

                        if (bytesRec > 0)
                        {
                            Console.WriteLine("Received Hex Bytes {0}: ", gf.ByteArrayToHexString(bytes));
                        }
                    }

                    Console.WriteLine("Disconnecting Panel.");

                    // Libera o socket.                     
                    sender.Shutdown(SocketShutdown.Both);
                    sender.Close();
                }
                catch (ArgumentNullException ane)
                {
                    throw new Exception(ane.Message);
                }
                catch (SocketException se)
                {
                    throw new Exception(se.Message);
                }
                catch (Exception e)
                {
                    throw new Exception(e.Message);
                }
            }
            catch (Exception e)
            {
                Console.WriteLine("Internal client message error: {0}.", e.Message);
            }
        }

        static void SendEvent(Socket sender, byte[] data)
        {
            try
            {
                while (sender.Connected)
                {
                    sender.Send(data);
                    Task.Delay(3000).Wait();
                    Console.WriteLine("Data Send.");
                }
            }
            catch (SocketException se)
            {
                // Está é uma exceção esperada pois o servidor vai forçar o encerramento do socket.
                Console.WriteLine("SocketException: {0}.", se.Message);               
            }            
        }
    }
    public class PanelEvent
    {
        private string centralCode;
        private string date;
        private string header;
        private string accountCode;
        private string code;
        private string description;
        private string partitionCode;
        private string zoneCode;
        private string userCode;
        private string checksum;

        public string Date { get => date; set => date = value; }
        public string Header { get => header; set => header = value; }
        public string AccountCode { get => accountCode; set => accountCode = value; }
        public string Code { get => code; set => code = value; }
        public string PartitionCode { get => partitionCode; set => partitionCode = value; }
        public string ZoneCode { get => zoneCode; set => zoneCode = value; }
        public string UserCode { get => userCode; set => userCode = value; }
        public string Checksum { get => checksum; set => checksum = value; }
        public string CentralCode { get => centralCode; set => centralCode = value; }
        public string Description { get => description; set => description = value; }        
    }

}