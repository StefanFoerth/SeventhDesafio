using System;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Net;
using System.Net.Sockets;

namespace PanelManagement
{
    public partial class FrmPanelViewer : Form
    {
        private const int portNum = 9000;
        // Tamanho máximo do buffer de conexão.
        private const int maxConnBuffer = 4;
        // Tamanho máximo do buffer de dados.
        private const int maxEvtBuffer = 9;
        // Funções gerais
        private GeneralFunctions gf = new GeneralFunctions();

        public FrmPanelViewer()
        {
            InitializeComponent();
        }

        private void FrmPanelViewer_Shown(object sender, EventArgs e)
        {
            // Executa em uma Task para não bloquear a interface.
            Task.Run(() => TcpConnectionManager());
        }

        // Verifica se já tem um painel conectado com o código informado.
        private bool PanelExists(string panelCode)
        {
            for (int i = 0; i < DgvCentrals.Rows.Count; i++)
            {               
                if (DgvCentrals.Rows[i].Cells[0].Value.Equals(panelCode))
                {
                    return true;                                               
                }             
            }

            return false;
        }

        delegate void ShowPanelConnectedCallback(AlarmPanel panelConnected);

        private void ShowPanelConnected(AlarmPanel panelConnected)
        {
            if (InvokeRequired)
            {
                ShowPanelConnectedCallback callback = ShowPanelConnected;
                Invoke(callback, panelConnected);
            }
            else
            {
                DgvCentrals.Rows.Add(
                    panelConnected.Code
                    );               
            }
        }

        delegate void RemovePanelFromListCallback(string panelCode);
        
        // Remove o painel específico da lista códigos.
        private void RemovePanelFromList(string panelCode)
        {
            if (InvokeRequired)
            {
                RemovePanelFromListCallback callback = RemovePanelFromList;
                Invoke(callback, panelCode);
            }
            else
            {
                for (int i = 0; i < DgvCentrals.Rows.Count; i++)
                {
                    if (DgvCentrals.Rows[i].Cells[0].Value.Equals(panelCode))
                    {
                        DgvCentrals.Rows.RemoveAt(i);
                        break;
                    }
                }
            }
        }

        delegate void ShowEventReceivedCallback(PanelEvent eventReceived);

        // Exibe um evento específico.
        private void ShowEventReceived(PanelEvent eventReceived)
        {
            if (InvokeRequired)
            {
                ShowEventReceivedCallback callback = ShowEventReceived;
                Invoke(callback, eventReceived);
            }
            else
            {              
                DgvEvents.Rows.Add(
                    eventReceived.Date,
                    eventReceived.CentralCode,
                    eventReceived.AccountCode,
                    eventReceived.Code,
                    gf.GetErrorCodeDescription(eventReceived.Code),        
                    eventReceived.PartitionCode,
                    eventReceived.ZoneCode,
                    eventReceived.UserCode                  
                    );        
            }
        }

        // Função reponsável pelo controle de conexões.
        public bool TcpConnectionManager()
        {
            bool done = false;
            try
            {                        
                // Configura processo que aguardará conexões na porta de rede especificada usando protocolo TCP.
                TcpListener tcpListener = new TcpListener(IPAddress.Any, portNum);
                tcpListener.Start();
           
                while (!done)
                {
                    // Processamento fica bloqueado aguardando conexão.
                    TcpClient tcpClient = tcpListener.AcceptTcpClient();
                    // Recupera o canal de comunicação.
                    NetworkStream networkStream = tcpClient.GetStream();

                    try
                    {
                        byte[] buffer = new byte[maxConnBuffer];
                        // Lê dados enviados pelo cliente.
                        int bytesRead = networkStream.Read(buffer, 0, maxConnBuffer);

                        // Se o tamanho do comando (dados) for diferente do esperado: Erro de protocolo - Fecha conexão.                  
                        if (bytesRead == 4)
                        {
                            // Se o byte do cabeçalho ou rodapé for diferente de 0xff: Erro de protocolo - Fecha conexão.  
                            if (buffer[0].ToString("x").Equals("ff") && buffer[3].ToString("x").Equals("ff"))
                            {
                                string cmdEventHexString = gf.ByteArrayToHexString(buffer);
                                var connPanel = new AlarmPanel
                                {                                
                                    Code = gf.HexStringToIntString(cmdEventHexString, 2, 4)
                                };
                            
                                if (!PanelExists(connPanel.Code))
                                {
                                    ShowPanelConnected(connPanel);
                                    // Inicia uma nova Task para cada cliente conectado, para que o mesmo possa gerenciar os eventos independentemente dos outros. 
                                    Task.Run(() => ConnectedPanelManager(networkStream, connPanel.Code));
                                }  
                                else
                                {                                
                                    throw new Exception("Panel Code Already Connected.");
                                }
                            }
                            else
                            {
                                throw new Exception("Invalid Header.");
                            }
                        }
                        else
                        {
                            throw new Exception("Invalid Command Size Received.");
                        }
                    }
                    catch (Exception e)
                    {
                        // Responde cliente.
                        var clientResponse = gf.HexStringToByteArray("ffffffff");
                        networkStream.Write(clientResponse, 0, clientResponse.Length);
                        // Encerra conexão.
                        networkStream.Close();
                        Console.WriteLine("Close client connection. Reason: {0}", e.Message);     
                    }
                }

                tcpListener.Stop();
            }
            catch (Exception e)
            {
                Console.WriteLine("Internal error. Reason: {0}", e.Message);
            }

            return done;
        }

        // Função reponsável controle de dados enviados pelo cliente.
        public bool ConnectedPanelManager(NetworkStream networkStream, string panelCode)
        {      
            bool done = false;
            try
            {                
                while (!done)
                {
                    byte[] buffer = new byte[maxEvtBuffer];                    
                    int bytesRead = networkStream.Read(buffer, 0, maxEvtBuffer);
                    // Se o tamanho do comando for diferente do esperado: Erro de protocolo - Fecha conexão.
                    if (bytesRead == 9)
                    {
                        // Se o byte do cabeçalho for diferente de 0xff: Erro de protocolo - Fecha conexão.                        
                        if (buffer[0].ToString("x").Equals("ff"))
                        {
                            // Se a soma dos bytes que antecedem o checksum for diferente do valor do checksum: Ignora evento.                            
                            if ((gf.SumBytesOfArray(buffer, 0, 8) - buffer[8]) == 0)
                            {
                                string cmdEventHexString = gf.ByteArrayToHexString(buffer);   
                                var centralEvent = new PanelEvent
                                {
                                    Date = DateTime.Now.ToString("dd/MM/yyyy HH:mm"),
                                    CentralCode = panelCode.ToString(),
                                    AccountCode = gf.HexStringToIntString(cmdEventHexString, 2, 4),
                                    Code = gf.HexStringToIntString(cmdEventHexString, 6, 4),
                                    PartitionCode = gf.HexStringToIntString(cmdEventHexString, 10, 2),
                                    ZoneCode = gf.HexStringToIntString(cmdEventHexString, 12, 2),
                                    UserCode = gf.HexStringToIntString(cmdEventHexString, 14, 2)
                                };

                                ShowEventReceived(centralEvent);
                            }
                            else
                            {
                                Console.WriteLine("Panel: {0}: Invalid Checksum. Event ignored.", panelCode);
                            }
                        }
                        else
                        {
                            throw new Exception("Panel: " + panelCode + ": Invalid Header.");
                        }
                    }
                    else
                    {
                        throw new Exception("Panel: " + panelCode + ": Invalid command size received.");                        
                    }
                }
            }
            catch (Exception e)
            {
                Console.WriteLine("Close client connection. Reason: {0}", e.Message);
                // Comando finalizador. Usado somente nos clientes genéricos desse programa. 
                networkStream.Write(gf.HexStringToByteArray("ffffffff"), 0, 4);
                networkStream.Close();                
                RemovePanelFromList(panelCode);                
            }

            return done;
        }
    }
}
