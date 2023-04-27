using System;
using System.IO.Ports;
using System.Text;

namespace Gensense {
    public class xbee_listener {
        private SerialPort port;
        // This will get the current WORKING directory
        string workingDirectory = Environment.CurrentDirectory;

        public xbee_listener(SerialPort port) {
            this.port = port;
            SerialPortProgram();
        }

        private void SerialPortProgram() { 
            Console.WriteLine("Incoming Data:");
            // Attach a method to be called when there
            // is data waiting in the port's buffer 
            this.port.DataReceived += new SerialDataReceivedEventHandler(port_DataReceived); 
            // Begin communications 
            this.port.Open(); 
            // Enter an application loop to keep this thread alive 
            
            Console.ReadLine();
        } 

        private void port_DataReceived(object sender, SerialDataReceivedEventArgs e) { 
            // Show all the incoming data in the port's buffer
            byte[] bytes = new byte[gensense_parser.len];
            bool timeout = false;

            for(int i = 0; i<gensense_parser.len; i++) {
                try{
                    Int32 x = port.ReadByte();
                    bytes[i] = (byte)x;
                }
                catch {
                    timeout = true;
                    break;
                }
            }    
            if(!timeout) {
                gensense_parser parser = new gensense_parser(bytes);
                string data_JSON = parser.getJSON();
                Console.WriteLine(data_JSON);
                
                //overwrite and write to out.txt
                using (StreamWriter writer = new StreamWriter(workingDirectory+"\\out.txt"))
                {
                writer.Write(data_JSON);
                }
            }
            
            
        } 
    }
}