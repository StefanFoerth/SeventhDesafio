using Microsoft.VisualStudio.TestTools.UnitTesting;
using System.Threading.Tasks;

namespace PanelManagement.Tests
{
    [TestClass()]
    public class GeneralTests
    {
        readonly FrmPanelViewer frmAlarms = new FrmPanelViewer();

        [TestMethod()]
        public void ConnectPanelTest1()
        {
            // Tamanho do comando errado. Finzaliza conexão.
            new AlarmPanel().StartPanel("ff04ff", "ff0535053501020379", "ff0004ff");
            // Cabeçalho do comando errado. Finzaliza conexão.
            new AlarmPanel().StartPanel("0f0004ff", "ff0535053501020379", "ff0004ff");
            // Rodapé do comando errado. Finzaliza conexão.
            new AlarmPanel().StartPanel("f000400", "ff0535053501020379", "ff0004ff");

        }

        [TestMethod()]
        public void ConnectPanelTest2()
        {
            // Conectar dois paineis com mesmo código 
            Task.Run(() => new AlarmPanel().StartPanel("ff0004ff", "ff0535053501020379", "ff0004ff"));            
            new AlarmPanel().StartPanel("ff0004ff", "ff0535053501020379", "ff0004ff");                        
        }

        [TestMethod()]
        public void ConnectPanelTest3()
        {
            // Tamanho do evento errado. Finzaliza conexão.
            new AlarmPanel().StartPanel("ff0004ff", "ff35053501020379", "ff0004ff");
        }

        [TestMethod()]
        public void ConnectPanelTest4()
        {
            // Cabeçalho do evento errado. Finzaliza conexão.
            new AlarmPanel().StartPanel("ff0005ff", "0f0535053501020379", "ff0005ff");           
        }

        [TestMethod()]
        public void ConnectPanelTest5()
        {
            // Checkum errado. Ignora evento e mantém conexão.
            new AlarmPanel().StartPanel("ff0006ff", "ff0535053501020378", "ff0006ff");
        }
    }
}