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
            // Novo painel 4. Correto.
            Task.Run(() => frmAlarms.TcpConnectionManager());

            var result = frmAlarms.StartClient("ff0004ff", "ff0535053501020379");
            Assert.IsTrue(result);
        }

        [TestMethod()]
        public void ConnectPanelTest2()
        {
            //  Novo painel 5. Comando do evento inválido.
            Task.Run(() => frmAlarms.TcpConnectionManager());

            var result = frmAlarms.StartClient("ff0005ff", "f00535053501020379");
            Assert.IsTrue(result);
        }

        [TestMethod()]
        public void ConnectPanelTest3()
        {
            //  Novo painel 6.Checksum inválido.
            Task.Run(() => frmAlarms.TcpConnectionManager());

            var result = frmAlarms.StartClient("ff0006ff", "ff0535053501020378");
            Assert.IsTrue(result);
        }

        [TestMethod()]
        public void ConnectPanelTest4()
        {
            //  Novo painel 7. Comando de conexão inválido.
            Task.Run(() => frmAlarms.TcpConnectionManager());
            
            var result = frmAlarms.StartClient("f00007ff", "ff0535053501020378");
            Assert.IsTrue(result);
        }
    }
}