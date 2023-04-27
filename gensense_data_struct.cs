using System;
using System.Collections.Generic;
using System.IO.Ports;

namespace Gensense {
    public class data_struct {
        public float amb_temperature {get; set;}
        public float amb_humidity {get; set;}
        public float IR_temperature {get; set;}
        public ushort CO2_concentration {get; set;}
        public uint light_intensity {get; set;}
        public ushort light_spectrum_F1 {get; set;}
        public ushort light_spectrum_F2 {get; set;}
        public ushort light_spectrum_FZ {get; set;}
        public ushort light_spectrum_F3 {get; set;}
        public ushort light_spectrum_F4 {get; set;}
        public ushort light_spectrum_FY {get; set;}
        public ushort light_spectrum_F5 {get; set;}
        public ushort light_spectrum_FXL {get; set;}
        public ushort light_spectrum_F6 {get; set;}
        public ushort light_spectrum_F7 {get; set;}
        public ushort light_spectrum_F8 {get; set;}
        public ushort light_spectrum_NIR {get; set;}
        public ushort light_spectrum_VIS {get; set;}
        public byte light_spectrum_gain {get; set;}
        public float light_spectrum_tint {get; set;}
    }
}