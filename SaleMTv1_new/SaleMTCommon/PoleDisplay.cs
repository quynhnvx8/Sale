using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Globalization;
using System.IO.Ports;

namespace SaleMTCommon
{
    class PoleDisplay : SerialPort
    {
        private SerialPort srPort = null;

        //doc cac thong so
        public PoleDisplay(string strPoleCom, string strPort)
        {
            try
            {
                srPort = new SerialPort("COM1", 9600, Parity.None, 8, StopBits.One);
                if (!srPort.IsOpen) srPort.Open();
            }
            catch { }
        }

        
        

        //reset trang thai
        public void ClearDisplay()
        {
            srPort.Write("                    ");
            srPort.WriteLine("                    ");

        }

        //hien thi poledispay
        public void Display(string textToDisplay, int line)
        {
            if (line == 0)
                srPort.Write(textToDisplay);
            else
                srPort.WriteLine(textToDisplay);
        }

    }
}
