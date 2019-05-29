using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System;
using System.Net;
using System.Net.Sockets;
using System.IO;
using System.Threading;


static class Constants
{
    public const int LON_INDEX = 0;
    public const int LAT_INDEX = 1;
    public const int THROTTLE_INDEX = 23;
    public const int RUDDER_INDEX = 21;
}
namespace WebApp_FlightSimulator.Models
{
    //should be singletone
    public class FlightManagerModel
    {
        Client client;
        ClientHandler clientHandler;
        TcpClient tcpClient;
        bool isConnectedToCommand;


        #region Singleton
        private FlightManagerModel()
        {
            this.clientHandler = new ClientHandlerFilghtParser();
            this.isConnectedToCommand = false;
        }
        private static FlightManagerModel m_Instance = null;

        public static FlightManagerModel Instance
        {
            get
            {
                if (m_Instance == null)
                {
                    m_Instance = new FlightManagerModel();
                }
                return m_Instance;
            }
        }
        #endregion
        #region Properties
        /**
         *  all notifies will be sent to the ViewModel beacuase the view model is the observer so it can check which property changed
         *  and find 
         */
        public double Lat
        {
            get; set;
        }
        public double Lon
        {
            get; set;
        }
        public double Throttle
        {
            get; set;
        }
        public double Rudder
        {
            get; set;
        }


        #endregion

        public void connect(string ip, int port)
        {
            isConnectedToCommand = client.connect(ip, port); ;
        }

        public void disconnectClient()
        {
            client.disconnect();
        }

        //writing to FS through the client class.
        public void write(string command)
        { 
            if (isConnectedToCommand)
            {
                client.write(command);
            }
        }
        ~FlightManagerModel()
        {
           client.disconnect();
        }
    }
}


