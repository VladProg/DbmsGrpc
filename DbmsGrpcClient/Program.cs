using Grpc.Net.Client;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace DbmsWcfClient
{
    internal static class Program
    {
        /// <summary>
        /// The main entry point for the application.
        /// </summary>
        [STAThread]
        static void Main()
        {
            Application.EnableVisualStyles();
            Application.SetCompatibleTextRenderingDefault(false);
            var result = FormStartDialog.ShowStartDialog();
            if (!result.HasValue)
                return;
            try
            {
                using var channel = GrpcChannel.ForAddress("http://localhost:5000");
                var client = new DbmsGrpc.DbmsProcessor.DbmsProcessorClient(channel);
                switch (result.Value.action)
                {
                    case FormStartDialog.Action.CREATE:
                        client.CreateDatabase(new() { DbName = result.Value.text });
                        break;
                    case FormStartDialog.Action.OPEN:
                        break;
                    case FormStartDialog.Action.DELETE:
                        client.DeleteDatabase(new() { DbName = result.Value.text });
                        return;
                }
                Application.Run(new FormDatabase(client, result.Value.text));
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }
    }
}
