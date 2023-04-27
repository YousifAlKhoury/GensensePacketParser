using System;
using Newtonsoft.Json;

namespace Gensense {
    public class gensense_parser {
        byte[] message;
        public const int len = 66;
        const byte amb_temp_index = 15;
        const byte amb_humidity_index = 19;
        const byte IR_temp_index = 23;
        const byte CO2_index = 27;
        const byte light_intensity_index = 29;
        const byte spectrum_index = 33;

        public gensense_parser(byte[] message) {
            // Constructor
            this.message = message;
            int len = message.Length;

            // Display an error if the received message does not follow the GenSense Packet Structure.
            if (len != 66) {
                Console.Error.WriteLine($"Unexpected packet received. Packet Length is {len}. A length of {gensense_parser.len} was expected");
            }
        }
        public float get_ambient_temperature() {
            return System.BitConverter.ToSingle(message, amb_temp_index);
        }
        public float get_ambient_humidity() {
            return System.BitConverter.ToSingle(message, amb_humidity_index);
        }
        public float get_IR_temperature() {
            return System.BitConverter.ToSingle(message, IR_temp_index);
        }
        public ushort get_co2_concentration() {
            // Console.WriteLine($"CO2 bytes are : {message[CO2_index]} {message[CO2_index+1]}");
            return System.BitConverter.ToUInt16(message, CO2_index);
        }
        public uint get_light_intensity() {
            return System.BitConverter.ToUInt32(message, light_intensity_index);
        }
        public ushort get_spectrum_F1() {
            return System.BitConverter.ToUInt16(message, spectrum_index);
        }
        public ushort get_spectrum_F2() {
            return System.BitConverter.ToUInt16(message, spectrum_index+2);
        }
        public ushort get_spectrum_FZ() {
            return System.BitConverter.ToUInt16(message, spectrum_index+4);
        }
        public ushort get_spectrum_F3() {
            return System.BitConverter.ToUInt16(message, spectrum_index+6);
        }
        public ushort get_spectrum_F4() {
            return System.BitConverter.ToUInt16(message, spectrum_index+8);
        }
        public ushort get_spectrum_FY() {
            return System.BitConverter.ToUInt16(message, spectrum_index+10);
        }
        public ushort get_spectrum_F5() {
            return System.BitConverter.ToUInt16(message, spectrum_index+12);
        }
        public ushort get_spectrum_FXL() {
            return System.BitConverter.ToUInt16(message, spectrum_index+14);
        }
        public ushort get_spectrum_F6() {
            return System.BitConverter.ToUInt16(message, spectrum_index+16);
        }
        public ushort get_spectrum_F7() {
            return System.BitConverter.ToUInt16(message, spectrum_index+18);
        }
        public ushort get_spectrum_F8() {
            return System.BitConverter.ToUInt16(message, spectrum_index+20);
        }
        public ushort get_spectrum_NIR() {
            return System.BitConverter.ToUInt16(message, spectrum_index+22);
        }
        public ushort get_spectrum_VIS() {
            return System.BitConverter.ToUInt16(message, spectrum_index+24);
        }
        public byte get_spectrum_gain() {
            return message[spectrum_index+26];
        }
        public float get_spectrum_integration_time() {
            return System.BitConverter.ToSingle(message, spectrum_index+27);
        }
        public string getJSON() {
            data_struct data = new data_struct()
                {
                    amb_temperature = get_ambient_temperature(),
                    amb_humidity = get_ambient_humidity(),
                    IR_temperature = get_IR_temperature(),
                    CO2_concentration = get_co2_concentration(),
                    light_intensity = get_light_intensity(),
                    light_spectrum_F1 = get_spectrum_F1(),
                    light_spectrum_F2 = get_spectrum_F2(),
                    light_spectrum_FZ = get_spectrum_FZ(),
                    light_spectrum_F3 = get_spectrum_F3(),
                    light_spectrum_F4 = get_spectrum_F4(),
                    light_spectrum_FY = get_spectrum_FY(),
                    light_spectrum_F5 = get_spectrum_F5(),
                    light_spectrum_FXL = get_spectrum_FXL(),
                    light_spectrum_F6 = get_spectrum_F6(),
                    light_spectrum_F7 = get_spectrum_F7(),
                    light_spectrum_F8 = get_spectrum_F8(),
                    light_spectrum_NIR = get_spectrum_NIR(),
                    light_spectrum_VIS = get_spectrum_VIS(),
                    light_spectrum_gain = get_spectrum_gain(),
                    light_spectrum_tint = get_spectrum_integration_time(),
                };

            string data_JSON = JsonConvert.SerializeObject(data);
            // Console.WriteLine(data_JSON);
            return data_JSON;
        }
    }
}