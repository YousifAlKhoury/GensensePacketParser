using System;
using System.Collections.Generic;
using System.IO.Ports;
using Newtonsoft.Json;

namespace Gensense{
    static class Globals
    {
        // global int
        public static string glob_string;

    }
    class Program {
        // Main function
        static void Main() {
            Console.WriteLine("Gensense Packet Parser");
            string com_port = "COM6";
            int baud_rate = 9600;
            Console.WriteLine("Using COM Port #" + com_port + " at the baud rate of " + baud_rate);
            Parity parity = Parity.None;
            int data_bits = 8;
            StopBits stopbits = StopBits.One;
            SerialPort port = new SerialPort(com_port, baud_rate, parity, data_bits, stopbits);
            port.ReadTimeout = 1000;
            
            xbee_listener listener = new xbee_listener(port);
            //running while loop checking coordinator serial port
            
        }
    }
}
